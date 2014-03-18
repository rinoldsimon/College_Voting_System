Imports System.Data.SqlClient
Public Class frmlogin
    Dim cn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=F:\studies\vb\projects\election vb project\election2\election2\elec.mdf;Integrated Security=True;User Instance=True")

    Dim cmd As New SqlCommand

    Dim dr As SqlDataReader
    Private Sub frmlogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmd.Connection = cn

    End Sub
    Sub clear()
        cmdtype.SelectedIndex = -1
        txtname.Text = ""
        txtpass.Text = ""

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        clear()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If cmdtype.Text = "" Then
            MsgBox("Enter Type")
        ElseIf txtname.Text = "" Then
            MsgBox("Enter Name")
        ElseIf txtpass.Text = "" Then
            MsgBox("Enter Password")
        Else
            cn.Open()
            cmd.CommandText = "select * from tbl_register where usertype='" & cmdtype.Text & "' and username='" & txtname.Text & "' and password='" & txtpass.Text & "'"
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader()

            If (dr.Read() = True) Then

                If cmdtype.Text = "ADMIN" Then

                    Me.Hide()
                    frmwelcome.Show()
                    'ComboBox1.SelectedIndex = -1
                    txtname.Text = ""
                    txtpass.Text = ""

                ElseIf cmdtype.Text = "STUDENT" Then


                    Me.Hide()

                    'menuform.PAYROLLToolStripMenuItem.Visible = False
                    frmwelcome.MASTERToolStripMenuItem.Visible = False
                    'frmwelcome.REPORTSToolStripMenuItem.Visible = False
                    frmwelcome.Show()
                    'ComboBox1.SelectedIndex = -1
                    txtname.Text = ""
                    txtpass.Text = ""
                End If

            Else
                MsgBox("Login Failed")
            End If
        End If
        cn.Close()
    End Sub


    Private Sub EXITToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXITToolStripMenuItem.Click
        If MsgBoxResult.No = MsgBox("DO YOU WANT TO EXIT?", MsgBoxStyle.YesNo) Then Exit Sub
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        frmreg.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmreg.Show()
    End Sub

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label5.Text = DateTime.Now.ToString("yyyy/MMMM/dd | HH:mm:ss")

    End Sub

    
End Class