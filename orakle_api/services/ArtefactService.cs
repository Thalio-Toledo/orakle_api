using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using orakle_api.Data;
using orakle_api.DTOs;
using orakle_api.Entities;
using orakle_api.Enums;
using orakle_api.Filters;


namespace orakle_api.services
{
    public class ArtefactService
    {
        private DataContext _Context { get; set; }
        private readonly IMapper _mapper;

        public ArtefactService(DataContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Artefact>> GetAll()
        {
            var docs = await _Context.Artefacts.ToListAsync();
            return docs;
        }
        public async Task<IEnumerable<Artefact>> GetByTitle(string title)
        {
            var docs = await _Context.Artefacts.Where(a => a.Title!.Contains(title)).ToListAsync();
            return docs;
        }

        public async Task<IEnumerable<Artefact>> GetByOwnerId(Guid OwnerId)
        {
            var docs = await _Context.Artefacts
                .Where(artefact => artefact.OwnerId == OwnerId && artefact.ArtefactType != ArtefactType.PROFILE)
                .ToListAsync();

            return docs;
        } 
        
        public async Task<IEnumerable<ArtefactSummaryDTO>> GetByFilter(ArtefactFilter filter)
        {
            var artefactsQueryable =  _Context.Artefacts.AsQueryable();

            if(filter.ArtefactType is not null)
            {
                artefactsQueryable = artefactsQueryable.Where(aq => aq.ArtefactType == filter.ArtefactType);
            }
            
            if(filter.Public is not null)
            {
                artefactsQueryable = artefactsQueryable.Where(aq => aq.Public == filter.Public);
            }

            var artefacts = await artefactsQueryable
                .Where(artefact => artefact.OwnerId == filter.OwnerId)
                .ToListAsync();

            var artefactsDTO = _mapper.Map<IEnumerable<ArtefactSummaryDTO>>(artefacts);

            return artefactsDTO;
        }

        public async Task<Artefact> FindById(Guid id)
        {
            var artefact = await _Context.Artefacts.FirstOrDefaultAsync(a => a.ArtefactId == id);
            return artefact;
        }

        public async Task<ArtefactDTO> Create(ArtefactCreateDTO dto)
        {
            
            var artefact =  _mapper.Map<Artefact>(dto);
            artefact.CreationDate = DateTime.Now;
            _Context.Artefacts.Add(artefact);
            var res =  _Context.SaveChanges() > 0;

            if (!res)
                return null;

            var artefactDTO = _mapper.Map<ArtefactDTO>(artefact);

            return artefactDTO;
        }

        public async Task<ArtefactDTO> Update(ArtefactUpdateDTO dto)
        {
            var artefact = await _Context.Artefacts.FirstOrDefaultAsync(a => a.ArtefactId == dto.ArtefactId);
            _mapper.Map(dto, artefact);
            artefact.UpdateDate = DateTime.Now;

            var res = _Context.SaveChanges() > 0;

            if (!res)
                return null;
            var artefactDTO = _mapper.Map<ArtefactDTO>(artefact);

            return artefactDTO;
        }

        public async Task<bool> Delete(Guid id)
        {
            var document = await _Context.Artefacts.FirstOrDefaultAsync(w => w.ArtefactId == id);
            _Context.Artefacts.Remove(document);
            return _Context.SaveChanges() > 0;
        }
    }
}
