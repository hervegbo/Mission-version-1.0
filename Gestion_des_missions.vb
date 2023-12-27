Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class Gestion_des_missions
    Sub vider()
        Matricule.Text = ""
        Nom.Text = ""
        Me.Datenaiss.Text = ""
        Me.Fonction.Text = ""
        Me.Prenom.Text = ""
        Me.Id.Text = NumAuto("Missions", "Id")
        Me.Objet.Text = ""
        Me.Typ_mission.Text = ""
        Me.Pays.Text = ""
        Me.Ville.Text = ""
        Me.debut.Value = Today.Date
        Me.Fin.Value = Today.Date
        Me.Direction.Text = ""
        remplir_datagrid("select * from Missions order by date_debut", DataGridView1)
        Ajouter.Enabled = True
        Modifier.Enabled = False
        Supprimer.Enabled = False
        Annuler.Enabled = False
    End Sub

    Private Sub Ajouter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ajouter.Click
        Dim vsql As String = "Insert into Missions(Id,Objet_miss,Typ_mission,Pays,Ville,Date_debut,Date_fin,Matricule) Values('" & Me.Id.Text & "','" & Me.Objet.Text.Replace("'", "''") & "','" & Me.Typ_mission.Text.Replace("'", "''") & "','" & Me.Pays.Text.Replace("'", "''") & "','" & Me.Ville.Text.Replace("'", "''") & "','" & Me.debut.Value.Date & "','" & Me.Fin.Value.Date & "','" & Me.Matricule.Text & "')"
        'MsgBox(vsql)
        proc_action(vsql)
        If recherche1("Select * from ville where ville='" & Ville.Text.Replace("'", "''") & "' and pays='" & Pays.Text.Replace("'", "''") & "'") = "" Then
            vsql = "Insert into Ville(Ville, pays) values('" & Ville.Text.Replace("'", "''") & "','" & Pays.Text.Replace("'", "''") & "')"
            proc_action(vsql)
        End If
        vider()
    End Sub

    Private Sub Modifier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Modifier.Click
        If MsgBox("Etes vous sûr de vouloir modifier cette mission?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
            Dim vsql As String = "Update Missions set Objet_miss='" & Me.Objet.Text.Replace("'", "''") & "',Typ_mission='" & Me.Typ_mission.Text.Replace("'", "''") & "',Pays='" & Me.Pays.Text.Replace("'", "''") & "',Ville='" & Me.Ville.Text.Replace("'", "''") & "',Date_debut='" & Me.debut.Value.Date & "',Date_fin='" & Me.Fin.Value.Date & "',Matricule='" & Me.Matricule.Text & "' where Id=" & Id.Text
            proc_action(vsql)
            If recherche1("Select * from ville where ville='" & Ville.Text.Replace("'", "''") & "' and pays='" & Pays.Text.Replace("'", "''") & "'") = "" Then
                vsql = "Insert into Ville(Ville, pays) values('" & Ville.Text.Replace("'", "''") & "','" & Pays.Text.Replace("'", "''") & "')"
                proc_action(vsql)
            End If
        End If
        vider()
    End Sub

    Private Sub Supprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Supprimer.Click
        If MsgBox("Etes vous sûr de vouloir supprimer cette mission?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
            Dim vsql As String = "Delete from Missions  where Id=" & Id.Text
            proc_action(vsql)
        End If
        vider()
    End Sub

    Private Sub Ville_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ville.DropDown
        remplir_combo("Select distinct Ville from Ville where Pays='" & Pays.Text.Replace("'", "''") & "'", "Ville", "Ville", Me.Ville)
    End Sub

    Private Sub Pays_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pays.DropDown
        remplir_combo("Select distinct Pays from Ville", "Pays", "Pays", Me.Pays)
    End Sub

    Private Sub Typ_mission_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Typ_mission.SelectedIndexChanged
        If Typ_mission.Text = "Intérieures" Then
            Pays.Text = "Bénin"
        Else
            Pays.Text = ""
        End If
    End Sub

    Private Sub Typ_mission_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Typ_mission.DropDown
        Typ_mission.Items.Clear()
        Typ_mission.Items.Add("Exterieures")
        Typ_mission.Items.Add("Intérieures")
    End Sub

    Private Sub Gestion_des_missions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        vider()
    End Sub

    Private Sub Rech_objet_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rech_objet.TextChanged
        remplir_datagrid("Select * from Missions where Objet_miss like '%" & Rech_objet.Text.Replace("'", "''") & "%' Order by Date_debut", DataGridView1)
    End Sub

    Private Sub Recherche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Recherche.Click
        Rech_emp.Show()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Matricule.Text = DataGridView1.Rows(e.RowIndex).Cells("Matricule").Value.ToString
        Id.Text = DataGridView1.Rows(e.RowIndex).Cells("Id").Value.ToString
        Nom.Text = recherche1("select Nom from employé where matricule='" & Matricule.Text & "'")
        Prenom.Text = recherche1("select Prénom from employé where matricule='" & Matricule.Text & "'")
        Datenaiss.Text = recherche1("select Datnaiss from employé where matricule='" & Matricule.Text & "'")
        Direction.Text = recherche1("select Service from employé where matricule='" & Matricule.Text & "'")
        Fonction.Text = recherche1("select Fonction from employé where matricule='" & Matricule.Text & "'")
        Me.debut.Text = DataGridView1.Rows(e.RowIndex).Cells("Date_debut").Value.ToString
        Me.Typ_mission.Text = DataGridView1.Rows(e.RowIndex).Cells("Typ_mission").Value.ToString
        Me.Pays.Text = DataGridView1.Rows(e.RowIndex).Cells("Pays").Value.ToString
        Me.Ville.Text = DataGridView1.Rows(e.RowIndex).Cells("Ville").Value.ToString
        Me.Fin.Text = DataGridView1.Rows(e.RowIndex).Cells("Date_fin").Value.ToString
        Me.Objet.Text = DataGridView1.Rows(e.RowIndex).Cells("Objet_miss").Value.ToString
        remplir_dgview(List_Rec, "Select * from Mission_rec where Num_mission=" & Id.Text)
        Modifier.Enabled = True
        Supprimer.Enabled = True
        Annuler.Enabled = True
        Ajouter.Enabled = False
    End Sub

    Private Sub Ajouter_rec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ajouter_rec.Click
        Dim i As Integer = NumAuto2("Select Num_rec from Mission_rec where num_mission=" & Id.Text)
        Dim vsql As String = "Insert into Mission_rec(Num_mission, Num_rec, Recomm) Values (" & Id.Text & "," & i & ",'" & Recom.Text.Replace("'", "''") & "')"
        ' MsgBox(vsql)
        proc_action(vsql)
        vider2()
    End Sub
    Sub vider2()
        Recom.Text = ""
        Num_rec.Text = ""
        Ajouter_rec.Enabled = True
        Modifier_rec.Enabled = False
        Supprimer_rec.Enabled = False
        Annuler_rec.Enabled = False
        remplir_dgview(List_Rec, "Select * from Mission_rec where Num_mission=" & Id.Text)
    End Sub

    Private Sub Modifier_rec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Modifier_rec.Click
        Dim vsql As String = "UPDATE Mission_rec set Recomm='" & Recom.Text.Replace("'", "''") & "' where Num_mission=" & Id.Text & " And Num_rec=" & Num_rec.text
        proc_action(vsql)
        vider2()
    End Sub

    Private Sub Supprimer_rec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Supprimer_rec.Click
        Dim vsql As String = "Delete from Mission_rec where Num_mission=" & Id.Text & " And Num_rec=" & Num_rec.Text
        proc_action(vsql)
        vider2()
    End Sub

    Private Sub List_Rec_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles List_Rec.RowHeaderMouseClick
        Recom.Text = List_Rec.Rows(e.RowIndex).Cells("Recomm").Value.ToString
        Num_rec.Text = List_Rec.Rows(e.RowIndex).Cells("Num_rec").Value.ToString
        Ajouter_rec.Enabled = False
        Modifier_rec.Enabled = True
        Supprimer_rec.Enabled = True
        Annuler_rec.Enabled = True
    End Sub

    Private Sub Id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Id.TextChanged
        If Id.Text <> "" Then
            Ajouter_rec.Enabled = True
        Else
            Ajouter_rec.Enabled = False
        End If
    End Sub
End Class
