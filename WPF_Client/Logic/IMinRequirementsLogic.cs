using WPF_Client.Models;

namespace WPF_Client.Logic
{
    public interface IMinRequirementsLogic
    {
        void Create(MinRequirements item, RestCollection<MinRequirements> g);
        void Delete(int id, RestCollection<MinRequirements> g);
        MinRequirements Read(int id, RestCollection<MinRequirements> g);
        void Update(MinRequirements item, RestCollection<MinRequirements> g);
    }
}