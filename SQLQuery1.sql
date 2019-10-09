SELECT StartTime,EndTime 
FROM Appointment 
WHERE DentistID_fk = 2 AND AppointmentDate = '10/10/2019' AND NOT AppointmentID = 19