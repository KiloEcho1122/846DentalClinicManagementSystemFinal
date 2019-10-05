SELECT	Appointment.AppointmentID AS ID,
		CONCAT(Appointment.Appointment_FName,' ', Appointment.Appointment_MName, ' ', Appointment.Appointment_LName) AS Patient_Name,
		CONCAT(Dentist.DentistFName,' ',Dentist.DentistMName, ' ', Dentist.DentistLName),
		Treatment.TreatmentType AS Treatment,
		CONCAT(Appointment.StartTime, ' - ', Appointment.EndTime) AS _Time
FROM Appointment INNER JOIN [Dentist] ON Appointment.DentistID_fk = [Dentist].DentistID
				 INNER JOIN [Treatment] ON Appointment.TreatmentID_fk = [Treatment].TreatmentID



