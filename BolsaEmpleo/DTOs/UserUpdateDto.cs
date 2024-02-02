namespace BolsaEmpleo.DTOs
{
    public class UserUpdateDto
    {
        public int typeId { get; set; }
        public int userIdentification { get; set; }
        public string userName { get; set; }
        public string userLastName { get; set; }
        public string userBirthday { get; set; }
        public string userProfession { get; set; }
        public int userSalary { get; set; }
        public string userEmail { get; set; }
    }
}
