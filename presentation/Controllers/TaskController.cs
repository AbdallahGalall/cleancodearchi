using cleancodearchi.application;
using cleancodearchi.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cleancodearchi.presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly Interface _service;
        public TaskController(Interface service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var res = _service.getall();
            return Ok(res);
        }
        [HttpGet("getbyid")]
        public IActionResult Get_by_id(int id)
        {
            var res = _service.getbyid(id);
            if (res == null) { return NotFound(); }
            return Ok(res);
        }
        [HttpPut("id")]
        public async Task<IActionResult> update(model updatedtask, int id)
        {
            var res = _service.getbyid(id);
            if (res is null)
            {
                return NotFound();
            }

            await _service.updatetask(updatedtask, id);
            return Ok(updatedtask);
        }

        [HttpPost("create")]
        public async Task<IActionResult> creat(model new_task)
        {
            var res = await _service.creattask(new_task);
            return CreatedAtAction(nameof(Get_by_id), new { new_task.id }, new_task);
        }

        [HttpDelete("delete")]

        public async Task<IActionResult> delete(int id)
        {
            var idd = _service.getbyid(id);
            if (idd == null) { return NotFound(); }
            int count = await _service.deletetask(id);
            return NoContent();

        }
    }
}
