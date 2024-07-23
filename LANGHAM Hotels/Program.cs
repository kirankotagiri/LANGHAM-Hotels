using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LanghamHotelManagementMenu
{
    internal class Program
    {
        static string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static void AddRooms()
        {
            //Accepting Room information from employee

            Console.WriteLine("Please Enter Room Number: ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Select Room Type, Single,Double,Delux: ");
            String roomType = Console.ReadLine();
            Console.WriteLine("Please Enter Employee Id: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Name: ");
            string employeeName = Console.ReadLine();

            using (StreamWriter LANGHAMHOTEL = new StreamWriter(myDocuments + "\\KiranK\\AddRooms.txt", true))
            {
                LANGHAMHOTEL.WriteLine("\n Information added to the system at: " + DateTime.Now);
                LANGHAMHOTEL.WriteLine("\n Room Number: " + roomNumber + "\n Room Type: " + roomType);
                LANGHAMHOTEL.WriteLine("\n Employee Id: " + employeeId + "\n Employee Name: " + employeeName);
                LANGHAMHOTEL.WriteLine("**************************************************");
            }

        }
        static void DisplayRooms()
        {
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(myDocuments + "\\KiranK\\AddRooms.txt");
                string allfileText = File.ReadAllText(myDocuments + "\\KiranK\\AddRooms.txt");
                Console.WriteLine(allfileText);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("An error occured\n" + ex.Message);
                Console.WriteLine("The file name 'AddRooms.txt' was not found");
            }
        }

        static void AllocateRooms()
        {
            //Accepting Room information from employee


            Console.WriteLine("Please Enter Room Number: ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Full Name: ");
            String customerName = Console.ReadLine();
            Console.WriteLine("Customer Phone Number: ");
            int customerphoneNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Check In Date (dd/mm/yyyy): ");
            string checkinDate = Console.ReadLine();
            Console.WriteLine("Check Out Date (dd/mm/yyyy): ");
            string checkoutDate = Console.ReadLine();
            Console.WriteLine("Please Enter Employee Name: ");
            string employeeName = Console.ReadLine();

            using (StreamWriter LANGHAMHOTEL = new StreamWriter(myDocuments + "\\KiranK\\Room_Allocation_DeAllocation.txt", true))
            {
                LANGHAMHOTEL.WriteLine("\n Information added to the system at: " + DateTime.Now);
                LANGHAMHOTEL.WriteLine("\n Room Number: " + roomNumber + "\n Room Type: " + customerName);
                LANGHAMHOTEL.WriteLine("\n Check In Date: " + checkinDate + "\n Check Out Date: " + checkoutDate);
                LANGHAMHOTEL.WriteLine("\n Phone Number: " + customerphoneNo + "\n Employee Name: " + employeeName);
                LANGHAMHOTEL.WriteLine("**************************************************");
            }
        }
        static void DeAllocateRooms()
        {
            //Accepting Room information from employee

            Console.WriteLine("Enter Deallocating Room Number: ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Name: ");
            String customerName = Console.ReadLine();
            Console.WriteLine("Customer Phone Number: ");
            int customerphoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Employee Name: ");
            string employeeName = Console.ReadLine();

            using (StreamWriter LANGHAMHOTEL = new StreamWriter(myDocuments + "\\KiranK\\Room_Allocation_DeAllocation.txt", true))
            {
                LANGHAMHOTEL.WriteLine("\n Information added to the system at: " + DateTime.Now);
                LANGHAMHOTEL.WriteLine("\n Room Number: " + roomNumber + "\n Room Type: " + customerName);
                LANGHAMHOTEL.WriteLine("\n Employee Id: " + customerphoneNumber + "\n Employee Name: " + employeeName);
                LANGHAMHOTEL.WriteLine("**************************************************");
            }
        }
        static void DisplayRoomAllocationDetails()
        {
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(myDocuments + "\\KiranK\\Room_Allocation_DeAllocation.txt");
                string allfileText = File.ReadAllText(myDocuments + "\\KiranK\\Room_Allocation_DeAllocation.txt");
                Console.WriteLine(allfileText);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("An error occured\n" + ex.Message);
                Console.WriteLine("The file name 'AddRooms.txt' was not found");
            }
        }
        static void Billing()
        {
            Console.WriteLine("Billing Feature is Under Construction and will be added soon…!!!");
        }
        static void SavetheRoomAllocationToaFile()
        {
            // Backing up data from 2 different files onto a new file
            string source1 = File.ReadAllText(myDocuments + "\\KiranK\\AddRooms.txt");
            string source2 = File.ReadAllText(myDocuments + "\\KiranK\\Room_Allocation_DeAllocation.txt");
            string doc = myDocuments + "lhms_764707530.txt";


            if (File.Exists(myDocuments + "\\KiranK\\lhms_764707530.txt"))
            {
                Console.WriteLine("File Created");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("File Not Created");
                Console.ReadLine();
            }


            using (StreamWriter newFile = new StreamWriter(doc))
            {
                newFile.WriteLine("info from file 1");
                newFile.WriteLine(source1);
                newFile.WriteLine("info from file 2");
                newFile.WriteLine(source2);
            }
            // copying from LHMS to backup file
            string docBack = myDocuments + "\\KiranK\\lhms_764707530_backup.txt";
            File.Copy(doc, docBack);

            string docBack2 = myDocuments + "\\KiranK\\lhms_764707530_backup2.txt";
            File.Copy(doc, docBack2);
            //Cleaning the temp backup file

            using (FileStream fs = new FileStream(doc, FileMode.Open))
            {
                fs.SetLength(0);
            }
            Console.WriteLine("Backup Created and original file has been reset!");
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
        }
        static void SavetheRoomAllocationFromaFile()
        {
            try
            {
                StreamWriter writer = new StreamWriter(myDocuments + "\\KiranK\\lhms_764707530_backup.txt");
                writer.WriteLine("This is a restricted content only for Admin Access");
                writer.Close();

                string allfileText = File.ReadAllText(myDocuments + "\\KiranK\\lhms_764707530_backup.txt");
                Console.WriteLine(allfileText);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: You don't have permission to access this file");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Go back to main Menu. Do not try to Access the data");
                Console.ReadLine();
            }

        }
      
        static void ToDisplayBackupfile()
        {
            string allfileText = File.ReadAllText(myDocuments + "\\KiranK\\lhms_764707530_backup2.txt");
            Console.WriteLine(allfileText);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        static void Exit()
        {
            Console.WriteLine("Thank You For the Visit. Press Enter To Exit");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            // Declare variables for user options
            char ans;
            ans = 'y';

            do
            {

                Console.Clear();
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("                 LANGHAM HOTEL MANAGEMENT SYSTEM                  ");
                Console.WriteLine("                            MENU                                 ");
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("1. Add Rooms");
                Console.WriteLine("2. Display Rooms");
                Console.WriteLine("3. Allocate Rooms");
                Console.WriteLine("4. De-Allocate Rooms");
                Console.WriteLine("5. Display Room Allocation Details");
                Console.WriteLine("6. Billing");
                Console.WriteLine("7. Save the Room Allocations To a File");
                Console.WriteLine("8. Show the Room Allocations From a File");
                Console.WriteLine("9. To Display Backup file");
                Console.WriteLine("0. Exit");
                Console.WriteLine("***********************************************************************************");
                Console.Write("Enter Your choice Number Here:");
                string inputChoice = Console.ReadLine();

                int choice;
                try
                {
                    // Attempt tp parse the user input to an integer
                    choice = int.Parse(inputChoice);


                }
                catch (FormatException)
                {
                    // Handle the format exception if the input is not a valid number
                    Console.WriteLine("Unhadled Exception: System.FormateException: Input string was not in a correct formate. \nPlease enter numerice numbers from 1 to 9", inputChoice);
                    Console.ReadLine();
                    continue;

                }

                try {


                    //get user choice and call a method which prints user choosen choice
                    switch (choice)
                    {
                        case 1:
                            // adding Rooms function
                            AddRooms();
                            break;
                        case 2:
                            // display Rooms function;
                            DisplayRooms();
                            break;
                        case 3:
                            // allocate Room To Customer function
                            AllocateRooms();
                            break;
                        case 4:
                            // De-Allocate Room From Customer function
                            DeAllocateRooms();
                            break;
                        case 5:
                            // display Room Alocations function;
                            DisplayRoomAllocationDetails();
                            break;
                        case 6:
                            //  Display "Billing Feature is Under Construction and will be added soon…!!!"
                            Billing();
                            break;
                        case 7:
                            // SaveRoomAllocationsToFile
                            SavetheRoomAllocationToaFile();
                            break;
                        case 8:
                            //Show Room Allocations From File
                            SavetheRoomAllocationFromaFile();
                            break;
                        case 9:
                            // Exit Application
                            ToDisplayBackupfile();
                            break;
                        case 0:
                            // Exit Application
                            Exit();
                            return;
                        default:
                           
                            //Console.WriteLine("Invalid choice. Please enter a number between 0 and 9 for Menu Options.");
                            throw new InvalidOperationException();
                    }


                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation Exception- " + ex.Message);
                }
                Console.Write("\nWould You Like To Go Back to Main Menu(Y/N):");
                ans = Convert.ToChar(Console.ReadLine());
            } while (ans == 'y' || ans == 'Y');




        }


    }
}




















