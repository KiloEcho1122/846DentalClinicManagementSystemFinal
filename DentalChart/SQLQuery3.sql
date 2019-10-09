SELECT  Teethnumber,TeethTop,TeethBottom,TeethLeft,
		TeethRight,TeethCheck,TeethEx
FROM Teeth INNER JOIN (Patient INNER JOIN [Patient-Teeth] 
ON Patient.PatientID = [Patient-Teeth].PatientID_fk)
ON Teeth.TeethID = [Patient-Teeth].TeethID_fk
WHERE [Patient-Teeth].PatientID_fk =4