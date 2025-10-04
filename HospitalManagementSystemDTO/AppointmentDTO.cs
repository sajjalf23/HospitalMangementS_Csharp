using System;

namespace HospitalManagementSystemDTO
{
    public class AppointmentDTO
    { 
        // private int AppointmentId;
        // private int DoctorId;
        // private string PatientCNIC;
        public Guid AppointmentId { get; set;}   // sir told to use Guid to get unique ID
        public Guid DoctorId{ get; set; }
        public string PatientCNIC{ get; set;}
        public DateTime AppointmentDate{get; set;}

        public AppointmentDTO(Guid did, string pcnic, DateTime adate)
        {
            DoctorId = did;
            PatientCNIC = pcnic;
            AppointmentDate = adate;
            AppointmentId = Guid.NewGuid();
            Console.WriteLine(AppointmentId);
        } 
        public AppointmentDTO(Guid appid ,Guid did, string pcnic, DateTime adate)
        { 
            DoctorId = did;
            PatientCNIC = pcnic;
            AppointmentDate = adate;
            AppointmentId = appid;
        } 

        public override string ToString(){
            return $"Doctor-ID: {DoctorId}, Patient-CNIC: {PatientCNIC}, Appointment-Id: {AppointmentId}, Appointment-Date: {AppointmentDate}";
        }
    }
}