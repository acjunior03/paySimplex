using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaySimplex.Dados
{
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdTarefa { get; set; }
        public DateTimeOffset DataInicio { get; set; }
        public DateTimeOffset DataFim { get; set; }
        public TimeSpan DuracaoEstimada { get; set; }
        public String Estado { get; set; }
        [ForeignKey("Usuario")]
        public Int64 IdUsuario { get; set; }
    }
}
