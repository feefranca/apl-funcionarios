using System.Collections.Generic;
using System.Linq;

using apl_api_funcionarios.Data;
using apl_api_funcionarios.Models;

namespace apl_api_funcionarios.Business
{
    public class FuncionarioService
    {
        private AplDbContext _context;
        private TelefoneService _telefoneService;
        private LiderService _liderService;
        public FuncionarioService(AplDbContext context, TelefoneService telefoneService, LiderService liderService)
        {
            _context = context;
            _telefoneService = telefoneService;
            _liderService = liderService;
        }

        public void Delete(string cpfFuncionario)
        {
            var func = GetById(cpfFuncionario);
            if (func != null)
            {
                _context.Remove(func);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Funcionario> GetAll()
        {
            return _context.Funcionarios.OrderBy(f => f.nome).ToList();
        }

        public Funcionario GetById(string cpfFuncionario)
        {
            return _context.Funcionarios.Where(f => f.cpfFuncionario == cpfFuncionario).FirstOrDefault();
        }

        public void Insert(Funcionario funcionario)
        {
            _context.Add(funcionario);

            foreach (var tel in funcionario.telefones)
            {
                _telefoneService.Insert(tel);

            }

            _context.SaveChanges();
        }

        public void Update(Funcionario funcionario)
        {
            var func = GetById(funcionario.cpfFuncionario);

            if (func != null)
            {
                func.nome = funcionario.nome;
                func.email = funcionario.email;
                func.cargo = funcionario.cargo;
                func.idLider = funcionario.idLider;

                _context.SaveChanges();
                _telefoneService.Update(funcionario.telefones);
            }
        }
    }
}
