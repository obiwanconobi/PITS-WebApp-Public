using System;

namespace ITWebApp.Features.Scripts
{
    public class UpdateScriptToRunDto
    {
        public Guid ScriptToRunGuid { get; set; }
        public Guid MachineGuid { get; set; }
        public Guid ScriptId { get; set; }
        public DateTime TimeToRun { get; set; }
        public Guid RunBy { get; set; }
        public int ScriptRun { get; set; }
    }
}
