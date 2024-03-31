using Dapper;
using System.Data;

namespace Repository.Data
{
    public class PersonaRepository : IPersona
    {
        private IDbConnection conexionDB;
        public PersonaRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }
        public string add(PersonaModel persona)
        {
            try
            {
                int insert = conexionDB.Execute("Insert into persona(nombre, apellido, cedula) values(@nombre, @apellido, @cedula)", persona);
                return (insert > 0) ? "Se inserto correctamente..." : "No se pudo insertar...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public PersonaModel get(int id)
        {
            try
            {
                return conexionDB.QueryFirst<PersonaModel>($"SELECT id, nombre, apellido, cedula from persona where id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PersonaModel> list()
        {
            try
            {
                return conexionDB.Query<PersonaModel>($"SELECT id, nombre, apellido, cedula from persona");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string remove(int id)
        {
            try
            {
                int delete = conexionDB.Execute($"DELETE FROM persona WHERE id = {id}");
                return (delete > 0) ? "Se eliminó correctamente el registro..." : "No se pudo eliminar...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string update(PersonaModel persona, int id)
        {
            try
            {
                int update = conexionDB.Execute($"UPDATE persona SET " +
                    "nombre = @nombre, " +
                    "apellido = @apellido, " +
                    "cedula = @cedula " +
                    $"WHERE id = {id}", persona);
                return (update > 0) ? "Se modificaron los datos correctamente..." : "No se pudo modificar...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
