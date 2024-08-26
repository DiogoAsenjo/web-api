using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using web_api.Data;
using web_api.Data.DTOs;
using web_api.Models;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : Controller
{
    private StudentContext _context;
    private IMapper _mapper;

    public StudentController(StudentContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult registerStudent([FromBody] CreateStudentDTO studentDTO)
    {
        Student student = _mapper.Map<Student>(studentDTO);
        _context.Students.Add(student);
        _context.SaveChanges();
        return CreatedAtAction(nameof(getStudent), new { id = student.Id}, student);
    }

    [HttpGet]
    public IEnumerable<ReadStudentDTO> getStudents([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        
        return _mapper.Map<List<ReadStudentDTO>>(_context.Students.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult getStudent(int id)
    {
        var student = _context.Students.FirstOrDefault(student => student.Id == id);
        if (student == null) return NotFound();
        var studentDTO = _mapper.Map<ReadStudentDTO>(student);
        return Ok(studentDTO);
    }

    [HttpPut("{id}")]
    public IActionResult updateStudent(int id, [FromBody] UpdateStudentDTO studentDTO)
    {
        var studentFound = _context.Students.FirstOrDefault(student => student.Id == id);
        if (studentFound == null) return NotFound();
        _mapper.Map(studentDTO, studentFound);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult partialUpdateStudent(int id, JsonPatchDocument<UpdateStudentDTO> studentNewData)
    {
        var studentFound = _context.Students.FirstOrDefault(student => student.Id == id);
        if (studentFound == null) return NotFound();

        var studentToUpdate = _mapper.Map<UpdateStudentDTO>(studentFound);
        studentNewData.ApplyTo(studentToUpdate, ModelState);

        if (!TryValidateModel(studentToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(studentToUpdate, studentFound);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deleteStudent(int id)
    {
        var studentFound = _context.Students.FirstOrDefault(student => student.Id == id);
        if (studentFound == null) return NotFound();
        _context.Students.Remove(studentFound);
        _context.SaveChanges();
        return NoContent();
    }
}
