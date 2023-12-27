<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gestion_des_employés
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1000 = New System.Windows.Forms.Label
        Me.Matricule = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Prenom = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Fermer = New System.Windows.Forms.Button
        Me.Annuler = New System.Windows.Forms.Button
        Me.Supprimer = New System.Windows.Forms.Button
        Me.Modifier = New System.Windows.Forms.Button
        Me.Ajouter = New System.Windows.Forms.Button
        Me.Datnaiss = New System.Windows.Forms.DateTimePicker
        Me.Datembauche = New System.Windows.Forms.DateTimePicker
        Me.Service = New System.Windows.Forms.ComboBox
        Me.Fonction = New System.Windows.Forms.ComboBox
        Me.Diplome = New System.Windows.Forms.ComboBox
        Me.Sexe = New System.Windows.Forms.ComboBox
        Me.Banque = New System.Windows.Forms.TextBox
        Me.SalNetAPE = New System.Windows.Forms.TextBox
        Me.Nation = New System.Windows.Forms.TextBox
        Me.NbEnfant = New System.Windows.Forms.TextBox
        Me.Statut = New System.Windows.Forms.TextBox
        Me.Nom = New System.Windows.Forms.TextBox
        Me.Residence = New System.Windows.Forms.TextBox
        Me.NumSecu = New System.Windows.Forms.TextBox
        Me.IPTSAPE = New System.Windows.Forms.TextBox
        Me.SitFam = New System.Windows.Forms.TextBox
        Me.DateRetraite = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Lieu = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.NumCompte = New System.Windows.Forms.TextBox
        Me.Echelon = New System.Windows.Forms.TextBox
        Me.NomJf = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Domaine = New System.Windows.Forms.TextBox
        Me.Categorie = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RechPrenom = New System.Windows.Forms.TextBox
        Me.RechNom = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1000
        '
        Me.Label1000.AutoSize = True
        Me.Label1000.Location = New System.Drawing.Point(38, 40)
        Me.Label1000.Name = "Label1000"
        Me.Label1000.Size = New System.Drawing.Size(50, 13)
        Me.Label1000.TabIndex = 0
        Me.Label1000.Text = "Matricule"
        '
        'Matricule
        '
        Me.Matricule.Location = New System.Drawing.Point(152, 40)
        Me.Matricule.Name = "Matricule"
        Me.Matricule.Size = New System.Drawing.Size(100, 20)
        Me.Matricule.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nom"
        '
        'Prenom
        '
        Me.Prenom.Location = New System.Drawing.Point(152, 115)
        Me.Prenom.Name = "Prenom"
        Me.Prenom.Size = New System.Drawing.Size(100, 20)
        Me.Prenom.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Fermer)
        Me.GroupBox1.Controls.Add(Me.Annuler)
        Me.GroupBox1.Controls.Add(Me.Supprimer)
        Me.GroupBox1.Controls.Add(Me.Modifier)
        Me.GroupBox1.Controls.Add(Me.Ajouter)
        Me.GroupBox1.Controls.Add(Me.Datnaiss)
        Me.GroupBox1.Controls.Add(Me.Datembauche)
        Me.GroupBox1.Controls.Add(Me.Service)
        Me.GroupBox1.Controls.Add(Me.Fonction)
        Me.GroupBox1.Controls.Add(Me.Diplome)
        Me.GroupBox1.Controls.Add(Me.Sexe)
        Me.GroupBox1.Controls.Add(Me.Banque)
        Me.GroupBox1.Controls.Add(Me.SalNetAPE)
        Me.GroupBox1.Controls.Add(Me.Nation)
        Me.GroupBox1.Controls.Add(Me.NbEnfant)
        Me.GroupBox1.Controls.Add(Me.Statut)
        Me.GroupBox1.Controls.Add(Me.Nom)
        Me.GroupBox1.Controls.Add(Me.Residence)
        Me.GroupBox1.Controls.Add(Me.NumSecu)
        Me.GroupBox1.Controls.Add(Me.Matricule)
        Me.GroupBox1.Controls.Add(Me.IPTSAPE)
        Me.GroupBox1.Controls.Add(Me.SitFam)
        Me.GroupBox1.Controls.Add(Me.DateRetraite)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Lieu)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.NumCompte)
        Me.GroupBox1.Controls.Add(Me.Echelon)
        Me.GroupBox1.Controls.Add(Me.NomJf)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Domaine)
        Me.GroupBox1.Controls.Add(Me.Categorie)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Prenom)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label1000)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(605, 691)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informations personnelles sur l'employé"
        '
        'Fermer
        '
        Me.Fermer.Location = New System.Drawing.Point(399, 609)
        Me.Fermer.Name = "Fermer"
        Me.Fermer.Size = New System.Drawing.Size(75, 23)
        Me.Fermer.TabIndex = 4
        Me.Fermer.Text = "Fermer"
        Me.Fermer.UseVisualStyleBackColor = True
        '
        'Annuler
        '
        Me.Annuler.Location = New System.Drawing.Point(311, 609)
        Me.Annuler.Name = "Annuler"
        Me.Annuler.Size = New System.Drawing.Size(75, 23)
        Me.Annuler.TabIndex = 4
        Me.Annuler.Text = "Annuler"
        Me.Annuler.UseVisualStyleBackColor = True
        '
        'Supprimer
        '
        Me.Supprimer.Location = New System.Drawing.Point(216, 609)
        Me.Supprimer.Name = "Supprimer"
        Me.Supprimer.Size = New System.Drawing.Size(75, 23)
        Me.Supprimer.TabIndex = 4
        Me.Supprimer.Text = "Supprimer"
        Me.Supprimer.UseVisualStyleBackColor = True
        '
        'Modifier
        '
        Me.Modifier.Location = New System.Drawing.Point(118, 609)
        Me.Modifier.Name = "Modifier"
        Me.Modifier.Size = New System.Drawing.Size(75, 23)
        Me.Modifier.TabIndex = 4
        Me.Modifier.Text = "Modifier"
        Me.Modifier.UseVisualStyleBackColor = True
        '
        'Ajouter
        '
        Me.Ajouter.Location = New System.Drawing.Point(23, 609)
        Me.Ajouter.Name = "Ajouter"
        Me.Ajouter.Size = New System.Drawing.Size(75, 23)
        Me.Ajouter.TabIndex = 4
        Me.Ajouter.Text = "Ajouter"
        Me.Ajouter.UseVisualStyleBackColor = True
        '
        'Datnaiss
        '
        Me.Datnaiss.Location = New System.Drawing.Point(152, 225)
        Me.Datnaiss.Name = "Datnaiss"
        Me.Datnaiss.Size = New System.Drawing.Size(110, 20)
        Me.Datnaiss.TabIndex = 3
        '
        'Datembauche
        '
        Me.Datembauche.Location = New System.Drawing.Point(168, 504)
        Me.Datembauche.Name = "Datembauche"
        Me.Datembauche.Size = New System.Drawing.Size(110, 20)
        Me.Datembauche.TabIndex = 3
        '
        'Service
        '
        Me.Service.FormattingEnabled = True
        Me.Service.Location = New System.Drawing.Point(118, 438)
        Me.Service.Name = "Service"
        Me.Service.Size = New System.Drawing.Size(98, 21)
        Me.Service.TabIndex = 2
        '
        'Fonction
        '
        Me.Fonction.FormattingEnabled = True
        Me.Fonction.Location = New System.Drawing.Point(118, 404)
        Me.Fonction.Name = "Fonction"
        Me.Fonction.Size = New System.Drawing.Size(98, 21)
        Me.Fonction.TabIndex = 2
        '
        'Diplome
        '
        Me.Diplome.FormattingEnabled = True
        Me.Diplome.Location = New System.Drawing.Point(116, 363)
        Me.Diplome.Name = "Diplome"
        Me.Diplome.Size = New System.Drawing.Size(98, 21)
        Me.Diplome.TabIndex = 2
        '
        'Sexe
        '
        Me.Sexe.FormattingEnabled = True
        Me.Sexe.Location = New System.Drawing.Point(151, 316)
        Me.Sexe.Name = "Sexe"
        Me.Sexe.Size = New System.Drawing.Size(98, 21)
        Me.Sexe.TabIndex = 2
        '
        'Banque
        '
        Me.Banque.Location = New System.Drawing.Point(473, 472)
        Me.Banque.Name = "Banque"
        Me.Banque.Size = New System.Drawing.Size(100, 20)
        Me.Banque.TabIndex = 1
        '
        'SalNetAPE
        '
        Me.SalNetAPE.Location = New System.Drawing.Point(471, 503)
        Me.SalNetAPE.Name = "SalNetAPE"
        Me.SalNetAPE.Size = New System.Drawing.Size(100, 20)
        Me.SalNetAPE.TabIndex = 1
        '
        'Nation
        '
        Me.Nation.Location = New System.Drawing.Point(469, 218)
        Me.Nation.Name = "Nation"
        Me.Nation.Size = New System.Drawing.Size(100, 20)
        Me.Nation.TabIndex = 1
        '
        'NbEnfant
        '
        Me.NbEnfant.Location = New System.Drawing.Point(473, 356)
        Me.NbEnfant.Name = "NbEnfant"
        Me.NbEnfant.Size = New System.Drawing.Size(100, 20)
        Me.NbEnfant.TabIndex = 1
        '
        'Statut
        '
        Me.Statut.Location = New System.Drawing.Point(471, 71)
        Me.Statut.Name = "Statut"
        Me.Statut.Size = New System.Drawing.Size(100, 20)
        Me.Statut.TabIndex = 1
        '
        'Nom
        '
        Me.Nom.Location = New System.Drawing.Point(152, 78)
        Me.Nom.Name = "Nom"
        Me.Nom.Size = New System.Drawing.Size(100, 20)
        Me.Nom.TabIndex = 1
        '
        'Residence
        '
        Me.Residence.Location = New System.Drawing.Point(471, 318)
        Me.Residence.Name = "Residence"
        Me.Residence.Size = New System.Drawing.Size(100, 20)
        Me.Residence.TabIndex = 1
        '
        'NumSecu
        '
        Me.NumSecu.Location = New System.Drawing.Point(469, 33)
        Me.NumSecu.Name = "NumSecu"
        Me.NumSecu.Size = New System.Drawing.Size(100, 20)
        Me.NumSecu.TabIndex = 1
        '
        'IPTSAPE
        '
        Me.IPTSAPE.Location = New System.Drawing.Point(473, 544)
        Me.IPTSAPE.Name = "IPTSAPE"
        Me.IPTSAPE.Size = New System.Drawing.Size(100, 20)
        Me.IPTSAPE.TabIndex = 1
        '
        'SitFam
        '
        Me.SitFam.Location = New System.Drawing.Point(471, 259)
        Me.SitFam.Name = "SitFam"
        Me.SitFam.Size = New System.Drawing.Size(100, 20)
        Me.SitFam.TabIndex = 1
        '
        'DateRetraite
        '
        Me.DateRetraite.Location = New System.Drawing.Point(168, 544)
        Me.DateRetraite.Name = "DateRetraite"
        Me.DateRetraite.Size = New System.Drawing.Size(100, 20)
        Me.DateRetraite.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(395, 472)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Banque"
        '
        'Lieu
        '
        Me.Lieu.Location = New System.Drawing.Point(152, 266)
        Me.Lieu.Name = "Lieu"
        Me.Lieu.Size = New System.Drawing.Size(100, 20)
        Me.Lieu.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(393, 503)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(81, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Salaire net APE"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(391, 218)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Nationalité"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(40, 510)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(122, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Date de prise de service"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Date de naissance"
        '
        'NumCompte
        '
        Me.NumCompte.Location = New System.Drawing.Point(471, 434)
        Me.NumCompte.Name = "NumCompte"
        Me.NumCompte.Size = New System.Drawing.Size(100, 20)
        Me.NumCompte.TabIndex = 1
        '
        'Echelon
        '
        Me.Echelon.Location = New System.Drawing.Point(469, 149)
        Me.Echelon.Name = "Echelon"
        Me.Echelon.Size = New System.Drawing.Size(100, 20)
        Me.Echelon.TabIndex = 1
        '
        'NomJf
        '
        Me.NomJf.Location = New System.Drawing.Point(150, 156)
        Me.NomJf.Name = "NomJf"
        Me.NomJf.Size = New System.Drawing.Size(100, 20)
        Me.NomJf.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(393, 400)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Domaine d'étude"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(391, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Catégorie"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(40, 407)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Fonction"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Prénom"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(395, 544)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "IPTS APE"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(393, 259)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Situation familiale"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(42, 551)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Date de la retraite"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 266)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Lieu de naissance"
        '
        'Domaine
        '
        Me.Domaine.Location = New System.Drawing.Point(473, 393)
        Me.Domaine.Name = "Domaine"
        Me.Domaine.Size = New System.Drawing.Size(100, 20)
        Me.Domaine.TabIndex = 1
        '
        'Categorie
        '
        Me.Categorie.Location = New System.Drawing.Point(471, 108)
        Me.Categorie.Name = "Categorie"
        Me.Categorie.Size = New System.Drawing.Size(100, 20)
        Me.Categorie.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(367, 434)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Numéro du Compte"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(393, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Echelon"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(393, 318)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Résidence"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(42, 441)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Service"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(391, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Numéro de sécurité sociale"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(395, 359)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Nom bre d'enfants"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nom de jeune fille"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(40, 325)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Sexe"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(393, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Statut"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(42, 366)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Diplôme"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(659, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(695, 691)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Répertoire des employés"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RechPrenom)
        Me.GroupBox3.Controls.Add(Me.RechNom)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Location = New System.Drawing.Point(31, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(637, 77)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rechercher un employé"
        '
        'RechPrenom
        '
        Me.RechPrenom.Location = New System.Drawing.Point(368, 35)
        Me.RechPrenom.Name = "RechPrenom"
        Me.RechPrenom.Size = New System.Drawing.Size(100, 20)
        Me.RechPrenom.TabIndex = 1
        '
        'RechNom
        '
        Me.RechNom.Location = New System.Drawing.Point(104, 35)
        Me.RechNom.Name = "RechNom"
        Me.RechNom.Size = New System.Drawing.Size(100, 20)
        Me.RechNom.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(311, 42)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(43, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Prenom"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(40, 42)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(29, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Nom"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(31, 134)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(637, 527)
        Me.DataGridView1.TabIndex = 0
        '
        'Gestion_des_employés
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 746)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Gestion_des_employés"
        Me.Text = "Gestion_des_employés"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1000 As System.Windows.Forms.Label
    Friend WithEvents Matricule As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Prenom As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Nom As System.Windows.Forms.TextBox
    Friend WithEvents Lieu As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NomJf As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SalNetAPE As System.Windows.Forms.TextBox
    Friend WithEvents Nation As System.Windows.Forms.TextBox
    Friend WithEvents NbEnfant As System.Windows.Forms.TextBox
    Friend WithEvents Statut As System.Windows.Forms.TextBox
    Friend WithEvents Residence As System.Windows.Forms.TextBox
    Friend WithEvents NumSecu As System.Windows.Forms.TextBox
    Friend WithEvents IPTSAPE As System.Windows.Forms.TextBox
    Friend WithEvents SitFam As System.Windows.Forms.TextBox
    Friend WithEvents DateRetraite As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents NumCompte As System.Windows.Forms.TextBox
    Friend WithEvents Echelon As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Domaine As System.Windows.Forms.TextBox
    Friend WithEvents Categorie As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RechPrenom As System.Windows.Forms.TextBox
    Friend WithEvents RechNom As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Sexe As System.Windows.Forms.ComboBox
    Friend WithEvents Service As System.Windows.Forms.ComboBox
    Friend WithEvents Fonction As System.Windows.Forms.ComboBox
    Friend WithEvents Diplome As System.Windows.Forms.ComboBox
    Friend WithEvents Datembauche As System.Windows.Forms.DateTimePicker
    Friend WithEvents Banque As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Ajouter As System.Windows.Forms.Button
    Friend WithEvents Annuler As System.Windows.Forms.Button
    Friend WithEvents Supprimer As System.Windows.Forms.Button
    Friend WithEvents Modifier As System.Windows.Forms.Button
    Friend WithEvents Fermer As System.Windows.Forms.Button
    Friend WithEvents Datnaiss As System.Windows.Forms.DateTimePicker
End Class
