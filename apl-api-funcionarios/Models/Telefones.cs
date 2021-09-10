using System.ComponentModel.DataAnnotations.Schema;

namespace apl_api_funcionarios.Models
{
    public class Telefones
    {
        public int idTelefone { get; set; }
        public int ddd { get; set; }
        public int numero { get; set; }
        public TipoTel tipo { get; set; }
        public string cpfFuncionario { get; set; }

        [ForeignKey("cpfFuncionario")]
        public Funcionario funcionario { get; set; }
    }

    public enum TipoTel
    {
        Celular,
        Residencial
    }
}
