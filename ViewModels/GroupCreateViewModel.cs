using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
{
    public class GroupCreateViewModel
    {
        [Required(ErrorMessage = "Groupname is required")]
        [StringLength(50, ErrorMessage = "Groupname cannot be longer than 50 characters")]
        public string ?Name { get; set; }
    }
}
