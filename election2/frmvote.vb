Imports System.Data.SqlClient
Public Class frmvote
    Dim cn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=F:\studies\vb\projects\election vb project\election2\election2\elec.mdf;Integrated Security=True;User Instance=True")

    Dim cmd As New SqlCommand

    Dim dr As SqlDataReader

    Public i As Integer
    Private Sub frmvote_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmd.Connection = cn
        loadpresident()
        loadjoint()
        loadsecretary()
        Label4.Text = DateTime.Now.ToString("yyyy/MMMM/dd")
    End Sub
    Sub loadpresident()
        i = 0
        DataGridView1.Rows.Clear()
        cn.Open()
        'Sql = " SELECT     name, post"
        'sql = sql + " FROM         dbo.tbl_candidate"
        'sql = sql + " WHERE     (post = N'PRESIDENT')"
        'If rs.State = 1 Then rs.Close()
        'rs.Open(sql, conn)
        'Do While Not rs.EOF
        cmd.CommandText = "select name,post from tbl_candidate where (post = N'PRESIDENT')"
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                DataGridView1.Rows.Add()
                DataGridView1.Item(0, i).Value = dr(0)
                i = i + 1
                'rs.MoveNext()

                'Loop
            End While
        End If
        cn.Close()
    End Sub
    Sub loadsecretary()
        i = 0
        DataGridView2.Rows.Clear()
        cn.Open()
        'sql = " SELECT     name, post"
        'sql = sql + " FROM         dbo.tbl_candidate"
        'sql = sql + " WHERE     (post = N'SECRETARY')"
        'If rs.State = 1 Then rs.Close()
        'rs.Open(sql, conn)
        'Do While Not rs.EOF
        cmd.CommandText = "select name,post from tbl_candidate where (post = N'SECRETARY')"
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                DataGridView2.Rows.Add()
                DataGridView2.Item(0, i).Value = dr(0)
                i = i + 1
                'rs.MoveNext()

                'Loop
            End While
        End If
        cn.Close()
    End Sub
    Sub loadjoint()
        i = 0
        DataGridView3.Rows.Clear()
        cn.Open()
        'sql = " SELECT     name, post"
        'sql = sql + " FROM         dbo.tbl_candidate"
        'sql = sql + " WHERE     (post = N'JOINT SECRETARY')"
        'If rs.State = 1 Then rs.Close()
        'rs.Open(sql, conn)
        'Do While Not rs.EOF
        cmd.CommandText = "select name,post from tbl_candidate where (post = N'JOINT SECRETARY')"
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                DataGridView3.Rows.Add()
                DataGridView3.Item(0, i).Value = dr(0)
                i = i + 1
                'rs.MoveNext()

                'Loop
            End While
        End If
        cn.Close()
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        frmwelcome.Show()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        DataGridView1.Visible = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        DataGridView2.Visible = True
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        DataGridView3.Visible = True
    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        For a = 0 To DataGridView1.Rows.Count - 1

            If DataGridView1.Rows(a).Cells(1).Selected = True Then
                cn.Open()
                cmd.CommandText = " update tbl_vote set vote= vote+1 where post='" & Button1.Text & "' and name= '" & DataGridView1.Rows(a).Cells(0).Value & "'"
                cmd.ExecuteNonQuery()
                cn.Close()

            End If
        Next
        DataGridView1.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub DataGridView2_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        For a = 0 To DataGridView2.Rows.Count - 1

            If DataGridView2.Rows(a).Cells(1).Selected = True Then
                cn.Open()
                cmd.CommandText = " update tbl_vote set vote= vote+1 where post='" & Button2.Text & "' and name= '" & DataGridView2.Rows(a).Cells(0).Value & "'"
                cmd.ExecuteNonQuery()
                cn.Close()

            End If
        Next
        DataGridView2.Enabled = False
        Button2.Enabled = False
    End Sub

    Private Sub DataGridView3_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        For a = 0 To DataGridView3.Rows.Count - 1

            If DataGridView3.Rows(a).Cells(1).Selected = True Then
                cn.Open()
                cmd.CommandText = " update tbl_vote set vote= vote+1 where post='" & Button3.Text & "' and name= '" & DataGridView3.Rows(a).Cells(0).Value & "'"
                cmd.ExecuteNonQuery()
                cn.Close()

            End If
        Next
        DataGridView3.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Close()
        frmwelcome.Show()
        frmwelcome.VOTINGToolStripMenuItem.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label5.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub
End Class