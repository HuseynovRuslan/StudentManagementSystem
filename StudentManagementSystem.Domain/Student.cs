using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Domain
{
    public class Student

    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int? GroupId { get; set; }
        public Group ?Group { get; set; }
        public ICollection<Teacher> ?Teachers { get; set; }
    }
}
