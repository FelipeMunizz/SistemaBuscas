using SistemaBuscas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaBuscas.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }

        [Required(ErrorMessage = "Digite o Nome")]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage ="Selecione uma Categoria")]
        public CategoriaContato Categoria { get; set; }

        [Phone(ErrorMessage = "O número não é valido")]
        [MaxLength(50)]
        public string? Residencial { get; set; }

        [Phone(ErrorMessage = "O número não é valido")]
        [MaxLength(50)]
        public string? Comercial { get; set; }

        [Phone(ErrorMessage = "O número não é valido")]
        [MaxLength(50)]
        public string? Celular { get; set; }
    }
}
