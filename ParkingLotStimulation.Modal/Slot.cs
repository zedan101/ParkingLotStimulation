using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotStimulation
{
    public class Slot 
    {
        string _slotNumber;
        Boolean _isBooked;
        public string _slotType;
        public Slot(string slotType, Boolean isbooked, int index)
        {
            _slotType = slotType;
            _slotNumber = slotType + index;
            _isBooked = isbooked;
        }

        public string SlotNumber
        {
            get { return _slotNumber; }
            set { _slotNumber = value; }
        }
        public Boolean IsBooked
        {
            get { return _isBooked; }
            set { _isBooked = value; }
        }
    }
}