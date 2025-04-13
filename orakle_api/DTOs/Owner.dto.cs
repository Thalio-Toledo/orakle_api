using orakle_api.Entities;
using System.ComponentModel.DataAnnotations;

namespace orakle_api.DTOs
{
    public class OwnerDTO
    {
        public Guid Id { get; set; }
        public string ProfileName { get; set; }
        public string Description { get; set; }
        public Artefact? Profile { get; set; }
    }
}
