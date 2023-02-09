using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotStimulation
{ 
    public class Ticket
    {
        int _ticketNumber;
        string _vehicleNumber;
        DateTime _inTime;
        DateTime _outTime;
        public string vchType;

        public int TicketNumber
        {
            get { return _ticketNumber; }
            set { _ticketNumber = value; }
        }
        public string VehicleNumber
        {
            get { return _vehicleNumber; }
            set { _vehicleNumber = value; }
        }
        public DateTime InTime
        {
            get { return _inTime; }
            set { _inTime = value; }
        }
        public DateTime OutTime
        {
            get { return _outTime; }
            set { _outTime = value; }
        }
    }
}
