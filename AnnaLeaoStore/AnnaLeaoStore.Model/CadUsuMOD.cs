using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class CadUsuMOD
    {
        [Required]
        [Display(Name = "Usuário: ")]
        public string Usuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha: ")]
        public string Senha { get; set; }
        public string Nivel { get; set; }
    }
}
