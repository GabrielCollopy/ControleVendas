using System.ComponentModel.DataAnnotations;

namespace ControleVendas.Models
{
    public class Produto
    {
       

        [Display(Name = "Id do Produto")]
        [Range(0, int.MaxValue, ErrorMessage = "Insira um valor válido.")]
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [Display(Name = "Nome do Produto")]
        [MaxLength(100)]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório")]
        [Display(Name = "Preço do Produto")]
        public double preco { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório")]
        [Display(Name = "Quantidade do Produto")]
        public int quantidade { get; set; }
    }
}
