Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Word = Microsoft.Office.Interop.Word
Public Class Tableau_recapitulatif

    Private Sub Tab_recap(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Annee.Text = Today.Year
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimer.Click
        Dim vdoc As Word.Application
        PBar1.Visible = True
        Label1.Visible = True
        PBar1.Value = 10
        Label1.Text = "Création du document Word................"
        ' Initialisation de la variable
        vdoc = CreateObject("Word.Application")
        vdoc.Visible = False
        vdoc.Documents.Open(Application.StartupPath & "\Doc1.docx")
        Dim vcon1 As New OleDbConnection(vchaine)
        vcon1.Open()
        PBar1.Value = 50
        Dim vcommand As New OleDbCommand("Select * from Missions order by Typ_mission, Date_debut")
        vcommand.Connection = vcon1
        Dim vdatatset As New DataSet
        Dim vadapter As New OleDbDataAdapter(vcommand)
        vadapter.Fill(vdatatset, "Tbl_mission")
        Dim vrow As DataRow = vdatatset.Tables("Tbl_mission").Rows(0)
        Dim l As Integer = 0
        Dim vmission As String = vrow.Item("Typ_mission")
        vdoc.Selection.TypeParagraph()
        vdoc.Selection.Font.Bold = True
        vdoc.Selection.TypeText(Text:="Missions " & vmission)
        vdoc.Selection.TypeParagraph()
        'vdoc.Selection.Font.Bold = False
        Dim debut As Boolean = True
        Dim vligne As Integer = 1
        PBar1.Value = 100
        Label1.Text = "Missions " & vmission
        For Each vrow In vdatatset.Tables("Tbl_mission").Rows
            'Si le type de la mission est différent
            If vmission <> vrow.Item("Typ_mission") Then
                'If debut = False Then
                'on insère la dernière ligne
                vdoc.ActiveDocument.Tables(l).Rows.Add()
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 1).Range.Text = "Nombre"
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 2).Range.Text = vligne - 2
                vdoc.ActiveDocument.Tables(l).Rows(vligne).Select()
                vdoc.Selection.Font.Bold = True
                vdoc.Selection.MoveDown()
                vdoc.Selection.MoveDown()
                vdoc.Selection.TypeParagraph()
                'End If
                vdoc.Selection.TypeParagraph()
                vmission = vrow.Item("Typ_mission")
                vdoc.Selection.TypeText(Text:="Missions " & vmission)
                vdoc.Selection.TypeParagraph()
                Label1.Text = "Missions " & vmission
                vligne = 1
            End If
            If vligne = 1 Then
                'On insère un nouveau tableau
                vdoc.ActiveDocument.Tables.Add(Range:=vdoc.Selection.Range, NumRows:=1, NumColumns:=4)
                l = l + 1
                vdoc.ActiveDocument.Tables(l).Cell(1, 1).Range.Text = "Objet"
                vdoc.ActiveDocument.Tables(l).Cell(1, 2).Range.Text = "Date de début"
                vdoc.ActiveDocument.Tables(l).Cell(1, 3).Range.Text = "Date de fin"
                vdoc.ActiveDocument.Tables(l).Cell(1, 4).Range.Text = "Lieu"
                vligne = 2
                vdoc.ActiveDocument.Tables(l).Columns(1).SetWidth(ColumnWidth:=160.75, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                vdoc.ActiveDocument.Tables(l).Columns(2).SetWidth(ColumnWidth:=92, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                vdoc.ActiveDocument.Tables(l).Columns(3).SetWidth(ColumnWidth:=115, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                vdoc.ActiveDocument.Tables(l).Columns(4).SetWidth(ColumnWidth:=60, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                vdoc.ActiveDocument.Tables(l).Select()
                'On définit le quadrillage du tableau
                With vdoc.Selection.Cells
                    With .Borders(Word.WdBorderType.wdBorderLeft)
                        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                        .Color = Word.WdColor.wdColorAutomatic
                    End With
                    With .Borders(Word.WdBorderType.wdBorderRight)
                        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                        .Color = Word.WdColor.wdColorAutomatic
                    End With
                    With .Borders(Word.WdBorderType.wdBorderTop)
                        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                        .Color = Word.WdColor.wdColorAutomatic
                    End With
                    With .Borders(Word.WdBorderType.wdBorderBottom)
                        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                        .Color = Word.WdColor.wdColorAutomatic
                    End With
                    With .Borders(Word.WdBorderType.wdBorderVertical)
                        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                        .Color = Word.WdColor.wdColorAutomatic
                    End With
                    With .Borders(Word.WdBorderType.wdBorderHorizontal)
                        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                        .Color = Word.WdColor.wdColorAutomatic
                    End With
                    Try
                        .Borders(Word.WdBorderType.wdBorderDiagonalDown).LineStyle = Word.WdLineStyle.wdLineStyleNone
                        .Borders(Word.WdBorderType.wdBorderDiagonalUp).LineStyle = Word.WdLineStyle.wdLineStyleNone
                        .Borders.Shadow = False
                    Catch ex As Exception
                    End Try
                End With
            End If
            If PBar1.Value + 10 > 100 Then
                PBar1.Value = 0
            Else
                PBar1.Value = PBar1.Value + 10
            End If
            vdoc.ActiveDocument.Tables(l).Rows.Add()
            vdoc.ActiveDocument.Tables(l).Rows(vligne).Select()
            vdoc.Selection.Font.Bold = False
            vdoc.ActiveDocument.Tables(l).Cell(vligne, 1).Range.Text = vrow.Item("Objet_miss")
            vdoc.ActiveDocument.Tables(l).Cell(vligne, 2).Range.Text = vrow.Item("Date_debut")
            vdoc.ActiveDocument.Tables(l).Cell(vligne, 3).Range.Text = vrow.Item("Date_fin")
            vdoc.ActiveDocument.Tables(l).Cell(vligne, 4).Range.Text = vrow.Item("Ville")
            vligne = vligne + 1
        Next
        'On insère la dernière ligne du dernier tableau
        PBar1.Value = 100
        vdoc.ActiveDocument.Tables(l).Rows.Add()
        vdoc.ActiveDocument.Tables(l).Cell(vligne, 1).Range.Text = "Nombre"
        vdoc.ActiveDocument.Tables(l).Cell(vligne, 2).Range.Text = vligne - 2
        vdoc.ActiveDocument.Tables(l).Rows(vligne).Select()
        vdoc.Selection.Font.Bold = True
        vdoc.ActiveDocument.SaveAs(Chemin.Text)
        If MsgBox("Le document word a bien été généré. Voulez vous l'ouvrir?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            vdoc.Visible = True
        Else
            vdoc.Quit()
        End If
        PBar1.Visible = False
        Label1.Visible = False
        vcon1.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SaveFileDialog1.Title = "INSAE - Déclaration IPTS : Enregistrer sous...."
        SaveFileDialog1.Filter = "*.doc|Fichiers Word"
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName <> "" Then
            Chemin.Text = SaveFileDialog1.FileName
            Imprimer.Enabled = True
        Else
            Imprimer.Enabled = False
        End If
    End Sub
End Class