Imports System.Data.SqlClient
Public Class Modif_passe

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If login.Text = "" Then
            MsgBox("Vous devez saisir le compte utilisateur")
            Exit Sub
        End If
        If pwd1.Text = "" Then
            MsgBox("Vous devez saisir le mot de passe actuel")
            Exit Sub
        End If
        If Pwd2.Text = "" Then
            MsgBox("Vous devez saisir le nouveau mot de passe")
            Exit Sub
        End If
        If Pwd3.Text = "" Then
            MsgBox("Vous devez repéter le nouveau mot de passe")
            Exit Sub
        End If
        If Pwd3.Text <> Pwd2.Text Then
            MsgBox("Vous avez mal saisi le nouveau mot de passe")
            Exit Sub
        End If
        Dim vcon2 As New SqlConnection
        vcon2.ConnectionString = vchaine
        vcon2.Open()
        vcon.Open()
        Dim vsql As String
        vsql = "Select * from utilisateur where login='" & login.Text & "' and pwd='" & pwd1.Text & "'"
        Dim vreader As SqlDataReader
        Dim vcommand1 As New sqlCommand(vsql, vcon)
        vreader = vcommand1.ExecuteReader
        If vreader.Read Then
            vsql = "update Utilisateur set Pwd='" & Pwd2.Text & "' where login='" & login.Text & "' and pwd='" & pwd1.Text & "'"
            'MsgBox(vsql)
            Dim vcommand As New SqlCommand(vsql, vcon2)
            Try
                vcommand.ExecuteNonQuery()
                login.Text = ""
                pwd1.Text = ""
                Pwd2.Text = ""
                Pwd3.Text = ""
                MsgBox("Votre mot de passe a été modifié")
            Catch ex As Exception
                MsgBox(ex.Message)
                vcon.Close()
            End Try
        Else
            MsgBox("Login ou mot de passe incorrect, veuillez recommencer")
        End If

        vcon.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Etes vous sûr de vouloir fermer le formulaire?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class