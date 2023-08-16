using AutoMapper;
using SpreadLayers.Application.DTOs;
using SpreadLayers.Application.Interfaces;
using SpreadLayers.Domain.Entities;
using SpreadLayers.Domain.Interfaces;

namespace SpreadLayers.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task CadastraEmpresaAsync(EmpresaDTO empresaDTO)
        {
            var empresa = _mapper.Map<Empresa>(empresaDTO);
            await _empresaRepository.CreateAsync(empresa);
            empresaDTO.Id = empresa.Id;
        }

        public async Task<IEnumerable<EmpresaDTO>> GetEmpresasCadastradasAsync()
        {
            var categoriesEntity = await _empresaRepository.GetEmpresasCadastradasAsync();
            return _mapper.Map<IEnumerable<EmpresaDTO>>(categoriesEntity);
        }
    }
}