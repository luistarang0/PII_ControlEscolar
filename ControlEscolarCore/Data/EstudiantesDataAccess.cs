using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ControlEscolarCore.Utilities;
using NLog;
using ControlEscolarCore.Model;
using System.Data;

namespace ControlEscolarCore.Data
{
    public class EstudiantesDataAccess
    {
        //Logger para la clase
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.EstudiantesDataAccess");
        //Instancia de PostgreSQLDataAccess para la conexión a la base de datos, motor de la clase, acceso a métodos de PostgreSQLDataAccess
        private readonly PostgreSQLDataAccess _dbAccess;
        //Instancia de PersonasDataAccess para la manipulación de datos de personas
        private readonly PersonasDataAccess _personasData;

        /// <summary>
        /// Constructor de la clase EstudiantesDataAccess.
        /// </summary>
        public EstudiantesDataAccess()
        {
            try
            {
                //Obtiene la instancia unica de PostgreSQLDataAccess
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                //Instancia de acceso a datos de personas
                _personasData = new PersonasDataAccess();
            }
            catch (Exception)
            {
                _logger.Error("Error al inicializar la clase EstudiantesDataAccess");
                throw;
            }
        }

        public List<Estudiante> ObtenerTodosLosEstudiantes(bool soloActivos = true, int tipoFecha = 0, DateTime?
                                                           fechaInicio = null, DateTime? fechaFin = null)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            try
            {
                string query = @"SELECT E.ID, E.MATRICULA, E.SEMESTRE, E.FECHA_ALTA, E.FECHA_BAJA, E.ESTATUS,
                                    CASE
                                        WHEN E.ESTATUS = 0 THEN 'Baja'
                                        WHEN E.ESTATUS = 1 then 'Activo'
                                        when e.estatus = 2 then 'Baja Temporal'
                                    else
                                        'Desconocido'
                                    end as descestatus_estudiante,
                                        e.id_persona, p.nombre_completo, p.correo, p.telefono, p.fecha_nacimiento, p.curp, p.estatus as estatus_persona
                                FROM ESCOLAR.estudiantes e
                                INNER JOIN seguridad.personas p on e.id_persona = p.id
                                where 1=1"; // Iniciamos con una condicion siempre verdadera para poder concatenar condiciones
                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

                //Filtro por estatus
                if (soloActivos)
                {
                    query += " AND E.ESTATUS = 1";
                }

                //Filtro por rango de fecha
                if (fechaInicio != null && fechaFin != null)
                {
                    switch (tipoFecha)
                    {
                        case 1: //Fecha de Nacimiento
                            query += " AND P.FECHA_NACIMIENTO BETWEEN @fechaInicio AND @fechaFin";
                            break;
                        case 2: // Fecha de Alta
                            query += " AND E.FECHA_ALTA BETWEEN @fechaInicio AND @fechaFin";
                            break;
                        case 3: // Fecha de Baja
                            query += " AND E.FECHA_BAJA BETWEEN @fechaInicio AND @fechaFin";
                            break;
                    }
                    parameters.Add(_dbAccess.CreateParameter("@FechaInicio", fechaInicio.Value));
                    parameters.Add(_dbAccess.CreateParameter("@FechaFin", fechaFin.Value));

                }
                //Ordena por Id
                query += " ORDER BY E.ID";

                //Conecta a la base de datos
                _dbAccess.Connect();

                //Ejecuta la consulta
                DataTable result = _dbAccess.ExecuteQuery_Reader(query, parameters.ToArray());

                //Convertir el resultado a una lista de objetos Estudiante
                foreach (DataRow row in result.Rows)
                {
                    //Crear el Objeto Persona
                    Persona persona = new Persona(
                        Convert.ToInt32(row["ID_PERSONA"]),
                        row["NOMBRE_COMPLETO"].ToString() ?? "",
                        row["CORREO"].ToString() ?? "",
                        row["TELEFONO"].ToString() ?? "",
                        row["CURP"].ToString() ?? "",
                        row["FECHA_NACIMIENTO"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["FECHA_NACIMIENTO"]) : null,
                        Convert.ToBoolean(row["ESTATUS_Persona"])
                    );

                    //Crear el objeto Estudiante
                    Estudiante estudiante = new Estudiante(
                        Convert.ToInt32(row["ID"]),
                        Convert.ToInt32(row["ID_PERSONA"]), //Tentativa a borrar
                        row["MATRICULA"].ToString() ?? "",
                        row["SEMESTRE"].ToString() ?? "",
                        Convert.ToDateTime(row["FECHA_ALTA"]),
                        row["FECHA_BAJA"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["FECHA_BAJA"]) : null,
                        Convert.ToInt32(row["ESTATUS"]),
                        row["DESCESTATUS_ESTUDIANTE"].ToString() ?? "",
                        persona
                    );

                    estudiantes.Add(estudiante);
                }

                _logger.Info($"Se obtuvieron {estudiantes.Count} registros de la base de datos");
                return estudiantes;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener los estudiantes de la base de datos");
                throw; //Retorna la lista vacía en caso de error
            }
            finally
            {
                //Asegurarse de cerrar la conexión a la base de datos
                _dbAccess.Disconnect();
            }
        }

