using base_project.Models;
using base_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace base_project.Controllers
{
    public class BaseController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class _BaseController<T> : ControllerBase where T : BaseEntity
        {
            private readonly BaseService<T> _service;

            public _BaseController(BaseService<T> service)
            {
                _service = service;
            }

            [HttpGet]
            public virtual async Task<IActionResult> GetAll()
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public virtual async Task<IActionResult> GetById(Guid id)
            {
                var entity = await _service.GetByIdAsync(id);
                if (entity == null) return NotFound();
                return Ok(entity);
            }

            [HttpPost]
            public virtual async Task<IActionResult> Create([FromBody] T entity)
            {
                var created = await _service.AddAsync(entity);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }

            [HttpPut("{id}")]
            public virtual async Task<IActionResult> Update(Guid id, [FromBody] T entity)
            {
                if (id != entity.Id) return BadRequest();

                var updated = await _service.UpdateAsync(entity);
                return Ok(updated);
            }

            [HttpDelete("{id}")]
            public virtual async Task<IActionResult> Delete(Guid id)
            {
                var success = await _service.DeleteAsync(id);
                return success ? NoContent() : NotFound();
            }
        }
    }
}
