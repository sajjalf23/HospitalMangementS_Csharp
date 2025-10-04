using System;
using System.Collections.Generic;
using HospitalManagementSystemDTO;
using HospitalManagementSystemDAL;

namespace HospitalManagementSystemBL
{ 
    public class AppointmentBL{
 
        public AppointmentDTO AddAppointment(Guid doctorId, string patientCNIC, DateTime appointmentDate)
        {  
            AppointmentDTO appt = new AppointmentDTO(doctorId, patientCNIC, appointmentDate);
            AppointmentDAL adata = new AppointmentDAL();
            adata.AddAppointment(appt);
            LogDAL plog = new LogDAL();
            plog.AppointmentLog(appt,"ADDED");
            return appt;
        } 

        public void DeleteAppointment(Guid id)
        {
            AppointmentDAL appDAL = new AppointmentDAL();
            appDAL.DeleteAppointment(id);
        }
    }
}