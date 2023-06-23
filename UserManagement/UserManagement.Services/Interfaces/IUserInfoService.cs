using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DataAccess.EntityDTO;
namespace UserManagement.Services.Interfaces
{
    public interface IUserInfoService
    {
        UserRecordDTO GetUserAuthenticate(LoginDTO userRecordDTO);
        List<string> UserRols(int UserId);

    }
}
