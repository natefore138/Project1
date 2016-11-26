Imports System.Data
Imports System.Data.SqlClient

Partial Class Profile
  Inherits System.Web.UI.Page

  'Connection String
  Public Shared conS As String = "Server=DESKTOP-NP2V6BB;Database= NFore ;Trusted_Connection=Yes;"
  Public Shared con As SqlConnection = New SqlConnection(conS)

  Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    'Get the User Name from the session variable - everything will be populated based off the user name
    Dim userName As String = CType(Session.Item("userName"), String)
    lblUser.Text = userName
    image1.ImageUrl = "images/redbird.png"

    'Populate Name, Email, Phone Number
    Dim cmdGetName As New SqlCommand("Select Name From users Where UserName = @p1", con)
    Dim cmdGetEmail As New SqlCommand("Select Email From users Where UserName = @p2", con)
    Dim cmdGetPhoneNum As New SqlCommand("Select PhoneNumber From users Where UserName = @p3", con)

    '*******STILL NEEDS TO BE COMPLETED - RETRIEVE IMAGE FROM DATABASE TO DISPLAY*************

    'Name
    With cmdGetName.Parameters
      .Clear()
      .AddWithValue("@p1", userName)
    End With

    'Email
    With cmdGetEmail.Parameters
      .Clear()
      .AddWithValue("@p2", userName)
    End With

    'Phone Number
    With cmdGetPhoneNum.Parameters
      .Clear()
      .AddWithValue("@p3", userName)
    End With

    'Add info to appropriate textboxes
    Try
      If con.State = ConnectionState.Closed Then con.Open()
      lblName.Text = cmdGetName.ExecuteScalar
      lblEmail.Text = cmdGetEmail.ExecuteScalar
      lblPhone.Text = cmdGetPhoneNum.ExecuteScalar
    Catch ex As Exception
      Response.Write(ex.Message)
    Finally
      con.Close()
    End Try

    'Display events user is hosting
    '**************NEEDS TO BE DONE - SIMILAR TO BELOW******************


    'Display events user is attending
    'Show Events user is currently attending - DOES NOT SHOW PAST EVENTS 
    '**********MAYBE MAKE AN ANALYTIC FORM THAT HAS A CHART OF A USERS PAST EVENTS*********
    Dim Da As New SqlDataAdapter("Select EventType as [Event], Location as [Where], Date as [When], time as [Time] from events Inner Join attending On events.eventID = attending.eventID and attending.UserName = @p1 and events.Date >= @p2", con)

    'Add username to parameter
    With Da.SelectCommand.Parameters
      .Clear()
      .AddWithValue("@p1", Session("userName"))
      .AddWithValue("@p2", Now)
    End With

    Dim dt As New DataTable
    'Fill the grid view for events user is attending
    Try
      If dt.Rows.Count > 0 Then dt.Rows.Clear()
      con.Open()
      Da.Fill(dt)
      gvAttending.DataSource = dt
      DataBind()
    Catch ex As Exception
      Response.Write(ex.Message)
    Finally
      con.Close()
    End Try
  End Sub

  Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
    'Open Find Events Page
    Response.Redirect("FindEvents.aspx")
  End Sub


  Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    'Open Submit Events Page
    Response.Redirect("events.aspx")
  End Sub

  Protected Sub lbLogOut_Click(sender As Object, e As EventArgs) Handles lbLogOut.Click
    'End Session Variable
    Session("userName") = ""
    'Return to Log in page
    Response.Redirect("LogIn.aspx")
  End Sub
End Class
