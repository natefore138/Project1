Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class _Default
  Inherits System.Web.UI.Page

  'Connection String
  Public Shared conS As String = "Server=DESKTOP-NP2V6BB;Database= NFore ;Trusted_Connection=Yes;"
  Public Shared con As SqlConnection = New SqlConnection(conS)



  Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

    'Validate textboxes aren't blank
    If txtName.Text = "" Or txtUserName.Text = "" Or txtArea.Text = "" Or txtPhoneNum.Text = "" Or txtEmail.Text = "" Then
      Response.Write("Must fill out all fields.")
      Exit Sub
    End If

    '****STILL NEEDS TO BE DONE Validate username is unique **********


    '**********STILL NEEDS TO BE DONE Validate Password meets requirements - NEEDS MORE REQUIREMENTS HALP!************
    If txtPassword.Text.Length < 8 Then
      Response.Write("Password must be at least 8 characters long")
      txtPassword.Focus()
      Exit Sub
    End If


    'Sql Command to input user into user database
    'Need to add profile pic
    Dim cmdInsert As New SqlCommand("Insert Into [Users] (Name, UserName, AreaCode, PhoneNumber, Email, Password, RegistrationDate) Values (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", con)

    With cmdInsert.Parameters
      .Clear()
      .AddWithValue("@p1", txtName.Text)
      .AddWithValue("@p2", txtUserName.Text)
      .AddWithValue("@p3", txtArea.Text)
      .AddWithValue("@p4", txtPhoneNum.Text)
      .AddWithValue("@p5", txtEmail.Text)
      .AddWithValue("@p6", txtPassword.Text)
      .AddWithValue("@p7", Now.ToString("yyyy/MM/dd HH:mm"))
      '.AddWithValue("@p8", FileUpload1.FileName) 'Doesn't work yet - NEED HALP!
    End With

    'Exception Handling
    Try
      If con.State = ConnectionState.Closed Then con.Open()
      cmdInsert.ExecuteNonQuery()
      Response.Write("User Added")
    Catch ex As Exception
      Response.Write(ex.Message)
    Finally
      con.Close()
    End Try

    'Clear text boxes
    txtName.Text = ""
    txtUserName.Text = ""
    txtArea.Text = ""
    txtPhoneNum.Text = ""
    txtEmail.Text = ""
    txtPassword.Text = ""
  End Sub

  Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
    'Upload file from fileupload to database (for image)
    Dim cmdInsert As New SqlCommand("Insert into [images](img) values (@p1)", con)

    With cmdInsert.Parameters
      .Clear()
      .AddWithValue("@p1", FileUpload1.FileContent)
    End With

    Try
      If con.State = ConnectionState.Closed Then con.Open()
      cmdInsert.ExecuteNonQuery()
      Response.Write("Image Added")
    Catch ex As Exception
      Response.Write(ex.Message)
    Finally
      con.Close()
    End Try


  End Sub

End Class
