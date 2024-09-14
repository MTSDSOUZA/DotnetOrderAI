using System.ComponentModel.DataAnnotations;

namespace DotnetOrderAI.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public string endereco { get; set; } = string.Empty;
        public string cep { get; set; } = string.Empty;
        public string cidade { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string cpf { get; set; } = string.Empty;
        public string dataCadastro { get; set; }
        public string dataNascimento { get; set; }
        public string sexo { get; set; } = string.Empty;
    }
}
