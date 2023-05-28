using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Client.Models;


namespace WPF_Client.ViewModels
{
    public  class StatViewModel : ObservableRecipient
    {
        private RestCollection<string> results;
        public RestCollection<string> Results { get { return results; } set { SetProperty(ref results, value); } }
        private RestCollection<Game> gameResults;
        public RestCollection<Game> GameResults { get { return gameResults; } set { SetProperty(ref gameResults, value); } }
        public string SStudio { get; set; }
        public string SYear { get; set; }
        public string SCPU { get; set; }
        public ICommand GamesWithThisCPU { get; set; }
        public ICommand GamesWithThisStudio { get; set; }
        public ICommand ReleaseYearSearch { get; set; }






        public ICommand GamesWithStudiosAndRequirements { get; set; }
        public ICommand GamesWithRequirements { get; set; }
        public ICommand GamesWithStudios { get; set; }
        
        public StatViewModel()
        {
            GamesWithRequirements = new RelayCommand(
                () => {

                    this.Results = new RestCollection<string>("http://localhost:60949/", "Stat/GamesWithRequirements", "hub");
                }

                );
            GamesWithStudiosAndRequirements = new RelayCommand(
                () => {

                    this.Results = new RestCollection<string>("http://localhost:60949/", "Stat/GamesWithStudiosAndRequirements", "hub");
                }

                );
            GamesWithStudios = new RelayCommand(
                () => {

                    this.Results = new RestCollection<string>("http://localhost:60949/", "Stat/GamesWithStudios", "hub");
                }

                );


            ReleaseYearSearch  = new RelayCommand(
                () => {

                    this.GameResults = new RestCollection<Game>("http://localhost:60949/", "Stat/ReleaseYearSearch/" + SYear,"hub");
                }

                );
            GamesWithThisStudio = new RelayCommand(
                () => {

                    this.GameResults = new RestCollection<Game>("http://localhost:60949/", "Stat/GamesWithThisStudio/" + SStudio, "hub");
                }

                );

            GamesWithThisCPU = new RelayCommand(
                () => {
                   
                    this.GameResults = new RestCollection<Game>("http://localhost:60949/", "Stat/GamesWithThisCPU/" + SCPU, "hub"); }
                
                );

            GamesWithStudios = new RelayCommand(
                () => { this.Results = new RestCollection<string>("http://localhost:60949/", "Stat/GamesWithStudios", "hub"); }

                ) ;
           
            
         
                
        }
        
    }
    
}
