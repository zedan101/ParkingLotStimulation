using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotStimulation
{
    internal class Ticket
    {
        string _vehicleNumber;
        string _inTime;
        string _outTime;

        public string VehicleNumber 
        {
            get { return _vehicleNumber; }  
            set { _vehicleNumber = value; }
        }

        public string InTime
        {
            get { return _inTime; }
            set { _inTime = value; }
        }

        public string OutTime
        {
            get { return _outTime; }
            set { _outTime = value; }
        }
    }
}
