using orakle_api.Entities;
using orakle_api.Enums;
using System.ComponentModel.DataAnnotations;

namespace orakle_api.Filters
{
    public class ArtefactFilter
    {
        public string? Title { get; set; }

        public Guid OwnerId { get; set; }
        public ArtefactType? ArtefactType { get; set; }
        public bool? Public { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
