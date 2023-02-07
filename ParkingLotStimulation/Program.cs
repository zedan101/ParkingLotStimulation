using System.Net.Sockets;

namespace ParkingLotStimulation
{
    public class Program
    {
        enum Menu
        {
            exit, occupancyStats , bookSlot , unBookSlot
        }
        static void Main(string[] args)
        {
            ParkingLot parking = new ParkingLot();
            Console.WriteLine("Parking Lot Stimulation");
            Boolean exit = false;
            do
            {
                Console.WriteLine("To Check Occupancy Status Enter 1");
                Console.WriteLine("To Issue ticket Enter 2");
                Console.WriteLine("To Empty A slot Enter 3");
                Console.WriteLine("To exit Enter 0");
                int userAction = Convert.ToInt32(Console.ReadLine());
                switch (userAction)
                {
                    case (int)Menu.exit:
                        exit = true;
                        break;

                    case (int)Menu.occupancyStats:
                        parking.Occupancystats();
                        break;

                    case (int)Menu.bookSlot:
                        Console.WriteLine("Enter Vehicle type \n twoWheeler->0 \n fourWheeler->1 \n heavyVehicle->2");
                        int vchType = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Slot Number");
                        string slotNumber = Console.ReadLine()!;
                        if (parking.ValidateSlotNumber(slotNumber, vchType))
                        {
                            Console.WriteLine("Enter Vehicle Number");
                            string vehicleNum = Console.ReadLine()!;
                            if (vchType == 0)
                            {
                                parking.BookSlot(slotNumber, vehicleNum, "twowhl");
                            }
                            else if (vchType == 1)
                            {
                                parking.BookSlot(slotNumber, vehicleNum, "fourwhl");
                            }
                            else if (vchType == 2)
                            {
                                parking.BookSlot(slotNumber, vehicleNum, "heavyvch");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid slotNumber");
                        }
                        break;

                    case (int)Menu.unBookSlot:
                        Console.WriteLine("Enter Vehicle type \n twoWheeler->0 \n fourWheeler->1 \n heavyVehicle->2");
                        vchType = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Slot Number");
                        string slotNumToRemove = Console.ReadLine()!;
                        if (parking.ValidateSlotNumber(slotNumToRemove, vchType))
                        {
                            if (vchType == 0)
                            {
                                parking.UnBookSlot(slotNumToRemove, "twowhl");
                            }
                            else if (vchType == 1)
                            {
                                parking.UnBookSlot(slotNumToRemove, "fourwhl");
                            }
                            else if (vchType == 2)
                            {
                                parking.UnBookSlot(slotNumToRemove, "heavyvch");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid slotNumber");
                        }
                        break;
                }
            } while (!exit);
            Console.ReadLine();
        }
    }
}