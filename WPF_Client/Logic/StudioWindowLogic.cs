using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Client.Models;

namespace WPF_Client.Logic
{
    public class StudioWindowLogic : IStudioWindowLogic
    {
        public StudioWindowLogic()
        {
            
        }
        public void Create(Studio item, RestCollection<Studio> g)
        {
            g.Add(item, "studio");
        }

        public void Delete(int id, RestCollection<Studio> g)
        {
            g.Delete(id.ToString(), "studio");
        }

        public Studio Read(int id, RestCollection<Studio> g)
        {

            try
            {
                var studio = g.Where(t => t.StudioID == id).FirstOrDefault();
                return studio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Studio not found!");
                return new Studio();
            }
        }


        public void Update(Studio item, RestCollection<Studio> g)
        {

            g.Update(item, "studio");
        }
    }
}
