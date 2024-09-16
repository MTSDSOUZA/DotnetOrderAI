using DotnetOrderAI.Models;
using DotnetOrderAI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        #region Injeção de dependência
        private readonly IPagamentoRepository pagamentoRepository;

        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            this.pagamentoRepository = pagamentoRepository;
        }
        #endregion

        /// <summary>
        /// Retorna a tabela completa de pagamentos
        /// </summary>
        #region GET para buscar todos os pagamentos
        [HttpGet]
        public async Task<ActionResult> getPagamento()
        {
            try
            {
                return Ok(await pagamentoRepository.GetPagamentos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }
        #endregion

        /// <summary>
        /// Retorna pagamento com o id especificado
        /// </summary>
        #region GET para buscar um pagamento usando o ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pagamento>> getPagamento(int id)
        {
            try
            {
                var result = await pagamentoRepository.GetPagamento(id);
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
        /// Inserção de um novo pagamento
        /// </summary>
        /// <response code="201">Retorna pagamento criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        #region POST para criar um novo pagamento
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Pagamento>> createEmpregado([FromBody] Pagamento pagamento)
        {
            try
            {
                if (pagamento == null) return BadRequest();

                var result = await pagamentoRepository.AddPagamento(pagamento);

                return CreatedAtAction(nameof(getPagamento), new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }
        #endregion

        /// <summary>
        /// Altera pagamento com o id especificado
        /// </summary>
        #region PUT para atualizar um pagamento
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Pagamento>> UpdateEmrpegado([FromBody] Pagamento pagamento)
        {
            try
            {
                var result = await pagamentoRepository.GetPagamento(pagamento.Id);
                if (result == null) return NotFound($"Pagamento chamado = {pagamento.apelido_cartao} não encontrado");

                return await pagamentoRepository.UpdatePagamento(pagamento);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }
        #endregion

        /// <summary>
        /// Deleta pagamento com o id especificado
        /// </summary>
        #region DELETE para deletar um pagamento
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Pagamento>> DeletePagamento(int id)
        {
            try
            {
                var result = await pagamentoRepository.GetPagamento(id);
                if (result == null) return NotFound($"Empregado com id = {id} não encontrado");

                await pagamentoRepository.DeletePagamento(id);

                return Ok("Pagamento deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
        #endregion
    }
}
