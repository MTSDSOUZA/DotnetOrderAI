using DotnetOrderAI.Models;
using DotnetOrderAI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        #region Injeção de dependência
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }
        #endregion

        /// <summary>
        /// Retorna a tabela completa de pedidos
        /// </summary>
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

        /// <summary>
        /// Retorna Pedido com o id especificado
        /// </summary>
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

        /// <summary>
        /// Inserção de um novo pedido
        /// </summary>
        /// <response code="201">Retorna pedido criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
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

        /// <summary>
        /// Altera pedido com o id especificado
        /// </summary>
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

        /// <summary>
        /// Deleta pedido com o id especificado
        /// </summary>
        #region DELETE para deletar um pedido
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Pedido>> DeletePedido(int id)
        {
            try
            {
                var result = await pedidoRepository.GetPedido(id);
                if (result == null) return NotFound($"Pedido com id = {id} não encontrado");

                await pedidoRepository.DeletePedido(id);

                return Ok("Pedido deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
        #endregion
    }
}
