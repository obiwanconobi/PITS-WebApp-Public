using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetDevices
{
    public class GetDevicesResponseDto
    {
        public Guid MachineGuid { get; set; }
        public Guid UserID { get; set; }
        public Guid ClientID { get; set; }
        public string MachineType { get; set; }
        public string Hostname { get; set; }
        public string Domain { get; set; }
        public string Username { get; set; }
        public string CPUVendor { get; set; }
        public int CPUCores { get; set; }
        public decimal CPUCurrentSpeed { get; set; }
        public decimal CPUCurrentLoad { get; set; }
        public string CPUModel { get; set; }
        public double CPUTemp { get; set; }
        public double FreeRam { get; set; }
        public double TotalRam { get; set; }
        public string RamVendor { get; set; }
        public int RamSpeed { get; set; }
        public DateTime LoggedDateTime { get; set; }
        public DateTime BoardedDateTime { get; set; }
        public DateTime DeviceCreateDateTime { get; set; }
        public int Active { get; set; }
      
        public List<DiskResponseDto> DiskInformation { get; set; }
       // public List<InstalledAppsResponseDto> InstalledApps { get; set; }

    }

  
}
