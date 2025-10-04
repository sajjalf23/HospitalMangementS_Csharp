using System;

namespace HospitalManagementSystemDTO
{
    public class DoctorDTO
    {
        
        // private int DoctorId;
        // private string Name;
        // private string Specialization;
        // private bool IsAvailable;

        // public int doctorid { get { return DoctorId; } }
        // public string name { get { return Name; } set { Name = value; } }
        // public string specialization { get { return Specialization; } set { Specialization = value; } }
        // public bool isavailable { get { return IsAvailable; } }

        public Guid DoctorId { get; set; }

        // sir told to use Guid to get unique ID
        public string Name { get; set; }
        public string Specialization{ get; set; }
        public bool IsAvailable{ get;  set; }
          
          
        public DoctorDTO(Guid DoctorI ,string name, string spec , bool available = true)
        {
            DoctorId = DoctorI;
            Name = name;
            Specialization = spec;
            IsAvailable = available;
        }
        
        public DoctorDTO(string name, string spec , bool available = true)
        {
            DoctorId = GenerateDoctorId();
            Name = name;
            Specialization = spec;
            IsAvailable = available;
        }

        public Guid GenerateDoctorId()
        {
            // int Id = new Random().Next(100000, 1000000);   // unique issue

            Guid Id = Guid.NewGuid();                      
               // unique issue solveds
            return Id;
        }

        public override string ToString()
        {
            return $"Doctor-ID: {DoctorId}, Name: {Name}, Specialization: {Specialization}, Available: {IsAvailable}";
        }
    }
}