using Microsoft.AspNetCore.Identity;
using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace orakle_api.Entities
{
    public class Owner : IdentityUser<Guid>
    {
        public string ProfileName { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Artefact>? Artefacts { get; set; } 
    }
}
