using System.ComponentModel.DataAnnotations;

namespace SistemaBuscas.Models;

public class Debito
{
    public int DebitoId { get; set; }

    [Required(ErrorMessage ="Digite o Imóvel")]
    [Display(Name = "Imóvel")]
    [MaxLength(50)]
    public string? Imovel { get; set; }

    [Required(ErrorMessage ="Digite o nome da Empresa")]
    [MaxLength(50)]
    public string? Empresa { get; set; }

    [Required(ErrorMessage ="Digite o Serviço")]
    [Display(Name ="Serviço")]
    [MaxLength(50)]
    public string? Servico { get; set; }

    [Required(ErrorMessage = "Digite o Número do Débito Automático")]
    [Display(Name = "Número do Débito Automático")]
    [MaxLength(50)]
    public string? NumeroDeb { get; set; }
}
