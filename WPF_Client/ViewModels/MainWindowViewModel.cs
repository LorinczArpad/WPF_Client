using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Client.Logic;

namespace WPF_Client.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IMainMenuLogic logic;
        public ICommand OpenGameM { get; set; }
        public ICommand OpenStudioM { get; set; }
        public ICommand OpenMinRequirementsM { get; set; }
        public ICommand OpenStatM { get; set; }

        public MainWindowViewModel(IMainMenuLogic  l) 
        { 
            this.logic = l;
            OpenGameM = new RelayCommand(
                ()=>logic.OpenGameWindow()
                );
            OpenStudioM = new RelayCommand(
                ()=>logic.OpenStudioWindow()
                );
            OpenMinRequirementsM = new RelayCommand(
                () => logic.OpenMinRequirementsWindow()
                ) ;
            OpenStatM = new RelayCommand(
                ()=> logic.OpenStatWindow()
                );
        }
    }
}
