using DotnetOrderAI.Models;
using DotnetOrderAI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderAI.Controllers
{
    public class PedidoController : ControllerBase
    {
        #region Injeção de dependência
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }
        #endregion

        #region GET para buscar todos os pedidos
        [HttpGet]
        public async Task<ActionResult> getPedido()
        {
            try
            {
                return Ok(await pedidoRepository.GetPedidos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }
        #endregion

        #region GET para buscar um pedido usando o ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pedido>> getPedido(int id)
        {
            try
            {
                var result = await pedidoRepository.GetPedido(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }
        #endregion

        #region POST para criar um novo pedido
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Pedido>> createEmpregado([FromBody] Pedido pedido)
        {
            try
            {
                if (pedido == null) return BadRequest();

                var result = await pedidoRepository.AddPedido(pedido);

                return CreatedAtAction(nameof(getPedido), new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }
        #endregion

        #region PUT para atualizar um pedido
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Pedido>> UpdateEmrpegado([FromBody] Pedido pedido)
        {
            try
            {
                var result = await pedidoRepository.GetPedido(pedido.Id);
                if (result == null) return NotFound($"Pedido não encontrado");

                return await pedidoRepository.UpdatePedido(pedido);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }
        #endregion

        #region DELETE para deletar um pedido
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Pedido>> DeletePedido(int id)
        {
            try
            {
                var result = await pedidoRepository.GetPedido(id);
                if (result == null) return NotFound($"Pedido com id = {id} não encontrado");

                pedidoRepository.DeletePedido(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
        #endregion
    }
    {
    }
}
