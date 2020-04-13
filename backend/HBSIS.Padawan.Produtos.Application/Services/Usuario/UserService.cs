using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Padawan.Produtos.Domain.Entities;


namespace HBSIS.Padawan.Produtos.Application.Services.Usuario
{
    public class UserService : IUserService
    {
        
        private List<UsuarioEntity> _users = new List<UsuarioEntity>
        { 
            new UsuarioEntity() { Id = 1, Usuario = "test", Senha = "test" } 
        };

        public async Task<UsuarioEntity> Authenticate(string usuario, string senha)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Usuario == usuario && x.Senha == senha));

            // retorna nulo se nao for encontrado
            if (user == null)
                return null;

            // se autenticacao der ok entao retorna os detalhes do usuario sem senha 
            user.Senha = null;
            return user;
        }

        public async Task<IEnumerable<UsuarioEntity>> GetAll()
        {
            // returna usuarios sem senha
            return await Task.Run(() => _users.Select(x => {
                x.Senha = null;
                return x;
            }));
        }
    }
}
