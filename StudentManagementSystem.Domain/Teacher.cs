namespace StudentManagementSystem.Domain
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
