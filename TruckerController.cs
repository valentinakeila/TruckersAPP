using Application.Interfaces;
using Application.Models.Requests;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckerController : ControllerBase
    {
        private readonly ITruckerService _truckerService;
        public TruckerController(ITruckerService truckerService)
        {
            _truckerService = truckerService;
        }


        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id) {
            var obj = _truckerService.GetById(id);
            return Ok(obj);


        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id, [FromBody] UserSaveRequest trucker)
        {
            var obj = _truckerService.Update(id, trucker);
            return Ok(obj);
        }
    }
}
// obtener truker por id y modificar trucker
