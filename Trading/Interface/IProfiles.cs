using TradingApp.Models;

namespace TradingApp.Interface
{
    public interface IProfiles
    {
        public List<Profile> GetProfiles();
        public Profile GetProfiles(int id);
        public void AddProfile(Profile profile);
        public void UpdateProfile(Profile profile);
        public Profile DeleteProfile(int id);
        public bool CheckProfile(int id);

    }
}