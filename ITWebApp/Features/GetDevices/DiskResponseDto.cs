using System;

namespace ITWebApp.Features.GetDevices
{
    public class DiskResponseDto
    {

        public Guid DiskId { get; set; }

        public Guid DeviceId { get; set; }
        public Guid ClientId { get; set; }
        public string DiskName { get; set; }
        public double DiskTotalSize { get; set; }
        public double DiskUsedSpace { get; set; }
        public double DiskFreeSpace { get; set; }
        public bool IsSSD { get; set; }
        public int DiskAge { get; set; }
        public DateTime LoggedDateTime { get; set; }

        public Guid FKDeviceEntryId { get; set; }

    }
}
