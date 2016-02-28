using Motd.Data;
using Motd.Data.Models;
using Motd.Repositories.Contracts;
using Motd.Services.Contracts;
using Motd.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motd.Services
{
    public class UserService : IUserService
    {
        IMotdRepository<User> _serRepository = new MotdRepository<User>(new MotdContext());

        /// <summary>
        ///   Get list of users
        /// </summary>
        public List<UserViewModel> GetUsers()
        {
            var list = _serRepository.Get();
            List<UserViewModel> returnList = null;

            if (list!=null)
            {
                returnList = new List<UserViewModel>();
                foreach (User user in list)
                {
                    UserViewModel model = new UserViewModel();
                    model.Birthday = user.Birthday;
                    model.Email = user.Email;
                    model.Id = user.Id;
                    model.IsFbUser = user.IsFbUser;
                    model.LastName = user.LastName;
                    model.Name = user.Name;

                    returnList.Add(model);
                } 
            }
            return returnList;
        }
    }
}
