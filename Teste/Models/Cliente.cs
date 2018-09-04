using System;
using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class Cliente : ModelBase
    {
        [Required(ErrorMessage = "O nome é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O endereço é obrigatório", AllowEmptyStrings = false)]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O CEP é obrigatório", AllowEmptyStrings = false)]
        public string CEP { get; set; }
        [Required(ErrorMessage = "O Sexo é obrigatório", AllowEmptyStrings = false)]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }
    }
}
