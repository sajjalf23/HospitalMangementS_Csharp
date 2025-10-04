using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HospitalManagementSystemDTO;


namespace HospitalManagementSystemDAL
{ 
    public class AppointmentDAL
    { 
        public void AddAppointment(AppointmentDTO app)
        {
            DatabaseHelperDAL db= new DatabaseHelperDAL();
            using (SqlConnection sqlConn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlConn.Open();
                string query = "INSERT INTO Appointments (DoctorID,PatientCNIC,AppointmentDate,AppointmentId) VALUES ( @did, @cnic ,@date,@aid);";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@aid", app.AppointmentId);
                cmd.Parameters.AddWithValue("@did", app.DoctorId);
                cmd.Parameters.AddWithValue("@cnic", app.PatientCNIC);
                cmd.Parameters.AddWithValue("@date", app.AppointmentDate);
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteAppointment(Guid appid)
        {
            using (SqlConnection sqlConn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlConn.Open();
                string query = "DELETE FROM Appointments WHERE AppointmentID = @appid";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@appid", appid);
                cmd.ExecuteNonQuery();
            }
        }

        public List<AppointmentDTO> FetchAppointments()
        { 
            using (SqlConnection sqlconn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlconn.Open();
                List<AppointmentDTO> appList = new List<AppointmentDTO>();
                string query = "SELECT * FROM Appointments";
                SqlCommand cmd = new SqlCommand(query, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AppointmentDTO a = new AppointmentDTO(
                        reader.GetGuid(reader.GetOrdinal("AppointmentID")),
                        reader.GetGuid(reader.GetOrdinal("DoctorID")),
                        reader.GetString(reader.GetOrdinal("PatientCNIC")),
                        reader.GetDateTime(reader.GetOrdinal("AppointmentDate"))
                    );
                    appList.Add(a);
                }
                return appList;
            }
        }
        
    }

}