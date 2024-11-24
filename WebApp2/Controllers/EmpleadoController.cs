using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

 
        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)

        {
            return Ok(_empleadoService.GetAllEmpleados(isActive));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var empleado = _empleadoService.GetEmpleadoByID(id); if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado);
        }

        [HttpPost]
        public IActionResult Post(AddUpdateEmpleado empleadoObject)
        {
            var empleado =
            _empleadoService.AddEmpleado(empleadoObject);

            return Ok(new
            {

                message = "Empleado creado exitosamente.",
                id = empleado.Id

            });
        }

        [HttpPut("{id}")]

        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateEmpleado empleadoObject)
        {
            var empleado = _empleadoService.UpdateEmpleado(id, empleadoObject);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(new
            {

                message = "Empleado actualizado exitosamente.",
                id = empleado.Id

            });
        }

        


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_empleadoService.DeleteEmpleadoByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {

                message = "Empleado eliminado exitosamente.",
                id = id

            });
        }
    }

}
