using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaEmpleo.Models
{
    public class VacantApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vacantApplicationID { get; set; }

        public int vacantId { get; set; }
        
        [ForeignKey("vacantId")]
        public virtual Vacancies Vacancies { get; set; }


        public int userId { get; set; }

        [ForeignKey("userId")]
        public virtual User User { get; set; }
    }
}
