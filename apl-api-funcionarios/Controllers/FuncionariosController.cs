using System.Collections.Generic;
using apl_api_funcionarios.Business;
using apl_api_funcionarios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apl_api_funcionarios.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private FuncionarioService _service;

        public FuncionariosController(FuncionarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Funcionario> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{cpfFuncionario}")]
        public Funcionario Get(string cpfFuncionario)
        {
            return _service.GetById(cpfFuncionario);
        }

        [HttpPost]
        public void Post([FromBody] Funcionario funcionario)
        {
            _service.Insert(funcionario);
        }

        [HttpPut]
        public void Put([FromBody] Funcionario funcionario)
        {
            _service.Update(funcionario);
        }

        [HttpDelete("{cpfFuncionario}")]
        public void Delete(string cpfFuncionario)
        {
            _service.Delete(cpfFuncionario);
        }
    }
}
