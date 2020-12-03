using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaySimplex.Dados.Classes
{
    public class EnvioArquivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdArquivo { get; set; }
        public long Comprimento { get; set; }
        public String Nome { get; set; }
        [ForeignKey("Tarefa")]
        public Int64 IdTarefa { get; set; }


    }
}
