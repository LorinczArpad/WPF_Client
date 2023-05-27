using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Client.Models;

namespace WPF_Client.Logic
{
    public class MinRequirementsLogic : IMinRequirementsLogic
    {
        public void Create(MinRequirements item, RestCollection<MinRequirements> g)
        {
            g.Add(item, "minrequirements");
        }

        public void Delete(int id, RestCollection<MinRequirements> g)
        {
            g.Delete(id.ToString(), "minrequirements");
        }

        public MinRequirements Read(int id, RestCollection<MinRequirements> g)
        {

            try
            {
                var minrequirements = g.Where(t => t.ReqId == id).FirstOrDefault();
                return minrequirements;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Minrequirements not found!");
                return new MinRequirements();
            }
        }


        public void Update(MinRequirements item, RestCollection<MinRequirements> g)
        {

            g.Update(item, "minrequirements");
        }
    }
}
