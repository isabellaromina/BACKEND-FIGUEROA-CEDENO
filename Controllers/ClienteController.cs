using Microsoft.AspNetCore.Mvc;
using ProyectoFerreteria.Entidades;
using ProyectoFerreteria.Repositorio;

namespace ferreteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public ClienteController(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioCliente.ObtenerClientes();
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
                var cliente = await _repositorioCliente.ObtenerClientePorId(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente clientes)
        {
            try
            {
                var id = await _repositorioCliente.CrearCliente(clientes);
                return Ok(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Cliente clientes)
        {
            try
            {
                await _repositorioCliente.ModificarCliente(clientes);
                return Ok(clientes.Id);
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
                await _repositorioCliente.EliminarCliente(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

    }
}
