using System;
using HospitalManagementSystemPL;

namespace HospitalConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HospitalPL pl = new HospitalPL();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n  ===== Hospital Management System Menu =====  ");
                Console.WriteLine("   1. Add Patient");
                Console.WriteLine("   2. Update Patient");
                Console.WriteLine("   3. Delete Patient");
                Console.WriteLine("   4. Display Patients");
                Console.WriteLine("   5. Add Doctor");
                Console.WriteLine("   6. Update Doctor");
                Console.WriteLine("   7. Delete Doctor");
                Console.WriteLine("   8. Display Doctors");
                Console.WriteLine("   9. Book Appointment");
                Console.WriteLine("   10. Cancel Appointment");
                Console.WriteLine("   11. Display Most Consulted Doctor");
                Console.WriteLine("   12. Display All Appointments");
                Console.WriteLine("   0. Exit");
                Console.Write("   Select an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        pl.AddPatient();
                        break;
                    case "2":
                        pl.UpdatePatient();
                        break;
                    case "3":
                        pl.DeletePatient();
                        break;
                    case "4":
                        pl.DisplayPatients();
                        break;
                    case "5":
                        pl.AddDoctor();
                        break;
                    case "6":
                        pl.UpdateDoctor();
                        break;
                    case "7":
                        pl.DeleteDoctor();
                        break;
                    case "8":
                        pl.DisplayDoctors();
                        break;
                    case "9":
                        pl.BookAppointment();
                        break;
                    case "10":
                        pl.CancelAppointment();
                        break;
                    case "11":
                        pl.DisplayMostConsultedDoctor();
                        break;
                    case "12":
                        pl.DisplayAppointments();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}
