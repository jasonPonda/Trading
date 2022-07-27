using Trading.Models;

namespace Trading.Interface
{
    public interface IProfiles
    {
        public List<ProfileModel> GetProfiles();
        public ProfileModel GetProfiles(int id);
        public void AddProfile(ProfileModel profile);
        public void UpdateProfile(ProfileModel profile);
        public ProfileModel DeleteProfile(int id);
        public bool CheckProfile(int id);

    }
}