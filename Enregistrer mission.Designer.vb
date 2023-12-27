<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Enregistrer_mission
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Imprimer = New System.Windows.Forms.Button()
        Me.Annuler = New System.Windows.Forms.Button()
        Me.Supprimer = New System.Windows.Forms.Button()
        Me.Modifier = New System.Windows.Forms.Button()
        Me.Ajouter = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DataGridView0 = New System.Windows.Forms.DataGridView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Rech_objet = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Vider_tout = New System.Windows.Forms.Button()
        Me.Ressource = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Fin = New System.Windows.Forms.DateTimePicker()
        Me.debut = New System.Windows.Forms.DateTimePicker()
        Me.Lieu = New System.Windows.Forms.ComboBox()
        Me.Moyen = New System.Windows.Forms.ComboBox()
        Me.Typ_mission = New System.Windows.Forms.ComboBox()
        Me.Objet = New System.Windows.Forms.TextBox()
        Me.DT = New System.Windows.Forms.TextBox()
        Me.Id = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RechPrenom = New System.Windows.Forms.TextBox()
        Me.RechNom = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.List_sel = New System.Windows.Forms.DataGridView()
        Me.Matricule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prenom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PBar1 = New System.Windows.Forms.ProgressBar()
        Me.Vtraitement = New System.Windows.Forms.Label()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.List_sel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Imprimer)
        Me.GroupBox5.Controls.Add(Me.Annuler)
        Me.GroupBox5.Controls.Add(Me.Supprimer)
        Me.GroupBox5.Controls.Add(Me.Modifier)
        Me.GroupBox5.Controls.Add(Me.Ajouter)
        Me.GroupBox5.Location = New System.Drawing.Point(652, 380)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(630, 53)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        '
        'Imprimer
        '
        Me.Imprimer.Location = New System.Drawing.Point(491, 16)
        Me.Imprimer.Name = "Imprimer"
        Me.Imprimer.Size = New System.Drawing.Size(75, 28)
        Me.Imprimer.TabIndex = 6
        Me.Imprimer.Text = "Imprimer OM"
        Me.Imprimer.UseVisualStyleBackColor = True
        '
        'Annuler
        '
        Me.Annuler.Location = New System.Drawing.Point(373, 16)
        Me.Annuler.Name = "Annuler"
        Me.Annuler.Size = New System.Drawing.Size(90, 28)
        Me.Annuler.TabIndex = 4
        Me.Annuler.Text = "Annuler"
        Me.Annuler.UseVisualStyleBackColor = True
        '
        'Supprimer
        '
        Me.Supprimer.Location = New System.Drawing.Point(241, 16)
        Me.Supprimer.Name = "Supprimer"
        Me.Supprimer.Size = New System.Drawing.Size(111, 28)
        Me.Supprimer.TabIndex = 5
        Me.Supprimer.Text = "Supprimer"
        Me.Supprimer.UseVisualStyleBackColor = True
        '
        'Modifier
        '
        Me.Modifier.Location = New System.Drawing.Point(127, 16)
        Me.Modifier.Name = "Modifier"
        Me.Modifier.Size = New System.Drawing.Size(88, 28)
        Me.Modifier.TabIndex = 2
        Me.Modifier.Text = "Modifier"
        Me.Modifier.UseVisualStyleBackColor = True
        '
        'Ajouter
        '
        Me.Ajouter.Location = New System.Drawing.Point(27, 16)
        Me.Ajouter.Name = "Ajouter"
        Me.Ajouter.Size = New System.Drawing.Size(75, 28)
        Me.Ajouter.TabIndex = 3
        Me.Ajouter.Text = "Enregistrer"
        Me.Ajouter.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridView0)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Rech_objet)
        Me.GroupBox3.Location = New System.Drawing.Point(565, 28)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(788, 351)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "REPERTOIRE DES MISSIONS"
        '
        'DataGridView0
        '
        Me.DataGridView0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView0.Location = New System.Drawing.Point(21, 74)
        Me.DataGridView0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridView0.Name = "DataGridView0"
        Me.DataGridView0.Size = New System.Drawing.Size(739, 270)
        Me.DataGridView0.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 41)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Objet de la mission"
        '
        'Rech_objet
        '
        Me.Rech_objet.Location = New System.Drawing.Point(207, 38)
        Me.Rech_objet.Name = "Rech_objet"
        Me.Rech_objet.Size = New System.Drawing.Size(191, 20)
        Me.Rech_objet.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Vider_tout)
        Me.GroupBox1.Controls.Add(Me.Ressource)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Fin)
        Me.GroupBox1.Controls.Add(Me.debut)
        Me.GroupBox1.Controls.Add(Me.Lieu)
        Me.GroupBox1.Controls.Add(Me.Moyen)
        Me.GroupBox1.Controls.Add(Me.Typ_mission)
        Me.GroupBox1.Controls.Add(Me.Objet)
        Me.GroupBox1.Controls.Add(Me.DT)
        Me.GroupBox1.Controls.Add(Me.Id)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 24)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(516, 386)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INFORMATIONS SUR LA MISSION"
        '
        'Vider_tout
        '
        Me.Vider_tout.Location = New System.Drawing.Point(365, 56)
        Me.Vider_tout.Name = "Vider_tout"
        Me.Vider_tout.Size = New System.Drawing.Size(127, 23)
        Me.Vider_tout.TabIndex = 6
        Me.Vider_tout.Text = "Vider tous les champs"
        Me.Vider_tout.UseVisualStyleBackColor = True
        '
        'Ressource
        '
        Me.Ressource.FormattingEnabled = True
        Me.Ressource.Location = New System.Drawing.Point(210, 277)
        Me.Ressource.Name = "Ressource"
        Me.Ressource.Size = New System.Drawing.Size(190, 21)
        Me.Ressource.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(21, 280)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Ressources"
        '
        'Fin
        '
        Me.Fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fin.Location = New System.Drawing.Point(210, 356)
        Me.Fin.Name = "Fin"
        Me.Fin.Size = New System.Drawing.Size(184, 20)
        Me.Fin.TabIndex = 3
        '
        'debut
        '
        Me.debut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.debut.Location = New System.Drawing.Point(210, 322)
        Me.debut.Name = "debut"
        Me.debut.Size = New System.Drawing.Size(184, 20)
        Me.debut.TabIndex = 3
        '
        'Lieu
        '
        Me.Lieu.FormattingEnabled = True
        Me.Lieu.Location = New System.Drawing.Point(211, 184)
        Me.Lieu.Name = "Lieu"
        Me.Lieu.Size = New System.Drawing.Size(187, 21)
        Me.Lieu.TabIndex = 2
        '
        'Moyen
        '
        Me.Moyen.FormattingEnabled = True
        Me.Moyen.Location = New System.Drawing.Point(211, 142)
        Me.Moyen.Name = "Moyen"
        Me.Moyen.Size = New System.Drawing.Size(190, 21)
        Me.Moyen.TabIndex = 2
        '
        'Typ_mission
        '
        Me.Typ_mission.FormattingEnabled = True
        Me.Typ_mission.Location = New System.Drawing.Point(211, 99)
        Me.Typ_mission.Name = "Typ_mission"
        Me.Typ_mission.Size = New System.Drawing.Size(190, 21)
        Me.Typ_mission.TabIndex = 2
        '
        'Objet
        '
        Me.Objet.Location = New System.Drawing.Point(210, 218)
        Me.Objet.Multiline = True
        Me.Objet.Name = "Objet"
        Me.Objet.Size = New System.Drawing.Size(306, 51)
        Me.Objet.TabIndex = 1
        '
        'DT
        '
        Me.DT.Location = New System.Drawing.Point(210, 29)
        Me.DT.Name = "DT"
        Me.DT.Size = New System.Drawing.Size(130, 20)
        Me.DT.TabIndex = 1
        '
        'Id
        '
        Me.Id.Enabled = False
        Me.Id.Location = New System.Drawing.Point(210, 58)
        Me.Id.Name = "Id"
        Me.Id.Size = New System.Drawing.Size(130, 20)
        Me.Id.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 102)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Type de la mission"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 322)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Date de début"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 356)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Date de fin"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 29)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Direction technique"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numéro de la mission"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 218)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Motif"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 150)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Moyen de transport"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 184)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Lieu"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(512, -25)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "GESTION DES MISSIONS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 418)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(596, 316)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Répertoire des employés"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RechPrenom)
        Me.GroupBox4.Controls.Add(Me.RechNom)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 29)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(437, 77)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Rechercher un employé"
        '
        'RechPrenom
        '
        Me.RechPrenom.Location = New System.Drawing.Point(294, 35)
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
        Me.Label26.Location = New System.Drawing.Point(237, 42)
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
        Me.DataGridView1.Location = New System.Drawing.Point(36, 112)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(518, 188)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.List_sel)
        Me.GroupBox6.Location = New System.Drawing.Point(652, 489)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(433, 236)
        Me.GroupBox6.TabIndex = 10
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Employés sélectionnés"
        '
        'List_sel
        '
        Me.List_sel.AllowUserToOrderColumns = True
        Me.List_sel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.List_sel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Matricule, Me.Nom, Me.Prenom})
        Me.List_sel.Location = New System.Drawing.Point(14, 25)
        Me.List_sel.Name = "List_sel"
        Me.List_sel.Size = New System.Drawing.Size(377, 180)
        Me.List_sel.TabIndex = 8
        '
        'Matricule
        '
        Me.Matricule.HeaderText = "Matricule"
        Me.Matricule.Name = "Matricule"
        '
        'Nom
        '
        Me.Nom.HeaderText = "Nom"
        Me.Nom.Name = "Nom"
        '
        'Prenom
        '
        Me.Prenom.HeaderText = "Prénom"
        Me.Prenom.Name = "Prenom"
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(652, 460)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(444, 23)
        Me.PBar1.TabIndex = 11
        '
        'Vtraitement
        '
        Me.Vtraitement.AutoSize = True
        Me.Vtraitement.Location = New System.Drawing.Point(657, 442)
        Me.Vtraitement.Name = "Vtraitement"
        Me.Vtraitement.Size = New System.Drawing.Size(0, 13)
        Me.Vtraitement.TabIndex = 12
        '
        'Enregistrer_mission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 746)
        Me.Controls.Add(Me.Vtraitement)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Name = "Enregistrer_mission"
        Me.Text = "Enregistrer_mission"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.List_sel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Annuler As System.Windows.Forms.Button
    Friend WithEvents Supprimer As System.Windows.Forms.Button
    Friend WithEvents Modifier As System.Windows.Forms.Button
    Friend WithEvents Ajouter As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView0 As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Rech_objet As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents debut As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lieu As System.Windows.Forms.ComboBox
    Friend WithEvents Moyen As System.Windows.Forms.ComboBox
    Friend WithEvents Typ_mission As System.Windows.Forms.ComboBox
    Friend WithEvents Objet As System.Windows.Forms.TextBox
    Friend WithEvents Id As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Ressource As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RechPrenom As System.Windows.Forms.TextBox
    Friend WithEvents RechNom As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents List_sel As System.Windows.Forms.DataGridView
    Friend WithEvents Matricule As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prenom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Imprimer As System.Windows.Forms.Button
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Vtraitement As System.Windows.Forms.Label
    Friend WithEvents Vider_tout As System.Windows.Forms.Button
    Friend WithEvents DT As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
