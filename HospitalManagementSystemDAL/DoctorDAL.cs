using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using HospitalManagementSystemDTO;


namespace HospitalManagementSystemDAL
{ 
    public class DoctorDAL
    { 
        public List<DoctorDTO> FetchDoctors()
        {
            using (SqlConnection sqlconn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlconn.Open();
                List<DoctorDTO> doctorList = new List<DoctorDTO>();
                string query = "SELECT * FROM Doctors";
                SqlCommand cmd = new SqlCommand(query, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DoctorDTO doctor = new DoctorDTO(
                        reader.GetGuid(reader.GetOrdinal("DoctorID")),
                        reader.GetString(reader.GetOrdinal("Name")),
                        reader.GetString(reader.GetOrdinal("Specialization")),
                        reader.GetBoolean(reader.GetOrdinal("IsAvailable"))
                    );
                    doctorList.Add(doctor);
                }
                return doctorList;
            }
        }

        public void AddDoctor(DoctorDTO doctor)
        {
            using (SqlConnection sqlConn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlConn.Open();
                string query = "INSERT INTO Doctors (DoctorID , Name, Specialization, IsAvailable) VALUES (@DoctorID , @Name, @Specialization, @IsAvailable);";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@Name", doctor.Name);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                cmd.Parameters.AddWithValue("@IsAvailable", doctor.IsAvailable);
                cmd.Parameters.AddWithValue("@DoctorID", doctor.DoctorId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateDoctor(DoctorDTO doctor)
        {
            using (SqlConnection sqlConn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlConn.Open();
                string query = "UPDATE Doctors SET Name = @Name, Specialization = @Specialization, IsAvailable = @IsAvailable WHERE DoctorID = @DoctorID;";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@Name", doctor.Name);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                cmd.Parameters.AddWithValue("@IsAvailable", doctor.IsAvailable);
                cmd.Parameters.AddWithValue("@DoctorID", doctor.DoctorId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDoctor(Guid doctorID)
        {
            using (SqlConnection sqlConn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlConn.Open();
                string query = "DELETE FROM Doctors WHERE DoctorID = @DoctorID;";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                cmd.ExecuteNonQuery();
            }
        }

        public void MarkDoctorAvailable(Guid doctorID)
        {
            using (SqlConnection sqlConn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlConn.Open();
                string query = "UPDATE Doctors SET IsAvailable = @isavailable  WHERE DoctorID= @DoctorID";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@isavailable", true);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                cmd.ExecuteNonQuery();
            }
        }
        public void MarkDoctorUnAvailable(Guid doctorID)
        {
            using (SqlConnection sqlConn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlConn.Open();
                string query = "UPDATE Doctors SET IsAvailable = @isavailable  WHERE DoctorID= @DoctorID";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@isavailable", false);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                cmd.ExecuteNonQuery();
            }
        }

        public DoctorDTO FindDoctor(Guid id){
            using (SqlConnection sqlConn = new SqlConnection(DatabaseHelperDAL.ConnectionString))
            {
                sqlConn.Open();
                string query = "SELECT * FROM Doctors WHERE DoctorID= @DoctorID";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@DoctorID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    DoctorDTO doctor = new DoctorDTO(
                        reader.GetGuid(reader.GetOrdinal("DoctorID")),
                        reader.GetString(reader.GetOrdinal("Name")),
                        reader.GetString(reader.GetOrdinal("Specialization")),
                        reader.GetBoolean(reader.GetOrdinal("IsAvailable"))
                    );
                    return doctor;
                    
                }
                return null;
            }
        }
        
        
        public DoctorDTO GetMostConsultedDoctor(){
            using (SqlConnection connection = new SqlConnection(DatabaseHelperDAL.ConnectionString)){
                connection.Open();
                string query = @"
                    SELECT TOP 1 d.DoctorID, d.Name, d.Specialization, d.IsAvailable, 
                    COUNT(a.AppointmentID) AS AppointmentCount
                    FROM Doctors d
                    LEFT JOIN Appointments a ON d.DoctorID = a.DoctorID
                    GROUP BY d.DoctorID, d.Name, d.Specialization, d.IsAvailable
                    ORDER BY COUNT(a.AppointmentID) DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read()){
                        Guid doctorId = (Guid)reader["DoctorID"];
                        string name = reader["Name"].ToString();
                        string specialization = reader["Specialization"].ToString();
                        bool isAvailable = (bool)reader["IsAvailable"];
                    return new DoctorDTO(doctorId, name, specialization, isAvailable);
                    }
                }
            } 
            return null;
        }


        
    }
}
