using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaEmpleo.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        public int typeId { get; set; }

        [ForeignKey("typeId")]
        public virtual Type Type { get; set; }

        public int userIdentification { get; set; }

        public string userName { get; set; }

        public string userLastName { get; set; }

        public string userBirthday { get; set; }

        public string userProfession { get; set; }

        public int userSalary { get; set; }

        public string userEmail { get; set; }
    }
}
