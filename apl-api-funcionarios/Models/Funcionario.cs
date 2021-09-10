using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace apl_api_funcionarios.Models
{
    public class Funcionario
    {
        public string cpfFuncionario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }               
        public string senha { get; set; }
        public string cargo { get; set; }
        public int idLider { get; set; }

        [ForeignKey("idLider")]
        public virtual Lider Lider { get; set; }
        public List<Telefones> telefones { get; set; }
    }
}
