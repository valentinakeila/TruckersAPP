using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public ActionResult<List<StudentDto>> GetAll()
        {
            var obj = _studentService.GetAll();
            return Ok(obj);
        }

        [HttpGet("controller2")]
        public ActionResult<List<Student>> GetAllFullData()
        {
            var obj = _studentService.GetAllFullData();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var obj = _studentService.GetById(id);
            return Ok(obj);
        }

        [HttpPost]
        public ActionResult Create([FromBody] StudentCreateRequest studentCreateRequest)
        {
            var obj = _studentService.Create(studentCreateRequest);
            return Ok(obj);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody]StudentUpdateRequest studentUpdateRequest)
        {
            _studentService.Update(id, studentUpdateRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _studentService.Delete(id);
            return NoContent();
        }


    }
}
