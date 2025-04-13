using orakle_api.Enums;
using System.ComponentModel.DataAnnotations;

namespace orakle_api.Entities
{
    public class Artefact
    {
        [Key]
        public Guid ArtefactId { get; set; }
        public string Title { get; set; }

        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
        public ArtefactType ArtefactType { get; set; }
        public bool? Public { get; set; } = true;

        [MaxLength]
        public string Text { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
