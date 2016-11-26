Imports System.Data
Imports System.Data.SqlClient

Partial Class events
  Inherits System.Web.UI.Page

  Public Shared conS As String = "Server= DESKTOP-NP2V6BB;Database= NFore ;Trusted_Connection=Yes;"
  Public Shared con As SqlConnection = New SqlConnection(conS)

  Private Sub events_Init(sender As Object, e As EventArgs) Handles Me.Init
    'Declare data adapter
    Dim daGetHost As New SqlDataAdapter("Select Name, UserName, UserID from users", con)

    Dim dtHost As New DataTable
    daGetHost.Fill(dtHost)

    'Fill Drop Down List for host
    '**************Probably Replace this with a textbox that auto fills with whoever is logged in as a user***************
    Try
      With ddlHost
        .DataSource = dtHost
        .DataTextField = "Name"
        .DataValueField = "UserID"
        .DataBind()
        .Items.Insert(0, "Please select host")
      End With
    Catch ex As Exception
      Response.Write(ex.Message)
    End Try
  End Sub

  Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
    'Validate a selection has been made
    If ddlEvent.SelectedIndex <= 0 Then
      Response.Write("Please select an event type.")
    End If

    'Validate textboxes aren't blank
    If txtLocation.Text = "" Or txtMax.Text = "" Or txtTime.Text = "" Then
      Response.Write("Must fill out all fields.")
      Exit Sub
    End If

    'Validate Date is selected
    If Calendar1.SelectedDate = Nothing Then
      Response.Write("Please select a date.")
      Exit Sub
    ElseIf Calendar1.SelectedDate < Now Then
      Response.Write("Selected date is in the past.")
      Exit Sub
    End If

    'Validate party size
    If IsNumeric(txtMax.Text) = False Then
      Response.Write("Party size must be numeric.")
      Exit Sub
    End If

    'Sql Command to input user into user database
    Dim cmdInsert As New SqlCommand("Insert Into [events] (EventType, Location, Date, Time, MaxOcc, UserID) Values (@p1, @p2, @p3, @p4, @p5, @p6)", con)

    With cmdInsert.Parameters
      .Clear()
      .AddWithValue("@p1", ddlEvent.SelectedItem.Text) '***********Probably change this to a textbox so you can input any event type*******************
      .AddWithValue("@p2", txtLocation.Text)
      .AddWithValue("@p3", Calendar1.SelectedDate.ToShortDateString)
      .AddWithValue("@p4", txtTime.Text)
      .AddWithValue("@p5", txtMax.Text)
      .AddWithValue("@p6", ddlHost.SelectedValue) '***********Change to textbox that auto fills host name based on user name******
    End With

    'Exception Handling
    Try
      If con.State = ConnectionState.Closed Then con.Open()
      cmdInsert.ExecuteNonQuery()
      Response.Write("Event Added")
    Catch ex As Exception
      Response.Write(ex.Message)
    Finally
      con.Close()
    End Try

    'Clear text boxes
    txtLocation.Text = ""
    Calendar1.SelectedDate = Nothing
    txtTime.Text = ""
    txtMax.Text = ""
    ddlHost.SelectedIndex = -1
    ddlEvent.SelectedIndex = -1


  End Sub


  Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
    'Open user profile page
    Response.Redirect("profile.aspx")
  End Sub
End Class
