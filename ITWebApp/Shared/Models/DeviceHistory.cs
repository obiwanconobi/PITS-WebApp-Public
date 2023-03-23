using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.Shared.Models
{
    public class DeviceHistory
    {
        public Guid MachineKey { get; set; }
        public Guid ClientId { get; set; }
        public bool ModalShow { get; set; } = false;
    }
}
