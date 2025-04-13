using AutoMapper;
using Microsoft.EntityFrameworkCore;
using orakle_api.Data;
using orakle_api.DTOs;
using orakle_api.Entities;
using orakle_api.Enums;

namespace orakle_api.services
{
    public class OwnerService
    {
        private DataContext _Context { get; set; }
        private readonly IMapper _mapper;

        public OwnerService(DataContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<OwnerDTO>> GetAll()
        {
            var owners = await _Context.Owners
                .Include(ow => ow.Artefacts.Where(a => a.ArtefactType == ArtefactType.PROFILE))
                .ToListAsync();

            var ownersDTO = _mapper.Map<IEnumerable<OwnerDTO>>(owners);

            ownersDTO = owners.Select(owner =>
            {
                var ownerDTO = _mapper.Map<OwnerDTO>(owner);

                if (owner.Artefacts.Count() > 0) ownerDTO.Profile = owner.Artefacts.First();

                return ownerDTO;
            });

            return ownersDTO;
        }

        public async Task<OwnerDTO> FindById(Guid id)
        {
            var owner = await _Context.Owners
                .Include(ow => ow.Artefacts.Where(a => a.ArtefactType == ArtefactType.PROFILE))
                .FirstOrDefaultAsync(owner => owner.Id == id);

            if (owner is null)
                return null;

            var ownerDTO = _mapper.Map<OwnerDTO>(owner);

            if(owner.Artefacts.Count() > 0) ownerDTO.Profile = owner.Artefacts.First();

            return ownerDTO;

        }

        public async Task<bool> Create(Owner owner)
        {
            _Context.Owners.Add(owner);
            return _Context.SaveChanges() > 0;
        }

        public async Task<bool> Update(Owner owner)
        {
            _Context.Owners.Update(owner);
            return _Context.SaveChanges() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var owner = await _Context.Owners.FirstOrDefaultAsync(w => w.Id == id);
            _Context.Owners.Remove(owner);
            return _Context.SaveChanges() > 0;
        }
    }
}
