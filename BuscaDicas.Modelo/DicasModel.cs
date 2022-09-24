using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaDicas.Modelo
{
    public class DicasModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O Id é obrigatório.")]
        public int id { get; set; }

        [StringLength(500)]
        public string Dicas { get; set; }

        [Display(Name = "Data criação")]
        public DateTime DataCriacao { get; set; }

    }
}
