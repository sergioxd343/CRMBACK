using System.Threading.Tasks;
using crm_admin.Models;
using Microsoft.EntityFrameworkCore;

namespace crm_admin.Services
{
    public class AuthService : IAuthService
    {
        private readonly AdminSoftliContext _context;

        public AuthService(AdminSoftliContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> Authenticate(string email, string password)
        {
            // Buscar el usuario por email
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            // Si el usuario no existe o la contraseña no coincide, devolver null
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash))
            {
                return null;
            }

            return user; // Si el email y la contraseña coinciden, devolver el usuario
        }

        // Temporalmente omitir el uso de BCrypt y hacer una comparación directa de las contraseñas
        private bool VerifyPasswordHash(string password, string storedHash)
        {
            // Comparación directa de la contraseña ingresada con el "hash" almacenado
            return password == storedHash; // Simple comparación mientras omites BCrypt
        }
    }
}
