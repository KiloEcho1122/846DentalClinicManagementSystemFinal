SELECT	Appointment.AppointmentID AS No,
		CONCAT(Appointment_FName,' ', Appointment_MName, ' ',Appointment_LName) AS Patient_Name,
		CONCAT(DentistFName,' ',DentistMName, ' ', DentistLName) AS Dentist,
		TreatmentType AS Treatment, AppointmentDate AS Date,
		CONCAT(StartTime, ' - ', EndTime) AS Time,
		Appointment.Status, Appointment.AppointmentNote AS Note
FROM Appointment INNER JOIN [Dentist] ON DentistID_fk = DentistID
				 INNER JOIN [Treatment] ON TreatmentID_fk = TreatmentID



