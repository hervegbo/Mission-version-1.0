Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class Gestion_des_employés
    Sub vider()
        Matricule.Text = ""
        Nom.Text = ""
        Me.Banque.Text = ""
        Me.Categorie.Text = ""
        Me.Datembauche.Text = ""
        Me.DateRetraite.Text = ""
        Me.Datnaiss.Text = ""
        Me.Diplome.Text = ""
        Me.Domaine.Text = ""
        Me.Echelon.Text = ""
        Me.Fonction.Text = ""
        Me.IPTSAPE.Text = ""
        Me.Lieu.Text = ""
        Me.Nation.Text = ""
        Me.NbEnfant.Text = ""
        Me.NomJf.Text = ""
        Me.NumCompte.Text = ""
        Me.NumSecu.Text = ""
        Me.Prenom.Text = ""
        Me.RechNom.Text = ""
        Me.RechPrenom.Text = ""
        Me.Residence.Text = ""
        Me.SalNetAPE.Text = ""
        Me.Service.Text = ""
        Me.Sexe.Text = ""
        Me.SitFam.Text = ""
        Me.Statut.Text = ""
        'Me..Text = ""
        remplir_datagrid("select * from employé order by nom, prénom", DataGridView1)
        Ajouter.Enabled = True
        Modifier.Enabled = False
        Supprimer.Enabled = False
        Annuler.Enabled = False

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Matricule.Text = DataGridView1.Rows(e.RowIndex).Cells("Matricule").Value.ToString
        Nom.Text = DataGridView1.Rows(e.RowIndex).Cells("Nom").Value.ToString
        Me.Banque.Text = DataGridView1.Rows(e.RowIndex).Cells("Banque").Value.ToString
        Me.Categorie.Text = DataGridView1.Rows(e.RowIndex).Cells("Categorie").Value.ToString
        Try
            Me.Datembauche.Value = DataGridView1.Rows(e.RowIndex).Cells("Datprise").Value.ToString
            Me.DateRetraite.Text = DataGridView1.Rows(e.RowIndex).Cells("DatFin").Value.ToString

        Catch ex As Exception
            Me.Datembauche.Value = Today.Date
            Me.DateRetraite.Text = ""
        End Try
        Try
            Me.Datnaiss.Value = DataGridView1.Rows(e.RowIndex).Cells("Datnaiss").Value.ToString
        Catch ex As Exception
            Me.Datnaiss.Value = Today.Date
        End Try
        Me.Diplome.Text = DataGridView1.Rows(e.RowIndex).Cells("Diplome").Value.ToString
        Me.Domaine.Text = DataGridView1.Rows(e.RowIndex).Cells("CodDom").Value.ToString
        Me.Echelon.Text = DataGridView1.Rows(e.RowIndex).Cells("Echelon").Value.ToString
        Me.Fonction.Text = DataGridView1.Rows(e.RowIndex).Cells("Fonction").Value.ToString
        Me.IPTSAPE.Text = DataGridView1.Rows(e.RowIndex).Cells("IptsApe").Value.ToString
        Me.Lieu.Text = DataGridView1.Rows(e.RowIndex).Cells("Lieu").Value.ToString
        Me.Nation.Text = DataGridView1.Rows(e.RowIndex).Cells("Nation").Value.ToString
        Me.NbEnfant.Text = DataGridView1.Rows(e.RowIndex).Cells("Enfant").Value.ToString
        Me.NomJf.Text = DataGridView1.Rows(e.RowIndex).Cells("NomJF").Value.ToString
        Me.NumCompte.Text = DataGridView1.Rows(e.RowIndex).Cells("NumCompte").Value
        Me.NumSecu.Text = DataGridView1.Rows(e.RowIndex).Cells("SécuSoc").Value.ToString
        Me.Prenom.Text = DataGridView1.Rows(e.RowIndex).Cells("Prénom").Value.ToString
        Me.Residence.Text = DataGridView1.Rows(e.RowIndex).Cells("Residence").Value.ToString
        Me.SalNetAPE.Text = DataGridView1.Rows(e.RowIndex).Cells("SalnetApe").Value
        Me.Service.Text = DataGridView1.Rows(e.RowIndex).Cells("Service").Value.ToString
        Me.Sexe.Text = DataGridView1.Rows(e.RowIndex).Cells("Sexe").Value.ToString
        Me.SitFam.Text = DataGridView1.Rows(e.RowIndex).Cells("SitFam").Value.ToString
        Me.Statut.Text = DataGridView1.Rows(e.RowIndex).Cells("Statut").Value.ToString
        Ajouter.Enabled = False
        Modifier.Enabled = True
        Supprimer.Enabled = True
        Annuler.Enabled = True

    End Sub

    Private Sub Ajouter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ajouter.Click
        Dim vsql As String = "Insert into Employé(Matricule,Nom, NomJF,Prénom,Datnaiss,Sexe,Diplome,Fonction, Service,Datprise, Datfin,SécuSoc,Statut,Categorie,Echelon,Nation,SitFam,Residence,Enfant,Coddom,Numcompte,Banque,IptsApe,SalnetApe) Values('" & Me.Label1000.Text & "','" & Me.Nom.Text & "','" & Me.NomJf.Text & "','" & Me.Prenom.Text & "','" & Me.Datnaiss.Text & "','" & Me.Sexe.Text & "','" & Me.Diplome.Text & "','" & Me.Fonction.Text & "','" & Me.Service.Text & "','" & Me.Datembauche.Text & "','" & Me.DateRetraite.Text & "','" & Me.NumSecu.Text & "','" & Me.Statut.Text & "','" & Me.Categorie.Text & "','" & Me.Echelon.Text & "','" & Me.Nation.Text & "','" & Me.SitFam.Text & "','" & Me.Residence.Text & "'," & Me.NbEnfant.Text & ",'" & Me.Domaine.Text & "','" & Me.NumCompte.Text & "','" & Me.Banque.Text & "'," & Me.IPTSAPE.Text & "," & Me.SalNetAPE.Text & ")"
        proc_action(vsql)
        vider()
    End Sub

    Private Sub Modifier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Modifier.Click
        Dim vsql As String = "Update Employé set Nom='" & Nom.Text.Replace("'", "''") & "', NomJF='" & NomJf.Text.Replace("'", "''") & "',Prénom='" & Me.Prenom.Text.Replace("'", "''") & "',Datnaiss='" & Me.Datnaiss.Value.Date & "',Sexe='" & Sexe.Text & "',Diplome='" & Me.Diplome.Text.Replace("'", "''") & "',Fonction='" & Fonction.Text.Replace("'", "''") & "', Service='" & Service.Text.Replace("'", "''") & "',Datprise='" & Datembauche.Value.Date & "', Datfin='" & DateRetraite.Text & "',SécuSoc='" & NumSecu.Text & "',Statut='" & Statut.Text.Replace("'", "''") & "',Categorie='" & Categorie.Text & "',Echelon='" & Me.Echelon.Text & "',Nation='" & Me.Nation.Text.Replace("'", "''") & "',SitFam='" & Me.SitFam.Text.Replace("'", "''") & "',Residence='" & Me.Residence.Text.Replace("'", "''") & "',Enfant=" & Me.NbEnfant.Text & ",Coddom='" & Me.Domaine.Text.Replace("'", "''") & "',Numcompte='" & Me.NumCompte.Text & "',Banque='" & Me.Banque.Text.Replace("'", "''") & "',IptsApe=" & Me.IPTSAPE.Text & ",SalnetApe=" & Me.SalNetAPE.Text & " Where Matricule='" & Matricule.Text & "'"
        proc_action(vsql)
        vider()
    End Sub

    Private Sub Supprimer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Supprimer.Click
        Dim vsql As String = "Update Employé set Nom='" & Nom.Text.Replace("'", "''") & "', NomJF='" & NomJf.Text.Replace("'", "''") & "',Prénom='" & Me.Prenom.Text.Replace("'", "''") & "',Datnais='" & Me.Datnaiss.Value.Date & "',Sexe='" & Sexe.Text & "',Diplome='" & Me.Diplome.Text.Replace("'", "''") & "',Fonction='" & Fonction.Text.Replace("'", "''") & "', Service='" & Service.Text.Replace("'", "''") & "',Datprise='" & Datembauche.Value.Date & "', Datfin='" & DateRetraite.Text & "',SécuSoc='" & NumSecu.Text & "',Statut='" & Statut.Text.Replace("'", "''") & "',Categorie='" & Categorie.Text & "',Echelon='" & Me.Echelon.Text & "',Nation='" & Me.Nation.Text.Replace("'", "''") & "',SitFam='" & Me.SitFam.Text.Replace("'", "''") & "',Residence='" & Me.Residence.Text.Replace("'", "''") & "',Enfant=" & Me.NbEnfant.Text & ",Coddom='" & Me.Domaine.Text.Replace("'", "''") & "',Numcompte='" & Me.NumCompte.Text & "',Banque='" & Me.Banque.Text.Replace("'", "''") & "',IptsApe=" & Me.IPTSAPE.Text & ",SalnetApe=" & Me.SalNetAPE.Text & " Where Matricule='" & Label1000.Text & "'"
        proc_action(vsql)
        vider()
    End Sub

    Private Sub Gestion_des_employés_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        vider()
    End Sub

    Private Sub RechNom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RechNom.TextChanged, RechPrenom.TextChanged
        Dim vsql As String = "Select * from Employé where nom like '" & RechNom.Text & "%' and prénom like '" & RechPrenom.Text & "%' Order by nom, prénom"
        remplir_datagrid(vsql, DataGridView1)
    End Sub
End Class