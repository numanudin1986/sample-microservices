using UserManagement.DataAccess.EntityDTO;
namespace UserManagement.Helper
{
    public interface ISessionManager
    {
       

        string GenerateToken(UserRecordDTO userRecordDTO);
    }
}
