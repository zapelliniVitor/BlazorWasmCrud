using BlazorWasmCrud.Server.Data;
using BlazorWasmCrud.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmCrud.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DatabaseContext _ctx;

        public PersonController(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public IActionResult AddUpdate(Person person)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Invalid Data";
                return Ok(status);
            }
            try
            {
                if (person.Id==0)
                {
                    _ctx.Person.Add(person); 
                } else
                {
                    _ctx.Person.Update(person);
                }
                _ctx.SaveChanges();
                status.StatusCode = 1;
                status.Message = "Saved sucessfully";
            }
            catch (Exception ex)
            {
                status.StatusCode = 0;
                status.Message = "Server Error";
            }

            return Ok(status);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var status = new Status();
            var person=_ctx.Person.Find(id);
            if (person is null)
            {
                status.StatusCode= 0;
                status.Message = "Person does not exist";
                return Ok(person);
            }
            _ctx.Person.Remove(person); 
            _ctx.SaveChanges();

            status.StatusCode = 1;
            status.Message = "Deleted Sucessfully";
            return Ok(person);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var data = _ctx.Person.Find(id);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _ctx.Person.ToList();
            EmpresaClienteList model = new EmpresaClienteList
            {
                Persons = data
            };
            return Ok(model); 
        }
    }
}
