using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotStimulation
{
    internal class Slot:Ticket
    {
        string _slotNumber;
        Boolean _isBooked;

        public Slot(string slotPrefix, Boolean isbooked, int index)
        {
            _slotNumber = slotPrefix + index;
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
