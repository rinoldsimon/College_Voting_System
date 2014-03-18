Imports System.Data.SqlClient
Public Class frmadvote
    Dim cn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=F:\studies\vb\projects\election vb project\election2\election2\elec.mdf;Integrated Security=True;User Instance=True")

    Dim cmd As New SqlCommand

    Dim dr As SqlDataReader

    Public i As Integer
    Private Sub frmadvote_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmd.Connection = cn
        loadgrid1()
    End Sub


    Sub loadgrid1()
        i = 0
        DataGridView1.Rows.Clear()
        cn.Open()
        'sql = "select * from tbl_vote"
        cmd.CommandText = "select * from tbl_vote"
        dr = cmd.ExecuteReader()
        'If rs.State = 1 Then rs.Close()
        'rs.Open(sql, conn)
        'Do While Not rs.EOF
        If dr.HasRows Then
            While (dr.Read())
                DataGridView1.Rows.Add()
                DataGridView1.Item(0, i).Value = dr(0)
                DataGridView1.Item(1, i).Value = dr(1)
                i = i + 1
                'dr.MoveNext()
            End While
        End If
        cn.Close()
        'Loop
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim sum As Integer

        For a = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(a).Cells(2).Selected = True Then
                cn.Open()
                sum = DataGridView1.Rows(a).Cells(3).Value
                cmd.CommandText = "update tbl_vote set vote=vote + " & sum & "  where post='" & DataGridView1.Rows(a).Cells(0).Value & "' and name='" & DataGridView1.Rows(a).Cells(1).Value & "'"
                cmd.ExecuteNonQuery()
            End If
            cn.Close()
        Next

        MsgBox("Saved Successfully ")
    End Sub
End Class