Imports System.Data.SqlClient
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.ListBox1.SelectedIndex >= 0 Then
            'something is selected
            Dim RemoteType = ListBox1.SelectedItem.ToString
            MessageBox.Show(RemoteType)
        Else
            'Nothing is
            MessageBox.Show("Remote Type not Selected")
        End If







    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '----------------------------------------
        Dim strConnection As String =
       "Data Source=DB0;Initial Catalog=PRODV4;" _
       & "Integrated Security=True"
        Dim connection1 As SqlConnection = New SqlConnection(strConnection)
        'Dim params(0) As SqlParameter
        'MessageBox.Show(FileToDelete)
        'MessageBox.Show(connection.ConnectionString)
        Dim command As New SqlCommand()

        command.Connection = connection1
        'command.CommandType = CommandType.TableDirect
        command.CommandText = "select distinct C_REMOTETYPE from ADVANCED.mef304
                                where C_REMOTETYPE not in ('50W-2','40GB','40GN','41ER','45ER','50W','50W-1','51ESS','52ESS','M2','INNOV-8','OC','')"

        connection1.Open()
        'MessageBox.Show("Connection Open")
        'command.ExecuteReader()
        'ListBox1.Item.addrange()
        Dim reader As SqlDataReader
        reader = command.ExecuteReader()
        While reader.Read()
            ' MsgBox(reader.Item(0))
            ListBox1.Items.Add(reader.Item(0))
        End While
        'ListBox1.Items.Add(reader.Item(0))
        reader.Close()

        connection1.Close()

        ' MessageBox.Show("Data uploaded please that data is in CIS")

        '----------------------------------------

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
