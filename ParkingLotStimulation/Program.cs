using System.Net.Sockets;

namespace ParkingLotStimulation
{
    public class Program
    {
        enum Menu
        {
            exit, occupancyStats , bookSlot , unBookSlot , displayTickets
        }
        static void Main(string[] args)
        {
            ParkingLot parking = new ParkingLot();
            Console.WriteLine("Parking Lot Stimulation");
            Boolean exit = false;
            do
            {
                Console.WriteLine("\n \n =======++++======== \n \n");
                Console.WriteLine("To Check Occupancy Status Enter 1");
                Console.WriteLine("To Issue ticket Enter 2");
                Console.WriteLine("To Empty A slot Enter 3");
                Console.WriteLine("To View All Tickets Enter 4");
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
                        if(vchType == 0 || vchType==1 || vchType==2)
                        {
                            Console.WriteLine("Enter Slot Number");
                            string slotNumber = Console.ReadLine()!;
                            if (parking.ValidateSlotNumber(slotNumber, vchType))
                            {
                                Console.WriteLine("Enter Vehicle Number");
                                string vehicleNum = Console.ReadLine()!;
                                parking.BookSlot(slotNumber, vehicleNum, vchType);
                            }
                            else
                            {
                                Console.WriteLine("Invalid slotNumber");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }

                    case (int)Menu.unBookSlot:
                        Console.WriteLine("Enter Vehicle type \n twoWheeler->0 \n fourWheeler->1 \n heavyVehicle->2");
                        vchType = Convert.ToInt32(Console.ReadLine());
                        if (vchType == 0 || vchType == 1 || vchType == 2)
                        {
                            Console.WriteLine("Enter Slot Number");
                            string slotNumToRemove = Console.ReadLine()!;
                            Console.WriteLine("Enter Ticket Number");
                            int ticketNum = Convert.ToInt32(Console.ReadLine());
                            if (parking.ValidateSlotNumber(slotNumToRemove, vchType))
                            {
                                parking.UnBookSlot(slotNumToRemove, vchType, ticketNum);

                            }
                            else
                            {
                                Console.WriteLine("Invalid slotNumber");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }

                    case (int)Menu.displayTickets:
                        parking.DisplayTickets();
                        break;

                    default:
                        Console.WriteLine("wrong menu option");
                        break;
                }
            } while (!exit);
            Console.ReadLine();
        }
    }
}