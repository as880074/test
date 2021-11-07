using System;
using System.Collections.Generic;
using System.Text;
using Demo.Lib.Infrastructure.Attribute;
using Demo.Lib.Models.Repository;

namespace Demo.Lib.Repository
{
    public class UserRepo
    {
        [CoreProfilingAsync("UserRepo.Create")]
        public IEnumerable<int> Create(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                user.Id = 1;
            }
            var result = new List<int>(){1,2,3,4,5,6 };
            return result;
        }

        [CoreProfilingAsync("UserRepo.GetDetail")]
        public IEnumerable<UserDetailDto> GetDetail(IEnumerable<int> ids)
        {
            var result = new List<UserDetailDto>()
            {
                new UserDetailDto(),
                new UserDetailDto(),
                new UserDetailDto(),
            };
            return result;
        }
    }
}
