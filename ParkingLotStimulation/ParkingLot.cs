namespace ParkingLotStimulation
{
    internal class ParkingLot
    {
        public enum VehicleType
        {
            twowhl, fourwhl, heavyvch
        }
        List<Slot> tickets = new List<Slot>();
        public Slot[] twoWheelerSlots = new Slot[200];
        public Slot[] fourWheelerSlots = new Slot[200];
        public Slot[] heavyVehicleSlots = new Slot[200];

        public ParkingLot()
        {
            InitializeSlots(twoWheelerSlots);
            InitializeSlots(fourWheelerSlots);
            InitializeSlots(heavyVehicleSlots);
        }

        public void InitializeSlots(Slot[] parkings)
        {
            int index = 0;
            for (int i = 0; i < 200; i++)
            {
                parkings[i] = new Slot(VehicleType.twowhl.ToString(), false, index);
                index++;
            }
        }

        int OccupancyStatsFunction(Slot[] parking)
        {
            int occupancyCount=0;
            foreach (Slot slot in parking)
            {
                if (slot.IsBooked == true)
                {
                    occupancyCount++;
                    break;
                }
            }
            return occupancyCount;
        }

        public void Occupancystats()
        {
            Console.WriteLine("Occupied Two Wheeler parking is " + OccupancyStatsFunction(twoWheelerSlots) + " out of 200");
            Console.WriteLine("Occupied Four Wheeler parking is " + OccupancyStatsFunction(fourWheelerSlots) + " out of 200");
            Console.WriteLine("Occupied Heavy Vehicle parking is " + OccupancyStatsFunction(heavyVehicleSlots) + " out of 200");
        }

        void BookingFunction(string sltNum, string vchNum, VehicleType lotType, Slot[] parkingLot)
        {
            foreach (Slot slot in parkingLot)
            {
                if (slot.SlotNumber == sltNum)
                {
                    if (slot.IsBooked == false)
                    {
                        slot.VehicleNumber = vchNum;
                        slot.InTime = DateTime.Now.ToString("HH:mm:ss tt");
                        slot.IsBooked = true;
                        slot.TicketNumber = tickets.Count + 1;
                        Console.WriteLine("Slot No. :-" + sltNum);
                        Console.WriteLine("Vehicle No. :-" + slot.VehicleNumber);
                        Console.WriteLine("In Time :-" + slot.InTime);
                        tickets.Add(slot);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Slot already occupied");
                        break;
                    }
                }
            }
        }

        public void BookSlot(string sltNum, string vchNum, VehicleType lotType)
        {
            if (lotType == VehicleType.twowhl) 
            {
               BookingFunction(sltNum, vchNum, lotType , twoWheelerSlots);
            } 
            else if(lotType == VehicleType.fourwhl) 
            {
                BookingFunction(sltNum, vchNum, lotType, fourWheelerSlots);
            }
            else if(lotType == VehicleType.heavyvch) 
            {
                BookingFunction(sltNum, vchNum, lotType, heavyVehicleSlots);
            }
     
            
        }

        void UnBookingFunction(string sltNum, VehicleType lotType, int ticketNum, Slot[] parkingLot)
        {
            foreach (Slot slot in parkingLot)
            {
                if (slot.SlotNumber == sltNum)
                {
                    if (slot.IsBooked == true)
                    {
                        slot.IsBooked = false;
                        foreach (Slot item in tickets)
                        {
                            if (item.TicketNumber == ticketNum)
                            {
                                item.OutTime = DateTime.Now.ToString("HH:mm:ss tt");
                            }
                        }
                        slot.OutTime = DateTime.Now.ToString("HH:mm:ss tt");
                        Console.WriteLine("Out Time :-" + slot.OutTime);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Slot already vacent");
                        break;
                    }
                }
            }
        }
        public void UnBookSlot(string sltNum, VehicleType lotType , int ticketNum)
        {
            if (lotType == VehicleType.twowhl)
            {
                UnBookingFunction(sltNum, lotType, ticketNum, twoWheelerSlots);
            }
            else if (lotType == VehicleType.fourwhl)
            {
                UnBookingFunction(sltNum, lotType, ticketNum, twoWheelerSlots);
            }
            else if (lotType==VehicleType.heavyvch)
            {
                UnBookingFunction(sltNum, lotType, ticketNum, twoWheelerSlots);
            }
        }

        public bool ValidateSlotNumber(string slotNum , VehicleType vehicleType)
        {
            if (!string.IsNullOrEmpty(slotNum))
            {
                if (vehicleType == VehicleType.twowhl)
                {
                    Slot foundSlot = Array.Find(twoWheelerSlots,slot => slot.SlotNumber == slotNum);
                    if (foundSlot==null) 
                    {
                        return false; 
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (vehicleType == VehicleType.fourwhl)
                {
                    Slot foundSlot = Array.Find(fourWheelerSlots, slot => slot.SlotNumber == slotNum);
                    if (foundSlot == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (vehicleType == VehicleType.heavyvch)
                {
                    Slot foundSlot = Array.Find(heavyVehicleSlots, slot => slot.SlotNumber == slotNum);
                    if (foundSlot == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void DisplayTickets()
        {
            if (tickets.Any())
            {
                foreach (Slot item in tickets)
                {
                    Console.WriteLine("Ticket Number :- " + item.TicketNumber);
                    Console.WriteLine("Vehicle Number :- " + item.VehicleNumber);
                    Console.WriteLine("Slot Number :- " + item.SlotNumber);
                    Console.WriteLine("In Time :- " + item.InTime);
                    Console.WriteLine("Out Time :- " + item.OutTime);
                }
            }
            else
            {
                Console.WriteLine("no ticket has been initialized yet");
            }
        }
    }
}
