using SpreadLayers.Application.DTOs;

namespace SpreadLayers.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaDTO>> GetEmpresasCadastradasAsync();

        Task CadastraEmpresaAsync(EmpresaDTO empresaDTO);
    }
}