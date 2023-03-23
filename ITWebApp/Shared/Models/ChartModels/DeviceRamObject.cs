using System;

namespace ITWebApp.Shared.Models.ChartModels
{
    public class DeviceRamObject
    {
        //public DeviceRamObject(double freeRam, DateTime loggedDateTime)
        //{
        //    FreeRam = freeRam;
        //    LoggedDateTime = loggedDateTime;
        //}

        public double FreeRam { get; set; }
        public DateTime LoggedDateTime { get; set; }

    }
}
