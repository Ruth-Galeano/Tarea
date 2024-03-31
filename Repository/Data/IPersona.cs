
namespace Repository.Data
{
    public interface IPersona
    {
        string add(PersonaModel persona);
        string remove(int persona);
        string update(PersonaModel persona, int id);
        PersonaModel get(int id);
        IEnumerable<PersonaModel> list();
    }
}
