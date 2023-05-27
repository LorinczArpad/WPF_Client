using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Client.Models;

namespace WPF_Client.Logic
{
    public class GameMenuLogic : IGameMenuLogic
    {
        public void Create(Game item, RestCollection<Game> g)
        {
            g.Add(item, "game");
        }

        public void Delete(int id, RestCollection<Game> g)
        {
            g.Delete(id.ToString(), "game");
        }

        public Game Read(int id, RestCollection<Game> g)
        {

            try
            {
                var game = g.Where(t => t.GameID == id).FirstOrDefault();
                return game;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Game not found!");
                return new Game();
            }
        }

        public void ReadAll(RestCollection<Game> g)
        {
            g = new RestCollection<Game>("http://localhost:60949/", "game");
        }

        public void Update(Game item, RestCollection<Game> g)
        {

            g.Update(item, "game");
        }

    }
}
