using System;
using System.Collections.Generic;
using HospitalManagementSystemBL;

namespace HospitalManagementSystemPL
{
    public class HospitalPL
    {
        public HospitalBL h { get; set; }

        public HospitalPL()
        {
            h = new HospitalBL();
        }

        public void AddPatient()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter CNIC: ");
            string cnic = Console.ReadLine();
            h.AddHPatient(name, cnic);
        }

        public void UpdatePatient()
        {
            Console.Write("Enter CNIC to update: ");
            string cnic = Console.ReadLine();
            Console.Write("Enter Updated Name: ");
            string name = Console.ReadLine();
            h.UpdateHPatient(name, cnic);
        }

        public void DeletePatient()
        {
            Console.Write("Enter CNIC to delete: ");
            string cnic = Console.ReadLine();
            h.DeleteHPatient(cnic);
        }

        public void DisplayPatients()
        {
            Console.WriteLine("\n Patients ");
            foreach (var p in h.patientlist)
            {
                Console.WriteLine(p);
                if (p.Appointments != null && p.Appointments.Count > 0)
                {
                    Console.WriteLine("Appointments: " + string.Join(", ", p.Appointments));
                }
            }
        }

        public void AddDoctor()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Specialization: ");
            string spec = Console.ReadLine();
            Console.Write("Is Available (true/false): ");
            bool available = bool.Parse(Console.ReadLine());
            h.AddHDoctor(name, spec, available);
        }

        public void UpdateDoctor()
        {
            Console.Write("Enter Doctor ID: ");
            Guid id = Guid.Parse(Console.ReadLine());
            Console.Write("Enter Updated Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Updated Specialization: ");
            string spec = Console.ReadLine();
            Console.Write("Is Available (true/false): ");
            bool available = bool.Parse(Console.ReadLine());
            h.UpdateHDoctor(id, name, spec, available);
        }

        public void DeleteDoctor()
        {
            Console.Write("Enter Doctor ID: ");
            Guid id = Guid.Parse(Console.ReadLine());
            h.DeleteHDoctor(id);
        }

        public void DisplayDoctors()
        {
            Console.WriteLine("\n Doctors ");
            foreach (var d in h.doctorlist)
            {
                Console.WriteLine(d);
            }
        }

        public void BookAppointment()
        {
            Console.Write("Enter Doctor ID: ");
            Guid doctorId = Guid.Parse(Console.ReadLine());
            Console.Write("Enter Patient CNIC: ");
            string cnic = Console.ReadLine();
            Console.Write("Enter Appointment Date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            h.AddHAppointment(doctorId, cnic, date);
        }

        public void CancelAppointment()
        {
            Console.Write("Enter Appointment ID: ");
            Guid id = Guid.Parse(Console.ReadLine());
            h.DeleteHAppointment(id);
        }

        public void DisplayAppointments()
        {
            Console.WriteLine("\n Appointments ");
            foreach (var app in h.appointmentlist)
            {
                Console.WriteLine(app);
            }
        }

        public void DisplayMostConsultedDoctor()
        {
            Console.WriteLine("\n Most Consulted Doctor ");
            var doc = h.GetMostConsulted();
            if (doc != null)
                Console.WriteLine(doc);
            else
                Console.WriteLine("No appointments found.");
        }
    }

    // public class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         HospitalPL pl = new HospitalPL();
    //         bool exit = false;

    //         while (!exit)
    //         {
    //             Console.WriteLine("\n Hospital Management System Menu ");
    //             Console.WriteLine("1. Add Patient");
    //             Console.WriteLine("2. Update Patient");
    //             Console.WriteLine("3. Delete Patient");
    //             Console.WriteLine("4. Display Patients");
    //             Console.WriteLine("5. Add Doctor");
    //             Console.WriteLine("6. Update Doctor");
    //             Console.WriteLine("7. Delete Doctor");
    //             Console.WriteLine("8. Display Doctors");
    //             Console.WriteLine("9. Book Appointment");
    //             Console.WriteLine("10. Cancel Appointment");
    //             Console.WriteLine("11. Display Appointments");
    //             Console.WriteLine("12. Declare Most Consulted Doctor");
    //             Console.WriteLine("0. Exit");
    //             Console.Write("Select an option: ");

    //             string choice = Console.ReadLine();
    //             Console.WriteLine();

    //             switch (choice)
    //             {
    //                 case "1": pl.AddPatient(); break;
    //                 case "2": pl.UpdatePatient(); break;
    //                 case "3": pl.DeletePatient(); break;
    //                 case "4": pl.DisplayPatients(); break;
    //                 case "5": pl.AddDoctor(); break;
    //                 case "6": pl.UpdateDoctor(); break;
    //                 case "7": pl.DeleteDoctor(); break;
    //                 case "8": pl.DisplayDoctors(); break;
    //                 case "9": pl.BookAppointment(); break;
    //                 case "10": pl.CancelAppointment(); break;
    //                 case "11": pl.DisplayAppointments(); break;
    //                 case "12": pl.DisplayMostConsultedDoctor(); break;
    //                 case "0": exit = true; break;
    //                 default: Console.WriteLine("Invalid choice!"); break;
    //             }
    //         }
    //     }
    // }
}
