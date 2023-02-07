using System.Net.Sockets;
using System.Security.AccessControl;

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
                string userInput = Console.ReadLine();
                int userAction;
                if (int.TryParse(userInput, out userAction))
                {
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
                            userInput = Console.ReadLine();
                            int vchType;
                            if (int.TryParse(userInput, out vchType))
                            {
                                if (vchType == 0 || vchType == 1 || vchType == 2)
                                {
                                    Console.WriteLine("Enter Slot Number");
                                    string slotNumber = Console.ReadLine()!;
                                    if (parking.ValidateSlotNumber(slotNumber, vchType))
                                    {
                                        Console.WriteLine("Enter Vehicle Number");
                                        string vehicleNum = Console.ReadLine()!;
                                        parking.BookSlot(slotNumber, vehicleNum, vchType);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid slotNumber");
                                        break;
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("InValid Input");
                                break;
                            }

                        case (int)Menu.unBookSlot:
                            Console.WriteLine("Enter Vehicle type \n twoWheeler->0 \n fourWheeler->1 \n heavyVehicle->2");
                            userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out vchType))
                            {
                                if (vchType == 0 || vchType == 1 || vchType == 2)
                                {
                                    Console.WriteLine("Enter Slot Number");
                                    string slotNumToRemove = Console.ReadLine()!;
                                    if (parking.ValidateSlotNumber(slotNumToRemove, vchType))
                                    {
                                        Console.WriteLine("Enter Ticket Number");
                                        int ticketNum = Convert.ToInt32(Console.ReadLine());
                                        parking.UnBookSlot(slotNumToRemove, vchType, ticketNum);
                                        break;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid slotNumber");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    break;
                                }
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
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            } while (!exit);
            Console.ReadLine();
        }
    }
}