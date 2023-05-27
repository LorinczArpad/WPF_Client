using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Client.Windows;

namespace WPF_Client.Logic
{
    public class MainMenuLogic : IMainMenuLogic
    {
        GameWindow g;
        MinRequirementsWindow m;
        StatWindow s;
        StudioWindow su;
        public MainMenuLogic()
        {
           
        }

        public void OpenGameWindow()
        {
            g = new GameWindow();
            g.Show();
        }
        public void OpenStudioWindow()
        {
            su = new StudioWindow();
            su.Show();
        }
        public void OpenMinRequirementsWindow()
        {
            m = new MinRequirementsWindow();
            m.Show();
        }
        public void OpenStatWindow()
        {
            s = new StatWindow();
            s.Show();
        }
    }
}
