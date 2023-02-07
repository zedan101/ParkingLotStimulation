namespace ParkingLotStimulation
{
    internal class ParkingLot
    {
        enum VehicleType
        {
            twowhl, fourwhl, heavyvch
        }

        List<Slot> tickets= new List<Slot>();

        public Slot[] twoWheelerSlots = new Slot[200];
        public Slot[] fourWheelerSlots = new Slot[200];
        public Slot[] heavyVehicleSlots = new Slot[200];

        public ParkingLot()
        {
            InitializeSlots();
        }

        public void InitializeSlots()
        {
            int index = 0;
            for (int i=0; i<200; i++)
            {
                this.twoWheelerSlots[i] = new Slot(VehicleType.twowhl.ToString(),false,index);
                index++;
            }

            index=0;
            for (int i = 0; i < 200; i++)
            {
                this.fourWheelerSlots[i] = new Slot(VehicleType.fourwhl.ToString(), false, index);
                index++;
            }

            index = 0;
            for (int i = 0; i < 200; i++)
            {
                this.heavyVehicleSlots[i] = new Slot(VehicleType.heavyvch.ToString(), false, index);
                index++;
            }
        }

        public void Occupancystats()
        {
            int twoWheelerOccupancyCount = 0;
            int fourWheelerOccupancyCount = 0;
            int heavyVehicleOccupancyCount = 0;
            foreach (Slot slot in twoWheelerSlots)
            {
                if (slot.IsBooked == true)
                {
                    twoWheelerOccupancyCount++;
                    break;
                }
            }
            foreach (Slot slot in fourWheelerSlots)
            {
                if (slot.IsBooked == true)
                {
                    fourWheelerOccupancyCount++;
                    break;
                }
            }
            foreach (Slot slot in heavyVehicleSlots)
            {
                if (slot.IsBooked == true)
                {
                    heavyVehicleOccupancyCount++;
                    break;
                }
            }
            Console.WriteLine("Occupied Two Wheeler parking is " + twoWheelerOccupancyCount + " out of 200");
            Console.WriteLine("Occupied Four Wheeler parking is " + fourWheelerOccupancyCount + " out of 200");
            Console.WriteLine("Occupied Heavy Vehicle parking is " + heavyVehicleOccupancyCount + " out of 200");
        }

        public void BookSlot(string sltNum, string vchNum, string lotType)
        {
            if (lotType == VehicleType.twowhl.ToString()) 
            {
                foreach (Slot slot in twoWheelerSlots)
                {
                    if (slot.SlotNumber == sltNum)
                    {
                        if (slot.IsBooked == false)
                        {
                            slot.VehicleNumber = vchNum;
                            slot.InTime = DateTime.Now.ToString("HH:mm:ss tt");
                            slot.IsBooked = true;
                            Console.WriteLine("Slot No. :-" + sltNum);
                            Console.WriteLine("Vehicle No. :-" + slot.VehicleNumber);
                            Console.WriteLine("In Time :-" + slot.InTime);
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
            else if(lotType == VehicleType.fourwhl.ToString()) 
            {
                foreach (Slot slot in fourWheelerSlots)
                {
                    if (slot.SlotNumber == sltNum)
                    {
                        if (slot.IsBooked == false)
                        {
                            slot.VehicleNumber = vchNum;
                            slot.InTime = DateTime.Now.ToString("HH:mm:ss tt");
                            slot.IsBooked = true;
                            Console.WriteLine("Slot No. :-" + sltNum);
                            Console.WriteLine("Vehicle No. :-" + slot.VehicleNumber);
                            Console.WriteLine("In Time :-" + slot.InTime);
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
            else if(lotType == VehicleType.heavyvch.ToString()) 
            {
                foreach (Slot slot in heavyVehicleSlots)
                {
                    if (slot.SlotNumber == sltNum)
                    {
                        if (slot.IsBooked == false)
                        {
                            slot.VehicleNumber = vchNum;
                            slot.InTime = DateTime.Now.ToString("HH:mm:ss tt");
                            slot.IsBooked = true;
                            Console.WriteLine("Slot No. :-" + sltNum);
                            Console.WriteLine("Vehicle No. :-" + slot.VehicleNumber);
                            Console.WriteLine("In Time :-" + slot.InTime);
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
     
            
        }

        public void UnBookSlot(string sltNum, string lotType)
        {
            if (lotType == VehicleType.twowhl.ToString())
            {
                foreach (Slot slot in twoWheelerSlots)
                {
                    if (slot.SlotNumber == sltNum && slot.IsBooked==true)
                    {
                        slot.IsBooked = false;
                        slot.OutTime = DateTime.Now.ToString();
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
            else if (lotType == VehicleType.fourwhl.ToString())
            {
                foreach (Slot slot in fourWheelerSlots)
                {
                    if (slot.SlotNumber == sltNum)
                    {
                        if (slot.IsBooked == true)
                        {
                            slot.IsBooked = false;
                            slot.OutTime = DateTime.Now.ToString();
                            Console.WriteLine("Out Time :-" + slot.OutTime);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Slot already occupied vacent");
                            break;
                        }
                    }
                }
            }
            else if (lotType==VehicleType.heavyvch.ToString())
            {
                foreach (Slot slot in heavyVehicleSlots)
                {
                    if (slot.SlotNumber == sltNum)
                    {
                        if (slot.IsBooked == true)
                        {
                            slot.IsBooked = false;
                            slot.OutTime = DateTime.Now.ToString();
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
        }
        public Boolean ValidateSlotNumber(string slotNum , int vehicleType)
        {
            if (!string.IsNullOrEmpty(slotNum))
            {
                if (vehicleType == (int)VehicleType.twowhl)
                {
                    Slot result = Array.Find(twoWheelerSlots,slot => slot.SlotNumber == slotNum);
                    if (string.IsNullOrEmpty(result.SlotNumber)) 
                    {
                        return false; 
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (vehicleType == (int)VehicleType.fourwhl)
                {
                    Slot result = Array.Find(fourWheelerSlots, slot => slot.SlotNumber == slotNum);
                    if (string.IsNullOrEmpty(result.SlotNumber))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (vehicleType == (int)VehicleType.heavyvch)
                {
                    Slot result = Array.Find(heavyVehicleSlots, slot => slot.SlotNumber == slotNum);
                    if (string.IsNullOrEmpty(result.SlotNumber))
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
    }
}
