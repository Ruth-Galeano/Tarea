using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Services;

namespace api.personas.Controllers
{
    [ApiController]
    [Route("api/persona/[controller]")]
    public class PersonaController : Controller
    {
        private PersonaService personaServices;
        private IConfiguration configuration;


        public PersonaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.personaServices = new PersonaService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpGet("listarPersona")]
        public ActionResult<List<PersonaModel>> ListarPersona()
        {
            var resultado = personaServices.list();
            return Ok(resultado);
        }
        [HttpGet("consultarPersona/{id}")]
        public ActionResult<PersonaModel> ConsultarPersona(int id)
        {
            var resultado = this.personaServices.consultarPersona(id);
            return Ok(resultado);
        }
        [HttpPost("insertarPersona")]
        public ActionResult<string> insertarPersona(PersonaModel modelo)
        {
            var resultado = this.personaServices.insertarPersona(new PersonaModel
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Cedula = modelo.Cedula,

            });
            return Ok(resultado);
        }
        [HttpPut("modificarPersona/{id}")]
        public ActionResult<string> modificarPersona(PersonaModel modelo, int id)
        {
            var resultado = this.personaServices.modificarPersona(new PersonaModel
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Cedula = modelo.Cedula,
            }, id);
            return Ok(resultado);
        }
        [HttpDelete("eliminarPersona/{id}")]
        public ActionResult<string> eliminarPersona(int id)
        {
            var resultado = this.personaServices.remove(id);
            return Ok(resultado);
        }

    }
}
