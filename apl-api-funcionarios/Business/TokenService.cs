using System.Linq;
using apl_api_funcionarios.Data;
using apl_api_funcionarios.Models;

namespace apl_api_funcionarios.Business
{
    public class TokenService
    {
        private AplDbContext _context;

        public TokenService(AplDbContext context)
        {
            _context = context;
        }

        public Token Obter(string user)
        {
            return _context.Tokens.Where(
                u => u.username == user).FirstOrDefault();
        }

        public void Incluir(Token user)
        {
            _context.Tokens.Add(user);
            _context.SaveChanges();
        }
    }
}
