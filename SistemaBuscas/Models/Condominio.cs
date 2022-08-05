using SistemaBuscas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaBuscas.Models
{
    public class Condominio
    {
        public int CondominioId { get; set; }

        [Required(ErrorMessage = "Digite o Nome")]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Digite o Endereço e número")]
        [MaxLength(150)]
        [Display(Name ="Endereço")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "Selecione o Complemento")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Digite o CEP")]
        [MaxLength(150)]
        public string? CEP { get; set; }

        [Phone(ErrorMessage = "O número não é valido")]
        [MaxLength(50)]
        [Display(Name = "Telefone Administradora")]
        public string? TelAdm { get; set; }

        [EmailAddress(ErrorMessage ="Email inválido")]
        [MaxLength(100)]
        [Display(Name ="E-mail")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "O número não é valido")]
        [MaxLength(50)]
        [Display(Name = "Telefone Portaria")]
        public string? TelPort { get; set; }

        [Phone(ErrorMessage = "O número não é valido")]
        [MaxLength(50)]
        [Display(Name = "Telefone Zelador ou Responsável")]
        public string? TelZela { get; set; }
        public string? SenhaBoletos { get; set; }
    }
}
