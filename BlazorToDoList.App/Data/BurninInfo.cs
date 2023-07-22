using MyProject;

using System;

namespace BlazorToDoList.App.Data
{
    public class BurninInfo
    {
        public DateTime startdate { get; set; }
        public string serial { get; set; }
        public int NumberOfSamples { get; set; }
        public LaserLogMsg4s laserLogMsg4S { get; set; }
            
    }
}
