namespace ParkingLotStimulation
{
    internal class ParkingLot
    {
        public enum VehicleType
        {
            twowhl, fourwhl, heavyvch
        }

        List<Ticket> tickets = new List<Ticket>();
        public Slot[] parkingSlots = new Slot[600];

        public ParkingLot()
        {
            InitializeSlots(0 , 200 , VehicleType.twowhl);
            InitializeSlots(200 , 400 ,VehicleType.fourwhl);
            InitializeSlots(400 , 600 ,VehicleType.heavyvch);
        }

        public void InitializeSlots(int startIndex , int endIndex ,VehicleType vchTyp)
        {
            int index = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                parkingSlots[i] = new Slot(vchTyp.ToString(), false, index);
                index++;
            }
        }

        public void OccupancyStats()
        {
            Console.WriteLine("Occupied Two Wheeler parking is " + parkingSlots.Count(e => e.IsBooked == true && e._slotType == "twowhl") + " out of 200");
            Console.WriteLine("Occupied Two Wheeler parking is " + parkingSlots.Count(e => e.IsBooked == true && e._slotType == "fourwhl") + " out of 200");
            Console.WriteLine("Occupied Two Wheeler parking is " + parkingSlots.Count(e => e.IsBooked == true && e._slotType == "heavyvch") + " out of 200");
        }

        public void BookSlot(string sltNum, string vchNum, VehicleType lotType)
        {
            foreach (Slot slot in parkingSlots)
            {
                if (slot.SlotNumber == sltNum)
                {
                    if (slot.IsBooked == false)
                    {
                        Ticket tickt = new Ticket();
                        tickt.VehicleNumber = vchNum;
                        tickt.InTime = DateTime.Now;
                        slot.IsBooked = true;
                        tickt.TicketNumber = tickets.Count() + 1;
                        tickt.vchType = lotType.ToString();
                        Console.WriteLine("Slot successfully booked :-" + sltNum);
                        tickets.Add(tickt);
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

        public void UnBookSlot(string sltNum, VehicleType lotType , int ticketNum)
        {
            foreach (Slot slot in parkingSlots)
            {
                if (slot.SlotNumber == sltNum)
                {
                    if (slot.IsBooked == true)
                    {
                        slot.IsBooked = false;
                        foreach (Ticket item in tickets)
                        {
                            if (item.TicketNumber == ticketNum)
                            {
                                item.OutTime = DateTime.Now;
                            }
                        }
                        Console.WriteLine("Slot Unbooked Successfully");
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

            public bool ValidateSlotNumber(string slotNum)
            {
                if (!string.IsNullOrEmpty(slotNum))
                {
                    Slot foundSlot = Array.Find(parkingSlots,slot => slot.SlotNumber == slotNum);
                    if (foundSlot==null) 
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
                if (parkingSlots.Count(e => e.IsBooked == true) == 0)
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
                if (parkingSlots.Count(e => e.IsBooked == false) == 0)
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
                foreach (Ticket item in tickets)
                {
                    Console.WriteLine("Ticket Number :- " + item.TicketNumber);
                    Console.WriteLine("Vehicle Number :- " + item.VehicleNumber);
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
                foreach(Ticket tckt in typeGroup)
                {
                    Console.WriteLine("\t Ticket Number :- " + tckt.TicketNumber);
                    Console.WriteLine("\t Vehicle Number :- " + tckt.VehicleNumber);
                    Console.WriteLine("\t Vehicle Type :- " + tckt.vchType);
                    Console.WriteLine("\t In Time :- " + tckt.InTime);
                    Console.WriteLine("\t Out Time :- " + tckt.OutTime + "\n");
                }
            }
        }

        public void ExtraTimeParkedVehicle()
        {
            var currentTime=DateTime.Now;
            var quarryExtraTimeParkedHeavyVehicle = tickets.Where(ticket=>((currentTime - ticket.InTime).Minutes > 1 && ticket.OutTime == new DateTime(0))
                                                                 || (ticket.OutTime != new DateTime(0) && (ticket.OutTime-ticket.InTime).TotalMinutes>1));
            foreach (Ticket tkt in quarryExtraTimeParkedHeavyVehicle)
            {
                Console.WriteLine("\t Ticket Number :- " + tkt.TicketNumber);
                Console.WriteLine("\t Vehicle Number :- " + tkt.VehicleNumber);
                Console.WriteLine("\t In Time :- " + tkt.InTime + "\n");
                
            }
        }
        
    }
}
