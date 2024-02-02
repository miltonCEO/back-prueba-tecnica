using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaEmpleo.Models
{
    public class Vacancies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vacantId { get; set; }

        public string vacantCode { get; set; }

        public string vacantJobTitle { get; set; }

        public string vacantDescription { get; set;  }

        public string vacantCompany { get; set; }

        public string vacantSalary { get; set; }


    }
}
