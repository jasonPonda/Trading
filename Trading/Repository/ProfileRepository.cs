using Trading.Interface;
using Trading.Models;
using Microsoft.EntityFrameworkCore;

namespace Trading.Repository
{
    public class ProfileRepository : IProfiles
    {
        readonly DatabaseContext _dbContext = new();

        public ProfileRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProfileModel> GetProfiles()
        {
            try
            {
                return _dbContext.Profiles.ToList();
            }
            catch
            {
                throw;
            }
        }

        public ProfileModel GetProfiles(int id)
        {
            try
            {
                ProfileModel? profile = _dbContext.Profiles.Find(id);
                if (profile != null)
                {
                    return profile;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddProfile(ProfileModel profile)
        {
            try
            {
                _dbContext.Profiles.Add(profile);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProfile(ProfileModel profile)
        {
            try
            {
                _dbContext.Entry(profile).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public ProfileModel DeleteProfile(int id)
        {
            try
            {
                ProfileModel? profile = _dbContext.Profiles.Find(id);

                if (profile != null)
                {
                    _dbContext.Profiles.Remove(profile);
                    _dbContext.SaveChanges();
                    return profile;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckProfile(int id)
        {
            return _dbContext.Profiles.Any(e => e.Id == id);
        }
    }
}