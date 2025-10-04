using System;

namespace HospitalManagementSystemDTO
{
    public class PatientDTO
    {
        // private string Name;
        // private string CNIC;
        // public List<int> Appointments { get; }
        public string Name { get; set; }
        public string CNIC { get; set;}
        public List<Guid> Appointments{get;set;}

        public PatientDTO(string name, string cnic)
        {
            Name = name;
            CNIC = cnic;
            Appointments = new List<Guid>();
        } 
        public PatientDTO(string name, string cnic,List<Guid> a)
        {
            Name = name;
            CNIC = cnic;
            Appointments = new List<Guid>();
            foreach(Guid app in a){
               Appointments.Add(app);
            }
            
        }

        public override string ToString(){
            string apps = Appointments != null ? string.Join(", ", Appointments) : "No appointments";
            return $"Name: {Name}, CNIC: {CNIC}, Appointments: [{apps}]";
        }


        // public void AddAppointments(int a)
        // {
        //     if(!HasAppointment(a))
        //         Appointments.Add(a);
        // }

        // public void RemoveAppointments(int a)
        // {
        //     if(HasAppointment(a))
        //         Appointments.Remove(a);
        // }
        
        // public bool HasAppointment(int appointmentid)
        // {
        //     foreach (var i in Appointments)
        //     {
        //         if (i == appointmentid)
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        // }

    }
}