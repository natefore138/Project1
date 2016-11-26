Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class FindEvents
  Inherits System.Web.UI.Page
  Public Shared conS As String = "Server=DESKTOP-NP2V6BB;Database= NFore ;Trusted_Connection=Yes;"
  Public Shared con As SqlConnection = New SqlConnection(conS)

  Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
    'Validate event type is selected
    If ddlEvents.SelectedIndex <= 0 Then
      Response.Write("Select an event.")
      Exit Sub
    End If

    'Show current events based on type of activity selected
    '*******INSTEAD OF DROP DOWN - LET USER SEARCH BY TEXTBOX - USE SOME KIND OF WILDCARD TO RETURN CLOSE RESULTS,


    '***** STILL NEED TO REMOVE TIME FROM DATE AND FIND A WAY TO HIDE EVENT ID COL************
    '***** NEED TO CODE IT TO NOT DISPLAY EVENTS THAT ARE IN THE PAST *********

    'Display event type, location, time, and a contact e-mail from user table (uses inner join)
    Dim daFindEvents As New SqlDataAdapter("Select events.EventType as [Event Type], events.Location as [Location], events.Date as [Date],events.Time as [Time], users.Email as [Contact], eventID from events Inner Join users On events.UserID = users.UserID where EventType = @p1", con)
    With daFindEvents.SelectCommand.Parameters
      .Clear()
      .AddWithValue("@p1", ddlEvents.SelectedItem.Text)
    End With

    Dim dtEvents As New DataTable

    daFindEvents.Fill(dtEvents)

    Try
      GridView1.DataSource = dtEvents
      GridView1.DataBind()
    Catch ex As Exception
      Response.Write(ex.Message)
    Finally
      con.Close()
    End Try
  End Sub

  Protected Sub btnAnalytics_Click(sender As Object, e As EventArgs) Handles btnAnalytics.Click
    '************NEED TO EITHER MAKE THIS HAVE IT'S OWN UNIQUE GRIDVIEW OR FIND WAY TO REMOVE BUTTONS FOR THIS INSTANCE********
    'OR CODE BUTTONS TO DO SOMETHING OF VALUE
    'Show number of events by event type - uses group by
    Dim GroupByDA As New SqlDataAdapter("Select EventType As [Event Type], count(EventID) as [Number of Events]  from events Group By EventType", con)

    Dim dtGroupby As New DataTable

    Try
      If dtGroupby.Rows.Count > 0 Then dtGroupby.Rows.Clear()
      con.Open()
      GroupByDA.Fill(dtGroupby)
      GridView1.DataSource = dtGroupby
      DataBind()

    Catch ex As Exception
      Response.Write(ex.Message)
    Finally
      con.Close()
    End Try
  End Sub


  Protected Sub btnHost_Click(sender As Object, e As EventArgs) Handles btnHost.Click
    'Show number of events by each host - uses inner join and group by.
    '************NEED TO EITHER MAKE THIS HAVE IT'S OWN UNIQUE GRIDVIEW OR FIND WAY TO REMOVE BUTTONS FOR THIS INSTANCE********
    Dim GroupByDA As New SqlDataAdapter("Select users.Name as [Host], COUNT(events.EventID) as [Number of Events] From users Inner Join events On users.UserID = events.UserID Group By users.Name", con)

    Dim dtGroupby As New DataTable

    Try
      If dtGroupby.Rows.Count > 0 Then dtGroupby.Rows.Clear()
      con.Open()
      GroupByDA.Fill(dtGroupby)
      GridView1.DataSource = dtGroupby
      DataBind()
    Catch ex As Exception
      Response.Write(ex.Message)
    Finally
      con.Close()
    End Try
  End Sub


  Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
    'This code handles the buttons in the gridview
    If e.CommandName = "Attend" Then
      Dim index As Integer = Convert.ToInt32(e.CommandArgument)
      ' Retrieve the row that contains the button clicked 
      ' by the user from the Rows collection.
      Dim row As GridViewRow = GridView1.Rows(index)

      'Insert event into attending table
      Dim cmd As New SqlCommand("Insert into [attending] (userName, eventID) Values (@p1, @p2)", con)

      With cmd.Parameters
        .Clear()
        .AddWithValue("@p1", Session("userName"))
        .AddWithValue("@p2", CInt(Server.HtmlDecode(row.Cells(6).Text)))
      End With

      'Exception handling
      Try
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        Response.Write("Event Added")
      Catch ex As Exception
        Response.Write(ex.Message)
      Finally
        con.Close()
      End Try
    End If
  End Sub

  Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
    'Opens user profile page
    Response.Redirect("profile.aspx")
  End Sub
End Class
