using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HospitalManagementSystemDTO;
using HospitalManagementSystemDAL;

namespace HospitalManagementSystemBL
{
    public class PatientBL{
        public PatientDTO AddPatient(string name,string cnic){
            PatientDTO p = new PatientDTO(name , cnic);
            PatientDAL pdata = new PatientDAL();
            pdata.AddPatient(p);
            LogDAL plog = new LogDAL();
            plog.PatientLog(p,"ADDED");
            return p;
        }

        public void UpdatePatient(string name,string cnic){
            PatientDTO p = new PatientDTO( name , cnic);
            PatientDAL pdata = new PatientDAL();
            pdata.UpdatePatient(p);
            LogDAL plog = new LogDAL();
            plog.PatientLog(p,"Updated");
        }

        public void DeletePatient(string CNIC){
            PatientDAL pdata = new PatientDAL();
            pdata.DeletePatient(CNIC);
        }

    }
}