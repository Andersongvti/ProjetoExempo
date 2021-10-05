using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoExemplo.Modelo
{
    [Table("PRODUTO")]
    public class Produto
    {
        [Key, Column("COD_PRODUTO"), StringLength(4)]
        public string CodigoDoProduto { get; set; }
        [Column("DES_PRODUTO"), StringLength(30)]
        public string DescricaoDoProduto { get; set; }
        [Column("STA_STATUS"), StringLength(1)]
        public string Status { get; set; }
    }
}
