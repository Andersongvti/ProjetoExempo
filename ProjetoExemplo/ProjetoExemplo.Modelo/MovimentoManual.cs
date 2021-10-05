using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoExemplo.Modelo
{
    [Table("MOVIMENTO_MANUAL")]
    public class MovimentoManual
    {
        public MovimentoManual()
        {
            CodigoUsuario = "TESTE";
        }

        [Key, Column("DAT_MES", Order = 0)]
        public short Mes { get; set; }

        [Key, Column("DAT_ANO", Order = 1)]
        public short Ano { get; set; }

        [Key, Column("NUM_LANCAMENTO", Order = 2)]
        public int NumeroLancamento { get; set; }

        [Column("COD_PRODUTO"), StringLength(4), Required]
        public string CodigoDoProduto { get; set; }
        [Column("DES_DESCRICAO"), StringLength(50), Required]
        public string Descricao { get; set; }
        [Column("DAT_MOVIMENTO", TypeName = "smalldatetime")]
        public DateTime DataMovimento { get; set; }
        [Column("COD_USUARIO"), StringLength(15), Required]
        public string CodigoUsuario { get; set; }
        [Column("VAL_VALOR")]
        public decimal Valor { get; set; }
        [Column("COD_COSIF"), StringLength(11), Required]
        public string CodigoCosif { get; set; }
        [ForeignKey("CodigoCosif")]
        public ProdutoCosif ProdutoCosif { get; set; }
    }

   
}
