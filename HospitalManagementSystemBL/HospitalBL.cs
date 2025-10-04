using System;
using System.Collections.Generic;
using HospitalManagementSystemDTO;
using HospitalManagementSystemDAL;

namespace HospitalManagementSystemBL
{
    public class HospitalBL{
        public List<PatientDTO> patientlist { get; set; }
        public List<DoctorDTO> doctorlist { get; set; }
        public List<AppointmentDTO> appointmentlist { get; set; }

        public HospitalBL(){
            patientlist = new List<PatientDTO>();
            doctorlist = new List<DoctorDTO>();
            DoctorDAL ddata = new DoctorDAL();
            doctorlist = ddata.FetchDoctors();
            appointmentlist = new List<AppointmentDTO>();
            PatientDAL pdata = new PatientDAL();
            patientlist = pdata.FetchPatient();
            AppointmentDAL adata = new AppointmentDAL();
            appointmentlist = adata.FetchAppointments();
        }

        public void AddHDoctor(string name, string spec, bool available){
           DoctorBL d = new DoctorBL();
           DoctorDTO dn = d.AddDoctor(name, spec, available);
           doctorlist.Add(dn);
        }

        public void UpdateHDoctor(Guid id, string name, string spec, bool available){
            DoctorBL d_1 = new DoctorBL();
            d_1.UpdateDoctor(id, name, spec, available);
            foreach(DoctorDTO d__ in doctorlist){
                if(d__.DoctorId == id){
                   d__.Name = name;
                   d__.Specialization = spec;
                   d__.IsAvailable = available;
                }
            }
        }

        public void DeleteHDoctor(Guid id){
            LogDAL dlog = new LogDAL();
            for (int i = 0; i < doctorlist.Count; i++)
            {
                if (doctorlist[i].DoctorId == id)
                {
                    dlog.DoctorLog(doctorlist[i], "DELETED"); 
                    doctorlist.RemoveAt(i); 
                    break;
                }
            }
            DoctorBL _d = new DoctorBL();
            _d.DeleteDoctor(id);             
        }

        public void MarkHDoctorAvailable(Guid id){
            DoctorBL d_ = new DoctorBL();
            d_.MarkDoctorAvai(id);
            foreach(DoctorDTO d1 in doctorlist){
                if(d1.DoctorId == id){
                   d1.IsAvailable = true;
                }
            }
        }

        public void MarkHDoctorUnAvailable(Guid id){
            DoctorBL d0 = new DoctorBL();
            d0.MarkDoctorUnAvai(id); 
            foreach(DoctorDTO d1 in doctorlist){
                if(d1.DoctorId == id){
                   d1.IsAvailable = false;
                }
            }
        }

        public void AddHPatient(string name, string cnic){
           PatientBL d9 = new PatientBL();
           PatientDTO p8 = d9.AddPatient(name, cnic);  // FIXED: changed 'd' to 'd9'
           patientlist.Add(p8);
        }  
 
        public void UpdateHPatient(string name, string cnic){
            PatientBL d7 = new PatientBL();
            d7.UpdatePatient(name, cnic);
            foreach(PatientDTO p1 in patientlist){
                if(p1.CNIC == cnic){
                   p1.Name = name;
                }
            }
        }

        public void DeleteHPatient(string id){
            LogDAL dlog = new LogDAL();
            for (int i = 0; i < patientlist.Count; i++)
            {
                if (patientlist[i].CNIC == id)
                {
                    dlog.PatientLog(patientlist[i], "DELETED"); 
                    patientlist.RemoveAt(i); 
                    break;
                }
            }
            PatientBL d6 = new PatientBL();
            d6.DeletePatient(id);             
        }
        
        public void AddHAppointment(Guid doctorId, string patientCNIC, DateTime appointmentDate)
        {
            AppointmentBL ab = new AppointmentBL();
            AppointmentDTO appt = ab.AddAppointment(doctorId, patientCNIC, appointmentDate);
            appointmentlist.Add(appt);
            foreach(PatientDTO p5 in patientlist){
                if(p5.CNIC == patientCNIC){
                    if(p5.Appointments == null) 
                       p5.Appointments = new List<Guid>();
                    p5.Appointments.Add(appt.AppointmentId);
                }
            }
        }

