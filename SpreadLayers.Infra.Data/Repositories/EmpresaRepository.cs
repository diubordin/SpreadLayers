using Microsoft.EntityFrameworkCore;
using SpreadLayers.Domain.Entities;
using SpreadLayers.Domain.Interfaces;
using SpreadLayers.Infra.Data.Context;

namespace SpreadLayers.Infra.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private ApplicationDbContext _context;

        public EmpresaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Empresa> CreateAsync(Empresa empresa)
        {
            _context.Add(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<IEnumerable<Empresa>> GetEmpresasCadastradasAsync()
        {
            return await _context.Empresa.OrderBy(c => c.Nome).ToListAsync();
        }
    }
}