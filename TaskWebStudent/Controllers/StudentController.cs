using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskWebSudent.Models;

namespace TaskWebStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> list { get; set; } = new List<Student>();

        //Fetch All Students Data

        [HttpGet]
        public IActionResult GetStudent()
        {
            if (list.Count > 0)
            {
                return Ok(new { Message = "Data fetch successfully", Data = list });
            }
            return BadRequest(new { Message = "Data not found" });
        }

        //Fetch Student By Id

        [HttpGet("student/{id}")]
        public IActionResult GetStudentById(int id)
        {
            Student? student = list.FirstOrDefault(ob => ob.studentId == id);
            if (student != null)
            {
                return Ok(new { Message = "Data Fetch By Id Successfully", Data = student });
            }
            return BadRequest("Id not found");
        }

        //Adding the Data or Post the Data

        [HttpPost("student")]
        public IActionResult PostStudent([FromBody] Student student)
        {
            list.Add(student);
            return Ok(new {Message= "Data Added Successfully",Students= student });
           
        }

        //Update the Student Data reference By Id

        [HttpPut]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            if (student != null || id > 0)
            {
                return Ok(new { Message = "Data Updated Successfully", Data = student });
            }
            return BadRequest("Data not Found");
        }

        //Delete the Student Data By Id

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            if (id > 0)
            {
                return Ok(new { Message = "Data Deleted Successfully", Data = id });
            }
            return BadRequest("Id not found");
        }

        //Perticular Parameter will Change 

        [HttpPatch("studentName/{id}")]
        public IActionResult PatchStudent(int id, [FromBody] string newName)
        {
            Student? student = list.FirstOrDefault(s => s.studentId == id);

            if (student != null)
            {
                student.studentName = newName;
                return Ok(new { Message = "Student Name Updated Successfully", Data = student });
            }

            return NotFound("Student not found");

        }

    }
}
