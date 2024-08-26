using System.ComponentModel.DataAnnotations;

namespace web_api.Models;

public class Student
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "You should inform the Student name")]
    [StringLength(100, ErrorMessage ="Student name should have two or more letters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "You should inform the Student birthday")]
    public DateTime Birthday { get; set; }
    public string Instagram { get; set; }
    public override string ToString()
    {
        return "Name: " + this.Name + "Age: " + (DateTime.Now.Year - Birthday.Year);
    }
}
