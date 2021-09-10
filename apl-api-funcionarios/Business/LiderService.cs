using System.Linq;
using apl_api_funcionarios.Data;
using apl_api_funcionarios.Models;

namespace apl_api_funcionarios.Business
{
    public class LiderService
    {
        private AplDbContext _context;

        public LiderService(AplDbContext context)
        {
            _context = context;
        }

        public Lider Get(int idLider, string cpfFuncionario)
        {
            return _context.Liders.Where(f => f.idLider == idLider && f.cpfFuncionario == cpfFuncionario).FirstOrDefault();
        }

        public void Insert(Lider lider)
        {
            _context.Add(lider);
            _context.SaveChanges();
        }

        public void Update(int idLider, string cpfFuncionario)
        {
            var lider = Get(idLider, cpfFuncionario);

            if (lider != null)
            {
                lider.idLider = idLider;               
                _context.SaveChanges();
            }
            else
            {
                Insert(new Lider { idLider = idLider, cpfFuncionario = cpfFuncionario });
            }
        }
    }
}
