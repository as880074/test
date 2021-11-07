using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AutoMapper;
using Demo.Lib.Infrastructure.Attribute;
using Demo.Lib.Models.Repository;
using Demo.Lib.Models.Services;
using Demo.Lib.Repository;

namespace Demo.Lib.Services
{
    public class UserService
    {
        private readonly UserRepo _userRepo;
        private readonly IMapper _iMapper;

        public UserService(UserRepo userRepo,IMapper iMapper)
        {
            _userRepo = userRepo;
            _iMapper = iMapper;
        }
        [CoreProfilingAsync("UserService.Create")]
        public IEnumerable<int> Create(IEnumerable<UserModel> userModels)
        {
            var param = userModels.Select(x => _iMapper.Map<User>(x));
            foreach (var item in param)
            {
                Debug.Write($"{item.Name}");
            }
            var result =_userRepo.Create(param);
            return result;
        }
        [CoreProfilingAsync("UserService.GetDetail")]
        public IEnumerable<UserDetailModel> GetDetail(IEnumerable<int> ids)
        {
            var data = _userRepo.GetDetail(ids);
            var result = data.Select(x => _iMapper.Map<UserDetailModel>(x));
            return result;
        }
    }
}
