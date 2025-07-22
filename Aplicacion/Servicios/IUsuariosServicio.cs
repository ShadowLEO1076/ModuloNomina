using System.ServiceModel;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;

namespace Aplicacion.Servicios
{
    [ServiceContract]
    public interface IUsuariosServicio
    {
        [OperationContract]
        Task<UsuarioDTO> LoginAsync(LoginDTO loginDto);
    }
}
