SELECT a.AppointmentID,a.AppointmentDate As Date,CONCAT(a.StartTime, ' - ',a.EndTime) AS Time, p.Treatment,
			CONCAT(d.DentistFName,' ',d.DentistLName) AS Dentist,a.Status 
FROM Appointment a INNER JOIN PatientTreatment p ON a.AppointmentID = p.AppointmentID_fk
						 INNER JOIN Dentist d ON a.DentistID_fk = d.DentistID
						  WHERE p.PatientID_fk = 2;