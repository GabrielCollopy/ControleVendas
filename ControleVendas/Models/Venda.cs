using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleVendas.Models
{
    public class Venda
    {
        
        [Display(Name = "Id da Venda")]
        [Range(0, int.MaxValue, ErrorMessage = "Insira um valor válido.")]
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Data da Venda é obrigatório")]
        [Display(Name = "Data da Venda")]
        public DateTime dataVenda { get; set; }

        [Required(ErrorMessage = "O campo ID do Vendedor é obrigatório")]
        [Display(Name = "ID do Vendedor")]
        [ForeignKey("Vendedor")]
        public int vendedorId { get; set; }
        public virtual Vendedor ?Vendedor { get; set; }

    }
}
