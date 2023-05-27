using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Client.Logic;
using WPF_Client.Models;

namespace WPF_Client.ViewModels
{
    public class GameWindowViewModel : ObservableRecipient
    {
        IGameMenuLogic logic;
        public RestCollection<Game> Games { get; set; }
        public string CreateName { get; set; }
        public string CreateYear { get; set; }
        public string CreateStudioId { get; set; }
        public string MinRequimentID { get; set; }

        private string updatename;
        public string UpdateName { get { return updatename; } set { SetProperty(ref updatename, value); } }
        private string updateyear;
        public string UpdateYear { get { return updateyear; } set { SetProperty(ref updateyear, value); } }

        public string updatestudioid;
        public string UpdateStudioId { get { return updatestudioid; } set { SetProperty(ref updatestudioid, value); }  }

        private string updateMinRequimentID;
        public string UpdateMinRequimentID { get { return updateMinRequimentID; } set { SetProperty(ref updateMinRequimentID, value); } }
        private string updategameid;
        public string UpdateGameID { get { return updategameid; } set { SetProperty(ref updategameid, value); } }

        //Read stuffs
        private string readname;
        public string ReadName { get { return readname; } set { SetProperty(ref readname, value); } }

        private string readYear;
        public string ReadYear { get { return readYear; } set { SetProperty(ref readYear, value); } }

        private string readgameid;
        public string ReadGameId { get { return readgameid; } set { SetProperty(ref readgameid, value); } }
        private string readstudid;
        public string ReadStudioId { get { return readstudid; } set { SetProperty(ref readstudid, value); } }


        private string readreqid;
        public string ReadReqId { get { return readreqid; } set { SetProperty(ref readreqid, value); } }
        private Game readresult;
        public Game ReadResult { get { return readresult; } set { SetProperty(ref readresult, value); } }








        public string ReadID { get; set; }
        public Game selectedGame;
        public Game SelectedGame { get { return selectedGame; } set
            {
                SetProperty(ref selectedGame, value);
                if (SelectedGame != null) 
                { 
                UpdateName = SelectedGame.Name;
                UpdateYear = SelectedGame.Pyear;
                UpdateMinRequimentID = SelectedGame.ReqId.ToString();
                UpdateStudioId = SelectedGame.StudioId.ToString();
                UpdateGameID = SelectedGame.GameID.ToString();
                }
            }
        } 
        

        public ICommand Create{ get; set; }
        public ICommand Update { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Read { get; set; }
        public GameWindowViewModel(IGameMenuLogic logic)
        {
            this.logic = logic;
            this.ReadResult = new Game();
            this.Games = new RestCollection<Game>("http://localhost:60949/","game");
            Create = new RelayCommand(
                ()=>logic.Create(new Game(CreateName,Games.Last().GameID + 1,CreateYear,int.Parse(CreateStudioId), int.Parse(MinRequimentID)),Games)
                );
            Update = new RelayCommand(
                ()=>  logic.Update(new Game(UpdateName,int.Parse(UpdateGameID),UpdateYear,int.Parse(UpdateStudioId),int.Parse(UpdateMinRequimentID)), Games)
                
                );
            Delete = new RelayCommand(
                () => logic.Delete(int.Parse(UpdateGameID),Games)
                );
            Read = new RelayCommand(
                ()=> {
                    var game = logic.Read(int.Parse(ReadID), Games);
                    ReadName = game.Name;
                    ReadYear = game.Pyear;
                    ReadGameId = game.GameID.ToString();
                    ReadReqId = game.ReqId.ToString();
                    ReadStudioId = game.StudioId.ToString();

                }
                );
        }
        
    }
}
