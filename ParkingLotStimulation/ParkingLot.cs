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
            InitializeSlots(twoWheelerSlots,VehicleType.twowhl);
            InitializeSlots(fourWheelerSlots,VehicleType.fourwhl);
            InitializeSlots(heavyVehicleSlots,VehicleType.heavyvch);
        }

        public void InitializeSlots(Slot[] parkings,VehicleType vchTyp)
        {
            int index = 0;
            for (int i = 0; i < 200; i++)
            {
                parkings[i] = new Slot(vchTyp.ToString(), false, index);
                index++;
            }
        }

        public void Occupancystats()
        {
            Console.WriteLine("Occupied Two Wheeler parking is " + twoWheelerSlots.Count(e => e.IsBooked == true) + " out of 200");
            Console.WriteLine("Occupied Four Wheeler parking is " + fourWheelerSlots.Count(e => e.IsBooked == true) + " out of 200");
            Console.WriteLine("Occupied Heavy Vehicle parking is " + heavyVehicleSlots.Count(e => e.IsBooked == true) + " out of 200");
        }

        void Booking(string sltNum, string vchNum, VehicleType lotType, Slot[] parkingLot)
        {
            foreach (Slot slot in parkingLot)
            {
                if (slot.SlotNumber == sltNum)
                {
                    if (slot.IsBooked == false)
                    {
                        slot.VehicleNumber = vchNum;
                        slot.InTime = DateTime.Now;
                        slot.IsBooked = true;
                        slot.TicketNumber = tickets.Count + 1;
                        slot.vchType = lotType.ToString();
                        Console.WriteLine("Slot successfully booked :-" + sltNum);
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
               Booking(sltNum, vchNum, lotType , twoWheelerSlots);
            } 
            else if(lotType == VehicleType.fourwhl) 
            {
                Booking(sltNum, vchNum, lotType, fourWheelerSlots);
            }
            else if(lotType == VehicleType.heavyvch) 
            {
                Booking(sltNum, vchNum, lotType, heavyVehicleSlots);
            }
     
            
        }

        void UnBooking(string sltNum, VehicleType lotType, int ticketNum, Slot[] parkingLot)
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
                                item.OutTime = DateTime.Now;
                            }
                        }
                        slot.OutTime = DateTime.Now;
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
                UnBooking(sltNum, lotType, ticketNum, twoWheelerSlots);
            }
            else if (lotType == VehicleType.fourwhl)
            {
                UnBooking(sltNum, lotType, ticketNum, twoWheelerSlots);
            }
            else if (lotType==VehicleType.heavyvch)
            {
                UnBooking(sltNum, lotType, ticketNum, twoWheelerSlots);
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

        public bool ValidateVehicleType(string vehicleType)
        {
            int vchType;
            if (int.TryParse(vehicleType, out vchType) && Enum.IsDefined(typeof(ParkingLot.VehicleType), vchType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateParkingSpace(int option)
        {
            if (option == 0)
            {
                if (twoWheelerSlots.Count(e => e.IsBooked == true) == 0 && fourWheelerSlots.Count(e => e.IsBooked == true) == 0 && heavyVehicleSlots.Count(e => e.IsBooked == true) == 0)
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
                if (twoWheelerSlots.Count(e => e.IsBooked == false) == 0 && fourWheelerSlots.Count(e => e.IsBooked == false) == 0 && heavyVehicleSlots.Count(e => e.IsBooked == false) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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
                    Console.WriteLine("Out Time :- " + item.OutTime + "\n");
                }
            }
            else
            {
                Console.WriteLine("no ticket has been initialized yet");
            }
        }

        public void DisplayTicketsByVehicleType()
        {
            var quarryToGroupByVchType = tickets.GroupBy(ticket => ticket.vchType);
            foreach(var typeGroup in quarryToGroupByVchType)
            {
                Console.WriteLine(typeGroup.Key + ":-");
                foreach(var tckt in typeGroup)
                {
                    Console.WriteLine("\t Ticket Number :- " + tckt.TicketNumber);
                    Console.WriteLine("\t Vehicle Number :- " + tckt.VehicleNumber);
                    Console.WriteLine("\t Vehicle Type :- " + tckt.vchType);
                    Console.WriteLine("\t Slot Number :- " + tckt.SlotNumber);
                    Console.WriteLine("\t In Time :- " + tckt.InTime);
                    Console.WriteLine("\t Out Time :- " + tckt.OutTime + "\n");
                }
            }
        }

        public void ExtraTimeParkedVehicle()
        {
            var currentTime=DateTime.Now;
            var quarryExtraTimeParkedHeavyVehicle = tickets.Where(ticket=>(currentTime - ticket.InTime).TotalMilliseconds >= 1);
            foreach (Slot tkt in quarryExtraTimeParkedHeavyVehicle)
            {
                Console.WriteLine("\t Ticket Number :- " + tkt.TicketNumber);
                Console.WriteLine("\t Vehicle Number :- " + tkt.VehicleNumber);
                Console.WriteLine("\t Slot Number :- " + tkt.SlotNumber);
                Console.WriteLine("\t In Time :- " + tkt.InTime + "\n");
                
            }
        }
        
    }
}
