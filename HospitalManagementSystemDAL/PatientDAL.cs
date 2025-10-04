using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HospitalManagementSystemDTO;
using Microsoft.Data.SqlClient;

namespace HospitalManagementSystemDAL
{
    public class PatientDAL
    {
        public List<PatientDTO> FetchPatient(){
            using (SqlConnection conn = new SqlConnection(DatabaseHelperDAL.ConnectionString)){
                conn.Open();
                List<PatientDTO> pl = new List<PatientDTO>();
                string query = "SELECT * FROM Patients";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){
                    string name = reader.GetString(reader.GetOrdinal("Name"));
                    string cnic = reader.GetString(reader.GetOrdinal("CNIC"));
                    PatientDTO p1 = new PatientDTO(name, cnic);
                    List<Guid> appointmentIds = FetchAppointmentIds(cnic);
                    p1.Appointments = appointmentIds;
                    pl.Add(p1);
                }
            return pl;
            }
        }
 
        public void AddPatient(PatientDTO p1)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                conn.Open();
                string query = "Insert INTO Patients (Name , CNIC) values (@Name , @CNIC);";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", p1.Name);
                cmd.Parameters.AddWithValue("@CNIC", p1.CNIC);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePatient(PatientDTO p1)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                conn.Open();
                string query = "Update Patients SET Name = @name  where CNIC =@precnic;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", p1.Name);
                cmd.Parameters.AddWithValue("@precnic", p1.CNIC);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePatient(string CNIC)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                conn.Open();
                string query = "Delete From Patients where CNIC=@cnic;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cnic", CNIC);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Guid> FetchAppointmentIds(string patientCNIC)
        {
            List<Guid> appointmentIds = new List<Guid>();
            using (SqlConnection conn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                conn.Open();
                string query = "SELECT AppointmentID FROM Appointments WHERE PatientCNIC = @cnic";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cnic", patientCNIC);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid appId = reader.GetGuid(reader.GetOrdinal("AppointmentID"));
                        appointmentIds.Add(appId);
                    }
                }
            }
            return appointmentIds;
        }

    }
}

