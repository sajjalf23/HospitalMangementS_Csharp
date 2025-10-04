using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using HospitalManagementSystemDTO;


namespace HospitalManagementSystemDAL
{
    public class DatabaseHelperDAL
    {  
        public static string ConnectionString{ get; private set; }
        static DatabaseHelperDAL()
{
           ConnectionString = "Server=localhost\\SQLEXPRESS;Database=HospitalDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
           InitializeDb();
}

        public static void InitializeDb()
        {
            string querycreatetable = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='Patients')
                BEGIN
                    CREATE TABLE Patients(
                        PatientID INT IDENTITY(1,1) PRIMARY KEY,
                        Name NVARCHAR(100) NOT NULL,
                        CNIC NVARCHAR(15) NOT NULL UNIQUE
                    );
                END";
            string querycreatedoctor = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='Doctors')
                BEGIN
                    CREATE TABLE Doctors(
                        DoctorID UNIQUEIDENTIFIER PRIMARY KEY,
                        Name NVARCHAR(100) NOT NULL,
                        Specialization NVARCHAR(100) NOT NULL,
                        IsAvailable BIT NOT NULL
                    );
                END";
            string querycreateappointment = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='Appointments')
                BEGIN
                    CREATE TABLE Appointments(
                        AppointmentID UNIQUEIDENTIFIER PRIMARY KEY,
                        DoctorID UNIQUEIDENTIFIER NOT NULL,
                        PatientCNIC NVARCHAR(15) NOT NULL,
                        AppointmentDate DATETIME NOT NULL,
                        FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID),
                        FOREIGN KEY (PatientCNIC) REFERENCES Patients(CNIC)                       
                    );
                END";
            using (SqlConnection SQLConn = new SqlConnection(ConnectionString))
            {
                SQLConn.Open();
                using (SqlCommand cmd = new SqlCommand(querycreatetable, SQLConn))
                    cmd.ExecuteNonQuery();
                using (SqlCommand cmd = new SqlCommand(querycreatedoctor, SQLConn))
                    cmd.ExecuteNonQuery();
                using (SqlCommand cmd = new SqlCommand(querycreateappointment, SQLConn))
                    cmd.ExecuteNonQuery();
            }
        }

    }
}