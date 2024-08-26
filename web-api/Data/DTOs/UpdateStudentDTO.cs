using System.ComponentModel.DataAnnotations;

namespace web_api.Data.DTOs;

public class UpdateStudentDTO
{
    [Required(ErrorMessage = "You should inform the Student name")]
    [StringLength(100, ErrorMessage = "Student name should have two or more letters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "You should inform the Student birthday")]
    public DateTime Birthday { get; set; }
    public string Instagram { get; set; }
}
