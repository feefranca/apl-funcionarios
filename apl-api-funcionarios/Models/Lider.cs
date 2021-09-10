using System.Collections.Generic;

namespace apl_api_funcionarios.Models
{
    public class Lider
    {   
        public int idLider { get; set; }
        public string cpfFuncionario { get; set; }
        public virtual List<Funcionario> Funcionarios { get; set; }
    }
}
