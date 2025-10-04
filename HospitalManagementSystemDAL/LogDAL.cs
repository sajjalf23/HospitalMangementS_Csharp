using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Text.Json;
using HospitalManagementSystemDTO;


namespace HospitalManagementSystemDAL
{
    public class LogDAL{
        public void PatientLog(PatientDTO p , string Action){
            string data = $"{Action} , {JsonSerializer.Serialize(p)}";
            File.AppendAllText("patient.txt",data + data + Environment.NewLine);
        }
        public void DoctorLog(DoctorDTO d , string Action){
            string data = $"{Action} , {JsonSerializer.Serialize(d)}";
            File.AppendAllText("doctor.txt",data + Environment.NewLine);
        }
        public void AppointmentLog(AppointmentDTO a , string Action){
            string data = $"{Action} , {JsonSerializer.Serialize(a)}";
            File.AppendAllText("appointment.txt",data + Environment.NewLine);
        }
    }
}