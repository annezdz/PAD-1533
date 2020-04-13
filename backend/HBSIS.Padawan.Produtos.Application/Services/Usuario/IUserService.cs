using System.Collections.Generic;
using System.Threading.Tasks;
using HBSIS.Padawan.Produtos.Domain.Entities;


namespace HBSIS.Padawan.Produtos.Application.Services.Usuario
{
    public interface IUserService
    {
        Task<UsuarioEntity> Authenticate(string username, string password);
        Task<IEnumerable<UsuarioEntity>> GetAll();
    }
}