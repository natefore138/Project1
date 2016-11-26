Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class LogIn
  Inherits System.Web.UI.Page

  'Connection String
  Public Shared conS As String = "Server=DESKTOP-NP2V6BB;Database= NFORE ;Trusted_Connection=Yes;"
  Public Shared con As SqlConnection = New SqlConnection(conS)


  Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
    Image1.ImageUrl = "images/redbird.png"
  End Sub

  Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
    'Validate username has been entered
    If txtUser.Text = Nothing Then
      Response.Write("Enter Username")
      txtUser.Focus()
      Exit Sub
    End If

    'Validate Password has been entered
    If txtPass.Text = Nothing Then
      Response.Write("Enter Password")
      txtPass.Focus()
      Exit Sub
    End If

    'Declare string variables for username and password
    Dim user, pass As String

    'Command to retrieve username from DB
    Dim cmdGetUser As New SqlCommand("Select UserName From users Where UserName = @p1", con)
    'Set parameter to user name textbox
    With cmdGetUser.Parameters
      .Clear()
      .AddWithValue("@p1", txtUser.Text)
    End With
    'Command to retrieve password based on username from DB
    Dim cmdGetPass As New SqlCommand("Select Password From users Where UserName = @p1", con)

    With cmdGetPass.Parameters
      .Clear()
      .AddWithValue("@p1", txtUser.Text)
    End With

    Try
      If con.State = ConnectionState.Closed Then con.Open()
      user = cmdGetUser.ExecuteScalar
      pass = cmdGetPass.ExecuteScalar
    Catch ex As Exception
      Response.Write(ex.Message)
    Finally
      con.Close()
    End Try

    'Display username and password in hidden textboxes
    txtHiddenUser.Text = user
    txtHiddenPass.Text = pass

    'Check if username is valid
    If txtHiddenUser.Text = Nothing Then
      Response.Write("Username not found.")
      txtUser.Focus()
      Exit Sub
    End If

    'Check if password matches
    If txtPass.Text = txtHiddenPass.Text Then
      Session("userName") = txtUser.Text
      Response.Redirect("Profile.aspx")
    Else
      Response.Write("Password is incorrect")
      txtPass.Focus()
      Exit Sub
    End If
  End Sub

  Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
    Response.Redirect("default.aspx")
  End Sub
End Class
