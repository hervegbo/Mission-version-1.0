<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tableau_recapitulatif
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
        Me.Imprimer = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Annee = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Chemin = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.PBar1 = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Imprimer
        '
        Me.Imprimer.Enabled = False
        Me.Imprimer.Location = New System.Drawing.Point(100, 192)
        Me.Imprimer.Name = "Imprimer"
        Me.Imprimer.Size = New System.Drawing.Size(145, 37)
        Me.Imprimer.TabIndex = 5
        Me.Imprimer.Text = "Imprimer"
        Me.Imprimer.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Annee)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Chemin)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(100, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(637, 120)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Informations sur le bulletin de salaire"
        '
        'Annee
        '
        Me.Annee.Location = New System.Drawing.Point(73, 37)
        Me.Annee.Name = "Annee"
        Me.Annee.Size = New System.Drawing.Size(100, 20)
        Me.Annee.TabIndex = 29
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(511, 84)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Parcourir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Chemin
        '
        Me.Chemin.Location = New System.Drawing.Point(105, 84)
        Me.Chemin.Name = "Chemin"
        Me.Chemin.Size = New System.Drawing.Size(400, 20)
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
        Me.Label5.Location = New System.Drawing.Point(17, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Année"
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(276, 192)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(461, 36)
        Me.PBar1.TabIndex = 7
        Me.PBar1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(275, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 8
        '
        'Tableau_recapitulatif
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 320)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Imprimer)
        Me.Name = "Tableau_recapitulatif"
        Me.Text = "Tableau recapitulatif"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Imprimer As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Chemin As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Annee As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
