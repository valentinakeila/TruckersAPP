using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }


        [HttpGet]
        public ActionResult<List<SubjectDto>> GetAll()
        {
            var obj = _subjectService.GetAll();
            return Ok(obj);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id) {
        
            _subjectService.Delete(id);
            return NoContent();
        }


        [HttpPost]
        public ActionResult Create([FromBody] SubjectCreateRequest subjectCreateRequest)
        {
            var obj = _subjectService.Create(subjectCreateRequest);
            return Ok(obj);
        }


        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] SubjectUpdateRequest subjectUpdateRequest)
        {
            _subjectService.Update(subjectUpdateRequest);
            return NoContent();
        }

         
    }
}
