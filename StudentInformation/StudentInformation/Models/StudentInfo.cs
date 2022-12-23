using System.ComponentModel.DataAnnotations;

namespace StudentInformation.Models
{
    public class StudentInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
