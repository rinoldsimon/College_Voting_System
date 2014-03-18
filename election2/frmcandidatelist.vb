Imports System.Data.SqlClient
Public Class frmcandidatelist
    Dim cn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=F:\studies\vb\projects\election vb project\election2\election2\elec.mdf;Integrated Security=True;User Instance=True")

    Dim cmd As New SqlCommand

    Dim dr As SqlDataReader

    Public i As Integer
    Private Sub frmcandidatelist_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmd.Connection = cn
        loadgrid1()
        loadgrid2()
        loadgrid3()
    End Sub
    Sub loadgrid1()
        i = 0
        DataGridView1.Rows.Clear()
        cn.Open()
        'sql = "select * from tbl_vote where (post = N'PRESIDENT')"
        'If rs.State = 1 Then rs.Close()
        'rs.Open(sql, conn)
        'Do While Not rs.EOF
        cmd.CommandText = "select * from tbl_candidate where (post = N'PRESIDENT')"
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                DataGridView1.Rows.Add()
                DataGridView1.Item(0, i).Value = dr(0)
                DataGridView1.Item(1, i).Value = dr(1)
                DataGridView1.Item(2, i).Value = dr(2)
                DataGridView1.Item(3, i).Value = dr(3)
                i = i + 1
                'rs.MoveNext()
                'Loop
            End While
        End If
        cn.Close()
    End Sub
    Sub loadgrid2()
        i = 0
        DataGridView2.Rows.Clear()
        cn.Open()
        'sql = "select * from tbl_vote where (post = N'SECRETARY')"
        'If rs.State = 1 Then rs.Close()
        'rs.Open(sql, conn)
        'Do While Not rs.EOF
        cmd.CommandText = "select * from tbl_candidate where post = 'SECRETARY'"
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                DataGridView2.Rows.Add()
                DataGridView2.Item(0, i).Value = dr(0)
                DataGridView2.Item(1, i).Value = dr(1)
                DataGridView2.Item(2, i).Value = dr(2)
                DataGridView2.Item(3, i).Value = dr(3)
                i = i + 1
                'rs.MoveNext()
                'Loop
            End While
        End If
        cn.Close()
    End Sub
    Sub loadgrid3()
        i = 0
        DataGridView3.Rows.Clear()
        cn.Open()
        'sql = "select * from tbl_vote where (post = N'JOINT SECRETARY')"
        'If rs.State = 1 Then rs.Close()
        'rs.Open(sql, conn)
        'Do While Not rs.EOF
        cmd.CommandText = "select * from tbl_candidate where (post = N'JOINT SECRETARY')"
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                DataGridView3.Rows.Add()
                DataGridView3.Item(0, i).Value = dr(0)
                DataGridView3.Item(1, i).Value = dr(1)
                DataGridView3.Item(2, i).Value = dr(2)
                DataGridView3.Item(3, i).Value = dr(3)
                i = i + 1
                'rs.MoveNext()
                'Loop
            End While
        End If
        cn.Close()
    End Sub
End Class