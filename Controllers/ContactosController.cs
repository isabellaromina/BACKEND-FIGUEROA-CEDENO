using Microsoft.AspNetCore.Mvc;
using ProyectoFerreteria.Entidades;
using ProyectoFerreteria.Repositorio;

namespace ferreteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController: ControllerBase
    {
        private readonly IRepositorioContactos _repositorioContactos;

        public ContactosController(IRepositorioContactos repositorioContactos)
        {
            _repositorioContactos = repositorioContactos;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioContactos.ObtenerContactos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contacto = await _repositorioContactos.ObtenerContactoPorId(id);
                return Ok(contacto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post(Contactos contactos)
        {
            try
            {
                var id = await _repositorioContactos.CrearContacto(contactos);
                return Ok(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Contactos contactos)
        {
            try
            {
                await _repositorioContactos.ModificarContacto(contactos);
                return Ok(contactos.Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositorioContactos.EliminarContacto(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

    }
}
