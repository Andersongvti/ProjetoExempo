using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoExemplo.Modelo
{
    [Table("PRODUTO_COSIF")]
    public class ProdutoCosif
    {
        [Key, Column("COD_COSIF" ), StringLength(11)]
        public string CodigoCosif { get; set; }
        [Column("COD_CLASSIFICACAO"), StringLength(6)]
        public string CodigoClassificacao { get; set; }
        [Column("STA_STATUS" ), StringLength(1)]
        public string Status { get; set; }
        [Column("COD_PRODUTO"), StringLength(4), Required]
        public string CodigoProduto { get; set; }
        [ForeignKey("CodigoProduto")]
        public Produto Produto { get; set; }
    }
}
