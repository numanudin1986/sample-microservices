using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Services.Interfaces;
using UserManagement.DataAccess.Interfaces;
using UserManagement.DataAccess.Enitites;
using UserManagement.DataAccess.EntityDTO;

namespace UserManagement.Services.Repositories
{
    public class UserInfoService : IUserInfoService
    {
        public readonly IGenericRepository<UserRecord> _userRecord;
        public UserInfoService(IGenericRepository<UserRecord> userRecord)
        {
            _userRecord = userRecord;
        }
        public UserRecordDTO GetUserAuthenticate(LoginDTO userRecordDTO)
        {
            UserRecordDTO _user = _userRecord.GetAll().Where(x => x.Email!=null && x.Email.ToLower().Trim() == userRecordDTO.Email.ToLower().Trim() && x.Password == userRecordDTO.Password).Select(x=> new UserRecordDTO {FirstName = x.FirstName,LastName = x.LastName,Email =x.Email,RoleId =x.RoleId,RoleType = x.RoleType,Id =x.Id }).FirstOrDefault();
            return _user;
        }

        public List<string> UserRols(int UserId)
        {
            return _userRecord.GetAll().Where(x => x.Id == UserId).Select(x => x.RoleType ?? string.Empty).ToList();
        }
    }
}
