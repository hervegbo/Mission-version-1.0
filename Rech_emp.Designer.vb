<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rech_emp
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
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(44, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(700, 564)
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
        Me.DataGridView1.Size = New System.Drawing.Size(547, 348)
        Me.DataGridView1.TabIndex = 0
        '
        'Rech_emp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 614)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Rech_emp"
        Me.Text = "Rech_emp"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RechPrenom As System.Windows.Forms.TextBox
    Friend WithEvents RechNom As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
