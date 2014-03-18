Imports System.Data.SqlClient
Public Class frmcandidates
    Dim cn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=F:\studies\vb\projects\election vb project\election2\election2\elec.mdf;Integrated Security=True;User Instance=True")

    Dim cmd As New SqlCommand

    Dim dr As SqlDataReader

    Public i As Integer
    Private Sub frmcandidates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmd.Connection = cn
        'loadlistbox()
        loadgrid()
    End Sub
    'Private Sub loadlistbox()
    '   ListBox1.Items.Clear()
    '  ListBox2.Items.Clear()
    ' ListBox3.Items.Clear()
    'ListBox4.Items.Clear()
    'cmdpost.Text = ""
    'txtname.Text = ""
    ' cmdclass.Text = ""
    'cn.Open()
    'cmd.CommandText = "select name,id from table1"
    '(or)
    'cmd.CommandText = "select * from tbl_candidate"
    'dr = cmd.ExecuteReader()
    'If dr.HasRows Then
    '   While (dr.Read())
    '      ListBox1.Items.Add(dr(0))
    '     ListBox2.Items.Add(dr(1))
    '    ListBox3.Items.Add(dr(2))
    '   ListBox4.Items.Add(dr(3))
    '(or)
    'ListBox1.Items.Add(dr("id"))
    'ListBox2.Items.Add(dr("post"))
    '   End While
    'End If
    'cn.Close()
    'End Sub
    Sub loadgrid()
        i = 0
        DataGridView1.Rows.Clear()
        cn.Open()
        'sql = "select * from tbl_candidate "
        'If rs.State = 1 Then rs.Close()
        'rs.Open(sql, conn)
        'Do While Not rs.EOF
        cmd.CommandText = "select * from tbl_candidate"
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
    Sub clear()
        cmdpost.SelectedIndex = -1
        txtname.Text = ""
        cmdclass.SelectedIndex = -1

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'If cmdpost.Text <> "" And txtname.Text <> "" And cmdclass.Text <> "" Then
        If cmdpost.Text = "" Then
            MsgBox("enter post")
        ElseIf txtname.Text = "" Then
            MsgBox("enter name")
        ElseIf cmdclass.Text = "" Then
            MsgBox("enter degree")
        Else
            cn.Open()


            cmd.CommandText = "select * from tbl_candidate where post='" & cmdpost.Text & "' and name='" & txtname.Text & "' and class='" & cmdclass.Text & "'"
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader()

            If (dr.Read() = True) Then
                MessageBox.Show("Record Exists")
                cn.Close()
            Else
                cn.Close()
                cn.Open()




                cmd.CommandText = "insert into tbl_candidate(post,name,class) values('" & cmdpost.Text & "','" & txtname.Text & "','" & cmdclass.Text & "')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "insert into tbl_vote(post,name,vote) values('" & cmdpost.Text & "','" & txtname.Text & "',0)"
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("Registered successfully")
                'TextBox1.Text = ""
                'TextBox2.Text = ""
                clear()
                'loadlistbox()
                loadgrid()
            End If
        End If


    End Sub

    'Private Sub ListBox1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles ListBox4.MouseClick, ListBox3.MouseClick, ListBox2.MouseClick, ListBox1.MouseClick
    'Dim lb As New ListBox()
    '   lb = sender
    'insert
    '  If lb.SelectedIndex <> -1 Then
    '     ListBox1.SelectedIndex = lb.SelectedIndex
    '    ListBox2.SelectedIndex = lb.SelectedIndex
    '   ListBox3.SelectedIndex = lb.SelectedIndex
    '  ListBox4.SelectedIndex = lb.SelectedIndex
    'update
    'TextBox1.Text = ListBox2.SelectedItem
    ' cmdpost.Text = ListBox2.SelectedItem
    'txtname.Text = ListBox3.SelectedItem
    'cmdclass.Text = ListBox4.SelectedItem

    '    End If

    'End Sub



    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        clear()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If cmdpost.Text <> "" And txtname.Text <> "" And cmdclass.Text <> "" Then
            Dim Confirm = MsgBox("Are you sure you want to delete this record?", vbYesNo, "Deletion Confirmation")
            If Confirm = vbYes Then
                cn.Open()
                'cmd.CommandText = "delete from  tbl_candidate where post='" & cmdpost.Text & "' and name='" & txtname.Text & "' and class='" & cmdclass.Text & "'"
                cmd.CommandText = "delete from tbl_candidate where id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "delete from  tbl_vote where post='" & cmdpost.Text & "' and name='" & txtname.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Record Deleted")
                cn.Close()
                clear()
                'TextBox1.Text = ""
                'TextBox2.Text = ""
                'loadlistbox()
                loadgrid()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'If cmdpost.Text <> "" And txtname.Text <> "" And cmdclass.Text <> "" Then
        If cmdpost.Text = "" Then
            MsgBox("Enter Post")
        ElseIf txtname.Text = "" Then
            MsgBox("Enter Name")
        ElseIf cmdclass.Text = "" Then
            MsgBox("Enter Degree")
        Else
            cn.Open()
            'cmd.CommandText = "update tbl_candidate set post='" & cmdpost.Text & "',name='" & txtname.Text & "',class='" & cmdclass.Text & "' where id='" & ListBox1.SelectedItem & "'"
            cmd.CommandText = "update tbl_candidate set post='" & cmdpost.Text & "',name='" & txtname.Text & "',class='" & cmdclass.Text & "' where id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "update tbl_vote set post='" & cmdpost.Text & "',name='" & txtname.Text & "' where name='" & txtname.Text & "'"
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Record Updated")
            clear()
            'TextBox1.Text = ""
            'TextBox2.Text = ""
            'loadlistbox()
            loadgrid()
        End If
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        cmdpost.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtname.Text = DataGridView1.CurrentRow.Cells(2).Value
        cmdclass.Text = DataGridView1.CurrentRow.Cells(3).Value
    End Sub


End Class