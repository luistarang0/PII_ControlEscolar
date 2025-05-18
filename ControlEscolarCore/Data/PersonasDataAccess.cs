using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Model;
using ControlEscolarCore.Utilities;
using NLog;
using Npgsql;

namespace ControlEscolarCore.Data
{
    public class PersonasDataAccess
    {
        //Logger para esta clase
        private readonly static Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.PersonasDataAccess");
        //Instancia de acceo a la base de datos PosgreSQL
        private readonly PostgreSQLDataAccess _dbAccess;

        
        public PersonasDataAccess()
        {
            try
            {
                //Obtiene la instancia unica de PostgreSQLDataAccess
                _dbAccess = PostgreSQLDataAccess.GetInstance();

            }
            catch (Exception)
            {
                _logger.Error("Error al inicializar la clase PersonasDataAccess");
                throw;
            }
        }

        public int InsertarPersona(Persona persona)
        {
            try
            {
                string query = "INSERT INTO seguridad.personas (nombre_completo, correo, telefono, fecha_nacimiento, curp, estatus) " +
                       "VALUES (@NombreCompleto, @Correo, @Telefono, @FechaNacimiento, @Curp, @Estatus) " +
                       "RETURNING id";

                // Crea los parámetros
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@Correo", persona.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@Telefono", persona.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", persona.FechaNacimiento ?? (object)DBNull.Value);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", persona.Curp);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", persona.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramNombre, paramCorreo, paramTelefono,
                                                            paramFechaNac, paramCurp, paramEstatus);

                // Convierte el resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Persona insertada correctamente con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar la persona {persona.NombreCompleto}");
                return -1;
            }
            finally
            {
                //Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si existe un CURP en la base de datos
        /// </summary>
        /// <param name="curp">CURP a verificar</param>
        /// <returns>True si existe, False si no existe</returns>
        public bool ExisteCurp(string curp)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM seguridad.personas WHERE curp = @Curp";
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", curp);

                _dbAccess.Connect();

                object? resultado = _dbAccess.ExecuteScalar(query, paramCurp);
                int count = Convert.ToInt32(resultado);

                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia del CURP: {curp}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public bool ActualizarPersona(Persona persona)
        {
            try
            {
                string query = "UPDATE seguridad.personas " +
                "SET nombre_completo = @NombreCompleto, " +
                " correo = @Correo, " +
                " telefono = @Telefono, " +
                " fecha_nacimiento = @FechaNacimiento, " +
                " curp = @Curp, " +
                " estatus = @Estatus " +
                "WHERE id = @Id";

                // Crea los parámetros
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", persona.Id);
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@Correo", persona.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@Telefono", persona.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", persona.FechaNacimiento ?? (object)DBNull.Value);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", persona.Curp);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", persona.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId, paramNombre, paramCorreo,
                    paramTelefono, paramFechaNac, paramCurp, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Persona con ID {persona.Id} actualizada correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar la persona con ID {persona.Id}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar la persona con ID {persona.Id}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }
    }
}
