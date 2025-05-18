using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ControlEscolarCore.Utilities;
using System.Configuration;
using System.Data;

namespace ControlEscolarCore.Data
{
    /// <summary>
    /// Clase que se encarga de la conexión a la base de datos PostgreSQL, incluyendo 
    /// conexiones, consultas y ejecucion de procedimientos almacenados.
    /// </summary>
    public class PostgreSQLDataAccess
    {
        //Logger usando el LoggingManager centralizado
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.PostgreSQLDataAccess");
        //Cadena de conexión desde App.config
        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        private NpgsqlConnection _connection;
        private static PostgreSQLDataAccess? _instance;

        /// <summary>
        /// Constructor privado para evitar instanciación directa (patrón Singleton)
        /// </summary>
        public PostgreSQLDataAccess() 
        {
            try
            {
                _connection = new NpgsqlConnection(_ConnectionString);
                _logger.Info("Conexión a base de datos creada");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al crear la conexión a la base de datos");
                throw;
            }
        }
        /// <summary>
        /// Método para obtener la instancia de la clase (patrón Singleton)
        /// </summary>
        /// <returns>La instancia de PostgreSQL</returns>
        public static PostgreSQLDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PostgreSQLDataAccess();
            }
            return _instance;
        }

        public bool Connect()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                    _logger.Info("Conexión a base de datos abierta");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al conectar con la base de datos");
                throw;
            }
        }

        public bool Disconnect()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                    _logger.Info("Conexión a base de datos cerrada");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al cerrar la conexión a la base de datos");
                throw;
            }
        }

        public DataTable ExecuteQuery_Reader(string query, params NpgsqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        _logger.Debug("Consulta ejecutada correctamente");
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar la consulta: {query}");
                throw;
            }
        }
        /// <summary>
        /// Ejecuta una consulta que devuelve un solo valor
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                _logger.Debug($"Ejecutando consulta: {query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    int reult = command.ExecuteNonQuery();
                    _logger.Debug($"Filas afectadas: {reult}");
                    return reult;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar la consulta: {query}");
                throw;
            }
        }

        public object? ExecuteScalar(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                _logger.Debug($"Ejecutando consulta escalar: {query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    object? result = command.ExecuteScalar();
                    _logger.Debug($"Consulta escalar ejecutada exitosamente: Id Afectado: {result}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar la consulta: {query}");
                throw;
            }
        }

        /// <summary>
        /// Crea y prepara un npgsqlCommand con los parámetros especificados
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public NpgsqlCommand CreateCommand(string query, NpgsqlParameter[] parameters)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
                foreach (var parameter in parameters)
                {
                    _logger.Trace($"Parámetro: {parameter.ParameterName} = {parameter.Value ?? "Null"}");
                }
            }

            return command;
        }

        /// <summary>
        /// Crea un parámetro de Npgsql con el nombre y valor especificados
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public NpgsqlParameter CreateParameter(string name, object value)
        {
            return new NpgsqlParameter(name, value ?? DBNull.Value);
        }
    }
}
