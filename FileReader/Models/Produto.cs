using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FileReader.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }
        public int ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public int ClienteID { get; set; }
        [ForeignKey("ClienteID")]
        public virtual Produto Prod { get; set; }
    }
}