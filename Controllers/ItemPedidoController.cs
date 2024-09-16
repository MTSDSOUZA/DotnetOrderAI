using DotnetOrderAI.Models;
using DotnetOrderAI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        #region Injeção de dependência
        private readonly IItemPedidoRepository itempedidoRepository;

        public ItemPedidoController(IItemPedidoRepository itempedidoRepository)
        {
            this.itempedidoRepository = itempedidoRepository;
        }
        #endregion

        #region GET para buscar todos os Itens 
        [HttpGet]
        public async Task<ActionResult> getItemPedido()
        {
            try
            {
                return Ok(await itempedidoRepository.GetItensPedido());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }
        #endregion

        #region GET para buscar um item usando o ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemPedido>> getItemPedido(int id)
        {
            try
            {
                var result = await itempedidoRepository.GetItemPedido(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }
        #endregion

        #region POST para criar um novo itempedido
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ItemPedido>> createEmpregado([FromBody] ItemPedido itempedido)
        {
            try
            {
                if (itempedido == null) return BadRequest();

                var result = await itempedidoRepository.AddItemPedido(itempedido);

                return CreatedAtAction(nameof(getItemPedido), new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }
        #endregion

        #region PUT para atualizar um item
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ItemPedido>> UpdateEmrpegado([FromBody] ItemPedido itempedido)
        {
            try
            {
                var result = await itempedidoRepository.GetItemPedido(itempedido.Id);
                if (result == null) return NotFound($"Item chamado = {itempedido.nome} não encontrado");

                return await itempedidoRepository.UpdateItemPedido(itempedido);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }
        #endregion

        #region DELETE para deletar um item
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ItemPedido>> DeleteItemPedido(int id)
        {
            try
            {
                var result = await itempedidoRepository.GetItemPedido(id);
                if (result == null) return NotFound($"Item com id = {id} não encontrado");

                itempedidoRepository.DeleteItemPedido(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
        #endregion
    }
}
