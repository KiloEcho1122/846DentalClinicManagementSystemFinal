SELECT Patient.PatientID,Teeth.Teethnumber,Teeth.TeethTop,
		Teeth.TeethBottom,Teeth.TeethLeft,Teeth.TeethRight,
		Teeth.TeethCheck,Teeth.TeethEx
FROM Teeth INNER JOIN (Patient INNER JOIN [Patient-Teeth] ON Patient.PatientID = [Patient-Teeth].PatientID_fk)
ON Teeth.TeethID = [Patient-Teeth].TeethID_fk
WHERE [Patient-Teeth].PatientID_fk =1