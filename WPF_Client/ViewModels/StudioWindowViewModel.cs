using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Client.Logic;
using WPF_Client.Models;

namespace WPF_Client.ViewModels
{
    public class StudioWindowViewModel : ObservableRecipient
    {
         public RestCollection<Studio> Studios { get; set; }
        //Commands
        public ICommand Create { get; set; }
        public ICommand Update { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Read { get; set; }
        //Create
        public string CreateName { get; set; }
        public string CreateCEOName { get; set; }
        //Update
        private string updatename;
        public string UpdateName { get { return updatename; } set { SetProperty(ref updatename, value); } }
        public string updatestudioid;
        public string UpdateStudioId { get { return updatestudioid; } set { SetProperty(ref updatestudioid, value); } }
        public string updateceoname;
        public string Updateceoname { get { return updateceoname; } set { SetProperty(ref updateceoname, value); } }
        //Read
        private string readstudid;
        public string ReadStudioId { get { return readstudid; } set { SetProperty(ref readstudid, value); } }
        private string readname;
        public string ReadName { get { return readname; } set { SetProperty(ref readname, value); } }
        private string readceoname;
        public string ReadCEOName { get { return readceoname; } set { SetProperty(ref readceoname, value); } }

        private Studio selectedstudio;
        public Studio SelectedStudio { get { return selectedstudio; } set
            {
                SetProperty(ref selectedstudio, value);
                if(SelectedStudio != null)
                {
                    UpdateName = SelectedStudio.Name;
                    UpdateStudioId = SelectedStudio.StudioID.ToString();
                    Updateceoname = SelectedStudio.CEOName;
                }

            } }

        public StudioWindowViewModel(IStudioWindowLogic logic)
        {
            Studios = new RestCollection<Studio>("http://localhost:60949/", "studio", "hub");
            Create = new RelayCommand(
               () => logic.Create(new Studio(CreateName,Studios.Last().StudioID + 1,CreateCEOName), Studios)
               );
            Update = new RelayCommand(
                ()=> logic.Update(new Studio(UpdateName,  int.Parse(UpdateStudioId), Updateceoname), Studios)
                );
            Delete = new RelayCommand(
                ()=> logic.Delete(SelectedStudio.StudioID,Studios)
                );
            Read = new RelayCommand(
                ()=> { var studio = logic.Read(int.Parse(ReadStudioId), Studios);
                    ReadStudioId = studio.StudioID.ToString();
                    ReadName = studio.Name;
                    ReadCEOName = studio.CEOName;



                }
                );
        }
    }
}
