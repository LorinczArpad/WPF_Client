using WPF_Client.Models;

namespace WPF_Client.Logic
{
    public interface IGameMenuLogic
    {
        void Create(Game item, RestCollection<Game> g);
        void Delete(int id, RestCollection<Game> g);
        Game Read(int id, RestCollection<Game> g);
        void ReadAll(RestCollection<Game> g);
        void Update(Game item, RestCollection<Game> g);
    }
}