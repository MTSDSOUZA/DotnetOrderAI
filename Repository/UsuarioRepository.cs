using DotnetOrderAI.Data;
using DotnetOrderAI.Models;
using DotnetOrderAI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DotnetOrderAI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dbContext dbContext;
        public UsuarioRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            var result = await dbContext.TabelaUsuario.AddAsync(usuario);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteUsuario(int Id)
        {
            var result = await dbContext.TabelaUsuario.FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                dbContext.TabelaUsuario.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Usuario> GetUsuario(int Id)
        {
            return await dbContext.TabelaUsuario.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await dbContext.TabelaUsuario.ToListAsync();
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            var result = await dbContext.TabelaUsuario.FirstOrDefaultAsync(e => e.Id == usuario.Id);
            if (result != null)
            {
                result.nome = usuario.nome;
                result.email = usuario.email;
                result.senha = usuario.senha;
                result.telefone = usuario.telefone;
                result.endereco = usuario.endereco;
                result.cep = usuario.cep;
                result.cidade = usuario.cidade;
                result.estado = usuario.estado;
                result.cpf = usuario.cpf;
                result.dataNascimento = usuario.dataNascimento;
                result.dataCadastro = usuario.dataCadastro;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
