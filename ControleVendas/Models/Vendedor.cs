using System.ComponentModel.DataAnnotations;

namespace ControleVendas.Models
{
    public class Vendedor
    {
        
        [Display(Name = "Id do Vendedor")]
        [Range(0, int.MaxValue, ErrorMessage = "Insira um valor válido.")]
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [Display(Name = "Nome do Vendedor")]
        [MaxLength(100)]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [Display(Name = "CPF do Vendedor")]
        [MaxLength(100)]
        public string cpf { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [Display(Name = "E-mail do Vendedor")]
        [MaxLength(100)]
        public string email { get; set; }
    }
}
