using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaySimplex.Dados
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdTarefa { get; set; }
        [Required(ErrorMessage = "A data de Inicio deve ser inserida.")]
        public DateTimeOffset DataInicio { get; set; }
        [Required(ErrorMessage = "A data de fim deve ser inserida.")]
        public DateTimeOffset DataFim { get; set; }
        [Required(ErrorMessage = "A duração estimada deve ser inserida.")]
        public TimeSpan DuracaoEstimada { get; set; }
        [Required(ErrorMessage = "A estado deve ser inserida.")]
        public String Estado { get; set; }
        [Required(ErrorMessage = "A Usuario deve ser inserido.")]
        [ForeignKey("Usuario")]
        public Int64 IdUsuario { get; set; }
    }
}
