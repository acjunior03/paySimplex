using PaySimplex.Dados.Classes;
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
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        [Required(ErrorMessage = "A duração estimada deve ser inserida.")]
        public Int64 DuracaoEstimada { get; set; }
        [Required(ErrorMessage = "A estado deve ser inserida.")]
        public String Estado { get; set; }
        [Required(ErrorMessage = "A Usuario deve ser inserido.")]
        [ForeignKey("Usuario")]
        public Int64 IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