        public void DeleteHAppointment(Guid id)
        {
            LogDAL log = new LogDAL();
            for (int i = 0; i < appointmentlist.Count; i++)
            {
                if(appointmentlist[i].AppointmentId == id){
                    log.AppointmentLog(appointmentlist[i], "DELETEDs"); 
                    appointmentlist.RemoveAt(i);
                    break;
                }
            }
            foreach(PatientDTO p4 in patientlist){
                if (p4.Appointments != null){
                    for (int i = 0; i < p4.Appointments.Count; i++)
                    {
                        if(p4.Appointments[i] == id){
                            p4.Appointments.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            AppointmentBL appBL = new AppointmentBL();
            appBL.DeleteAppointment(id);
        }

        public DoctorDTO GetMostConsulted(){
            DoctorBL d2 = new DoctorBL();
            return d2.mostconsulted(); 
        }
    }
}



// using System;
// using System.Collections.Generic;
// using HospitalManagementSystemDTO;
// using HospitalManagementSystemDAL;

// namespace HospitalManagementSystemBL
// {
//     public class HospitalBL{
//         public  List<PatientDTO> patientlist{get;set;}
//         public  List<DoctorDTO> doctorlist{get;set;}
//         public  List<AppointmentDTO> appointmentlist{get;set;}

//         public HospitalBL(){
//             patientlist = new List<PatientDTO>();
//             doctorlist = new List<DoctorDTO>();
//             DoctorDAL ddata = new DoctorDAL();
//             doctorlist = ddata.FetchDoctors();
//             appointmentlist = new List<AppointmentDTO>();
//             PatientDAL pdata = new PatientDAL();
//             patientlist = pdata.FetchPatient();
//             AppointmentDAL adata = new AppointmentDAL();
//             appointmentlist = adata.FetchAppointments();
//         }

//         public void AddHDoctor(string name , string spec , bool available){
//            DoctorBL d= new DoctorBL();
//            DoctorDTO dn = d.AddDoctor(name,spec,available);
//            doctorlist.Add(dn);
//         }

//         public void UpdateHDoctor(Guid id ,string name , string spec , bool available){
//             DoctorBL d_1= new DoctorBL();
//             d_1.UpdateDoctor(id ,name,spec,available);
//             foreach(DoctorDTO d__ in doctorlist){
//                 if(d__.DoctorId == id){
//                    d__.Name = name;
//                    d__.Specialization = spec;
//                    d__.IsAvailable = available;
//                 }
//             }
//         }

//         public void DeleteHDoctor(Guid id){
//             LogDAL dlog = new LogDAL();
//             for (int i = 0; i < doctorlist.Count; i++)
//             {
//                 if (doctorlist[i].DoctorId == id)
//                 {
//                     dlog.DoctorLog(doctorlist[i],"DELETED"); 
//                     doctorlist.RemoveAt(i); 
//                     break;
//                 }
//             }
//             DoctorBL _d = new DoctorBL();
//             _d.DeleteDoctor(id);             
//         }

//         public void MarkHDoctorAvailable(Guid id){
//             DoctorBL d_ = new DoctorBL();
//             d_.MarkDoctorAvai(id);
//             foreach(DoctorDTO d1 in doctorlist){
//                 if(d1.DoctorId == id){
//                    d1.IsAvailable = true;
//                 }
//             }
//         }

//         public void MarkHDoctorUnAvailable(Guid id){
//             DoctorBL d0 = new DoctorBL();
//             d0.MarkDoctorUnAvai(id); 
//             foreach(DoctorDTO d1 in doctorlist){
//                 if(d1.DoctorId == id){
//                    d1.IsAvailable = false;
//                 }
//             }
//         }

//         public void AddHPatient(string name , string cnic){
//            PatientBL d9= new PatientBL();
//            PatientDTO p8 = d.AddPatient(name,cnic);
//            patientlist.Add(p8);
//         }  
 
//         public void UpdateHPatient(string name , string cnic){
//             PatientBL d7= new PatientBL();
//             d7.UpdatePatient(name,cnic);
//             foreach(PatientDTO p1 in patientlist){
//                 if(p1.CNIC == cnic){
//                    p1.Name = name;
//                 }
//             }
//         }

//         public void DeleteHPatient(string id){
//             LogDAL dlog = new LogDAL();
//             for (int i = 0; i < patientlist.Count; i++)
//             {
//                 if (patientlist[i].CNIC == id)
//                 {
//                     dlog.PatientLog(patientlist[i],"DELETED"); 
//                     patientlist.RemoveAt(i); 
//                     break;
//                 }
//             }
//             PatientBL d6 = new PatientBL();
//             d6.DeletePatient(id);             
//         }
        
//         public void AddHAppointment(Guid doctorId, string patientCNIC, DateTime appointmentDate)
//         {
//             AppointmentBL ab = new AppointmentBL();
//             AppointmentDTO appt = ab.AddAppointment(doctorId, patientCNIC, appointmentDate);
//             appointmentlist.Add(appt);
//             foreach(PatientDTO p5 in patientlist){
//                 if(p5.CNIC == patientCNIC){
//                     if(p5.Appointments == null) 
//                        p5.Appointments = new List<Guid>();
//                     p5.Appointments.Add(appt.AppointmentId);
//                 }
//             }
//         }

//         public void DeleteHAppointment(Guid id)
//         {
//             LogDAL log = new LogDAL();
//             for (int i = 0; i < appointmentlist.Count; i++)
//             {
//                 if(appointmentlist[i].AppointmentId == id){
//                     log.AppointmentLog(appointmentlist[i],"DELETEDs"); 
//                     appointmentlist.RemoveAt(i);
//                     break;
//                 }
//             }
//             foreach(PatientDTO p4 in patientlist){
//                 for (int i = 0; i < p4.Appointments.Count; i++)
//                 {
//                     if(p4.Appointments[i] == id){
//                         p4.Appointments.RemoveAt(i);
//                         break;
//                     }
//                 }
//             }
//             AppointmentBL appBL = new AppointmentBL();
//             appBL.DeleteAppointment(id);
//         }

//         public DoctorDTO GetMostConsulted(){
//             DoctorBL d2 = new DoctorBL();
//             return d2.mostconsulted(); 
//         }


//     }
// }
