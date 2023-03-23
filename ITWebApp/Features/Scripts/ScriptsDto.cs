using System;

namespace ITWebApp.Features.Scripts
{
    public class ScriptsDto
    {
        public Guid ScriptId { get; set; }
        public string MachineType { get; set; }
        public int PermissionLevel { get; set; }
        public string ScriptName { get; set; }
        public string Script { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime EditedDate { get; set; }
        public Guid EditedBy { get; set; }
        public int Active { get; set; }
    }
}
