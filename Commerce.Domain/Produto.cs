using System.ComponentModel.DataAnnotations.Schema;

namespace Commerce.Domain

{
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Estoque{ get; set; }
    }
}
