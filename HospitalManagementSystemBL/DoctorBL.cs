using System;
using System.Collections.Generic;
using HospitalManagementSystemDTO;
using HospitalManagementSystemDAL;

namespace HospitalManagementSystemBL
{ 
    public class DoctorBL{
        public DoctorDTO AddDoctor(string name,string spec,bool available){
            DoctorDTO doctor = new DoctorDTO(name , spec , available);
            DoctorDAL doctordata = new DoctorDAL();
            doctordata.AddDoctor(doctor);
            LogDAL plog = new LogDAL();
            plog.DoctorLog(doctor,"ADDED");
            return doctor;
        }
 
        public void UpdateDoctor(Guid id , string name , string spec , bool available){
            DoctorDTO doctor = new DoctorDTO(id , name , spec , available);
            DoctorDAL doctordata = new DoctorDAL();
            doctordata.UpdateDoctor(doctor);
            LogDAL plog = new LogDAL();
            plog.DoctorLog(doctor,"UPDATED");
        }

        public void DeleteDoctor(Guid id){
            DoctorDAL doctordata = new DoctorDAL();
            doctordata.DeleteDoctor(id);
        }

        public void MarkDoctorAvai(Guid id){
            DoctorDAL doctordata = new DoctorDAL();
            doctordata.MarkDoctorAvailable(id);
        }

        public void MarkDoctorUnAvai(Guid id){
            DoctorDAL doctordata = new DoctorDAL();
            doctordata.MarkDoctorUnAvailable(id);
        }

        public DoctorDTO mostconsulted(){
            DoctorDAL doctordata = new DoctorDAL();
            return doctordata.GetMostConsultedDoctor();
        }

    }
}