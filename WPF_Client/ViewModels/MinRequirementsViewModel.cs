using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Client.Logic;
using WPF_Client.Models;

namespace WPF_Client.ViewModels
{
    public class MinRequirementsViewModel : ObservableRecipient
    {
        //Create
        public string CreateCPU { get; set; }
        public string CreateGPU { get; set; }
        public RestCollection<MinRequirements> MinReques {get;set;}
        //update
        private string updatecpu;
        public string UpdateCPU { get { return updatecpu; } set { SetProperty(ref updatecpu, value); } }
        public string updategpu;
        public string UpdateGPU { get { return updategpu; } set { SetProperty(ref updategpu, value); } }
        public string updatereqid;
        public string UpdateReqId { get { return updatereqid; } set { SetProperty(ref updatereqid, value); } }
        //read 
        private string readminreqid;
        public string ReadMinreqId { get { return readminreqid; } set { SetProperty(ref readminreqid, value); } }
        private string readcpu;
        public string ReadCPU { get { return readcpu; } set { SetProperty(ref readcpu, value); } }
        private string readgpu;
        public string ReadGPU { get { return readgpu; } set { SetProperty(ref readgpu, value); } }
        private MinRequirements selectedminreq;
        public MinRequirements SelectedMinReq { get { return selectedminreq; } set
            {
                SetProperty(ref selectedminreq, value);
                if (SelectedMinReq != null) { 
                UpdateCPU = SelectedMinReq.CPU;
                UpdateGPU = SelectedMinReq.GPU;
                UpdateReqId = SelectedMinReq.ReqId.ToString();
                    }
            } }
        public ICommand Create { get; set; }
        public ICommand Update { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Read { get; set; }
        public MinRequirementsViewModel(IMinRequirementsLogic logic)
        {
            MinReques = new RestCollection<MinRequirements>("http://localhost:60949/", "minrequirements","hub");
            Create = new RelayCommand(
                ()=> logic.Create(new MinRequirements( MinReques.Last().ReqId  + 1 , CreateCPU, CreateGPU), MinReques)
                );
            Update = new RelayCommand(
                ()=> logic.Update(new MinRequirements(int.Parse(UpdateReqId),UpdateCPU,UpdateGPU),MinReques)
                );
            Delete = new RelayCommand(
                ()=> logic.Delete(SelectedMinReq.ReqId,MinReques)
                );
            Read = new RelayCommand(
                ()=> { var minreq = logic.Read(int.Parse(ReadMinreqId), MinReques);
                    ReadCPU = minreq.CPU;
                    ReadGPU = minreq.GPU;
                
                
                
                }
                );
        }
    }
}
