using System.Collections.Generic;
using System.Linq;
using apl_api_funcionarios.Data;
using apl_api_funcionarios.Models;

namespace apl_api_funcionarios.Business
{
    public class TelefoneService
    {
        private AplDbContext _context;

        public TelefoneService(AplDbContext context)
        {
            _context = context;
        }
       
        public IEnumerable<Telefones> GetByFuncionario(string cpfFuncionario)
        {
            return _context.Telefones.Where(f => f.cpfFuncionario == cpfFuncionario);
        }

        public Telefones GetById(int idTelefone)
        {
            return _context.Telefones.Where(f => f.idTelefone == idTelefone).FirstOrDefault();
        }

        public void Insert(Telefones telefone)
        {
            _context.Add(telefone);
            _context.SaveChanges();
        }  
        
        public void Update(List<Telefones> telefones)
        {
            foreach (var telefone in telefones)
            {
                var tel = GetById(telefone.idTelefone);

                if (tel != null)
                {
                    tel.ddd = telefone.ddd;
                    tel.numero = telefone.numero;
                    tel.tipo = telefone.tipo;                   

                    _context.SaveChanges();                    
                } 
                else
                {
                    Insert(telefone);
                }
            }
        }
    }
}
