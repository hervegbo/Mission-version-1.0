<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ordre_de_virement_partiel
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RechPrenom = New System.Windows.Forms.TextBox
        Me.RechNom = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Matricule = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Prenom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Banque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Ecraser = New System.Windows.Forms.CheckBox
        Me.Prime = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Annee_prime = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Trimestre = New System.Windows.Forms.ComboBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Annee = New System.Windows.Forms.TextBox
        Me.Parcourir = New System.Windows.Forms.Button
        Me.Chemin = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Imprimer_BS = New System.Windows.Forms.Button
        Me.Imprimer_OV = New System.Windows.Forms.Button
        Me.Fermer = New System.Windows.Forms.Button
        Me.PBar1 = New System.Windows.Forms.ProgressBar
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Vtraitement = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(571, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(666, 632)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Répertoire des employés"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RechPrenom)
        Me.GroupBox3.Controls.Add(Me.RechNom)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Location = New System.Drawing.Point(47, 33)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(601, 77)
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
        Me.DataGridView1.Location = New System.Drawing.Point(47, 128)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(601, 478)
        Me.DataGridView1.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Matricule, Me.Nom, Me.Prenom, Me.Banque})
        Me.DataGridView2.Location = New System.Drawing.Point(22, 262)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(479, 297)
        Me.DataGridView2.TabIndex = 6
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
        'Banque
        '
        Me.Banque.HeaderText = "Banque"
        Me.Banque.Name = "Banque"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Ecraser)
        Me.GroupBox1.Controls.Add(Me.Prime)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.DataGridView2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(539, 566)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employés sélectionnés"
        '
        'Ecraser
        '
        Me.Ecraser.AutoSize = True
        Me.Ecraser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ecraser.Location = New System.Drawing.Point(37, 140)
        Me.Ecraser.Name = "Ecraser"
        Me.Ecraser.Size = New System.Drawing.Size(202, 17)
        Me.Ecraser.TabIndex = 28
        Me.Ecraser.Text = "Ecraser les données existantes"
        Me.Ecraser.UseVisualStyleBackColor = True
        '
        'Prime
        '
        Me.Prime.AutoSize = True
        Me.Prime.Location = New System.Drawing.Point(37, 163)
        Me.Prime.Name = "Prime"
        Me.Prime.Size = New System.Drawing.Size(108, 17)
        Me.Prime.TabIndex = 27
        Me.Prime.Text = "Ajouter les primes"
        Me.Prime.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Annee_prime)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Trimestre)
        Me.GroupBox5.Enabled = False
        Me.GroupBox5.Location = New System.Drawing.Point(37, 186)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(441, 60)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Trimestre"
        '
        'Annee_prime
        '
        Me.Annee_prime.Location = New System.Drawing.Point(84, 25)
        Me.Annee_prime.Name = "Annee_prime"
        Me.Annee_prime.Size = New System.Drawing.Size(100, 20)
        Me.Annee_prime.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Année"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(235, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Trimestre"
        '
        'Trimestre
        '
        Me.Trimestre.FormattingEnabled = True
        Me.Trimestre.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.Trimestre.Location = New System.Drawing.Point(302, 24)
        Me.Trimestre.Name = "Trimestre"
        Me.Trimestre.Size = New System.Drawing.Size(121, 21)
        Me.Trimestre.TabIndex = 5
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Annee)
        Me.GroupBox4.Controls.Add(Me.Parcourir)
        Me.GroupBox4.Controls.Add(Me.Chemin)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(495, 103)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Informations sur le bulletin de salaire"
        '
        'Annee
        '
        Me.Annee.Location = New System.Drawing.Point(348, 25)
        Me.Annee.Name = "Annee"
        Me.Annee.Size = New System.Drawing.Size(100, 20)
        Me.Annee.TabIndex = 29
        '
        'Parcourir
        '
        Me.Parcourir.Location = New System.Drawing.Point(348, 74)
        Me.Parcourir.Name = "Parcourir"
        Me.Parcourir.Size = New System.Drawing.Size(75, 23)
        Me.Parcourir.TabIndex = 28
        Me.Parcourir.Text = "Parcourir"
        Me.Parcourir.UseVisualStyleBackColor = True
        '
        'Chemin
        '
        Me.Chemin.Location = New System.Drawing.Point(105, 77)
        Me.Chemin.Name = "Chemin"
        Me.Chemin.Size = New System.Drawing.Size(176, 20)
        Me.Chemin.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Enregistrer sous"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(304, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Année"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Donner le mois"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(96, 25)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(138, 21)
        Me.ComboBox1.TabIndex = 23
        '
        'Imprimer_BS
        '
        Me.Imprimer_BS.Location = New System.Drawing.Point(12, 605)
        Me.Imprimer_BS.Name = "Imprimer_BS"
        Me.Imprimer_BS.Size = New System.Drawing.Size(118, 29)
        Me.Imprimer_BS.TabIndex = 8
        Me.Imprimer_BS.Text = "Imprimer BS"
        Me.Imprimer_BS.UseVisualStyleBackColor = True
        '
        'Imprimer_OV
        '
        Me.Imprimer_OV.Location = New System.Drawing.Point(230, 609)
        Me.Imprimer_OV.Name = "Imprimer_OV"
        Me.Imprimer_OV.Size = New System.Drawing.Size(118, 29)
        Me.Imprimer_OV.TabIndex = 8
        Me.Imprimer_OV.Text = "Imprimer OV"
        Me.Imprimer_OV.UseVisualStyleBackColor = True
        '
        'Fermer
        '
        Me.Fermer.Location = New System.Drawing.Point(413, 609)
        Me.Fermer.Name = "Fermer"
        Me.Fermer.Size = New System.Drawing.Size(118, 29)
        Me.Fermer.TabIndex = 8
        Me.Fermer.Text = "Fermer"
        Me.Fermer.UseVisualStyleBackColor = True
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(18, 681)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(533, 37)
        Me.PBar1.TabIndex = 26
        Me.PBar1.Visible = False
        '
        'Vtraitement
        '
        Me.Vtraitement.AutoSize = True
        Me.Vtraitement.Location = New System.Drawing.Point(15, 665)
        Me.Vtraitement.Name = "Vtraitement"
        Me.Vtraitement.Size = New System.Drawing.Size(0, 13)
        Me.Vtraitement.TabIndex = 27
        '
        'Ordre_de_virement_partiel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 730)
        Me.Controls.Add(Me.Vtraitement)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.Fermer)
        Me.Controls.Add(Me.Imprimer_OV)
        Me.Controls.Add(Me.Imprimer_BS)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Ordre_de_virement_partiel"
        Me.Text = "Ordre_de_virement_partiel"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RechPrenom As System.Windows.Forms.TextBox
    Friend WithEvents RechNom As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Annee As System.Windows.Forms.TextBox
    Friend WithEvents Parcourir As System.Windows.Forms.Button
    Friend WithEvents Chemin As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Imprimer_BS As System.Windows.Forms.Button
    Friend WithEvents Imprimer_OV As System.Windows.Forms.Button
    Friend WithEvents Fermer As System.Windows.Forms.Button
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Vtraitement As System.Windows.Forms.Label
    Friend WithEvents Matricule As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prenom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prime As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Annee_prime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Trimestre As System.Windows.Forms.ComboBox
    Friend WithEvents Ecraser As System.Windows.Forms.CheckBox
End Class
