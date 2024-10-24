using System.Threading.Tasks;
using crm_admin.Models;

namespace crm_admin.Services
{
    public interface IAuthService
    {
        Task<Usuario?> Authenticate(string email, string password);
    }
}
