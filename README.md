# Hospital Management System (C#)

A console-based Hospital Management System written in C# that allows admins to manage **Doctors**, **Patients**, and **Appointments** efficiently. This system supports CRUD operations, logging, serialization, and provides a menu-driven interface for ease of use.

using N Tier Architecture 
   - Presentation Layer PL
   - Business Layer BL
   - Data Access Layer DAL
   - Data Transfer Layer DTO

---

## Features

### Doctor Management
- Add, update, delete, and display doctors.
- Automatically generates a unique `DoctorID` for each doctor.
- Tracks doctor availability (`IsAvailable`) for appointments.
- Logs changes to `Doctor.txt` with `Added:` or `Deleted:` prefixes.

### Patient Management
- Add, update, delete, and display patients.
- Each patient is uniquely identified by `CNIC`.
- Stores patient appointments and checks for duplicates.
- Logs changes to `Patient.txt` with `Added:` or `Deleted:` prefixes.

### Appointment Management
- Book and cancel appointments between patients and doctors.
- Generates unique `AppointmentID` for each appointment.
- Only allows appointments if the doctor is available.
- Logs changes to `Appointment.txt` with `Added:` or `Deleted:` prefixes.

### Reporting
- Display the doctor with the most consultations.
- View all doctors along with their availability status.
- View all patients and their booked appointments.

---

## Classes Overview

### `Doctor`
- `DoctorID` (int, auto-generated)
- `Name` (string)
- `Specialization` (string)
- `IsAvailable` (bool)
- Methods: `MarkAvailable()`, `MarkUnavailable()`, `ToString()`

### `Patient`
- `Name` (string)
- `CNIC` (string, unique)
- `Appointments` (List of Appointment IDs)
- Methods: `HasAppointment(int appointmentID)`, `ToString()`

### `Appointment`
- `AppointmentID` (GUID)
- `DoctorID` (int)
- `PatientCNIC` (string)
- `AppointmentDate` (DateTime)
- Methods: `ToString()`

### `HospitalSystem`
- Stores lists of doctors, patients, and appointments.
- CRUD operations for doctors and patients.
- Appointment booking and cancellation.
- Reporting features like `DeclareMostConsultedDoctor()`.
- Serialization and logging of all operations.

---

## Database Schema

**Doctor Table**
| Column        | Type      | Key           |
|---------------|----------|---------------|
| DoctorID      | GUID      | Primary Key   |
| Name          | nvarchar |               |
| Specialization| nvarchar |               |
| IsAvailable   | bit      |               |

**Patient Table**
| Column   | Type      | Key           |
|----------|----------|---------------|
| PatientID| int      | Primary Key (Auto Increment) |
| Name     | nvarchar |               |
| CNIC     | nvarchar | Unique        |

**Appointment Table**
| Column        | Type      | Key           |
|---------------|----------|---------------|
| AppointmentID | GUID      | Primary Key   |
| DoctorID      | int      | Foreign Key   |
| PatientCNIC   | nvarchar | Foreign Key   |
| AppointmentDate| datetime|               |

---

## Usage

1. Clone the repository:

```bash
git clone https://github.com/sajjalf23/HospitalMangementS_Csharp.git
