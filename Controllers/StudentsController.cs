using MDSoftTestBE.DataSet;
using MDSoftTestBE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDSoftTestBE.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private StudentDBContext _dbContext;

        public StudentsController(StudentDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetStudents")]
        public IActionResult GetStudent()
        {
            try
            {
                var studentsList = _dbContext.Students.ToList();
                return Ok(studentsList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("SetStudents")]
        public IActionResult SetStudents([FromBody] StudentModel newStudent)
        {
            try
            {
                var student = _dbContext.Students.Add(newStudent);
                _dbContext.SaveChanges();
                return Ok(student);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("DeleteStudents")]
        public IActionResult DeleteStudents(int StudentId)
        {
            try
            {
                var student = _dbContext.Students.Where(w => w.Id == StudentId).FirstOrDefault();
                _dbContext.Remove(student);
                _dbContext.SaveChanges();

                return Ok(student);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("EditStudent")]
        public IActionResult EditStudent([FromBody] StudentModel student)
        {
            try
            {
                var editStudent = _dbContext.Students.Where(w => w.Id == student.Id).FirstOrDefault();
                editStudent.Name = student.Name;
                _dbContext.SaveChanges();

                return Ok(editStudent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
