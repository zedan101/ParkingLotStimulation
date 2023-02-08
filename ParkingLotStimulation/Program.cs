using System.ComponentModel;
using System.Net.Sockets;
using System.Security.AccessControl;

namespace ParkingLotStimulation
{
    public class Program
    {
        enum Menu
        {
            Exit, OccupancyStats , BookSlot , UnBookSlot , DisplayTickets , DisplayTicketsByVchType ,heavyVehicleTakingExtraTime
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
                Console.WriteLine("To View Tickets by Vehicle Type Enter 5");
                Console.WriteLine("To View Heavy Vehicle taking Extra Time Enter 6");
                Console.WriteLine("To exit Enter 0");
                string userInput = Console.ReadLine();
                int userAct;
                if (int.TryParse(userInput, out userAct))
                {
                    Menu userAction = (Menu)userAct;
                    switch (userAction)
                    {
                        case Menu.Exit:
                            exit = true;
                            break;

                        case Menu.OccupancyStats:
                            parking.Occupancystats();
                            break;

                        case Menu.BookSlot:
                            Console.WriteLine("Enter Vehicle type \n twoWheeler->0 \n fourWheeler->1 \n heavyVehicle->2");
                            string vehicleType = Console.ReadLine();
                            int vchType;
                            if (int.TryParse(vehicleType, out vchType))
                            {
                                if (Enum.IsDefined(typeof(ParkingLot.VehicleType), vchType))
                                {
                                    Console.WriteLine("Enter Slot Number");
                                    string slotNumber = Console.ReadLine()!;
                                    if (parking.ValidateSlotNumber(slotNumber, (ParkingLot.VehicleType)vchType))
                                    {
                                        Console.WriteLine("Enter Vehicle Number");
                                        string vehicleNum = Console.ReadLine()!;
                                        parking.BookSlot(slotNumber, vehicleNum, (ParkingLot.VehicleType)vchType);
                                        break;
                                    }
                                    else
                                    {
                                        Warning("Invalid slotNumber");
                                        break;
                                    }
                                }
                                else
                                {
                                    Warning("Invalid Input");
                                    break;
                                }
                            }
                            else
                            {
                                Warning("InValid Input");
                                break;
                            }

                        case Menu.UnBookSlot:
                            Console.WriteLine("Enter Vehicle type \n twoWheeler->0 \n fourWheeler->1 \n heavyVehicle->2");
                            userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out vchType))
                            {
                                if (Enum.IsDefined(typeof(ParkingLot.VehicleType), vchType))
                                {
                                    Console.WriteLine("Enter Slot Number");
                                    string slotNumToRemove = Console.ReadLine()!;
                                    if (parking.ValidateSlotNumber(slotNumToRemove, (ParkingLot.VehicleType)vchType))
                                    {
                                        Console.WriteLine("Enter Ticket Number");
                                        int ticketNum = Convert.ToInt32(Console.ReadLine());
                                        parking.UnBookSlot(slotNumToRemove, (ParkingLot.VehicleType)vchType, ticketNum);
                                        break;

                                    }
                                    else
                                    {
                                        Warning("Invalid slotNumber");
                                        break;
                                    }
                                }
                                else
                                {
                                    Warning("Invalid Input");
                                    break;
                                }
                            }
                            else
                            {
                                Warning("Invalid Input");
                                break;
                            }

                        case Menu.DisplayTickets:
                            parking.DisplayTickets();
                            break;

                        case Menu.DisplayTicketsByVchType:
                            parking.DisplayTicketsByVehicleType();
                            break;

                        case Menu.heavyVehicleTakingExtraTime:
                            parking.ExtraTimeParkedHeavyVehicle();
                            break;

                        default:
                            Warning("wrong menu option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            } while (!exit);
            void Warning(string msg)
            {
                Console.WriteLine(msg);
            }
            Console.ReadLine();
        }
    }
}
