using orakle_api.Entities;
using orakle_api.Enums;
using System.ComponentModel.DataAnnotations;

namespace orakle_api.DTOs
{
    public class ArtefactDTO
    {
        public Guid ArtefactId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
        public ArtefactType ArtefactType { get; set; }
        public bool? Public { get; set; } = true;
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class ArtefactSummaryDTO
    {
        public Guid ArtefactId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class ArtefactCreateDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid OwnerId { get; set; }
        public ArtefactType ArtefactType { get; set; }
        public bool? Public { get; set; } = true;
    } 
    public class ArtefactUpdateDTO
    {
        public Guid ArtefactId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid OwnerId { get; set; }
        public ArtefactType ArtefactType { get; set; }
        public bool? Public { get; set; } = true;

    }
}
