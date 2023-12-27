Imports System.Data.SqlClient
Imports Word = Microsoft.Office.Interop.Word
Imports System.Diagnostics
Imports System.IO


Public Class Enregistrer_mission
    Dim vrec As String
    Private Sub RechNom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RechNom.TextChanged, RechPrenom.TextChanged
        Dim vsql As String = "Select * from Employé where nom like '" & RechNom.Text & "%' and prénom like '" & RechPrenom.Text & "%' Order by nom, prénom"
        remplir_datagrid(vsql, DataGridView1)
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim vrow As DataGridViewRow
        For Each vrow In List_sel.Rows
            If vrow.Index = List_sel.Rows.Count Then
                Exit For
            End If
            If vrow.Cells("Matricule").Value = DataGridView1.Rows(e.RowIndex).Cells("Matricule").Value.ToString Then
                MsgBox("Cet employé a déjà été sélectionné")
                Exit Sub
            End If
        Next
        List_sel.Rows.Add()
        List_sel.Rows(List_sel.Rows.Count - 2).Cells("Matricule").Value = DataGridView1.Rows(e.RowIndex).Cells("Matricule").Value.ToString
        List_sel.Rows(List_sel.Rows.Count - 2).Cells("Nom").Value = DataGridView1.Rows(e.RowIndex).Cells("Nom").Value.ToString
        List_sel.Rows(List_sel.Rows.Count - 2).Cells("Prenom").Value = DataGridView1.Rows(e.RowIndex).Cells("Prénom").Value.ToString
        'DataGridView1.Rows(DataGridView1.Rows.Count - 2).Cells("Banque").Value = DataGridView1.Rows(e.RowIndex).Cells("Banque").Value.ToString
    End Sub
    Sub vider()
        Me.Id.Text = NumAuto("Mission", "Id_Mission")
        'Me.Objet.Text = ""
        'Me.Typ_mission.Text = ""
        Me.Moyen.Text = ""
        Me.Lieu.Text = ""
        'Me.debut.Value = Today.Date
        'Me.Fin.Value = Today.Date
        remplir_datagrid("select * from Mission order by Id_Mission ", DataGridView0)
        Dim vsql As String = "Select * from Employé Order by nom, prénom"
        remplir_datagrid(vsql, DataGridView1)
        List_sel.Rows.Clear()
        Ajouter.Enabled = True
        Modifier.Enabled = False
        Supprimer.Enabled = False
        Annuler.Enabled = False
    End Sub

    Private Sub Ajouter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ajouter.Click

        Dim vsql As String = "Insert into Mission(Id_Mission,Motif,Typ_mission,Lieu,Depart,Retour,Moyen,Ressource) Values('" & Me.Id.Text & "','" & Me.Objet.Text.Replace("'", "''") & "','" & Me.Typ_mission.Text.Replace("'", "''") & "','" & Me.Lieu.Text.Replace("'", "''") & "','" & Me.debut.Value.Date & "','" & Me.Fin.Value.Date & "','" & Me.Moyen.Text.Replace("'", "''") & "','" & Ressource.Text.Replace("'", "''") & "')"
        'MsgBox(vsql)
        proc_action(vsql)
        'If recherche1("Select * from ville where ville='" & Ville.Text.Replace("'", "''") & "' and pays='" & Pays.Text.Replace("'", "''") & "'") = "" Then
        '    vsql = "Insert into Ville(Ville, pays) values('" & Lieu.Text.Replace("'", "''") & "','" & Moyen.Text.Replace("'", "''") & "')"
        '    proc_action(vsql)
        'End If
        For Each vrow In List_sel.Rows
            If vrow.Index = List_sel.Rows.Count - 1 Then
                Exit For
            End If
            vsql = "Insert into Participer(Matricule, Id_Mission) Values ('" & vrow.Cells("Matricule").Value & "'," & Id.Text & ")"
            proc_action(vsql)
        Next
        vider()
    End Sub

    Private Sub Modifier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Modifier.Click
        If MsgBox("Etes vous sûr de vouloir modifier cette mission?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
            Dim vsql As String = "Update Mission set Motif='" & Me.Objet.Text.Replace("'", "''") & "',Typ_mission='" & Me.Typ_mission.Text.Replace("'", "''") & "',Lieu='" & Me.Lieu.Text.Replace("'", "''") & "',Ressource='" & Me.Ressource.Text.Replace("'", "''") & "',Depart='" & Me.debut.Value.Date & "',Retour='" & Me.Fin.Value.Date & "',Moyen='" & Me.Moyen.Text.Replace("'", "''") & "' where Id_Mission=" & Id.Text
            proc_action(vsql)
            'If recherche1("Select * from ville where ville='" & Ville.Text.Replace("'", "''") & "' and pays='" & Pays.Text.Replace("'", "''") & "'") = "" Then
            '    vsql = "Insert into Ville(Ville, pays) values('" & Lieu.Text.Replace("'", "''") & "','" & Moyen.Text.Replace("'", "''") & "')"
            '    proc_action(vsql)
            'End If
            'Ajout d'éventuels nouveaux employés
            For Each vrow In List_sel.Rows
                If vrow.Index = List_sel.Rows.Count - 1 Then
                    Exit For
                End If
                If recherche("Select Id_Mission from participer where ID_Mission=" & Id.Text & " and Matricule='" & vrow.Cells("Matricule").Value & "'") = "" Then
                    vsql = "Insert into Participer(Matricule, Id_Mission) Values ('" & vrow.Cells("Matricule").Value & "'," & Id.Text & ")"
                    proc_action(vsql)
                End If

            Next
        End If
        vider()
    End Sub

    Private Sub Supprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Supprimer.Click
        If MsgBox("Etes vous sûr de vouloir supprimer cette mission?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
            Dim vsql As String = "Delete from Mission  where Id_Mission=" & Id.Text
            proc_action(vsql)
            vsql = "Delete from Participer  where Id_Mission=" & Id.Text
            proc_action(vsql)
        End If
        vider()
    End Sub

    Private Sub Lieu_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lieu.DropDown
        remplir_combo("Select distinct Lieu from Mission", "Lieu", "Lieu", Lieu)
    End Sub

    Private Sub Moyen_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Moyen.DropDown
        remplir_combo("Select distinct Moyen from Mission", "Moyen", "Moyen", Moyen)
    End Sub
    Private Sub Ressource_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ressource.DropDown
        remplir_combo("Select distinct Ressource from Mission", "Ressource", "Ressource", Ressource)
    End Sub

    'Private Sub Typ_mission_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Typ_mission.SelectedIndexChanged
    '    If Typ_mission.Text = "Intérieures" Then
    '        Moyen.Text = "Bénin"
    '    Else
    '        Moyen.Text = ""
    '    End If
    'End Sub

    Private Sub Typ_mission_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Typ_mission.DropDown
        Typ_mission.Items.Clear()
        Typ_mission.Items.Add("Exterieures")
        Typ_mission.Items.Add("Intérieures")
    End Sub

    Private Sub Gestion_des_missions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        vider()
    End Sub

    Private Sub Rech_objet_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rech_objet.TextChanged
        remplir_datagrid("Select * from Mission where Motif like '%" & Rech_objet.Text.Replace("'", "''") & "%' Order by Depart", DataGridView0)
    End Sub

    Private Sub DataGridView0_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView0.RowHeaderMouseClick
        If e.RowIndex = DataGridView0.Rows.Count - 1 Then
            MsgBox("vous ne pouvez pas sélectionner cette ligne")
            vider()
            Exit Sub
        End If
        Id.Text = DataGridView0.Rows(e.RowIndex).Cells("Id_Mission").Value.ToString
        Me.debut.Text = DataGridView0.Rows(e.RowIndex).Cells("Depart").Value.ToString
        Me.Typ_mission.Text = DataGridView0.Rows(e.RowIndex).Cells("Typ_mission").Value.ToString
        Me.Moyen.Text = DataGridView0.Rows(e.RowIndex).Cells("Moyen").Value.ToString
        Me.Lieu.Text = DataGridView0.Rows(e.RowIndex).Cells("Lieu").Value.ToString
        Me.Fin.Text = DataGridView0.Rows(e.RowIndex).Cells("Retour").Value.ToString
        Me.Objet.Text = DataGridView0.Rows(e.RowIndex).Cells("Motif").Value.ToString
        Me.Ressource.Text = DataGridView0.Rows(e.RowIndex).Cells("Ressource").Value.ToString
        Modifier.Enabled = True
        Supprimer.Enabled = True
        Annuler.Enabled = True
        Ajouter.Enabled = False
        remplir_liste()

    End Sub
    Sub remplir_liste()
        'Remplissage du tableau des employés ayant patyicipé à la mission
        Dim vsql As String = "Select E.Matricule, Nom, Prénom from Participer P, Employé E where E.Matricule=P.Matricule and Id_mission=" & Id.Text
        Try
            vcon.Open()

        Catch ex As Exception

        End Try
        Dim vcommand As New SqlCommand(vsql, vcon)
        Dim vadapter As New SqlDataAdapter(vcommand)
        Dim vdataset As New DataSet
        vadapter.Fill(vdataset, "List_emp")
        List_sel.Rows.Clear()
        'MsgBox(vdataset.Tables("List_emp").Rows.Count)
        For Each vrow In vdataset.Tables("List_emp").Rows
            List_sel.Rows.Add()
            List_sel.Rows(List_sel.Rows.Count - 2).Cells("Matricule").Value = vrow("Matricule")
            List_sel.Rows(List_sel.Rows.Count - 2).Cells("Nom").Value = vrow("Nom")
            List_sel.Rows(List_sel.Rows.Count - 2).Cells("Prenom").Value = vrow("Prénom")
        Next
    End Sub
    'Private Sub Ajouter_rec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim i As Integer = NumAuto2("Select Num_rec from Mission_rec where num_mission=" & Id.Text)
    '    Dim vsql As String = "Insert into Mission_rec(Num_mission, Num_rec, Recomm) Values (" & Id.Text & "," & i & ",'" & Recom.Text.Replace("'", "''") & "')"
    '    ' MsgBox(vsql)
    '    proc_action(vsql)
    '    vider2()
    'End Sub
    'Sub vider2()
    '    Recom.Text = ""
    '    Num_rec.Text = ""
    '    Ajouter_rec.Enabled = True
    '    Modifier_rec.Enabled = False
    '    Supprimer_rec.Enabled = False
    '    Annuler_rec.Enabled = False
    '    remplir_dgview(List_Rec, "Select * from Mission_rec where Num_mission=" & Id.Text)
    'End Sub

    'Private Sub Modifier_rec_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim vsql As String = "UPDATE Mission_rec set Recomm='" & Recom.Text.Replace("'", "''") & "' where Num_mission=" & Id.Text & " And Num_rec=" & Num_rec.text
    '    proc_action(vsql)
    '    vider2()
    'End Sub

    'Private Sub Supprimer_rec_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim vsql As String = "Delete from Mission_rec where Num_mission=" & Id.Text & " And Num_rec=" & Num_rec.Text
    '    proc_action(vsql)
    '    vider2()
    'End Sub

    'Private Sub List_Rec_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    '    Recom.Text = List_Rec.Rows(e.RowIndex).Cells("Recomm").Value.ToString
    '    Num_rec.Text = List_Rec.Rows(e.RowIndex).Cells("Num_rec").Value.ToString
    '    Ajouter_rec.Enabled = False
    '    Modifier_rec.Enabled = True
    '    Supprimer_rec.Enabled = True
    '    Annuler_rec.Enabled = True
    'End Sub

    'Private Sub Id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Id.TextChanged
    '    If Id.Text <> "" Then
    '        Ajouter_rec.Enabled = True
    '    Else
    '        Ajouter_rec.Enabled = False
    '    End If
    'End Sub

    Private Sub Annuler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Annuler.Click
        vider()
    End Sub

    Private Sub List_sel_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles List_sel.UserDeletedRow
        'MsgBox(e.Row.Cells("matricule").Value)
        vrec = "delete from participer where Id_mission=" & Id.Text & " and Matricule='" & e.Row.Cells(0).Value & "'"
        proc_action(vrec)
        remplir_liste()
    End Sub

    Private Sub Imprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimer.Click
        imprimer_plusieurs()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Vider_tout.Click
        vider()
        Me.Objet.Text = ""
        Me.Typ_mission.Text = ""
        Me.debut.Value = Today.Date
        Me.Fin.Value = Today.Date
    End Sub
    Sub imprimer_plusieurs()
        Cursor = Cursors.WaitCursor
        PBar1.Visible = True
        Vtraitement.Visible = True
        Dim vdoc As Word.Application
        Vtraitement.Text = "Création du fichier word......"
        PBar1.Value = 10
        Dim vespace As String = " "
        'vdoc = CreateObject("Word.Application")
        'vdoc.Visible = True
        Dim l As Integer = 1
        Dim civilité As String
        'Vérifier que le document n'est pas ouvert et verrouillé. Le déverrouiler et le fermer en tuant le processus si c'etait le cas
        'MsgBox(File.GetAttributes(Application.StartupPath & "\Doc1.docx"))
        If File.GetAttributes(Application.StartupPath & "\Doc1.docx") = 32 Then
            Dim myProcesses As Process() = Process.GetProcessesByName("WinWord")
            Dim myProcess As Process
            For Each myProcess In myProcesses
                myProcess.Kill()
            Next myProcess
        End If
        ' Initialisation de la variable
        vdoc = CreateObject("Word.Application")
        vdoc.Documents.Open(Application.StartupPath & "\Doc1.docx")
        '    vdoc.Selection.TypeParagraph()
        '    vdoc.Selection.TypeBackspace()
        'Catch ex As Exception

        'End Try
        ' vdoc.Application.Visible = True
        '
        Try
            vcon.Open()
        Catch ex As Exception

        End Try
        Dim vdirection, vservice As String
        'vdoc.ActiveDocument.Tables(1).Select()
        'vdoc.Selection.Copy()
        'vdoc.Selection.MoveDown()
        'vdoc.Selection.MoveDown()
        Try

            For Each vrow1 In DataGridView0.SelectedRows
                'MsgBox(vrow1.index)
                If vrow1.index <> DataGridView0.Rows.Count - 1 Then
                    Dim vsql As String = "select * from participer where Id_mission=" & vrow1.cells("Id_mission").value
                    Dim vcommand As New SqlCommand(vsql, vcon)
                    Dim vdataset As New DataSet
                    Dim vadapter As New SqlDataAdapter(vcommand)
                    Dim vnomJf, vnom, vprenom As String
                    vadapter.Fill(vdataset, "Tbl_donnees")
                    For Each vrow In vdataset.Tables("Tbl_donnees").Rows
                        vnom = recherche("select Nom from Employé where matricule='" & vrow.item("Matricule") & "'")
                        vprenom = recherche("select prénom from Employé where matricule='" & vrow.item("Matricule") & "'")
                        vnomJf = recherche("select NomJF from Employé where matricule='" & vrow.item("Matricule") & "'")
                        Vtraitement.Text = "Employé    :    " & vnom & " " & vprenom
                        PBar1.Value = 10
                        'If l > 2 Then
                        '    vdoc.Selection.PasteAndFormat(Word.WdRecoveryType.wdFormatOriginalFormatting)
                        '    vdoc.Selection.MoveDown()
                        '    vdoc.Selection.MoveDown()
                        'End If
                        vdoc.Selection.Font.Name = "Bookman Old Style"

                        vdoc.Selection.ParagraphFormat.SpaceAfter = 0
                        vdoc.Selection.ParagraphFormat.SpaceBefore = 0
                        vdoc.Selection.ParagraphFormat.Space15()
                        'vdoc.Selection.Font.Name = "Calibri"
                        vdoc.Selection.Font.Size = 11
                        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                        vdoc.Selection.ParagraphFormat.LeftIndent = 290
                        'vdoc.Visible = True
                        vdoc.Selection.TypeText(Text:="Cotonou le")
                        vdoc.Selection.TypeParagraph()
                        vdoc.Selection.ParagraphFormat.LeftIndent = 0
                        vdoc.Selection.Font.Size = 10
                        vdoc.Selection.TypeText(Text:="N°______/MEF/DC/SGM/INStaD/DAF-" & DT.Text & "/SP")

                        'vdoc.Selection.Font.Size = 11
                        'vdoc.Selection.TypeParagraph()
                        vdoc.Selection.TypeParagraph()
                        vdoc.Selection.TypeParagraph()
                        'définit le format de police du titre
                        vdoc.Selection.Font.Bold = True
                        vdoc.Selection.Font.Size = 20
                        'vdoc.Selection.Font.Name = "Algerian"
                        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                        Dim vsexe As String = recherche("select Sexe from Employé where matricule='" & vrow.item("Matricule") & "'")
                        Dim vcategorie As String = recherche("select Categorie from Employé where matricule='" & vrow.item("Matricule") & "'")
                        Dim vechelon As String = recherche("select Echelon from Employé where matricule='" & vrow.item("Matricule") & "'")
                        Dim vcatape As String = recherche("select APE from Grade_APE_INSAE where INSAE='" & vcategorie & "-" & vechelon & "'")
                        Dim vstatut As String = recherche("select Statut from Employé where matricule='" & vrow.item("Matricule") & "'")
                        vservice = ""
                        'MsgBox(vrow.item("Matricule"))
                        vservice = recherche("select Service from Employé where matricule='" & vrow.item("Matricule") & "'")
                        If vservice <> "" Then
                            vdirection = recherche("select D.Direction from Service S, Direction D where S.Direction = D.Coddir And  S.Codserv='" & vservice & "'")
                        Else
                            vdirection = recherche("select D.Direction from Employé E,Direction D where E.matricule=D.Matricule And  E.matricule='" & vrow.item("Matricule") & "'")
                        End If
                        'Dim vdirection As String = recherche("select D.Direction from Employé E, Service S, Direction D where E.Service=S.Codserv and S.Direction = D.Coddir And  E.matricule='" & vrow.Cells("Matricule").Value & "'")
                        'vdirection = recherche("select Service from Employé where matricule='" & vrow.item("Matricule") & "'")
                        Dim vfonction As String = recherche("select Fonction from Employé where matricule='" & vrow.item("Matricule") & "'")
                        Dim vindice = recherche("Select Indice from Indices where Echelon='" & vechelon & "' and Categorie='" & vcategorie & "'")
                        Dim vindiceape = recherche("Select distinct Indice_APE from Grade_APE_INSAE where APE='" & vcatape & "'")
                        vdoc.Selection.TypeText(Text:="ORDRE DE MISSION")
                        vdoc.Selection.Font.Size = 11
                        'Retour à la ligne
                        vdoc.Selection.Font.Bold = False
                        vdoc.Selection.Font.Name = "Bookman Old Style"
                        'vdoc.Selection.TypeParagraph()
                        vdoc.Selection.TypeParagraph()
                        'vdoc.Selection.Font.Name = "Times New Roman"
                        'vdoc.Selection.Font.Size = 12
                        'vdoc.Selection.TypeParagraph()
                        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                        'on crée un nouveau tableau
                        vdoc.ActiveDocument.Tables.Add(Range:=vdoc.Selection.Range, NumRows:=13, NumColumns:=2)
                        'Sélection du tableau
                        'l = 1
                        vdoc.ActiveDocument.Tables(l).Select()
                        'interligne 1,5
                        vdoc.Selection.ParagraphFormat.Space15()
                        'On diminue à 0 l'espacement entre les lignes
                        vdoc.Selection.ParagraphFormat.SpaceAfter = 0
                        vdoc.Selection.ParagraphFormat.SpaceBefore = 0
                        'Format et police
                        'vdoc.Selection.Font.Name = "Times New Roman"
                        vdoc.Selection.Font.Size = 12
                        'Remplissage de l'entête
                        PBar1.Value = PBar1.Value + 10
                        PBar1.Value = PBar1.Value + 10
                        vdoc.ActiveDocument.Tables(l).Columns(1).SetWidth(ColumnWidth:=125.5, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                        vdoc.ActiveDocument.Tables(l).Columns(2).SetWidth(ColumnWidth:=400, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)

                        'vdoc.Selection.ParagraphFormat.LineSpacing = Word.WdLineStyle.wdLineStyleSingle
                        If vsexe = "" Or vsexe = "M" Then
                            civilité = "Monsieur"
                        Else
                            civilité = "Madame"
                        End If
                        vdoc.ActiveDocument.Tables(l).Cell(1, 1).Range.Text = civilité
                        If vnomJf = "" Then
                            vdoc.ActiveDocument.Tables(l).Cell(1, 2).Range.Text = vnom & " " & vprenom
                        Else
                            vdoc.ActiveDocument.Tables(l).Cell(1, 2).Range.Text = vnomJf & " " & vprenom & " Epouse " & vnom
                        End If
                        'vdoc.ActiveDocument.Tables(l).Cell(1, 2).Range.Text = vnom & " " & vprenom
                        vdoc.ActiveDocument.Tables(l).Cell(2, 1).Range.Text = "Ministère"
                        vdoc.ActiveDocument.Tables(l).Cell(2, 2).Range.Text = "Ministère de l'Economie et des Finances"
                        vdoc.ActiveDocument.Tables(l).Cell(3, 1).Range.Text = "Structure"
                        vdoc.ActiveDocument.Tables(l).Cell(3, 2).Range.Text = "Institut National de la Statistique et de la Démographie"
                        vdoc.ActiveDocument.Tables(l).Cell(4, 1).Range.Text = "Direction"
                        vdoc.ActiveDocument.Tables(l).Cell(4, 2).Range.Text = premiereLettreMaj(vdirection)
                        vdoc.ActiveDocument.Tables(l).Cell(5, 1).Range.Text = "Fonction"
                        vdoc.ActiveDocument.Tables(l).Cell(5, 2).Range.Text = premiereLettreMaj(vfonction)
                        vdoc.ActiveDocument.Tables(l).Cell(6, 2).Split(NumRows:=1, NumColumns:=2)
                        vdoc.ActiveDocument.Tables(l).Cell(7, 2).Split(NumRows:=1, NumColumns:=2)
                        vdoc.ActiveDocument.Tables(l).Cell(8, 2).Split(NumRows:=1, NumColumns:=2)
                        vdoc.ActiveDocument.Tables(l).Cell(6, 2).SetWidth(ColumnWidth:=130, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                        vdoc.ActiveDocument.Tables(l).Cell(7, 2).SetWidth(ColumnWidth:=130, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                        vdoc.ActiveDocument.Tables(l).Cell(8, 2).SetWidth(ColumnWidth:=130, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                        vdoc.ActiveDocument.Tables(l).Cell(6, 2).Range.Text = "Convention"
                        vdoc.ActiveDocument.Tables(l).Cell(6, 3).Range.Text = "APE"
                        vdoc.ActiveDocument.Tables(l).Cell(7, 1).Range.Text = "Grade"
                        vdoc.ActiveDocument.Tables(l).Cell(7, 2).Range.Text = vcategorie & "-" & vechelon
                        vdoc.ActiveDocument.Tables(l).Cell(7, 3).Range.Text = vcatape
                        vdoc.ActiveDocument.Tables(l).Cell(8, 1).Range.Text = "Indice"
                        vdoc.ActiveDocument.Tables(l).Cell(8, 2).Range.Text = vindice
                        vdoc.ActiveDocument.Tables(l).Cell(8, 3).Range.Text = vindiceape
                        vdoc.ActiveDocument.Tables(l).Cell(9, 1).Range.Text = "Se rendra "
                        vdoc.ActiveDocument.Tables(l).Cell(9, 2).Range.Text = vrow1.cells("Lieu").value.Substring(0, 1).ToUpper & vrow1.cells("Lieu").value.Substring(1)
                        vdoc.ActiveDocument.Tables(l).Cell(10, 1).Range.Text = "Motif"
                        vdoc.ActiveDocument.Tables(l).Cell(10, 2).Range.Text = vrow1.cells("Motif").value
                        vdoc.ActiveDocument.Tables(l).Cell(11, 1).Range.Text = "Moyen de transport"
                        vdoc.ActiveDocument.Tables(l).Cell(11, 2).Range.Text = vrow1.cells("Moyen").value.Substring(0, 1).ToUpper & vrow1.cells("Moyen").value.Substring(1)
                        vdoc.ActiveDocument.Tables(l).Cell(12, 1).Range.Text = "Date de départ"
                        vdoc.ActiveDocument.Tables(l).Cell(12, 2).Range.Text = FormatDateTime(vrow1.cells("depart").value, DateFormat.LongDate).Substring(0, 1).ToUpper & FormatDateTime(vrow1.cells("depart").value, DateFormat.LongDate).Substring(1)
                        vdoc.ActiveDocument.Tables(l).Cell(13, 1).Range.Text = "Date de retour"
                        vdoc.ActiveDocument.Tables(l).Cell(13, 2).Range.Text = FormatDateTime(vrow1.cells("Retour").value, DateFormat.LongDate).Substring(0, 1).ToUpper & FormatDateTime(vrow1.cells("Retour").value, DateFormat.LongDate).Substring(1)
                        'On met interligne 1 au niveau de motif
                        'vdoc.ActiveDocument.Tables(l).Cell(10, 2).Select()
                        'vdoc.Selection.ParagraphFormat.Space1()
                        'On sélectionne la dernière cellule
                        'vdoc.ActiveDocument.Tables(l).Cell(13, 2).Select()
                        'Aligner les valeurs des colonnes de nombre à droite
                        ' vdoc.ActiveDocument.Tables(l).Columns(6).Select()
                        'On selectionne le tableau
                        vdoc.ActiveDocument.Tables(l).Select()
                        'On applique au tableau l'interligne 1.5
                        With vdoc.Selection.ParagraphFormat
                            .Space15()
                            .SpaceBefore = 6
                        End With
                        vdoc.Selection.MoveDown()
                        vdoc.Selection.MoveDown()
                        vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                        vdoc.Selection.Font.Name = "Bookman Old Style"
                        vdoc.Selection.Font.Size = 12
                        'vdoc.Selection.TypeParagraph()
                        PBar1.Value = PBar1.Value + 10
                        PBar1.Value = PBar1.Value + 10
                        vdoc.Selection.ParagraphFormat.Space15()
                        vdoc.Selection.ParagraphFormat.SpaceBefore = 12
                        vdoc.Selection.TypeText(Text:="Les frais de mission seront payés sur les ressources " & vrow1.cells("Ressource").value.ToString)
                        vdoc.Selection.TypeParagraph()
                        vdoc.Selection.ParagraphFormat.SpaceBefore = 0
                        vdoc.Selection.ParagraphFormat.Space15()
                        If vnomJf = "" Then
                            'vdoc.ActiveDocument.Tables(l).Cell(1, 2).Range.Text = vnom & " " & vprenom
                            vdoc.Selection.TypeText(Text:="Les autorités administratives sont priées de faciliter à " & civilité & " " & vnom & " " & vprenom & " l'accomplissement de sa mission.")

                        Else
                            'vdoc.ActiveDocument.Tables(l).Cell(1, 2).Range.Text = vnomJf & " " & vprenom & " Epouse " & vnom
                            vdoc.Selection.TypeText(Text:="Les autorités administratives sont priées de faciliter à " & civilité & " " & vnomJf & " " & vprenom & " Epouse " & vnom & " l'accomplissement de sa mission.")

                        End If
                        'vdoc.Selection.TypeText(Text:="Les autorités administratives sont priées de faciliter à " & civilité & " " & vnom & " " & vprenom & " l'accomplissement de sa mission")
                        vdoc.Selection.TypeParagraph()
                        vdoc.Selection.TypeParagraph()
                        vdoc.Selection.TypeParagraph()
                        'vdoc.Selection.TypeParagraph()
                        'vdoc.Selection.TypeParagraph()
                        'vdoc.Selection.TypeParagraph()
                        'vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                        vdoc.Selection.Font.Size = 13
                        vdoc.Selection.Font.Bold = True
                        'With vdoc.Selection.ParagraphFormat
                        '    '.LeftIndent = Word. CentimetersToPoints(11)
                        '    .LeftIndent = 11
                        '    .SpaceBeforeAuto = False
                        '    .SpaceAfterAuto = False
                        'End With
                        vdoc.Selection.ParagraphFormat.SpaceBefore = 0
                        vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
                        'vdoc.Selection.TypeText(Text:=vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab)
                        vdoc.Selection.TypeText(Text:=recherche("Select Valeur from parametre where variable='DG'"))
                        vdoc.Selection.Font.Bold = False
                        vdoc.Selection.Font.Size = 11
                        vdoc.Selection.ParagraphFormat.SpaceBefore = 0
                        vdoc.Selection.ParagraphFormat.Space1()
                        vdoc.Selection.TypeParagraph()
                        vdoc.Selection.ParagraphFormat.SpaceBefore = 0
                        'vdoc.Selection.TypeText(Text:=vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab)
                        'vdoc.Selection.Font.Size = 11
                        vdoc.Selection.TypeText(Text:="Directeur Général")
                        'vdoc.Selection.TypeParagraph()
                        'vdoc.Selection.InsertBreak()
                        vdoc.Selection.InsertBreak(Type:=Word.WdBreakType.wdSectionBreakNextPage)
                        l = l + 1
                    Next
                End If
            Next
        Catch ex As Exception
            MsgBox("Une erreur s'est produite : " & ex.Source & Chr(13) & "Méthode ayant levé l'exception : " & Chr(13) & ex.Message & Chr(13) & ex.StackTrace)
            'vdoc.ActiveDocument.Close()
            vcon.Close()
            vdoc.Quit(SaveChanges:=Word.WdSaveOptions.wdDoNotSaveChanges)
            Cursor = Cursors.Default
            PBar1.Visible = False
            Vtraitement.Visible = False
            Exit Sub
        End Try
        vcon.Close()
        vdoc.Selection.Font.Color = Word.WdColor.wdColorGray25
        Cursor = Cursors.Default
        PBar1.Visible = False
        Vtraitement.Visible = False
        Dim chemin As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\OM" & Today.Date.ToString.Substring(0, 10).Replace("/", "_") & ".docx"
        'MsgBox(chemin)
        vdoc.ActiveDocument.SaveAs(chemin)
        If MsgBox("Le document a été généré. Voulez vous l'ouvrir?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            vdoc.Visible = True

        Else
            vdoc.Quit()
        End If
    End Sub
End Class