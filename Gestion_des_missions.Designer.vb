<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gestion_des_missions
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Fin = New System.Windows.Forms.DateTimePicker
        Me.debut = New System.Windows.Forms.DateTimePicker
        Me.Ville = New System.Windows.Forms.ComboBox
        Me.Pays = New System.Windows.Forms.ComboBox
        Me.Typ_mission = New System.Windows.Forms.ComboBox
        Me.Objet = New System.Windows.Forms.TextBox
        Me.Id = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Recherche = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Fonction = New System.Windows.Forms.Label
        Me.Prenom = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Datenaiss = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Direction = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Nom = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Matricule = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label12 = New System.Windows.Forms.Label
        Me.Rech_objet = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Annuler = New System.Windows.Forms.Button
        Me.Supprimer = New System.Windows.Forms.Button
        Me.Modifier = New System.Windows.Forms.Button
        Me.Ajouter = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Annuler_rec = New System.Windows.Forms.Button
        Me.Supprimer_rec = New System.Windows.Forms.Button
        Me.Modifier_rec = New System.Windows.Forms.Button
        Me.Ajouter_rec = New System.Windows.Forms.Button
        Me.Recom = New System.Windows.Forms.TextBox
        Me.List_Rec = New System.Windows.Forms.DataGridView
        Me.Num_rec = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.List_Rec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numéro de la mission"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 81)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Type de la mission"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 129)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Pays"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 335)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Date de fin"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 163)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Ville"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 197)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Objet"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 301)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Date de début"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(511, 9)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(222, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "GESTION DES MISSIONS"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Fin)
        Me.GroupBox1.Controls.Add(Me.debut)
        Me.GroupBox1.Controls.Add(Me.Ville)
        Me.GroupBox1.Controls.Add(Me.Pays)
        Me.GroupBox1.Controls.Add(Me.Typ_mission)
        Me.GroupBox1.Controls.Add(Me.Objet)
        Me.GroupBox1.Controls.Add(Me.Id)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 106)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(516, 369)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INFORMATIONS SUR LA MISSION"
        '
        'Fin
        '
        Me.Fin.Location = New System.Drawing.Point(203, 335)
        Me.Fin.Name = "Fin"
        Me.Fin.Size = New System.Drawing.Size(184, 26)
        Me.Fin.TabIndex = 3
        '
        'debut
        '
        Me.debut.Location = New System.Drawing.Point(203, 301)
        Me.debut.Name = "debut"
        Me.debut.Size = New System.Drawing.Size(184, 26)
        Me.debut.TabIndex = 3
        '
        'Ville
        '
        Me.Ville.FormattingEnabled = True
        Me.Ville.Location = New System.Drawing.Point(204, 163)
        Me.Ville.Name = "Ville"
        Me.Ville.Size = New System.Drawing.Size(187, 28)
        Me.Ville.TabIndex = 2
        '
        'Pays
        '
        Me.Pays.FormattingEnabled = True
        Me.Pays.Location = New System.Drawing.Point(204, 121)
        Me.Pays.Name = "Pays"
        Me.Pays.Size = New System.Drawing.Size(190, 28)
        Me.Pays.TabIndex = 2
        '
        'Typ_mission
        '
        Me.Typ_mission.FormattingEnabled = True
        Me.Typ_mission.Location = New System.Drawing.Point(204, 78)
        Me.Typ_mission.Name = "Typ_mission"
        Me.Typ_mission.Size = New System.Drawing.Size(190, 28)
        Me.Typ_mission.TabIndex = 2
        '
        'Objet
        '
        Me.Objet.Location = New System.Drawing.Point(203, 197)
        Me.Objet.Multiline = True
        Me.Objet.Name = "Objet"
        Me.Objet.Size = New System.Drawing.Size(306, 86)
        Me.Objet.TabIndex = 1
        '
        'Id
        '
        Me.Id.Enabled = False
        Me.Id.Location = New System.Drawing.Point(203, 37)
        Me.Id.Name = "Id"
        Me.Id.Size = New System.Drawing.Size(191, 26)
        Me.Id.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Recherche)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Fonction)
        Me.GroupBox2.Controls.Add(Me.Prenom)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Datenaiss)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Direction)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Nom)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Matricule)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 485)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(504, 253)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "INFORMATIONS SUR L'AGENT"
        '
        'Recherche
        '
        Me.Recherche.Location = New System.Drawing.Point(350, 35)
        Me.Recherche.Name = "Recherche"
        Me.Recherche.Size = New System.Drawing.Size(106, 42)
        Me.Recherche.TabIndex = 2
        Me.Recherche.Text = "Recherche"
        Me.Recherche.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(40, 73)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 20)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Nom"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(40, 224)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 20)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Fonction"
        '
        'Fonction
        '
        Me.Fonction.AutoSize = True
        Me.Fonction.Location = New System.Drawing.Point(250, 224)
        Me.Fonction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Fonction.Name = "Fonction"
        Me.Fonction.Size = New System.Drawing.Size(0, 20)
        Me.Fonction.TabIndex = 0
        '
        'Prenom
        '
        Me.Prenom.AutoSize = True
        Me.Prenom.Location = New System.Drawing.Point(250, 108)
        Me.Prenom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Prenom.Name = "Prenom"
        Me.Prenom.Size = New System.Drawing.Size(0, 20)
        Me.Prenom.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 182)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(159, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Date de naissance"
        '
        'Datenaiss
        '
        Me.Datenaiss.AutoSize = True
        Me.Datenaiss.Location = New System.Drawing.Point(250, 182)
        Me.Datenaiss.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Datenaiss.Name = "Datenaiss"
        Me.Datenaiss.Size = New System.Drawing.Size(0, 20)
        Me.Datenaiss.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 144)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Direction"
        '
        'Direction
        '
        Me.Direction.AutoSize = True
        Me.Direction.Location = New System.Drawing.Point(250, 144)
        Me.Direction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Direction.Name = "Direction"
        Me.Direction.Size = New System.Drawing.Size(0, 20)
        Me.Direction.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(40, 38)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 20)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Matricule"
        '
        'Nom
        '
        Me.Nom.AutoSize = True
        Me.Nom.Location = New System.Drawing.Point(250, 73)
        Me.Nom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Nom.Name = "Nom"
        Me.Nom.Size = New System.Drawing.Size(0, 20)
        Me.Nom.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(40, 108)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 20)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Prénom"
        '
        'Matricule
        '
        Me.Matricule.AutoSize = True
        Me.Matricule.Location = New System.Drawing.Point(250, 38)
        Me.Matricule.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Matricule.Name = "Matricule"
        Me.Matricule.Size = New System.Drawing.Size(0, 20)
        Me.Matricule.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Rech_objet)
        Me.GroupBox3.Location = New System.Drawing.Point(564, 110)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(803, 317)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "REPERTOIRE DES MISSIONS"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(22, 89)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(915, 216)
        Me.DataGridView1.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 41)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(161, 20)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Objet de la mission"
        '
        'Rech_objet
        '
        Me.Rech_objet.Location = New System.Drawing.Point(207, 38)
        Me.Rech_objet.Name = "Rech_objet"
        Me.Rech_objet.Size = New System.Drawing.Size(191, 26)
        Me.Rech_objet.TabIndex = 1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Annuler)
        Me.GroupBox5.Controls.Add(Me.Supprimer)
        Me.GroupBox5.Controls.Add(Me.Modifier)
        Me.GroupBox5.Controls.Add(Me.Ajouter)
        Me.GroupBox5.Location = New System.Drawing.Point(297, 32)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(632, 55)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'Annuler
        '
        Me.Annuler.Location = New System.Drawing.Point(445, 15)
        Me.Annuler.Name = "Annuler"
        Me.Annuler.Size = New System.Drawing.Size(90, 33)
        Me.Annuler.TabIndex = 4
        Me.Annuler.Text = "Annuler"
        Me.Annuler.UseVisualStyleBackColor = True
        '
        'Supprimer
        '
        Me.Supprimer.Location = New System.Drawing.Point(313, 15)
        Me.Supprimer.Name = "Supprimer"
        Me.Supprimer.Size = New System.Drawing.Size(111, 33)
        Me.Supprimer.TabIndex = 5
        Me.Supprimer.Text = "Supprimer"
        Me.Supprimer.UseVisualStyleBackColor = True
        '
        'Modifier
        '
        Me.Modifier.Location = New System.Drawing.Point(199, 15)
        Me.Modifier.Name = "Modifier"
        Me.Modifier.Size = New System.Drawing.Size(88, 33)
        Me.Modifier.TabIndex = 2
        Me.Modifier.Text = "Modifier"
        Me.Modifier.UseVisualStyleBackColor = True
        '
        'Ajouter
        '
        Me.Ajouter.Location = New System.Drawing.Point(99, 15)
        Me.Ajouter.Name = "Ajouter"
        Me.Ajouter.Size = New System.Drawing.Size(75, 33)
        Me.Ajouter.TabIndex = 3
        Me.Ajouter.Text = "Ajouter"
        Me.Ajouter.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Annuler_rec)
        Me.GroupBox4.Controls.Add(Me.Supprimer_rec)
        Me.GroupBox4.Controls.Add(Me.Modifier_rec)
        Me.GroupBox4.Controls.Add(Me.Ajouter_rec)
        Me.GroupBox4.Controls.Add(Me.Recom)
        Me.GroupBox4.Controls.Add(Me.List_Rec)
        Me.GroupBox4.Controls.Add(Me.Num_rec)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Location = New System.Drawing.Point(564, 435)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(737, 303)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Recommandations"
        '
        'Annuler_rec
        '
        Me.Annuler_rec.Enabled = False
        Me.Annuler_rec.Location = New System.Drawing.Point(621, 244)
        Me.Annuler_rec.Name = "Annuler_rec"
        Me.Annuler_rec.Size = New System.Drawing.Size(110, 37)
        Me.Annuler_rec.TabIndex = 2
        Me.Annuler_rec.Text = "Annuler"
        Me.Annuler_rec.UseVisualStyleBackColor = True
        '
        'Supprimer_rec
        '
        Me.Supprimer_rec.Enabled = False
        Me.Supprimer_rec.Location = New System.Drawing.Point(621, 201)
        Me.Supprimer_rec.Name = "Supprimer_rec"
        Me.Supprimer_rec.Size = New System.Drawing.Size(110, 37)
        Me.Supprimer_rec.TabIndex = 2
        Me.Supprimer_rec.Text = "Supprimer"
        Me.Supprimer_rec.UseVisualStyleBackColor = True
        '
        'Modifier_rec
        '
        Me.Modifier_rec.Enabled = False
        Me.Modifier_rec.Location = New System.Drawing.Point(621, 158)
        Me.Modifier_rec.Name = "Modifier_rec"
        Me.Modifier_rec.Size = New System.Drawing.Size(110, 37)
        Me.Modifier_rec.TabIndex = 2
        Me.Modifier_rec.Text = "Modifier"
        Me.Modifier_rec.UseVisualStyleBackColor = True
        '
        'Ajouter_rec
        '
        Me.Ajouter_rec.Enabled = False
        Me.Ajouter_rec.Location = New System.Drawing.Point(621, 119)
        Me.Ajouter_rec.Name = "Ajouter_rec"
        Me.Ajouter_rec.Size = New System.Drawing.Size(110, 37)
        Me.Ajouter_rec.TabIndex = 2
        Me.Ajouter_rec.Text = "Ajouter"
        Me.Ajouter_rec.UseVisualStyleBackColor = True
        '
        'Recom
        '
        Me.Recom.Location = New System.Drawing.Point(276, 25)
        Me.Recom.Multiline = True
        Me.Recom.Name = "Recom"
        Me.Recom.Size = New System.Drawing.Size(369, 66)
        Me.Recom.TabIndex = 1
        '
        'List_Rec
        '
        Me.List_Rec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.List_Rec.Location = New System.Drawing.Point(40, 97)
        Me.List_Rec.Name = "List_Rec"
        Me.List_Rec.Size = New System.Drawing.Size(552, 191)
        Me.List_Rec.TabIndex = 0
        '
        'Num_rec
        '
        Me.Num_rec.AutoSize = True
        Me.Num_rec.Location = New System.Drawing.Point(36, 71)
        Me.Num_rec.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Num_rec.Name = "Num_rec"
        Me.Num_rec.Size = New System.Drawing.Size(0, 20)
        Me.Num_rec.TabIndex = 0
        Me.Num_rec.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(36, 44)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(233, 20)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Libellé de la recommanation"
        '
        'Gestion_des_missions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 746)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Gestion_des_missions"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.List_Rec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Fonction As System.Windows.Forms.Label
    Friend WithEvents Prenom As System.Windows.Forms.Label
    Friend WithEvents Datenaiss As System.Windows.Forms.Label
    Friend WithEvents Direction As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Nom As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Matricule As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Ville As System.Windows.Forms.ComboBox
    Friend WithEvents Pays As System.Windows.Forms.ComboBox
    Friend WithEvents Typ_mission As System.Windows.Forms.ComboBox
    Friend WithEvents Objet As System.Windows.Forms.TextBox
    Friend WithEvents Fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents debut As System.Windows.Forms.DateTimePicker
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Rech_objet As System.Windows.Forms.TextBox
    Friend WithEvents Recherche As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Annuler As System.Windows.Forms.Button
    Friend WithEvents Supprimer As System.Windows.Forms.Button
    Friend WithEvents Modifier As System.Windows.Forms.Button
    Friend WithEvents Ajouter As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Recom As System.Windows.Forms.TextBox
    Friend WithEvents List_Rec As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Annuler_rec As System.Windows.Forms.Button
    Friend WithEvents Supprimer_rec As System.Windows.Forms.Button
    Friend WithEvents Modifier_rec As System.Windows.Forms.Button
    Friend WithEvents Ajouter_rec As System.Windows.Forms.Button
    Friend WithEvents Num_rec As System.Windows.Forms.Label

End Class
