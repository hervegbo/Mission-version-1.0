Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Security.AccessControl


Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Créez une nouvelle instance du formulaire enfant.
        'Dim ChildForm As New System.Windows.Forms.Form
        ' Configurez-la en tant qu'enfant de ce formulaire MDI avant de l'afficher.
        'ChildForm.MdiParent = Me

        'm_ChildFormNumber += 1
        'ChildForm.Text = "Fenêtre " & m_ChildFormNumber

        'ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        'Dim OpenFileDialog As New OpenFileDialog
        'OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        'OpenFileDialog.Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*"
        'If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
        'Dim FileName As String = OpenFileDialog.FileName
        ' TODO : ajoutez le code ici pour ouvrir le fichier.
        'End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Dim SaveFileDialog As New SaveFileDialog
        'SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        'SaveFileDialog.Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*"

        'If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
        'Dim FileName As String = SaveFileDialog.FileName
        ' TODO : ajoutez le code ici pour enregistrer le contenu actuel du formulaire dans un fichier.
        'End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilisez My.Computer.Clipboard pour insérer les images ou le texte sélectionné dans le Presse-papiers
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilisez My.Computer.Clipboard pour insérer les images ou le texte sélectionné dans le Presse-papiers
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilisez My.Computer.Clipboard.GetText() ou My.Computer.Clipboard.GetData pour extraire les informations du Presse-papiers.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Fermez tous les formulaires enfants du parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub MDIParent1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Redimensioner()
        'EmployéTools.Enabled = False
        'AteliersToolStripMenuItem.Enabled = False
        OutilsToolStripMenuItem.Enabled = False
        MissionsToolStripMenuItem.Enabled = False
        Try
            Dim repname As String = Application.StartupPath
            'IO.File.SetAccessControl(Application.StartupPath & "\BaseUnfpa.mdb", FileSystemRights.FullControl)
            Dim accessRule As FileSystemAccessRule = New FileSystemAccessRule("Tout le monde", FileSystemRights.FullControl, AccessControlType.Allow)
            Dim fSecurity As DirectorySecurity = Directory.GetAccessControl(repname)
            fSecurity.AddAccessRule(accessRule)
            Directory.SetAccessControl(repname, fSecurity)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ModifierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Modifier.MdiParent = Me
        'Modifier.Dock = DockStyle.Fill
        'Modifier.Show()
    End Sub

    Private Sub GestionDesUtilisateursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestionDesUtilisateursToolStripMenuItem.Click
        'User.MdiParent = Me
        'User.Show()
    End Sub

    Private Sub ModifierMotDePasseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifierMotDePasseToolStripMenuItem.Click
        Modif_passe.MdiParent = Me
        Modif_passe.Show()
    End Sub

    Private Sub DéconnexionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DéconnexionToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
        'EmployéTools.Enabled = False
        'AteliersToolStripMenuItem.Enabled = False
        OutilsToolStripMenuItem.Enabled = False
        MissionsToolStripMenuItem.Enabled = False
        'Connection.MdiParent = Me
        'Connection.Show()
        Panel2.Show()
        Redimensioner()
        Label8.Visible = True

    End Sub

    Sub Redimensioner()
        Panel2.Left = -Panel2.Width + Label8.Width
        Panel2.Top = (Me.Height / 2) - Panel2.Height / 2
        Login.Text = ""
        Pwd.Text = ""
        err.Visible = False
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Label8.Hide()
        Panel2.Left = 0
        Login.Focus()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Redimensioner()
        Label8.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        connect()
        'creer_table()
        vcon.Open()
        Dim vcommand As New SqlCommand
        Dim vreader As sqlDataReader
        Dim vsql As String
        vsql = "select * from utilisateur where login ='" & Replace(Login.Text, "'", "''") & "' and pwd='" & Replace(Pwd.Text, "'", "''") & "'"
        vcommand = New SqlCommand(vsql, vcon)
        vreader = vcommand.ExecuteReader
        If vreader.Read Then
            'AteliersToolStripMenuItem.Enabled = True
            'EmployéTools.Enabled = True
            OutilsToolStripMenuItem.Enabled = True
            MissionsToolStripMenuItem.Enabled = True
            tus.Text = ": " & Login.Text.ToLower
            tus.Visible = True
            Redimensioner()
            Panel2.Hide()
        Else
            err.Visible = True
            Pwd.Text = ""
            Login.Focus()
        End If
        vcon.Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub Login_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Login.TextChanged
        If Login.Text.Trim.Length > 2 And Pwd.Text.Trim.Length > 2 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Pwd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pwd.TextChanged
        If Login.Text.Trim.Length > 2 And Pwd.Text.Trim.Length > 2 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub
    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        If MsgBox("Etes vous sûr de vouloir quitter l'application?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Quitter SIT Admin?") = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.MdiParent = Me
        AboutBox1.Show()
    End Sub
   

    Private Sub GestionDesMissionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestionDesMissionsToolStripMenuItem.Click
        Enregistrer_mission.MdiParent = Me
        Enregistrer_mission.Show()
    End Sub

    Private Sub TableauRécapitulatifToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Tableau_recapitulatif.MdiParent = Me
        Tableau_recapitulatif.Show()
    End Sub

    
End Class
