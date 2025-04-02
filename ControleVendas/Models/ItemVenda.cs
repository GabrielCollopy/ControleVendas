using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleVendas.Models
{
    public class ItemVenda
    {
           
        [Display(Name = "Id do Item de Venda")]
        [Range(0, int.MaxValue, ErrorMessage = "Insira um valor válido.")]
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo ID da Venda é obrigatório")]
        [Display(Name = "ID da Venda")]
        [ForeignKey("Venda")]
        public int vendaId { get; set; }
        public virtual Venda ?Venda { get; set; }

        [Required(ErrorMessage = "O campo ID do Produto é obrigatório")]
        [Display(Name = "ID do Produto")]
        [ForeignKey("Produto")]
        public int produtoId { get; set; }
        public virtual Produto ?Produto { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório")]
        [Display(Name = "Quantidade do Produto")]
        public int quantidade { get; set; }

        [Required(ErrorMessage = "O campo Preço Unitário é obrigatório")]
        [Display(Name = "Preço Unitário do Produto")]
        public double precoUnitario { get; set; }
    }
}
