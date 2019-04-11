using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileReader.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public string ClienteNome { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public int Email { get; set; }
        public bool Ativo { get; set; }
        public string Produto { get; set; }
    }
}