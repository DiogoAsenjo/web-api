using System.ComponentModel.DataAnnotations;

namespace web_api.Data.DTOs;

public class ReadStudentDTO
{
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Instagram { get; set; }
}
