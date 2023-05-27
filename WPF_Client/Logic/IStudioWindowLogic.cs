using WPF_Client.Models;

namespace WPF_Client.Logic
{
    public interface IStudioWindowLogic
    {
        void Create(Studio item, RestCollection<Studio> g);
        void Delete(int id, RestCollection<Studio> g);
        Studio Read(int id, RestCollection<Studio> g);
        void Update(Studio item, RestCollection<Studio> g);
    }
}