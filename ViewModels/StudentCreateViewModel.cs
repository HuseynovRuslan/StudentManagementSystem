using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
    
{
    public class StudentCreateViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50,ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(1,120,ErrorMessage = "Age must be between 1 and 120")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
   
        public string Email { get; set; }

        [Required(ErrorMessage = "GroupId is required")]
        public int GroupId { get; set; }
    }
}
