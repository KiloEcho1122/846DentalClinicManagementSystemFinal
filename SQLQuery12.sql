

SELECT * FROM Appointment
WHERE Appointment.Appointment_FName in (SELECT Patient.PatientFName FROM Patient)
AND  Appointment.Appointment_MName in (SELECT Patient.PatientMName FROM Patient)
AND Appointment.Appointment_LName in (SELECT Patient.PatientLName FROM Patient)
AND AppointmentID = 1


