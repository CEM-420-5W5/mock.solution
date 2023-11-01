using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mock.depart.Data;
using mock.depart.Models;
using mock.depart.Services;

namespace mock.depart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly CatsService _service;

        public CatsController(CatsService service)
        {
            _service = service;
        }

        public virtual string? UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            }
        }

        // DELETE: api/Cats/5
        // TODO Pour facilité les tests il vaut mieux utiliser un ActionResult<Type>
        [HttpDelete("{id}")]
        public ActionResult<Cat?> DeleteCat(int id)
        {
            Cat? cat = _service.Get(id);
            if (cat == null)
            {
                return NotFound();
            }
            if (cat.CatOwner!.Id != UserId)
            {
                return BadRequest("Cat is not yours");
            }
            if (cat.CuteLevel == Cuteness.BarelyOk)
            {
                cat = _service.Delete(id);
                return Ok(cat);
            }
            else
            {
                return BadRequest("Cat is too cute");
            }
        }
    }
}
