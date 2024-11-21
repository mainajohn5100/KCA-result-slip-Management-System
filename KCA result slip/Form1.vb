Imports System.Drawing.Printing

Public Class Form1
    ' Declare a PrintDocument object
    Private WithEvents printDoc As New PrintDocument
    Private printContent As String

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        ' Variables for marks
        Dim dataStructures As Integer = CInt(txtDataStructures.Text)
        Dim artificialIntelligence As Integer = CInt(txtAI.Text)
        Dim appProgramming As Integer = CInt(txtAppProgramming.Text)
        Dim eCommerce As Integer = CInt(txtECommerce.Text)
        Dim financialAccounting As Integer = CInt(txtFinancialAccounting.Text)

        ' Calculate totals
        Dim totalMarks As Integer = dataStructures + artificialIntelligence + appProgramming + eCommerce + financialAccounting
        Dim percentage As Decimal = (totalMarks / 500D) * 100
        Dim gpa As Decimal = (totalMarks / 500D) * 4.0 ' Assuming a scale of 4.0

        ' Display results
        txtTotalMarks.Text = totalMarks.ToString()
        txtPercentage.Text = percentage.ToString("0.00")
        txtGPA.Text = gpa.ToString("0.00")

        ' Assign grades
        txtGradeDataStructures.Text = AssignGrade(dataStructures)
        txtGradeAI.Text = AssignGrade(artificialIntelligence)
        txtGradeAppProgramming.Text = AssignGrade(appProgramming)
        txtGradeECommerce.Text = AssignGrade(eCommerce)
        txtGradeFinancialAccounting.Text = AssignGrade(financialAccounting)
    End Sub

    Private Function AssignGrade(marks As Integer) As String
        Select Case marks
            Case >= 90 : Return "HIGH DISTINCTION"
            Case >= 80 : Return "DISTINCTION"
            Case >= 70 : Return "CREDIT"
            Case >= 60 : Return "PASS"
            Case Else : Return "FAIL"
        End Select
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Clear all input and output fields
        txtDataStructures.Clear()
        txtAI.Clear()
        txtAppProgramming.Clear()
        txtECommerce.Clear()
        txtFinancialAccounting.Clear()
        txtTotalMarks.Clear()
        txtPercentage.Clear()
        txtGradeDataStructures.Clear()
        txtGradeAI.Clear()
        txtGradeAppProgramming.Clear()
        txtGradeECommerce.Clear()
        txtGradeFinancialAccounting.Clear()
        txtGPA.Clear()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ' Prepare content for printing
        printContent = "KCA UNIVERSITY - RESULT SLIP" & Environment.NewLine &
                       "-----------------------------------" & Environment.NewLine & Environment.NewLine &
                       "Name: " & txtName.Text & Environment.NewLine &
                       "Reg No: " & txtRegNo.Text & Environment.NewLine &
                       "Department: " & cmbDepartment.Text & Environment.NewLine & Environment.NewLine &
                       "-----------------------------------" & Environment.NewLine & Environment.NewLine &
                       "GPA: " & txtGPA.Text & Environment.NewLine &
                       "-----------------------------------" & Environment.NewLine & Environment.NewLine &
                       "Course: Data Structures and Algorithms" & Environment.NewLine &
                       "Marks: " & txtDataStructures.Text & " Grade: " & txtGradeDataStructures.Text & Environment.NewLine &
                       "Course: Artificial Intelligence" & Environment.NewLine &
                       "Marks: " & txtAI.Text & " Grade: " & txtGradeAI.Text & Environment.NewLine &
                       "Course: Application Programming" & Environment.NewLine &
                       "Marks: " & txtAppProgramming.Text & " Grade: " & txtGradeAppProgramming.Text & Environment.NewLine &
                       "Course: E-Commerce" & Environment.NewLine &
                       "Marks: " & txtECommerce.Text & " Grade: " & txtGradeECommerce.Text & Environment.NewLine &
                       "Course: Financial Accounting" & Environment.NewLine &
                       "Marks: " & txtFinancialAccounting.Text & " Grade: " & txtFinancialAccounting.Text & Environment.NewLine & Environment.NewLine &
                       "-----------------------------------" & Environment.NewLine & Environment.NewLine &
                       "Total Marks: " & txtTotalMarks.Text & Environment.NewLine &
                       "Percentage: " & txtPercentage.Text

        ' Print the document
        PrintPreviewDialog1.Document = printDoc
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        ' Set the content to print on the page
        e.Graphics.DrawString(printContent, New Font("Arial", 12), Brushes.Black, 50, 50)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Exit the application
        Me.Close()
    End Sub
End Class