        public int InsertarEstudiante(Estudiante estudiante)
        {
            try
            {
                // Primero insertamos la persona
                int idPersona = _personasData.InsertarPersona(estudiante.DatosPersonales);

                if (idPersona <= 0)
                {
                    _logger.Error($"No se pudo insertar la persona para el estudiante {estudiante.Matricula}");
                    return -1;
                }

                // Actualizar el IdPersona en el objeto estudiante
                estudiante.IdPersona = idPersona;

                // Luego insertamos el estudiante
                string query = @"
            INSERT INTO escolar.estudiantes (id_persona, matricula, semestre, fecha_alta, estatus)
            VALUES (@IdPersona, @Matricula, @Semestre, @FechaAlta, @Estatus)
            RETURNING id";

                // Crea los parámetros
                NpgsqlParameter paramIdPersona = _dbAccess.CreateParameter("@IdPersona", estudiante.IdPersona);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@FechaAlta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramIdPersona, paramMatricula,
                                                            paramSemestre, paramFechaAlta, paramEstatus);

                // Convierte el resultado a entero
                int idestudiante_generado = Convert.ToInt32(resultado);
                _logger.Info($"Estudiante insertado correctamente con ID: {idestudiante_generado}");

                // Actualizar el Id en el objeto estudiante
                //estudiante.Id = idestudiante_generado;

                return idestudiante_generado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el estudiante con matrícula {estudiante.Matricula}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si una matrícula ya está registrada en la base de datos.
        /// </summary>
        /// <param name="matricula">Matrícula a verificar</param>
        /// <returns>True si la matrícula ya existe, false en caso contrario</returns>
        public bool ExisteMatricula(string matricula)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM escolar.estudiantes WHERE matricula = @Matricula";

                // Crea el parámetro
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", matricula);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                object? resultado = _dbAccess.ExecuteScalar(query, paramMatricula);

                int cantidad = Convert.ToInt32(resultado);
                bool existe = cantidad > 0;

                return existe;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia de la matrícula {matricula}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        public Estudiante? ObtenerEstudiantePorId(int id)
        {
            try
            {
                string query = @"
                SELECT e.id, e.matricula, e.semestre, e.fecha_alta, e.fecha_baja, e.estatus,
                        CASE
                            WHEN e.estatus = 0 THEN 'Baja'
                            WHEN e.estatus = 1 THEN 'Activo'
                            WHEN e.estatus = 2 THEN 'Baja Temporal'
                            ELSE 'Desconocido'
                        END as descestatus_estudiante,
                       e.id_persona, p.nombre_completo, p.correo, p.telefono, p.fecha_nacimiento, p.curp, p.estatus as estatus_persona
                FROM escolar.estudiantes e
                INNER JOIN seguridad.personas p ON e.id_persona = p.id
                WHERE e.id = @Id";

                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", id);
                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId); // EjecutarReader -> ExecuteQuery

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún estudiante con ID {id}");
                    return null;
                }

                DataRow row = resultado.Rows[0];
                Persona persona = new Persona(
                    Convert.ToInt32(row["id_persona"]),
                    row["nombre_completo"].ToString() ?? "",
                    row["correo"].ToString() ?? "",
                    row["telefono"].ToString() ?? "",
                    row["curp"].ToString() ?? "",
                    row["fecha_nacimiento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_nacimiento"]) : null,
                    Convert.ToBoolean(row["estatus_persona"])
                );

                Estudiante estudiante = new Estudiante(
                    Convert.ToInt32(row["id"]),
                    Convert.ToInt32(row["id_persona"]),
                    row["matricula"].ToString() ?? "",
                    row["semestre"].ToString() ?? "",
                    Convert.ToDateTime(row["fecha_alta"]),
                    row["fecha_baja"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_baja"]) : null,
                    Convert.ToInt32(row["estatus"]),
                    row["descestatus_estudiante"]?.ToString() ?? "Desconocido",
                    persona
                );

                return estudiante;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el estudiante con ID {id}");
                return null;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                _logger.Debug($"Actualizando estudiante con ID {estudiante.Id} y persona con ID {estudiante.IdPersona}");

                // Primero actualizamos los datos de la persona
                bool actualizacionPersonaExitosa = _personasData.ActualizarPersona(estudiante.DatosPersonales);
                if (!actualizacionPersonaExitosa)
                {
                    _logger.Warn($"No se pudo actualizar la persona con ID {estudiante.IdPersona}");
                    return false;
                }

                // Luego actualizamos los datos del estudiante
                string queryEstudiante = @"
        UPDATE escolar.estudiantes
        SET matricula = @Matricula,
            semestre = @Semestre,
            fecha_alta = @FechaAlta,
            estatus = @Estatus,
            fecha_baja = @FechaBaja
        WHERE id = @IdEstudiante";

                // Establecemos la conexión a la BD
                _dbAccess.Connect();

                // Creamos los parámetros para la actualización del estudiante
                NpgsqlParameter paramIdEstudiante = _dbAccess.CreateParameter("@IdEstudiante", estudiante.Id);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@FechaAlta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);
                NpgsqlParameter paramFechaBaja = _dbAccess.CreateParameter("@FechaBaja",
                    estudiante.FechaBaja.HasValue ? (object)estudiante.FechaBaja.Value : DBNull.Value);

                // Ejecutamos la actualización del estudiante
                int filasAfectadasEstudiante = _dbAccess.ExecuteNonQuery(queryEstudiante,
                    paramIdEstudiante, paramMatricula, paramSemestre,
                    paramFechaAlta, paramEstatus, paramFechaBaja);

                bool exito = filasAfectadasEstudiante > 0;
                if (!exito)
                {
                    _logger.Warn($"No se pudo actualizar el estudiante con ID {estudiante.Id}. No se encontró el registro");
                }
                else
                {
                    _logger.Debug($"Estudiante con ID {estudiante.Id} actualizado correctamente");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el estudiante con ID {estudiante.Id}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
    }
}
