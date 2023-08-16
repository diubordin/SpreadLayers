using SpreadLayers.Domain.Entities;

namespace SpreadLayers.Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> GetEmpresasCadastradasAsync();

        Task<Empresa> CreateAsync(Empresa empresa);
    }
}