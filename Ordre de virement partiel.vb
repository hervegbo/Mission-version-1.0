Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Word = Microsoft.Office.Interop.Word
Public Class Ordre_de_virement_partiel
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text <> "" And Annee.Text <> "" Then
            Imprimer_BS.Enabled = True
            Imprimer_OV.Enabled = True
            Chemin.Text = verif_chemin("BISpartiel_" & ComboBox1.Text & Year(Today.Date))
        End If
    End Sub
    Private Sub Chemin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chemin.TextChanged
        If ComboBox1.Text <> "" And Chemin.Text <> "" Then
            Imprimer_BS.Enabled = True
            Imprimer_OV.Enabled = True
        Else
            Imprimer_BS.Enabled = False
            Imprimer_OV.Enabled = False
        End If
    End Sub

    Private Sub Ordre_de_virement_partiel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Annee_prime.Text = Today.Year
        Annee.Text = Today.Year
        ComboBox1.Items.Add("Janvier")
        ComboBox1.Items.Add("Février")
        ComboBox1.Items.Add("Mars")
        ComboBox1.Items.Add("Avril")
        ComboBox1.Items.Add("Mai")
        ComboBox1.Items.Add("Juin")
        ComboBox1.Items.Add("Juillet")
        ComboBox1.Items.Add("Août")
        ComboBox1.Items.Add("Septembre")
        ComboBox1.Items.Add("Octobre")
        ComboBox1.Items.Add("Novembre")
        ComboBox1.Items.Add("Décembre")
        ComboBox1.Items.Add("13ième mois")

        remplir_datagrid("Select * from Employé Order by Nom, Prénom", DataGridView1)

    End Sub

    Private Sub Parcourir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Parcourir.Click
        SaveFileDialog1.Title = "INSAE - Déclaration IPTS : Enregistrer sous...."
        SaveFileDialog1.Filter = "*.doc|Fichiers Word"
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName <> "" Then
            Chemin.Text = SaveFileDialog1.FileName
        End If
        If ComboBox1.Text <> "" And Annee.Text <> "" And Chemin.Text <> "" Then
            Imprimer_BS.Enabled = True
            Imprimer_OV.Enabled = True
        End If
    End Sub
    Private Sub RechNom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RechNom.TextChanged, RechPrenom.TextChanged
        Dim vsql As String = "Select * from Employé where nom like '" & RechNom.Text & "%' and prénom like '" & RechPrenom.Text & "%' Order by nom, prénom"
        remplir_datagrid(vsql, DataGridView1)
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim vrow As DataGridViewRow
        For Each vrow In DataGridView2.Rows
            If vrow.Index = DataGridView2.Rows.Count Then
                Exit For
            End If
            If vrow.Cells("Matricule").Value = DataGridView1.Rows(e.RowIndex).Cells("Matricule").Value.ToString Then
                MsgBox("Cet employé a déjà été sélectionné")
                Exit Sub
            End If
        Next
        DataGridView2.Rows.Add()
        DataGridView2.Rows(DataGridView2.Rows.Count - 2).Cells("Matricule").Value = DataGridView1.Rows(e.RowIndex).Cells("Matricule").Value.ToString
        DataGridView2.Rows(DataGridView2.Rows.Count - 2).Cells("Nom").Value = DataGridView1.Rows(e.RowIndex).Cells("Nom").Value.ToString
        DataGridView2.Rows(DataGridView2.Rows.Count - 2).Cells("Prenom").Value = DataGridView1.Rows(e.RowIndex).Cells("Prénom").Value.ToString
        DataGridView2.Rows(DataGridView2.Rows.Count - 2).Cells("Banque").Value = DataGridView1.Rows(e.RowIndex).Cells("Banque").Value.ToString

        If ComboBox1.Text <> "" And Annee.Text <> "" Then
            Imprimer_BS.Enabled = True
            Imprimer_OV.Enabled = True
            Chemin.Text = verif_chemin("BIS_" & ComboBox1.Text & Year(Today.Date))
        End If

    End Sub

    Private Sub Imprimer_BS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Imprimer_BS.Click
        Cursor = Cursors.WaitCursor
        PBar1.Visible = True
        Vtraitement.Visible = True
        Dim vdoc As Word.Application
        Vtraitement.Text = "Création du fichier word......"
        PBar1.Value = 10
        Dim vespace As String = " "
        ' Initialisation de la variable
        vdoc = CreateObject("Word.Application")
        'vdoc.Visible = True
        vdoc.Documents.Open(Application.StartupPath & "\Doc1.docx")
        Dim vcon1 As New OleDbConnection(vchaine)
        vcon1.Open()
        PBar1.Value = 50
        Dim vrow As DataGridViewRow
        Dim vlong As Integer
        Dim l As Integer = 1
        Dim vsql As String
        Dim salnet, vipts, resp, rend, TotPT, Totprimefixe As Integer
        Dim Pd As Integer = 20000
        Dim retenue As Integer = 0
        TotPT = 0
        For Each vrow In DataGridView2.Rows
            If vrow.Index = DataGridView2.Rows.Count - 1 Then
                Exit For
            End If
            resp = 0
            retenue = 0
            Vtraitement.Text = "Employé    :    " & vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value
            PBar1.Value = 10
            'définit le format de police du titre
            vdoc.Selection.Font.Bold = True
            vdoc.Selection.Font.Size = 18
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            Dim vcategorie As String = recherche("select Categorie from Employé where matricule='" & vrow.Cells("Matricule").Value & "'")
            Dim vechelon As String = recherche("select Echelon from Employé where matricule='" & vrow.Cells("Matricule").Value & "'")
            Dim vstatut As String = recherche("select Statut from Employé where matricule='" & vrow.Cells("Matricule").Value & "'")
            Dim Vipsape As Integer = CInt(recherche("select iptsape from Employé where matricule='" & vrow.Cells("Matricule").Value & "'"))
            Dim Vsalnetape As Integer = CInt(recherche("select SalnetApe from Employé where matricule='" & vrow.Cells("Matricule").Value & "'"))
            Dim Venfant As String = CInt(recherche("select Enfant from Employé where matricule='" & vrow.Cells("Matricule").Value & "'"))
            Dim vposte As String = recherche("select Poste from Employé where matricule='" & vrow.Cells("Matricule").Value & "'")
            If Trim(recherche("select statut from Employé where matricule='" & vrow.Cells("Matricule").Value & "'")) = "Conventionné" Then
                vdoc.Selection.TypeText(Text:="BULLETIN DE SALAIRE " & ComboBox1.Text.ToUpper & " " & Year(Today.Date))
            Else
                vdoc.Selection.TypeText(Text:="SALAIRE COMPLEMENTAIRE " & ComboBox1.Text.ToUpper & " " & Year(Today.Date))
            End If
            'Retour à la ligne
            vdoc.Selection.Font.Size = 12
            'vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            'On diminue à 0 l'espacement entre les lignes
            vdoc.Selection.ParagraphFormat.SpaceAfter = 0
            vdoc.Selection.ParagraphFormat.SpaceBefore = 0
            'Remplissage de l'entête
            PBar1.Value = PBar1.Value + 10
            vdoc.Selection.TypeText(Text:="Matricule   :    " & vrow.Cells("Matricule").Value)
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeText(Text:="Employé    :    " & vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value)
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeText(Text:="Grade         :     " & recherche("select Categorie from Employé where matricule='" & vrow.Cells("Matricule").Value & "'") & "-" & recherche("select Echelon from Employé where matricule='" & vrow.Cells("Matricule").Value & "'"))
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeText(Text:="Indice         :    " & recherche("Select Indice from Indices where Categorie='" & vcategorie & "' and Echelon='" & vechelon & "'"))
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeText(Text:="N°CNSS     :    " & recherche("select SécuSoc from Employé where matricule='" & vrow.Cells("Matricule").Value & "'"))

            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeText(Text:="Sit.Fam      :    " & recherche("select SitFam from Employé where matricule='" & vrow.Cells("Matricule").Value & "'") & " " & recherche("select Enfant from Employé where matricule='" & vrow.Cells("Matricule").Value & "'") & " Enfant(s)")
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeText(Text:="Direction   :    " & recherche("select Service from Employé where matricule='" & vrow.Cells("Matricule").Value & "'"))
            'vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeParagraph()
            PBar1.Value = PBar1.Value + 10
            'création du tableau
            If ComboBox1.Text = "13ième mois" Then
                vdoc.ActiveDocument.Tables.Add(Range:=vdoc.Selection.Range, NumRows:=13, NumColumns:=6)
            Else
                If Prime.Checked = True Then
                    vdoc.ActiveDocument.Tables.Add(Range:=vdoc.Selection.Range, NumRows:=18, NumColumns:=6)
                Else
                    vdoc.ActiveDocument.Tables.Add(Range:=vdoc.Selection.Range, NumRows:=16, NumColumns:=6)
                End If
            End If

            vdoc.ActiveDocument.Tables(l).Columns(1).SetWidth(ColumnWidth:=195, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
            vdoc.ActiveDocument.Tables(l).Columns(2).SetWidth(ColumnWidth:=52, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
            vdoc.ActiveDocument.Tables(l).Columns(3).SetWidth(ColumnWidth:=40, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
            vdoc.ActiveDocument.Tables(l).Columns(4).SetWidth(ColumnWidth:=52, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
            vdoc.ActiveDocument.Tables(l).Columns(5).SetWidth(ColumnWidth:=50, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
            vdoc.ActiveDocument.Tables(l).Columns(6).SetWidth(ColumnWidth:=52, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)

            With vdoc.ActiveDocument.Tables(l)
                .ApplyStyleHeadingRows = True
                .ApplyStyleLastRow = True
                .ApplyStyleFirstColumn = True
                .ApplyStyleLastColumn = True
            End With
            'définit le format de police de l'entête
            vdoc.Selection.Font.Bold = True
            'vdoc.Selection.Font.Name = FontDialog1.Font.Name
            'Ecrit l'entête
            Dim indem_logement As Integer = Math.Round(salbase(vrow.Cells("Matricule").Value) * 0.1, 0, MidpointRounding.AwayFromZero)
            'Dim salbrut As Integer = salbase(vrow.Cells("Matricule").Value) + indem_logement * 2
            'Dim Cnss_ouv As Integer = Math.Round(salbrut * 0.036, 0, MidpointRounding.AwayFromZero)
            'Dim Cnss_pat As Integer = Math.Round(salbrut * 0.164, 0, MidpointRounding.AwayFromZero)
            'vdoc.ActiveDocument.Tables(l).Rows(1).Select()
            vdoc.ActiveDocument.Tables(l).Cell(1, 1).Range.Text = "Rubrique"
            vdoc.ActiveDocument.Tables(l).Cell(1, 2).Range.Text = "Base"
            vdoc.ActiveDocument.Tables(l).Cell(1, 3).Range.Text = "Qté"
            vdoc.ActiveDocument.Tables(l).Cell(1, 4).Range.Text = "Gain"
            vdoc.ActiveDocument.Tables(l).Cell(1, 5).Range.Text = "Retenue"
            vdoc.ActiveDocument.Tables(l).Cell(1, 6).Range.Text = "Total"
            'Aligner les valeurs des colonnes de nombre à droite
            vdoc.ActiveDocument.Tables(l).Columns(6).Select()
            vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            vdoc.ActiveDocument.Tables(l).Columns(5).Select()
            vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            vdoc.ActiveDocument.Tables(l).Columns(4).Select()
            vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            vdoc.ActiveDocument.Tables(l).Columns(3).Select()
            vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            vdoc.ActiveDocument.Tables(l).Columns(2).Select()
            vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            PBar1.Value = PBar1.Value + 10
            'Salaire indiciaire
            vdoc.ActiveDocument.Tables(l).Cell(2, 1).Range.Text = "Salaire indiciaire"
            vdoc.ActiveDocument.Tables(l).Cell(2, 2).Range.Text = Format$(salbase(vrow.Cells("Matricule").Value), "#,###,###,##0")
            'Salaire de base
            PBar1.Value = PBar1.Value + 10
            vdoc.ActiveDocument.Tables(l).Cell(3, 1).Range.Text = "Salaire de base"
            vdoc.ActiveDocument.Tables(l).Cell(3, 2).Range.Text = Format$(salbase(vrow.Cells("Matricule").Value), "#,###,###,##0")
            vdoc.ActiveDocument.Tables(l).Cell(3, 3).Range.Text = "1"
            vdoc.ActiveDocument.Tables(l).Cell(3, 4).Range.Text = Format$(salbase(vrow.Cells("Matricule").Value), "#,###,###,##0")
            'Indemnité de résidence
            PBar1.Value = PBar1.Value + 10
            vdoc.ActiveDocument.Tables(l).Cell(4, 1).Range.Text = "Indemnité de résidence"
            vdoc.ActiveDocument.Tables(l).Cell(4, 4).Range.Text = Format$(Math.Round(salbase(vrow.Cells("Matricule").Value) * 0.1, 0, MidpointRounding.AwayFromZero), "#,###,###,##0")
            'Indemnité de logement
            vdoc.ActiveDocument.Tables(l).Cell(5, 1).Range.Text = "Indemnité de logement"
            vdoc.ActiveDocument.Tables(l).Cell(5, 4).Range.Text = Format$(Math.Round(salbase(vrow.Cells("Matricule").Value) * 0.1, 0, MidpointRounding.AwayFromZero), "#,###,###,##0")
            Dim vligne As Integer = 6
            If ComboBox1.Text <> "13ième mois" Then
                'Prime de déplacement
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 1).Range.Text = "Prime de déplacement"
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 4).Range.Text = Format$(Pd, "#,###,###,##0")
                vligne = vligne + 1
                'Prime de responsabilité
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 1).Range.Text = "Prime de responsabilité"
                If vposte <> "" Then
                    vsql = "select prime from Poste where Poste_Id= '" & vposte & "'"
                    Try
                        resp = recherche(vsql)
                    Catch ex As Exception

                    End Try
                End If
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 4).Range.Text = Format$(resp, "#,###,###,##0")
                vligne = vligne + 1
            End If

            'total primes fixes
            If ComboBox1.Text <> "13ième mois" Then
                Totprimefixe = Math.Round(salbase(vrow.Cells("Matricule").Value) * 0.1, 0, MidpointRounding.AwayFromZero) * 2 + resp + Pd
            Else
                Totprimefixe = Math.Round(salbase(vrow.Cells("Matricule").Value) * 0.1, 0, MidpointRounding.AwayFromZero) * 2
            End If
            vdoc.ActiveDocument.Tables(l).Cell(vligne, 1).Range.Text = "Total primes fixes"
            vdoc.ActiveDocument.Tables(l).Cell(vligne, 4).Range.Text = Format$(Totprimefixe, "#,###,###,##0")
            vligne = vligne + 1

            'Accessoires du salaire si la case à cocher prime est activée
            If Prime.Checked = True Then
                'vligne = vligne + 1
                'Prime de rendement
                Try
                    rend = recherche("select PrimeB from Rendement where Année=" & Annee_prime.Text & " and trimestre=" & Trimestre.Text & " And Matricule='" & vrow.Cells("Matricule").Value & "'")

                Catch ex As Exception
                    rend = 0
                End Try
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 1).Range.Text = "Prime de rendement"
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 4).Range.Text = Format$(rend, "#,###,###,##0")
                vligne = vligne + 1
                'Total prime trimestrielle
                TotPT = rend
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 1).Range.Text = "Total prime trimestrielle"
                vdoc.ActiveDocument.Tables(l).Cell(vligne, 4).Range.Text = Format$(TotPT, "#,###,###,##0")
                vligne = vligne + 1
            End If
            'total brut
            Dim salbrut As Integer = salbase(vrow.Cells("Matricule").Value) + Totprimefixe + rend
            Dim Cnss_ouv As Integer = Math.Round(salbrut * 0.036, 0, MidpointRounding.AwayFromZero)
            Dim Cnss_pat As Integer = Math.Round(salbrut * 0.164, 0, MidpointRounding.AwayFromZero)
            vdoc.ActiveDocument.Tables(l).Cell(vligne, 1).Range.Text = "SALAIRE BRUT"
            'salbrut = salbrut + TotPT
            Cnss_ouv = Math.Round(salbrut * 0.036, 0, MidpointRounding.AwayFromZero)
            Cnss_pat = Math.Round(salbrut * 0.164, 0, MidpointRounding.AwayFromZero)
            vdoc.ActiveDocument.Tables(l).Cell(vligne, 6).Range.Text = Format$(salbrut, "#,###,###,##0")
            PBar1.Value = PBar1.Value + 10
            'Recherche de la retenue
            If ComboBox1.Text = "13ième mois" Then
                retenue = 0
            Else
                vsql = "select Montant from Retenue where Matricule= '" & vrow.Cells("Matricule").Value & "'"
                Try
                    retenue = recherche(vsql)
                Catch ex As Exception

                End Try

            End If


            If Trim(vstatut) = "Conventionné" Then
                'Cotisation CNSS
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 1, 1).Range.Text = "Cotisations C.N.S.S (Part ouvrière)"
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 1, 5).Range.Text = Format$(Cnss_ouv, "#,###,###,##0")
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 1, 2).Range.Text = Format$(salbrut, "#,###,###,##0")
                'Total cotisations sociales
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 2, 1).Range.Text = "Total cotisations sociales"
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 2, 5).Range.Text = Format$(Cnss_ouv, "#,###,###,##0")
                'I.P.T.S
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 3, 1).Range.Text = "I.R.P.P"
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 3, 5).Range.Text = Format$(ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value), "#,###,###,##0")
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 3, 2).Range.Text = Format$(convertir_millieme(salbrut), "#,###,###,##0")
                'Total Impôts
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 4, 1).Range.Text = "Total impôt"
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 4, 5).Range.Text = Format$(ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value), "#,###,###,##0")
                'Salaire net
                salnet = Format$(salbrut - ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value) - Cnss_ouv, "#,###,###,##0")
                vipts = ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value)
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 5, 1).Range.Text = "Salaire net"
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 5, 6).Range.Text = Format$(salnet, "#,###,###,##0")
                'vdoc.ActiveDocument.Tables(l).Cell(vligne + 5, 6).Range.Text = Format$(salbrut - ipts(convertir_millieme(salbrut), vrow.Item("Matricule")) - Cnss_ouv, "#,###,###,##0")
                If ComboBox1.Text <> "13ième mois" Then
                    'Retenue
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 6, 1).Range.Text = "Retenue sur salaire"
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 6, 5).Range.Text = Format$(retenue, "#,###,###,##0")
                    'Montant à payer
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 7, 1).Range.Text = "Montant à payer"
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 7, 6).Range.Text = Format$(salnet - retenue, "#,###,###,##0")
                Else
                    'Montant à payer
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 6, 1).Range.Text = "Montant à payer"
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 6, 6).Range.Text = Format$(salnet, "#,###,###,##0")
                End If

            Else
                'Si c'est un APE
                Cnss_ouv = 0
                'I.P.T.S
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 1, 1).Range.Text = "I.R.P.P"
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 1, 5).Range.Text = Format$(ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value), "#,###,###,##0")
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 1, 2).Range.Text = Format$(convertir_millieme(salbrut), "#,###,###,##0")
                'I.P.T.S APE
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 2, 1).Range.Text = "Retenue I.R.P.P/APE"
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 2, 5).Range.Text = Format$(Vipsape, "#,###,###,##0")
                'Total Impôts
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 3, 1).Range.Text = "Total impôt"
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 3, 5).Range.Text = Format$(ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value) - Vipsape, "#,###,###,##0")
                'Retenue net APE
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 4, 1).Range.Text = "Retenue net APE"
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 4, 5).Range.Text = Format$(Vsalnetape, "#,###,###,##0")
                'Salaire net
                salnet = Format$(salbrut - ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value) - Vsalnetape, "#,###,###,##0")
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 5, 1).Range.Text = "Salaire net"
                'vdoc.ActiveDocument.Tables(l).Cell(vligne + 5, 6).Range.Text = Format$(salbrut - ipts(convertir_millieme(salbrut), vrow.Item("Matricule")) - vrow.Item("SalnetApe"), "#,###,###,##0")
                vdoc.ActiveDocument.Tables(l).Cell(vligne + 5, 6).Range.Text = Format$(salnet, "#,###,###,##0")
                vipts = Format$(ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value) - Vipsape, "#,###,###,##0")
                'ipts(convertir_millieme(salbrut), vrow.Item("Matricule"))
                If ComboBox1.Text <> "13ième mois" Then
                    'Retenue
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 6, 1).Range.Text = "Retenue sur salaire"
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 6, 5).Range.Text = Format$(retenue, "#,###,###,##0")
                    'Montant à payer
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 7, 1).Range.Text = "Montant à payer"
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 7, 6).Range.Text = Format$(salnet - retenue, "#,###,###,##0")
                Else
                    'Montant à payer
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 6, 1).Range.Text = "Montant à payer"
                    vdoc.ActiveDocument.Tables(l).Cell(vligne + 6, 6).Range.Text = Format$(salnet, "#,###,###,##0")
                End If
            End If
            PBar1.Value = PBar1.Value + 10
            vdoc.ActiveDocument.Tables(l).Select()
            vdoc.Selection.Font.Size = 11
            vdoc.Selection.ParagraphFormat.Space15()
            vdoc.Selection.ParagraphFormat.SpaceAfter = 0
            vdoc.Selection.ParagraphFormat.SpaceBefore = 0

            'Mise en forme du tableau
            With vdoc.Selection.Cells
                'With .Shading
                '.Texture = Word.WdTextureIndex.wdTextureNone
                '.ForegroundPatternColor = Word.WdColor.wdColorAutomatic
                '.BackgroundPatternColor = Word.WdColor.wdColorGray30
                'End With
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

            vdoc.Selection.MoveDown()
            vdoc.Selection.MoveDown()
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            vdoc.Selection.TypeText(Text:="Fait à Cotonou le " & Today.Day & " " & MonthName(Today.Month) & " " & Today.Year)
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeParagraph()
            'vdoc.Selection.TypeParagraph()
            vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            vdoc.Selection.TypeText(Text:="L'Employé(e)                                                                                                                La DAF/INSAE")
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeParagraph()
            'vdoc.Selection.TypeParagraph()
            vlong = Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value)
            Dim vbas As String
            Dim ajout As Integer = 20
            'MsgBox(Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value))
            If vlong <= 14 Then
                vbas = vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value & vespace.PadLeft(91 - Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value) + ajout, " ") & recherche("Select Valeur from parametre where variable='DAF'")
            ElseIf vlong > 14 And vlong <= 16 Then
                vbas = vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value & vespace.PadLeft(89 - Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value) + ajout, " ") & recherche("Select Valeur from parametre where variable='DAF'")
            ElseIf vlong > 16 And vlong <= 20 Then
                vbas = vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value & vespace.PadLeft(87 - Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value) + ajout, " ") & recherche("Select Valeur from parametre where variable='DAF'")
            ElseIf vlong > 20 And vlong <= 25 Then
                vbas = vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value & vespace.PadLeft(80 - Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value) + ajout, " ") & recherche("Select Valeur from parametre where variable='DAF'")
            ElseIf vlong > 25 And vlong <= 30 Then
                vbas = vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value & vespace.PadLeft(78 - Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value) + ajout, " ") & recherche("Select Valeur from parametre where variable='DAF'")
            ElseIf vlong > 30 And vlong <= 35 Then
                vbas = vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value & vespace.PadLeft(70 - Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value) + ajout, " ") & recherche("Select Valeur from parametre where variable='DAF'")
            ElseIf vlong > 35 And vlong <= 37 Then
                vbas = vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value & vespace.PadLeft(71 - Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value) + ajout, " ") & recherche("Select Valeur from parametre where variable='DAF'")
            ElseIf vlong > 37 Then
                vbas = vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value & vespace.PadLeft(67 - Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value) + ajout, " ") & recherche("Select Valeur from parametre where variable='DAF'")

            End If
            'Enregistrement de l'historique des salaires
            If recherche("select Salnet from Historique_salaire where Année=" & Annee.Text & " and Mois='" & ComboBox1.Text & "' And Matricule='" & vrow.Cells("matricule").Value & "'") <> "" Then
                If Ecraser.Checked = True Then
                    vsql = "delete from Historique_salaire where Année=" & Annee.Text & " and Mois='" & ComboBox1.Text & "' And Matricule='" & vrow.Cells("matricule").Value & "'"
                    proc_action(vsql)
                    'historique_sal(vrow.Cells("Matricule").Value, vrow.Cells("Nom").Value, vrow.Cells("Prenom").Value, ComboBox1.Text, Annee.Text, vrow.Cells("cat").Value, vrow.Cells("echelon").Value, salbase(vrow.Cells("Matricule").Value), salbrut, vipts, Cnss_ouv, salnet, vrow.Cells("Enfant").Value, vrow.Cells("salnetApe").Value, vrow.Cells("IPTSApe").Value, resp, Pd, retenue)
                    historique_sal(vrow.Cells("Matricule").Value, vrow.Cells("Nom").Value, vrow.Cells("Prenom").Value, ComboBox1.Text, Annee.Text, vcategorie, vechelon, salbase(vrow.Cells("Matricule").Value), salbrut, vipts, Cnss_ouv, salnet - retenue, Venfant, Vsalnetape, Vipsape, resp, Pd, retenue)
                End If
            Else
                historique_sal(vrow.Cells("Matricule").Value, vrow.Cells("Nom").Value, vrow.Cells("Prenom").Value, ComboBox1.Text, Annee.Text, vcategorie, vechelon, salbase(vrow.Cells("Matricule").Value), salbrut, vipts, Cnss_ouv, salnet - retenue, Venfant, Vsalnetape, Vipsape, resp, Pd, retenue)
            End If

            'If recherche("Select matricule from Historique_salaire where Année=" & Annee.Text & " and mois='" & ComboBox1.Text & "'") <> "" Then
            '    proc_action("Delete from Historique_salaire where Année=" & Annee.Text & " and mois='" & ComboBox1.Text & "'")
            'End If
            'Try
            '    historique_sal(vrow.Cells("Matricule").Value, vrow.Cells("Nom").Value, vrow.Cells("Prenom").Value, ComboBox1.Text, Annee.Text, vcategorie, vechelon, salbase(vrow.Cells("Matricule").Value), salbrut, vipts, Cnss_ouv, salnet, Venfant, Vsalnetape, Vipsape)
            'Catch ex As Exception
            'End Try
            PBar1.Value = 100
            'MsgBox("le nom mesure : " & Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value) & Chr(13) & "On doit insérer : " & 78 - Len(vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value))
            'MsgBox("La longueur totale est : " & Len(vbas))
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.TypeText(Text:=vbas)
            vdoc.Selection.TypeParagraph()
            vdoc.Selection.InsertBreak()
            l = l + 1
        Next
        vdoc.Selection.Font.Color = Word.WdColor.wdColorGray25
        vdoc.ActiveDocument.SaveAs(Chemin.Text)
        'vdoc.Quit()
        vcon1.Close()
        'vdoc.ActiveDocument.Tables(l).Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
        'vdoc.ActiveDocument.Tables(l).Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
        Cursor = Cursors.Default
        PBar1.Visible = False
        Vtraitement.Visible = False
        If MsgBox("Le document a été généré. Voulez vous l'ouvrir?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            vdoc.Visible = True
        Else
            vdoc.Quit()
        End If
    End Sub

    Private Sub Imprimer_OV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Imprimer_OV.Click
        imprimer_OV_Partiel()
        'Dim vdoc As Word.Application
        'PBar1.Visible = True
        'Vtraitement.Visible = True
        'PBar1.Value = 10
        'Vtraitement.Text = "Création du fichier word......"
        'Cursor = Cursors.WaitCursor
        '' Initialisation de la variable
        'vdoc = CreateObject("Word.Application")
        ''vdoc.Visible = True
        'vdoc.Documents.Open(Application.StartupPath & "\Doc1.docx")
        'Dim vcon1 As New OleDbConnection(vchaine)
        'vcon1.Open()
        'Dim vcommand As New OleDbCommand(vsql_emp & " order by banque, Nom, Prénom")
        'vcommand.Connection = vcon1
        'Dim vdatatset As New DataSet
        'Dim vadapter As New OleDbDataAdapter(vcommand)
        'vadapter.Fill(vdatatset, "Tbl_employé")
        'Dim vrow As DataGridViewRow
        'Dim l As Integer = 1
        'Dim vbanque As String = ""
        'Dim debut As Boolean = True
        'Dim nb_virement As Integer = 2
        'Dim vtotal As Integer
        'Dim indem_logement, salbrut, cnssouv, vipts, vmontant As Integer
        'For Each vrow In DataGridView2.Rows
        '    If vrow.Index = DataGridView2.Rows.Count - 1 Then
        '        Exit For
        '    End If
        '    Dim vcategorie As String = recherche("select Categorie from Employé where matricule='" & vrow.Cells("Matricule").Value & "'")
        '    Dim vechelon As String = recherche("select Echelon from Employé where matricule='" & vrow.Cells("Matricule").Value & "'")
        '    Dim vstatut As String = recherche("select Statut from Employé where matricule='" & vrow.Cells("Matricule").Value & "'")
        '    Dim Vipsape As Integer = CInt(recherche("select iptsape from Employé where matricule='" & vrow.Cells("Matricule").Value & "'"))
        '    Dim Vsalnetape As Integer = CInt(recherche("select SalnetApe from Employé where matricule='" & vrow.Cells("Matricule").Value & "'"))
        '    Dim Venfant As String = CInt(recherche("select Enfant from Employé where matricule='" & vrow.Cells("Matricule").Value & "'"))
        '    Dim vnumcompte As String = recherche("select Numcompte from Employé where matricule='" & vrow.Cells("Matricule").Value & "'")
        '    If PBar1.Value + 10 > 100 Then
        '        PBar1.Value = 0
        '    Else
        '        PBar1.Value = PBar1.Value + 10
        '    End If
        '    'Si la banque est différente
        '    If vbanque <> vrow.Cells("Banque").Value Then
        '        If vbanque <> "" Then
        '            'on insère la dernière ligne
        '            vdoc.ActiveDocument.Tables(l).Rows.Add()
        '            vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 1).Range.Text = "Total"
        '            vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 2).Range.Text = nb_virement - 2 & " virements"
        '            vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 3).Range.Text = vbanque
        '            'vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 3).RightPadding = True
        '            vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 4).Range.Text = Format$(vtotal, "#,###,###,##0")
        '        End If
        '        'On récupère la nouvelle banque
        '        vbanque = vrow.Cells("Banque").Value
        '        Vtraitement.Text = vbanque
        '        nb_virement = 2
        '        'Si c'est la première page, on n'imprime pas le bas du tableau
        '        If debut <> True Then

        '            'On sélectionne le tableau
        '            vdoc.ActiveDocument.Tables(l).Select()
        '            'On définit le quadrillage du tableau
        '            With vdoc.Selection.Cells
        '                With .Borders(Word.WdBorderType.wdBorderLeft)
        '                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '                    .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '                    .Color = Word.WdColor.wdColorAutomatic
        '                End With
        '                With .Borders(Word.WdBorderType.wdBorderRight)
        '                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '                    .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '                    .Color = Word.WdColor.wdColorAutomatic
        '                End With
        '                With .Borders(Word.WdBorderType.wdBorderTop)
        '                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '                    .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '                    .Color = Word.WdColor.wdColorAutomatic
        '                End With
        '                With .Borders(Word.WdBorderType.wdBorderBottom)
        '                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '                    .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '                    .Color = Word.WdColor.wdColorAutomatic
        '                End With
        '                With .Borders(Word.WdBorderType.wdBorderVertical)
        '                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '                    .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '                    .Color = Word.WdColor.wdColorAutomatic
        '                End With
        '                With .Borders(Word.WdBorderType.wdBorderHorizontal)
        '                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '                    .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '                    .Color = Word.WdColor.wdColorAutomatic
        '                End With
        '                Try
        '                    .Borders(Word.WdBorderType.wdBorderDiagonalDown).LineStyle = Word.WdLineStyle.wdLineStyleNone
        '                    .Borders(Word.WdBorderType.wdBorderDiagonalUp).LineStyle = Word.WdLineStyle.wdLineStyleNone
        '                    .Borders.Shadow = False
        '                Catch ex As Exception

        '                End Try

        '            End With
        '            vdoc.Selection.MoveDown()
        '            vdoc.Selection.MoveDown()
        '            vdoc.Selection.TypeParagraph()
        '            vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        '            vdoc.Selection.TypeText(Text:="Arrêter à la somme de  " & convertir(vtotal) & " francs CFA")
        '            vdoc.Selection.TypeParagraph()
        '            vdoc.Selection.TypeText(Text:="Veuillez agréer, Monsieur le Directeur Général, l'expression de nos salutations distinguées")
        '            vdoc.Selection.TypeParagraph()
        '            vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        '            vdoc.Selection.TypeText(Text:="La Directrice Administrative et Financière                                                                    Le Directeur Général")
        '            vdoc.Selection.TypeParagraph()
        '            vdoc.Selection.TypeParagraph()
        '            vdoc.Selection.TypeParagraph()
        '            vdoc.Selection.TypeText(Text:=recherche("Select Valeur from parametre where variable='DAF'") & "                                                                                                                " & recherche("Select Valeur from parametre where variable='DG'"))
        '            vdoc.Selection.TypeParagraph()
        '            vdoc.Selection.InsertBreak()
        '            l = l + 1
        '            vtotal = 0
        '        End If
        '        debut = False
        '        'Impression du haut du tableau
        '        vdoc.Selection.Font.Bold = True
        '        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
        '        vdoc.Selection.TypeParagraph()
        '        vdoc.Selection.TypeText(Text:="BANK OF AFRICA BENIN")
        '        vdoc.Selection.TypeParagraph()
        '        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        '        vdoc.Selection.TypeText(Text:="N/REF:____/MPD/INSAE/DAF/SC-SP")
        '        vdoc.Selection.TypeParagraph()
        '        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
        '        vdoc.Selection.TypeText(Text:="Cotonou, le " & Today.Day & " " & MonthName(Today.Month) & " " & Today.Year)
        '        vdoc.Selection.TypeParagraph()
        '        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        '        vdoc.Selection.Font.Underline = Word.WdUnderline.wdUnderlineSingle
        '        vdoc.Selection.TypeText(Text:="Objet")
        '        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        '        vdoc.Selection.Font.Underline = Word.WdUnderline.wdUnderlineNone
        '        vdoc.Selection.TypeText(Text:=" : Ordre de virement Salaire du mois de  " & ComboBox1.Text & " " & Today.Year)
        '        vdoc.Selection.TypeParagraph()
        '        vdoc.Selection.Font.Bold = False
        '        vdoc.Selection.TypeText(Text:="Monsieur le Directeur Général")
        '        vdoc.Selection.TypeParagraph()
        '        vdoc.Selection.TypeText(Text:="Par le débit de notre compte ")
        '        vdoc.Selection.Font.Bold = True
        '        vdoc.Selection.TypeText(Text:="N° 01711042624 INSAE, ")
        '        vdoc.Selection.Font.Bold = False
        '        vdoc.Selection.TypeText(Text:="nous vous prions de bien vouloir effectuer le virement au profit des bénéficiaires suivants : ")
        '        vdoc.Selection.Font.Bold = True
        '        'création du tableau
        '        vdoc.ActiveDocument.Tables.Add(Range:=vdoc.Selection.Range, NumRows:=1, NumColumns:=4)
        '        vdoc.ActiveDocument.Tables(l).Columns(1).SetWidth(ColumnWidth:=160.75, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
        '        vdoc.ActiveDocument.Tables(l).Columns(2).SetWidth(ColumnWidth:=92, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
        '        vdoc.ActiveDocument.Tables(l).Columns(3).SetWidth(ColumnWidth:=115, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
        '        vdoc.ActiveDocument.Tables(l).Columns(4).SetWidth(ColumnWidth:=60, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
        '        'Aligner les valeurs des colonnes de nombre à droite
        '        vdoc.ActiveDocument.Tables(l).Columns(2).Select()
        '        vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
        '        vdoc.ActiveDocument.Tables(l).Columns(4).Select()
        '        vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight

        '        With vdoc.ActiveDocument.Tables(l)
        '            .ApplyStyleHeadingRows = True
        '            .ApplyStyleLastRow = True
        '            .ApplyStyleFirstColumn = True
        '            .ApplyStyleLastColumn = True
        '        End With
        '        vdoc.ActiveDocument.Tables(l).Cell(1, 1).Range.Text = "Bénéficiaire"
        '        vdoc.ActiveDocument.Tables(l).Cell(1, 2).Range.Text = "N° de compte"
        '        vdoc.ActiveDocument.Tables(l).Cell(1, 3).Range.Text = "Banque"
        '        vdoc.ActiveDocument.Tables(l).Cell(1, 4).Range.Text = "Montant"
        '    End If
        '    vdoc.Selection.Font.Bold = False
        '    indem_logement = Math.Round(salbase(vrow.Cells("Matricule").Value) * 0.1, 0, MidpointRounding.AwayFromZero)
        '    salbrut = salbase(vrow.Cells("Matricule").Value) + indem_logement * 2
        '    cnssouv = Math.Round(salbrut * 0.036, 0, MidpointRounding.AwayFromZero)
        '    If Trim(vstatut) = "Conventionné" Then
        '        vmontant = salbrut - cnssouv - ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value)
        '    Else
        '        vmontant = salbrut - ipts(convertir_millieme(salbrut), vrow.Cells("Matricule").Value) - Vsalnetape
        '    End If
        '    vdoc.ActiveDocument.Tables(l).Rows.Add()
        '    vdoc.ActiveDocument.Tables(l).Rows(nb_virement).Select()
        '    vdoc.Selection.Font.Bold = False
        '    vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 1).Range.Text = vrow.Cells("Nom").Value & " " & vrow.Cells("Prenom").Value
        '    vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 2).Range.Text = vNumcompte
        '    vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 3).Range.Text = vrow.Cells("Banque").Value
        '    'vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 3).RightPadding = True
        '    vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 4).Range.Text = Format$(vmontant, "#,###,###,##0")
        '    vtotal = vtotal + vmontant
        '    nb_virement = nb_virement + 1
        'Next
        'If vbanque <> "" Then
        '    'on insère la dernière ligne du dernier tableau
        '    vdoc.ActiveDocument.Tables(l).Rows.Add()
        '    vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 1).Range.Text = "Total"
        '    vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 2).Range.Text = nb_virement - 2 & " virements"
        '    vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 3).Range.Text = vbanque
        '    'vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 3).RightPadding = True
        '    vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 4).Range.Text = Format$(vtotal, "#,###,###,##0")
        'End If
        ''On sélectionne le dernier tableau
        ''On sélectionne le tableau
        'vdoc.ActiveDocument.Tables(l).Select()
        ''On définit le quadrillage du tableau
        'With vdoc.Selection.Cells
        '    With .Borders(Word.WdBorderType.wdBorderLeft)
        '        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '        .Color = Word.WdColor.wdColorAutomatic
        '    End With
        '    With .Borders(Word.WdBorderType.wdBorderRight)
        '        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '        .Color = Word.WdColor.wdColorAutomatic
        '    End With
        '    With .Borders(Word.WdBorderType.wdBorderTop)
        '        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '        .Color = Word.WdColor.wdColorAutomatic
        '    End With
        '    With .Borders(Word.WdBorderType.wdBorderBottom)
        '        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '        .Color = Word.WdColor.wdColorAutomatic
        '    End With
        '    With .Borders(Word.WdBorderType.wdBorderVertical)
        '        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '        .Color = Word.WdColor.wdColorAutomatic
        '    End With
        '    With .Borders(Word.WdBorderType.wdBorderHorizontal)
        '        .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        '        .LineWidth = Word.WdLineWidth.wdLineWidth050pt
        '        .Color = Word.WdColor.wdColorAutomatic
        '    End With
        '    Try
        '        .Borders(Word.WdBorderType.wdBorderDiagonalDown).LineStyle = Word.WdLineStyle.wdLineStyleNone
        '        .Borders(Word.WdBorderType.wdBorderDiagonalUp).LineStyle = Word.WdLineStyle.wdLineStyleNone
        '        .Borders.Shadow = False
        '    Catch ex As Exception

        '    End Try

        'End With
        'vdoc.Selection.MoveDown()
        'vdoc.Selection.MoveDown()
        'vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        ''vdoc.Selection.TypeText(Text:="Arrêter à la somme de  (" & Format$(vtotal, "#,###,###,##0") & ") francs CFA")
        'vdoc.Selection.TypeText(Text:="Arrêter à la somme de  " & convertir(vtotal) & " francs CFA")
        'vdoc.Selection.TypeParagraph()
        'vdoc.Selection.TypeText(Text:="Veuillez agréer, Monsieur le Directeur Général, l'expression de nos salutations distinguées")
        'vdoc.Selection.TypeParagraph()
        'vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        'vdoc.Selection.TypeText(Text:="La Directrice Administrative et Financière                                                                    Le Directeur Général")
        'vdoc.Selection.TypeParagraph()
        'vdoc.Selection.TypeParagraph()
        'vdoc.Selection.TypeParagraph()
        'vdoc.Selection.TypeText(Text:=recherche("Select Valeur from parametre where variable='DAF'") & "                                                                                                                " & recherche("Select Valeur from parametre where variable='DG'"))
        'vdoc.Selection.TypeParagraph()
        ''vdoc.Selection.InsertBreak()
        'vdoc.Selection.Font.Color = Word.WdColor.wdColorGray25
        'vcon1.Close()
        'vdoc.ActiveDocument.SaveAs(Chemin.Text)
        ''vdoc.Quit()
        'Cursor = Cursors.Default
        'PBar1.Visible = False
        'Vtraitement.Visible = False
        'If MsgBox("Le document a été généré. Voulez vous l'ouvrir?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
        '    vdoc.Visible = True
        'Else
        '    vdoc.Quit()
        'End If

    End Sub
    Sub imprimer_OV_Partiel()
        Dim vdoc As Word.Application
        PBar1.Visible = True
        Vtraitement.Visible = True
        PBar1.Value = 10
        Vtraitement.Text = "Création du fichier word......"
        Cursor = Cursors.WaitCursor
        ' Initialisation de la variable
        vdoc = CreateObject("Word.Application")
        'vdoc.Visible = True
        vdoc.Documents.Open(Application.StartupPath & "\Doc1.docx")
        Dim vcon1 As New OleDbConnection(vchaine)
        vcon1.Open()
        Dim l As Integer = 1
        Dim vbanque As String = ""
        Dim debut As Boolean = True
        Dim nb_virement As Integer = 2
        Dim vtotal As Integer
        Dim indem_logement, salbrut, cnssouv, vipts, vmontant As Integer
        Dim list_mat As String = ""
        Dim i As Integer = 0
        For Each vrow2 In DataGridView2.Rows
            If i = 0 Then
                list_mat = list_mat & "'" & vrow2.Cells("Matricule").Value & "'"
            Else
                list_mat = list_mat & ",'" & vrow2.Cells("Matricule").Value & "'"
            End If
            'MsgBox(list_mat)
            i = i + 1
        Next
        Dim vcommand As New OleDbCommand(vsql_OV & " And Année=" & Annee.Text & "And Mois='" & ComboBox1.Text & "' And E.matricule In(" & list_mat & ") order by banque, E.Nom, E.Prénom")
        vcommand.Connection = vcon1
        Dim vdatatset As New DataSet
        Dim vadapter As New OleDbDataAdapter(vcommand)
        vadapter.Fill(vdatatset, "Tbl_employé")
        Dim vrow As DataRow
        'Dim l As Integer = 1
        'Dim vbanque As String = ""
        'Dim debut As Boolean = True
        'Dim nb_virement As Integer = 2
        'Dim vtotal As Integer
        'Dim indem_logement, salbrut, cnssouv, vipts, vmontant As Integer
        For Each vrow In vdatatset.Tables("Tbl_employé").Rows
            If PBar1.Value + 10 > 100 Then
                PBar1.Value = 0
            Else
                PBar1.Value = PBar1.Value + 10
            End If
            'Si la banque est différente
            If vbanque <> vrow.Item("Banque") Then
                If vbanque <> "" Then
                    'on insère la dernière ligne
                    vdoc.ActiveDocument.Tables(l).Rows.Add()
                    vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 1).Range.Text = "Total"
                    vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 2).Range.Text = nb_virement - 2 & " virements"
                    vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 3).Range.Text = vbanque
                    'vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 3).RightPadding = True
                    vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 4).Range.Text = Format$(vtotal, "#,###,###,##0")
                End If
                'On récupère la nouvelle banque
                vbanque = vrow.Item("Banque")
                Vtraitement.Text = vbanque
                nb_virement = 2
                'Si c'est la première page, on n'imprime pas le bas du tableau
                If debut <> True Then

                    'On sélectionne le tableau
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
                    vdoc.Selection.MoveDown()
                    vdoc.Selection.MoveDown()
                    vdoc.Selection.TypeParagraph()
                    vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                    vdoc.Selection.TypeText(Text:="Arrêter à la somme de  " & convertir(vtotal) & " francs CFA")
                    vdoc.Selection.TypeParagraph()
                    vdoc.Selection.TypeText(Text:="Veuillez agréer, Monsieur le Directeur Général, l'expression de nos salutations distinguées")
                    vdoc.Selection.TypeParagraph()
                    vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                    vdoc.Selection.TypeText(Text:="La Directrice Administrative et Financière                                                                    Le Directeur Général")
                    vdoc.Selection.TypeParagraph()
                    vdoc.Selection.TypeParagraph()
                    vdoc.Selection.TypeParagraph()
                    vdoc.Selection.TypeText(Text:=recherche("Select Valeur from parametre where variable='DAF'") & "                                                                                                                " & recherche("Select Valeur from parametre where variable='DG'"))
                    vdoc.Selection.TypeParagraph()
                    vdoc.Selection.InsertBreak()
                    l = l + 1
                    vtotal = 0
                End If
                debut = False
                'Impression du haut du tableau
                vdoc.Selection.Font.Bold = True
                vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
                vdoc.Selection.TypeParagraph()
                vdoc.Selection.TypeText(Text:="BANK OF AFRICA BENIN")
                vdoc.Selection.TypeParagraph()
                vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                vdoc.Selection.TypeText(Text:="N/REF:____/MPD/INSAE/DAF/SC-SP")
                vdoc.Selection.TypeParagraph()
                vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
                vdoc.Selection.TypeText(Text:="Cotonou, le " & Today.Day & " " & MonthName(Today.Month) & " " & Today.Year)
                vdoc.Selection.TypeParagraph()
                vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                vdoc.Selection.Font.Underline = Word.WdUnderline.wdUnderlineSingle
                vdoc.Selection.TypeText(Text:="Objet")
                vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                vdoc.Selection.Font.Underline = Word.WdUnderline.wdUnderlineNone
                If ComboBox1.Text = "13ième mois" Then
                    vdoc.Selection.TypeText(Text:=" : Ordre de virement " & ComboBox1.Text & " " & Today.Year)
                Else
                    vdoc.Selection.TypeText(Text:=" : Ordre de virement Salaire du mois de  " & ComboBox1.Text & " " & Today.Year)
                End If
                vdoc.Selection.TypeParagraph()
                vdoc.Selection.Font.Bold = False
                vdoc.Selection.TypeText(Text:="Monsieur le Directeur Général")
                vdoc.Selection.TypeParagraph()
                vdoc.Selection.TypeText(Text:="Par le débit de notre compte ")
                vdoc.Selection.Font.Bold = True
                vdoc.Selection.TypeText(Text:="N° 01711042624 INSAE, ")
                vdoc.Selection.Font.Bold = False
                vdoc.Selection.TypeText(Text:="nous vous prions de bien vouloir effectuer le virement au profit des bénéficiaires suivants : ")
                vdoc.Selection.Font.Bold = True
                'création du tableau
                vdoc.ActiveDocument.Tables.Add(Range:=vdoc.Selection.Range, NumRows:=1, NumColumns:=4)
                vdoc.ActiveDocument.Tables(l).Columns(1).SetWidth(ColumnWidth:=160.75, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                vdoc.ActiveDocument.Tables(l).Columns(2).SetWidth(ColumnWidth:=92, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                vdoc.ActiveDocument.Tables(l).Columns(3).SetWidth(ColumnWidth:=115, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                vdoc.ActiveDocument.Tables(l).Columns(4).SetWidth(ColumnWidth:=60, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                'Aligner les valeurs des colonnes de nombre à droite
                vdoc.ActiveDocument.Tables(l).Columns(2).Select()
                vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
                vdoc.ActiveDocument.Tables(l).Columns(4).Select()
                vdoc.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight

                With vdoc.ActiveDocument.Tables(l)
                    .ApplyStyleHeadingRows = True
                    .ApplyStyleLastRow = True
                    .ApplyStyleFirstColumn = True
                    .ApplyStyleLastColumn = True
                End With
                vdoc.ActiveDocument.Tables(l).Cell(1, 1).Range.Text = "Bénéficiaire"
                vdoc.ActiveDocument.Tables(l).Cell(1, 2).Range.Text = "N° de compte"
                vdoc.ActiveDocument.Tables(l).Cell(1, 3).Range.Text = "Banque"
                vdoc.ActiveDocument.Tables(l).Cell(1, 4).Range.Text = "Montant"
            End If
            vdoc.Selection.Font.Bold = False
            vmontant = vrow.Item("Salnet")
            vdoc.ActiveDocument.Tables(l).Rows.Add()
            vdoc.ActiveDocument.Tables(l).Rows(nb_virement).Select()
            vdoc.Selection.Font.Bold = False
            vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 1).Range.Text = vrow.Item("E.Nom") & " " & vrow.Item("Prénom")
            vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 2).Range.Text = vrow.Item("Numcompte")
            vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 3).Range.Text = vrow.Item("Banque")
            'vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 3).RightPadding = True
            vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 4).Range.Text = Format$(vmontant, "#,###,###,##0")
            vtotal = vtotal + vmontant
            nb_virement = nb_virement + 1
        Next
        If vbanque <> "" Then
            'on insère la dernière ligne du dernier tableau
            vdoc.ActiveDocument.Tables(l).Rows.Add()
            vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 1).Range.Text = "Total"
            vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 2).Range.Text = nb_virement - 2 & " virements"
            vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 3).Range.Text = vbanque
            'vdoc.ActiveDocument.Tables(l).Cell(nb_virement, 3).RightPadding = True
            vdoc.ActiveDocument.Tables(l).Cell(nb_virement + 1, 4).Range.Text = Format$(vtotal, "#,###,###,##0")
        End If
        'On sélectionne le dernier tableau
        'On sélectionne le tableau
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
        vdoc.Selection.MoveDown()
        vdoc.Selection.MoveDown()
        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        'vdoc.Selection.TypeText(Text:="Arrêter à la somme de  (" & Format$(vtotal, "#,###,###,##0") & ") francs CFA")
        vdoc.Selection.TypeText(Text:="Arrêter à la somme de  " & convertir(vtotal) & " francs CFA")
        vdoc.Selection.TypeParagraph()
        vdoc.Selection.TypeText(Text:="Veuillez agréer, Monsieur le Directeur Général, l'expression de nos salutations distinguées")
        vdoc.Selection.TypeParagraph()
        vdoc.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        vdoc.Selection.TypeText(Text:="La Directrice Administrative et Financière                                                                    Le Directeur Général")
        vdoc.Selection.TypeParagraph()
        vdoc.Selection.TypeParagraph()
        vdoc.Selection.TypeParagraph()
        vdoc.Selection.TypeText(Text:=recherche("Select Valeur from parametre where variable='DAF'") & "                                                                                                                " & recherche("Select Valeur from parametre where variable='DG'"))
        vdoc.Selection.TypeParagraph()
        'vdoc.Selection.InsertBreak()
        vdoc.Selection.Font.Color = Word.WdColor.wdColorGray25
        vcon1.Close()
        vdoc.ActiveDocument.SaveAs(Chemin.Text)
        'vdoc.Quit()
        Cursor = Cursors.Default
        PBar1.Visible = False
        Vtraitement.Visible = False
        If MsgBox("Le document a été généré. Voulez vous l'ouvrir?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            vdoc.Visible = True
        Else
            vdoc.Quit()

        End If





    End Sub
    Private Sub Fermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fermer.Click
        fermer_form(Me)
    End Sub

    Private Sub Prime_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Prime.CheckedChanged
        If Prime.Checked = True Then
            GroupBox5.Enabled = True
        Else
            GroupBox5.Enabled = False
        End If
    End Sub
End Class