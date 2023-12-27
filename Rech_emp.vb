Public Class Rech_emp

    Private Sub Rech_emp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        remplir_datagrid("Select * from Employé Order by Nom, Prénom", DataGridView1)
    End Sub

    Private Sub RechNom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RechNom.TextChanged, RechPrenom.TextChanged
        Dim vsql As String = "Select * from Employé where nom like '" & RechNom.Text & "%' and prénom like '" & RechPrenom.Text & "%' Order by nom, prénom"
        remplir_datagrid(vsql, DataGridView1)
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        'Enregistrer_mission.Matricule.Text = DataGridView1.Rows(e.RowIndex).Cells("Matricule").Value.ToString
        'Gestion_des_missions.Nom.Text = DataGridView1.Rows(e.RowIndex).Cells("Nom").Value.ToString
        'Gestion_des_missions.Prenom.Text = DataGridView1.Rows(e.RowIndex).Cells("Prénom").Value.ToString
        'Gestion_des_missions.Direction.Text = DataGridView1.Rows(e.RowIndex).Cells("Service").Value.ToString
        'Gestion_des_missions.Fonction.Text = DataGridView1.Rows(e.RowIndex).Cells("Fonction").Value.ToString
        'Gestion_des_missions.Datenaiss.Text = DataGridView1.Rows(e.RowIndex).Cells("Datnaiss").Value.ToString
        Me.Close()
    End Sub
End Class