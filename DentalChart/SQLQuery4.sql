SELECT CASE WHEN EXISTS (
   SELECT Teeth.Teethnumber
   FROM Teeth iNNER JOIN [Patient-Teeth]
   ON Teeth.TeethID = [Patient-Teeth].TeethID_fk
   WHERE PatientID_fk = 4 AND Teeth.Teethnumber = 3
)
THEN CAST(1 AS BIT)
ELSE CAST(0 AS BIT) END