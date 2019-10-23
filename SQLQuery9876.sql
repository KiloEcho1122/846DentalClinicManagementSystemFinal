
SELECT b.BillingID,b.BillingDate, t.TreatmentType, b.AmountCharged,b.AmountPay,b.BillingBalance ,b.DateModified
FROM Billing b INNER JOIN Treatment t ON b.TreatmentID_fk = t.TreatmentID
INNER JOIN Patient p ON b.PatientID_fk = p.PatientID
WHERE b.PatientID_fk = @PatientID

	
	