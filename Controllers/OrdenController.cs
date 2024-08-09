using Microsoft.AspNetCore.Mvc;
using ProyectoFerreteria.Entidades;
using ProyectoFerreteria.Repositorio;

namespace ferreteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IRepositorioOrdenCompra _repositorioOrdenCompra;

        public OrdenController(IRepositorioOrdenCompra repositorioOrden)
        {
            _repositorioOrdenCompra = repositorioOrden;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioOrdenCompra.ObtenerOrden();
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
                var orden = await _repositorioOrdenCompra.ObtenerOrdenPorId(id);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdenCompra orden)
        {
            try
            {
                var id = await _repositorioOrdenCompra.CrearOrden(orden);
                return Ok(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(OrdenCompra orden)
        {
            try
            {
                await _repositorioOrdenCompra.ModificarOrden(orden);
                return Ok(orden.Id);
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
                await _repositorioOrdenCompra.EliminarOrden(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

    }
}
