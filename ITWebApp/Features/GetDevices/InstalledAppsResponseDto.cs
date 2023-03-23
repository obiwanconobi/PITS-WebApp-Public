using System;

namespace ITWebApp.Features.GetDevices
{
    public class InstalledAppsResponseDto
    {
        public Guid AppId { get; set; }
        public string AppName { get; set; }
        public string Publisher { get; set; }
        public DateTime InstalledDate { get; set; }
        public int SizeOnDisk { get; set; }
        public int Active { get; set; }
        public Guid FKDeviceEntryId { get; set; }
    }
}
