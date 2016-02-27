using Motd.Data.Models;
using Motd.Repositories.Contracts;
using Motd.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motd.Services
{
    public class UserService : IUserService
    {
        IMotdRepository<User> _userRepository = null;

        public UserService(IMotdRepository<User> userRepository)
            : base()
        {
            _userRepository = userRepository;

        }

        public List<User> GetUsers()
        {
            return _userRepository.Get().ToList();
        }
    }
}
