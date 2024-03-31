using Repository.Data;

namespace Services 
{ 
 public class PersonaService
{
    private PersonaRepository personaRepository;

    public PersonaService(string connectionString)
    {
        this.personaRepository = new PersonaRepository(connectionString);
    }

    public bool insertarPersona(PersonaModel persona)
    {
        personaRepository.add(persona);
        return true;
    }

    public string modificarPersona(PersonaModel persona, int id)
    {
        if (personaRepository.get(id) != null)
            return validarDatosPersona(persona) ?
              personaRepository.update(persona, id) :
                throw new Exception("Error en la validacion");
        else
            return "No se encontraron los datos de este cliente";
    }
    public string remove(int id)
    {
        return personaRepository.remove(id);
    }

    public PersonaModel consultarPersona(int id)
    {
        return personaRepository.get(id);
    }

    public IEnumerable<PersonaModel> list()
    {
        return personaRepository.list();
    }

    private bool validarDatosPersona(PersonaModel persona)
    {
        if (persona.Nombre.Trim().Length < 2)
        {
            return false;
        }

        if (persona.Apellido.Trim().Length < 2)
        {
            return false;
        }

        return true;
    }
 }
}

