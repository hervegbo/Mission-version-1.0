Imports System.Data.SqlClient
Imports Word = Microsoft.Office.Interop.Word
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO
Module Module1
    Public vserver As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\connexion.txt")
    Public vcon, vcon2 As New System.Data.SqlClient.SqlConnection
    Public vchaine, vchaine2, vsql_emp, vsql_OV As String
    Public Sub killprocess(ByVal vdocument As String, ByVal vapplication As String)
        If File.GetAttributes(Application.StartupPath & vdocument) = 32 Then
            Dim myProcesses As Process() = Process.GetProcessesByName(vdocument)
            Dim myProcess As Process
            For Each myProcess In myProcesses
                myProcess.Kill()
            Next myProcess
        End If
    End Sub

    Public Sub connect()
        test_connexion()
        ' vchaine = "Data Source=" & vserver & ";Initial Catalog=Base_Personnel;User ID=sa"
        'vchaine = "Server=" & vserver & "; Initial Catalog='Presidentiel'; Trusted_Connection=True;"
        'vchaine = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Base_Personnel.mdb"
        vchaine2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Arrieres.mdb"
        vcon.ConnectionString = vchaine
        'vcon2.ConnectionString = vchaine2
        'Connection.Show()
        vsql_emp = "Select * from Employé where Matricule not in(select matricule from debauchage)"
        vsql_OV = "Select E.*, H.* from Employé E, Historique_salaire H where H.matricule=E.matricule and E.Matricule not in(select matricule from debauchage)"
    End Sub
    Public Function recherche(ByVal vsql As String) As String

        Dim vcon2 As New System.Data.SqlClient.SqlConnection
        vcon2.ConnectionString = vchaine
        vcon2.Open()
        Dim vcommand As New System.Data.SqlClient.SqlCommand(vsql, vcon2)
        'MsgBox(vsql)
        Dim vreader As System.Data.SqlClient.SqlDataReader
        vreader = vcommand.ExecuteReader
        If vreader.Read Then
            recherche = vreader.GetValue(0).ToString
        Else
            recherche = ""
        End If
        vcon2.Close()
    End Function
    Public Function rechercheArriere(ByVal vsql As String) As String

        Dim vcon2 As New System.Data.SqlClient.SqlConnection
        vcon2.ConnectionString = vchaine2
        vcon2.Open()
        Dim vcommand As New System.Data.SqlClient.SqlCommand(vsql, vcon2)
        Dim vreader As System.Data.SqlClient.SqlDataReader
        vreader = vcommand.ExecuteReader
        If vreader.Read Then
            rechercheArriere = vreader.GetValue(0).ToString
        Else
            rechercheArriere = ""
        End If
        vcon2.Close()
    End Function
    Public Function NumAuto(ByVal vtable As String, ByVal vchamp As String) As Integer
        Dim vcon2 As New SqlConnection
        vcon2.ConnectionString = vchaine
        vcon2.Open()
        Dim vsql As String
        Dim vcommand As SqlCommand
        Dim vreader As SqlDataReader
        vsql = "select max(" & vchamp & ") from " & vtable
        'MsgBox(vsql)
        vcommand = New SqlCommand(vsql, vcon2)
        vreader = vcommand.ExecuteReader
        vreader.Read()
        Try
            NumAuto = vreader.GetValue(0) + 1
        Catch
            NumAuto = 1
        End Try
        vcon2.Close()
    End Function
    Public Function salairenet(ByVal Matricule As String) As String
        Dim vindem_logement As Integer = Math.Round(salbase(Matricule) * 0.1, 0, MidpointRounding.AwayFromZero)
        Dim vsalbrut As Integer = salbase(Matricule) + vindem_logement * 2
        Dim Cnss_ouv As Integer = Math.Round(vsalbrut * 0.036, 0, MidpointRounding.AwayFromZero)
        Dim Cnss_pat As Integer = Math.Round(vsalbrut * 0.164, 0, MidpointRounding.AwayFromZero)
        If recherche("select Statut from Employé where Matricule='" & Matricule & "'") = "Conventionné" Then

            'Montant à payer
            salairenet = Format$(vsalbrut - ipts(convertir_millieme(vsalbrut), Matricule) - Cnss_ouv, "#,###,###,##0")
            'vipts = ipts(convertir_millieme(vsalbrut), vrow.Item("Matricule"))
        Else
            'Si c'est un APE
            salairenet = Format$(vsalbrut - ipts(convertir_millieme(vsalbrut), Matricule) - recherche("select SalnetApe from Employé where Matricule='" & Matricule & "'"), "#,###,###,##0")
            ' vipts = ipts(convertir_millieme(salbrut), vrow.Item("Matricule"))
        End If

    End Function
    Public Function salairenetAncien(ByVal Matricule As String, ByVal Ancien As Boolean, ByVal Nouveau As Boolean) As String
        Dim vindem_logement As Integer = Math.Round(salbaseAncien(Matricule, Ancien, Nouveau) * 0.1, 0, MidpointRounding.AwayFromZero)
        Dim vsalbrut As Integer = salbaseAncien(Matricule, Ancien, Nouveau) + vindem_logement * 2
        Dim Cnss_ouv As Integer = Math.Round(vsalbrut * 0.036, 0, MidpointRounding.AwayFromZero)
        Dim Cnss_pat As Integer = Math.Round(vsalbrut * 0.164, 0, MidpointRounding.AwayFromZero)
        If rechercheArriere("select Statut from Statut where Matricule='" & Matricule & "'") = "Conventionné" Then

            'Montant à payer
            salairenetAncien = Format$(vsalbrut - iptsAncien(convertir_millieme(vsalbrut), Matricule) - Cnss_ouv, "#,###,###,##0")
            'vipts = ipts(convertir_millieme(vsalbrut), vrow.Item("Matricule"))
        Else
            'Si c'est un APE
            salairenetAncien = Format$(vsalbrut - iptsAncien(convertir_millieme(vsalbrut), Matricule) - rechercheArriere("select SalnetApe from Employé where Matricule='" & Matricule & "'"), "#,###,###,##0")
            ' vipts = ipts(convertir_millieme(salbrut), vrow.Item("Matricule"))
        End If

    End Function
    Public Sub remplir_dgview(ByVal dgview As DataGridView, ByVal vsql As String)
        Try
            Dim vcon2 As New SqlConnection
            vcon2.ConnectionString = vchaine
            vcon2.Open()
            Dim vcommand2 As SqlCommand
            Dim vdataset As New DataSet
            Dim vadapter2 As SqlDataAdapter
            vcommand2 = New SqlCommand(vsql, vcon2)
            vadapter2 = New SqlDataAdapter(vcommand2)
            vadapter2.Fill(vdataset, "Tbl_data")
            dgview.DataSource = vdataset.Tables("Tbl_data")
            dgview.Refresh()
            vcon2.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub remplir_combo2(ByVal cbbox As ComboBox, ByVal vsql As String, ByVal vvalue As String, ByVal vdisplay As String)
        Try
            Dim vcon2 As New SqlConnection
            vcon2.ConnectionString = vchaine
            vcon2.Open()
            Dim vcommand2 As SqlCommand
            Dim vdataset As New DataSet
            Dim vadapter2 As SqlDataAdapter
            vcommand2 = New SqlCommand(vsql, vcon2)
            vadapter2 = New SqlDataAdapter(vcommand2)
            vadapter2.Fill(vdataset, "Tbl_data")
            cbbox.ValueMember = vvalue
            cbbox.DisplayMember = vdisplay
            cbbox.DataSource = vdataset.Tables("Tbl_data")
            vcon2.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function salbase(ByVal Vmat As String)
        Dim vindice As Integer
        Dim vcat As String = recherche("Select categorie from Employé where matricule='" & Vmat & "'")
        Dim vechelon As String = recherche("Select Echelon from Employé where matricule='" & Vmat & "'")
        vindice = recherche("Select Indice from Indices where Echelon='" & vechelon & "' and Categorie='" & vcat & "'")
        salbase = Math.Round(vindice * 469.25, 0, MidpointRounding.AwayFromZero)
    End Function
    Public Function salbaseAncien(ByVal Vmat As String, ByVal Ancien As Boolean, ByVal Nouveau As Boolean)
        Dim vindice As Integer
        Dim vcat As String
        'Dim vechelon As String = recherche("Select Echelon from Employé where matricule='" & Vmat & "'")
        If Ancien = True Then
            vcat = rechercheArriere("Select Cat2015A  from Employé where matricule='" & Vmat & "'")
        Else
            vcat = rechercheArriere("Select Cat2015N  from Employé where matricule='" & Vmat & "'")
        End If
        If Nouveau = False Then
            vindice = rechercheArriere("Select Indice2008 from Indices where grades='" & vcat & "'")
        Else
            vindice = rechercheArriere("Select Indice2016 from Indices where grades='" & vcat & "'")
        End If
        salbaseAncien = Math.Round(vindice * 469.25, 0, MidpointRounding.AwayFromZero)
    End Function
    Sub main()
        connect()
        Dim vmont As Integer = InputBox("Donner le salaire brut")
        Dim vmat As String = InputBox("Donner le matricule")
        MsgBox(ipts(vmont, vmat))

    End Sub
    Function convertir(ByVal nbre2 As Integer)
        'Dim nbre2 As Integer = InputBox("Donner le nombre")
        Dim nbre As String = Trim(Str(nbre2))
        Dim vlong As Integer = Len(Trim(Str(nbre)))
        'Dim vlong2 As Integer = Len(Str(nbre))
        Dim million, millier, centaine As String
        Dim k As Integer = 0
        Dim reste, cpt As Integer
        cpt = 1
        reste = vlong
        Do While k < vlong
            reste = reste - 3
            If reste > 0 Then
                'vlong = reste
                Select Case cpt
                    Case 1
                        centaine = conv_lettre(Right(Trim(CStr(nbre)), 3))
                    Case 2
                        'pour éviter qu'il n'affiche mille si la position des millier ne contient que des zéro  
                        If Mid(Trim(CStr(nbre)), reste + 1, 3) = "000" Then
                            millier = ""
                        ElseIf Mid(Trim(CStr(nbre)), reste + 1, 3) = "001" Then
                            millier = "mille"
                        Else
                            millier = conv_lettre(Mid(Trim(CStr(nbre)), reste + 1, 3)) & " mille "
                        End If
                        'MsgBox(millier)
                    Case 3
                        million = conv_lettre(Left(CStr(nbre), reste + 3)) & "million "
                End Select
            Else
                Select Case cpt
                    Case 1
                        centaine = conv_lettre(Mid(CStr(nbre), 1, 3 + reste))
                    Case 2
                        'Pour empêcher que si c'était mille, il n'écrive un mille
                        If Int(Mid(CStr(nbre), 1, 3 + reste)) = 1 Then
                            millier = "mille"
                        Else
                            millier = conv_lettre(Mid(CStr(nbre), 1, 3 + reste)) & "mille "
                        End If
                    Case 3
                        million = conv_lettre(Mid(CStr(nbre), 1, 3 + reste)) & " million "
                End Select
            End If
            cpt = cpt + 1
            k = k + 3
        Loop
        convertir = million & millier & centaine
    End Function
    Function conv_lettre(ByVal Vnombre As Integer) As String
        Dim vresultat As String = ""
        Dim vnombre2 As String = LTrim(CStr(Vnombre))
        Dim vtaille As Integer = Len(vnombre2)
        'MsgBox(vtaille)
        Dim v1, v2, v3 As Integer
        For i As Integer = vtaille To 1 Step -1
            'MsgBox(Mid(vnombre2, i, 1))
            Select Case vtaille
                Case 1
                    v1 = 0
                    v2 = 0
                    v3 = Mid(vnombre2, 1, 1)
                Case 2
                    v1 = 0
                    v2 = Mid(vnombre2, 1, 1)
                    v3 = Mid(vnombre2, 2, 1)
                Case 3
                    v1 = Mid(vnombre2, 1, 1)
                    v2 = Mid(vnombre2, 2, 1)
                    v3 = Mid(vnombre2, 3, 1)
            End Select
            vresultat = vresultat & " " & Position(i, v1, v2, v3)
        Next
        conv_lettre = vresultat
    End Function
    Function Nb(ByVal Vnb As Integer) As String
        Select Case Vnb
            Case 1
                Nb = "Un"
            Case 2
                Nb = "deux"
            Case 3
                Nb = "trois"
            Case 4
                Nb = "quatre"
            Case 5
                Nb = "cinq"
            Case 6
                Nb = "six"
            Case 7
                Nb = "sept"
            Case 8
                Nb = "huit"
            Case 9
                Nb = "neuf"
            Case Else
                Nb = ""
        End Select
    End Function
    Function Position(ByVal Vpos As Integer, ByVal Nb1 As Integer, ByVal nb2 As Integer, ByVal nb3 As Integer) As String
        Select Case Vpos
            Case 3
                If Nb1 = 1 Then
                    Position = "cent"
                Else
                    Position = Nb(Nb1) & " cent"
                End If
            Case 2
                Select Case nb2
                    Case 1
                        Position = dizaine(nb3)
                    Case 2
                        Position = "vingt"
                    Case 3
                        Position = "trente"
                    Case 4
                        Position = "quarante"
                    Case 5
                        Position = "cinquante"
                    Case 6
                        Position = "soixante"
                    Case 7
                        Position = "soixante " & dizaine(nb3)
                    Case 8
                        Position = "quatre vingt "
                    Case 9
                        Position = "quatre vingt " & dizaine(nb3)
                End Select
            Case 1
                If nb2 = 1 Or nb2 = 9 Or nb2 = 7 Then
                    Position = ""
                Else
                    Position = Nb(nb3)
                End If
            Case Else
                Position = ""
        End Select
    End Function
    Function dizaine(ByVal nb2 As Integer) As String
        Select Case nb2
            Case 1
                dizaine = "onze"
            Case 2
                dizaine = "douze"
            Case 3
                dizaine = "treize"
            Case 4
                dizaine = "quatorze"
            Case 5
                dizaine = "quinze"
            Case 6
                dizaine = "seize"
            Case 7
                dizaine = "dix sept"
            Case 8
                dizaine = "dix huit"
            Case 9
                dizaine = "dix neuf"
            Case 0
                dizaine = "dix"
            Case Else
                dizaine = ""
        End Select

    End Function
    Public Function ipts(ByVal salbrut As Integer, ByVal vmat As String) As Integer
        Dim Nbenfant As Integer = recherche("Select Enfant from Employé where Matricule='" & vmat & "'")
        Dim vipts As Double = 0
        Dim t1, t2, t3, t4, t5 As Integer
        Select Case salbrut
            Case 0 To 50000
                t1 = 0
                t2 = 0
                t3 = 0
                t4 = 0
                t5 = 0
            Case 50001 To 130000
                t1 = 0
                t2 = salbrut - 50000
                t3 = 0
                t4 = 0
                t5 = 0
            Case 130001 To 280000
                t1 = 0
                t2 = 80000
                t3 = salbrut - 130000
                t4 = 0
                t5 = 0

            Case 280001 To 530000
                t1 = 0
                t2 = 80000
                t3 = 150000
                t4 = salbrut - 280000
                t5 = 0

            Case Is > 530000
                t1 = 0
                t2 = 80000
                t3 = 150000
                t4 = 250000
                t5 = salbrut - 530000
        End Select
        vipts = Math.Round(t2 * 0.1, 0, MidpointRounding.AwayFromZero) + Math.Round(t3 * 0.15, 0, MidpointRounding.AwayFromZero) + Math.Round(t4 * 0.2, 0, MidpointRounding.AwayFromZero) + Math.Round(t5 * 0.3, 0, MidpointRounding.AwayFromZero)
        'MsgBox("IPTS avant abattement = " & vipts)
        If Nbenfant < 2 Then
            ipts = vipts
        ElseIf Nbenfant = 2 Then
            ipts = vipts - Math.Round(vipts * 0.05, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.05, 0, MidpointRounding.AwayFromZero))
        ElseIf Nbenfant = 3 Then
            ipts = vipts - Math.Round(vipts * 0.1, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.1, 0, MidpointRounding.AwayFromZero))
        ElseIf Nbenfant = 4 Then
            ipts = vipts - Math.Round(vipts * 0.15, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.15, 0, MidpointRounding.AwayFromZero))
        ElseIf Nbenfant = 5 Then
            ipts = vipts - Math.Round(vipts * 0.2, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.2, 0, MidpointRounding.AwayFromZero))
        ElseIf Nbenfant >= 6 Then
            ipts = vipts - Math.Round(vipts * 0.23, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.23, 0, MidpointRounding.AwayFromZero))
        End If
        'MsgBox("IPTS après abattement = " & ipts)
    End Function
    Public Function iptsAncien(ByVal salbrut As Integer, ByVal vmat As String) As Integer
        Dim Nbenfant As Integer = recherche("Select Enfant from Employé where Matricule='" & vmat & "'")
        Dim vipts As Double = 0
        Dim t1, t2, t3, t4, t5 As Integer
        Select Case salbrut
            Case 0 To 50000
                t1 = 0
                t2 = 0
                t3 = 0
                t4 = 0
                t5 = 0
            Case 50001 To 130000
                t1 = 0
                t2 = salbrut - 50000
                t3 = 0
                t4 = 0
                t5 = 0
            Case 130001 To 280000
                t1 = 0
                t2 = 80000
                t3 = salbrut - 130000
                t4 = 0
                t5 = 0

            Case 280001 To 530000
                t1 = 0
                t2 = 80000
                t3 = 150000
                t4 = salbrut - 280000
                t5 = 0

            Case Is > 530000
                t1 = 0
                t2 = 80000
                t3 = 150000
                t4 = 250000
                t5 = salbrut - 530000
        End Select
        vipts = Math.Round(t2 * 0.1, 0, MidpointRounding.AwayFromZero) + Math.Round(t3 * 0.15, 0, MidpointRounding.AwayFromZero) + Math.Round(t4 * 0.2, 0, MidpointRounding.AwayFromZero) + Math.Round(t5 * 0.3, 0, MidpointRounding.AwayFromZero)
        'MsgBox("IPTS avant abattement = " & vipts)
        If Nbenfant < 2 Then
            iptsAncien = vipts
        ElseIf Nbenfant = 2 Then
            iptsAncien = vipts - Math.Round(vipts * 0.05, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.05, 0, MidpointRounding.AwayFromZero))
        ElseIf Nbenfant = 3 Then
            iptsAncien = vipts - Math.Round(vipts * 0.1, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.1, 0, MidpointRounding.AwayFromZero))
        ElseIf Nbenfant = 4 Then
            iptsAncien = vipts - Math.Round(vipts * 0.15, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.15, 0, MidpointRounding.AwayFromZero))
        ElseIf Nbenfant = 5 Then
            iptsAncien = vipts - Math.Round(vipts * 0.2, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.2, 0, MidpointRounding.AwayFromZero))
        ElseIf Nbenfant >= 6 Then
            iptsAncien = vipts - Math.Round(vipts * 0.23, 0, MidpointRounding.AwayFromZero)
            'MsgBox("Montant abattement : " & Math.Round(vipts * 0.23, 0, MidpointRounding.AwayFromZero))
        End If
        'MsgBox("IPTS après abattement = " & ipts)
    End Function
    'Public Sub Salnet(ByVal vmat As String)
    '    Dim indem_logement As Integer = Math.Round(salbase(vmat) * 0.1, 0, MidpointRounding.AwayFromZero)
    '    'MsgBox("Salaire de base : " & salbase("092/2003") & Chr(13) & "Logement : " & Math.Round(salbase("092/2003") * 0.1, 0, MidpointRounding.AwayFromZero) & Chr(13) & "Résidence : " & Math.Round(salbase("092/2003") * 0.1, 0, MidpointRounding.AwayFromZero) & Chr(13) & "Salaire brut : " & salbase("092/2003") + Math.Round(salbase("092/2003") * 0.1, 0, MidpointRounding.AwayFromZero) + Math.Round(salbase("092/2003") * 0.1, 0, MidpointRounding.AwayFromZero))
    '    Dim salbrut As Integer = salbase(vmat) + indem_logement * 2
    '    'Dim Cnss_ouv As Integer = Math.Round(salbase(vmat) * 3.6, 0, MidpointRounding.AwayFromZero)
    '    Dim Cnss_ouv As Integer = salbase(vmat) * 0.36
    '    Dim Cnss_pat As Integer = Math.Round(salbase(vmat) * 16.4, 0, MidpointRounding.AwayFromZero)
    '    'MsgBox("CNSS : " & Cnss_ouv)
    'End Sub

    Public Function convertir_millieme(ByVal salbrut As Integer) As Integer
        Try
            Dim VstringSal As String
            VstringSal = Left(CStr(salbrut), Len(CStr(salbrut)) - 3) & "000"
            convertir_millieme = CInt(VstringSal)
        Catch ex As Exception

        End Try

    End Function
    Public Sub proc_action(ByVal vsql As String)
        Dim Vconnection As New SqlConnection(vchaine)
        Vconnection.Open()
        Dim Vcommande As New SqlCommand(vsql, Vconnection)
        ' MsgBox(vsql)
        Try
            Vcommande.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Vconnection.Close()
    End Sub
    Public Sub fermer_form(ByVal vform As Form)
        If MsgBox("Voulez-vous fermer le formulaire?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            vform.Close()
        End If
    End Sub
    Public Sub remplir_combo(ByVal vsql As String, ByVal vvalue As String, ByVal vdisplay As String, ByVal vcombo As ComboBox)
        Try
            vcon.Open()
        Catch ex As Exception
        End Try
        'Try
        Dim vcommand As New SqlCommand(vsql, vcon)
        Dim vadapter As New SqlDataAdapter(vcommand)
        Dim vdataset As New DataSet
        vadapter.Fill(vdataset, "Tbl_donnees")
        vcombo.ValueMember = vvalue
        vcombo.DisplayMember = vdisplay
        vcombo.DataSource = vdataset.Tables("Tbl_donnees")
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try
        vcon.Close()
    End Sub
    Public Sub remplir_datagrid(ByVal vsql As String, ByVal vdatagrid As DataGridView)
        Dim vcon2 As New SqlConnection(vchaine)
        vcon2.Open()
        Dim vcommand As New SqlCommand(vsql, vcon)
        Dim vadapter As New SqlDataAdapter(vcommand)
        Dim vdataset As New DataSet
        'MsgBox(vsql)
        vadapter.Fill(vdataset, "Tbl_donnees")
        vdatagrid.DataSource = vdataset.Tables("Tbl_donnees")
        vdatagrid.Refresh()
        vcon2.Close()
    End Sub
    Function verif_chemin(ByVal nom_fich As String) As String
        Dim vchemin As String
        If IO.Directory.Exists("C:\Succès") = False Then
            IO.Directory.CreateDirectory("C:\Succès")
        ElseIf IO.Directory.Exists("C:\Succès\Personnel") = False Then
            IO.Directory.CreateDirectory("C:\Succès\Personnel")
        ElseIf IO.Directory.Exists("C:\Succès\Personnel\Paye") = False Then
            IO.Directory.CreateDirectory("C:\Succès\Personnel\Paye")
        End If
        vchemin = "C:\Succès\Personnel\Paye\" & nom_fich
        Dim vok As Boolean = False
        Dim i As Integer = 1
        Do While vok = False
            If IO.File.Exists(vchemin & ".docx") Or IO.File.Exists(vchemin & ".xlsx") Or IO.File.Exists(vchemin & ".doc") Or IO.File.Exists(vchemin & ".xls") Then
                vchemin = vchemin & "_" & i
            Else
                vok = True
            End If
        Loop
        verif_chemin = vchemin
    End Function
    Public Sub historique_sal(ByVal matricule As String, ByVal Nom As String, ByVal prenom As String, ByVal mois As String, ByVal annee As Integer, ByVal categorie As String, ByVal echelon As String, ByVal salbase As Integer, ByVal salbrut As Integer, ByVal ipts As Integer, ByVal cnss As Integer, ByVal salnet As Integer, ByVal nb_enf As Integer, ByVal salnetApe As Integer, ByVal IPTSApe As Integer, ByVal resp As Integer, ByVal Pd As Integer, ByVal Retenue As Integer)
        Dim vsql As String = "Insert into Historique_salaire(Matricule,Nom, Prenom, Mois, Année,Categorie,Echelon,salbase,salbrut, ipts, cnss, salnet,Enfant, SalnetApe, IPTSApe, PR, PD, Retenue) values('" & matricule & "','" & Nom & "','" & prenom & "','" & mois & "'," & annee & ",'" & categorie & "','" & echelon & "'," & salbase & "," & salbrut & "," & ipts & "," & cnss & "," & salnet & "," & nb_enf & "," & salnetApe & "," & IPTSApe & "," & resp & "," & Pd & "," & Retenue & ")"
        Try
            proc_action(vsql)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub decla_CNSS(ByVal pbar1 As ProgressBar, ByVal vtraitement As Label, ByVal chemin As String, ByVal vdecla As String, ByVal annee As Integer, ByVal periode As String, ByVal vfichier As String)
        Dim vsql As String = ""
        Select Case vdecla
            Case "Salaire"
                vsql = "select matricule, nom, prenom, salbase, salbrut,CNSS  from Historique_Salaire where iptsApe=0 and Mois='" & periode & "' And Année=" & annee
            Case "Rendement"
                vsql = "select E.matricule, nom, prénom As prenom, salaire as salbase, PrimeB as salbrut,CNSS from Rendement R, Employé E where R.matricule=E.matricule and CNSS>0 and Trimestre=" & periode & " And Année=" & annee
            Case "Respo_carburant"
                vsql = "select matricule, nom, prenom, PrimeBrut as salbrut,CNSS from Historique_prime where Trimestre=" & periode & " And  CNSS>0 and Année=" & annee
        End Select
        ' Déclaration de la variable objet Excel
        pbar1.Visible = True
        vtraitement.Visible = True
        Dim vexcel As Excel.Application
        pbar1.Value = 10
        vtraitement.Text = "Création du fichier Excel...."
        ' Initialisation de la variable
        vexcel = CreateObject("Excel.Application")
        'vexcel.Visible = True
        vexcel.Workbooks.Open(Application.StartupPath & "\" & vfichier)
        Dim vcon1 As New SqlConnection(vchaine)
        vcon1.Open()
        Dim vcommand As New SqlCommand(vsql)
        vcommand.Connection = vcon1
        Dim vdatatset As New DataSet
        Dim vadapter As New SqlDataAdapter(vcommand)
        'MsgBox(vsql)
        vadapter.Fill(vdatatset, "Tbl_employé")
        Dim vrow As DataRow
        Dim l As Integer = 1
        'Dim vbanque As String = ""
        'Dim debut As Boolean = True
        Dim nb_virement As Integer = 2
        Dim vtotalsal As Integer = 0
        Dim vprest_fam As Integer = 0
        Dim vrisque_pro As Integer = 0
        Dim vpart_pat As Integer = 0
        Dim vpart_ouv As Integer = 0
        Dim vtotalcot As Integer = 0
        Dim indem_logement, salbrut, cnssouv, vipts, vmontant As Integer
        'On écrit la date
        pbar1.Value = 100
        vexcel.Cells(27, 4) = "Fait à Cotonou le " & Today.Date
        vexcel.Cells(34, 4) = recherche("select valeur from parametre where variable='DG'")
        For Each vrow In vdatatset.Tables("Tbl_employé").Rows
            vtraitement.Text = vrow.Item("Nom") & " " & vrow.Item("Prenom")
            'If Trim(vrow.Item("Statut")) = "Conventionné" Then
            'Dim vlogement As Integer = Math.Round(salbase(vrow.Item("Matricule")) * 0.1, 0, MidpointRounding.AwayFromZero)
            Dim vsalbrut As Integer = vrow.Item("salbrut")
            Dim vcnssouv As Integer
            Try
                vcnssouv = vrow.Item("CNSS")
            Catch ex As Exception
                vcnssouv = vsalbrut * 0.036
            End Try
            Dim vcnspat As Integer = Math.Round(vsalbrut * 0.064, 0, MidpointRounding.AwayFromZero)
            Dim vprestfam As Integer = Math.Round(vsalbrut * 0.09, 0, MidpointRounding.AwayFromZero)
            Dim vrisquepro As Integer = Math.Round(vsalbrut * 0.01, 0, MidpointRounding.AwayFromZero)
            'Incrémentations
            vtotalsal = vtotalsal + vsalbrut
            vprest_fam = vprest_fam + vprestfam
            vrisque_pro = vrisque_pro + vrisquepro
            vpart_ouv = vpart_ouv + vcnssouv
            vpart_pat = vpart_pat + vcnspat
            'End If
            If pbar1.Value + 10 > 100 Then
                pbar1.Value = 0
            Else
                pbar1.Value = pbar1.Value + 10
            End If
        Next
        vtotalcot = vprest_fam + vrisque_pro + vpart_ouv + vpart_pat
        vexcel.Cells(16, 2) = convertir(vtotalcot)
        vexcel.Cells(16, 12) = vtotalsal
        vexcel.Cells(20, 12) = vprest_fam
        vexcel.Cells(22, 12) = vrisque_pro
        vexcel.Cells(26, 12) = vpart_pat
        vexcel.Cells(27, 12) = vpart_ouv
        vexcel.Cells(34, 12) = vtotalcot
        'vexcel.Cells(15, 12) = vtotalsal
        vexcel.ActiveWorkbook.SaveAs(chemin)
        'vexcel.Quit()
        pbar1.Value = 100
        vcon1.Close()
        vtraitement.Visible = False
        pbar1.Visible = False
        If MsgBox("Le document a été généré. Voulez vous l'ouvrir?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            vexcel.Visible = True
        Else
            vexcel.Quit()
        End If
    End Sub
    Sub modif_dateCongé()
        vcon.Open()
        Dim vsql, vsql2 As String
        Dim i As Integer = 1
        Dim vchamp As DataColumn
        Dim vrow As DataRow
        vsql = "Select matricule, c2008c,c2009c, c2010c, c2011c, c2012c, c2013c, c2014c, c2015c, c2016c, c2017c, c2018c from etat_congés"
        Dim vdataset As New DataSet
        Dim vdepart, vretour As Date
        Dim vcommand As New SqlCommand(vsql, vcon)
        Dim vadapter As New SqlDataAdapter(vcommand)
        Dim vtable As DataTable
        vadapter.Fill(vdataset, "Etat_congé")
        vtable = vdataset.Tables("Etat_congé")
        For Each vrow In vtable.Rows
            For Each vchamp In vtable.Columns
                If vchamp.ColumnName <> "matricule" Then
                    If Not IsDBNull(vrow.Item(vchamp)) Then
                        If vrow.Item(vchamp) <> 0 Then
                            vdepart = CDate("01/01/" & Mid(vchamp.ColumnName, 2, 4))
                            vretour = DateAdd(DateInterval.Day, vrow.Item(vchamp), vdepart)
                            vsql2 = "Insert into congé (Id_conge,Matricule, Depart, Retour, Duree, Annee, Cod_typ) Values (" & i & ",'" & vrow.Item("matricule") & "','" & vdepart & "','" & vretour & "'," & vrow.Item(vchamp) & "," & Mid(vchamp.ColumnName, 2, 4) & ",'Administratif')"
                            ' MsgBox(vsql2)
                            proc_action(vsql2)
                            i = i + 1
                        End If
                    End If
                End If
            Next
        Next
    End Sub
    Sub test_connexion()
        Dim serveur As String
        Dim ok As Boolean = False
        ok = False
        Do While ok = False
            Try
                vchaine = "Data Source=" & vserver & ";Initial Catalog=Base_Personnel;User ID=sa;Password=H@wila11071974;"

                'vchaine = "Data Source=" & vserver & ";Initial Catalog=Base_Personnel;User ID=sa;Password=H@wila11071974;"
                'vchaine = "Data Source=" & vserver & ";Initial Catalog=Base_Personnel;User ID=sa"
                vcon.ConnectionString = vchaine
                vcon.Open()
                vcon.Close()
                ok = True
                'Exit Sub
            Catch ex As Exception
                MsgBox(ex.Message)
                serveur = InputBox("La connexion avec le serveur de base de données n'a pa répondu. Donner le nom du serveur.")
                If serveur <> "" Then
                    My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\connexion.txt", serveur, False)
                    vserver = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\connexion.txt")
                Else
                    End
                End If
            End Try
        Loop

    End Sub

    Public Function premiereLettreMaj(vchaine As String) As String
        Dim vresult As String
        Dim vtab As Array
        vresult = ""
        vtab = Split(vchaine, " ")
        'vtab2 = Split(vchaine, "'")
        For i = 0 To vtab.Length - 1
            If vtab(i) <> "du" And vtab(i) <> "des" And vtab(i) <> "de" And vtab(i) <> "et" And vtab(i) <> "le" And vtab(i) <> "la" Then
                'MsgBox(vtab(i) & "     " & Mid(vtab(i), 2))
                If Mid(vtab(i), 2, 1) <> "'" Then
                    If vresult = "" Then
                        vresult = Left(vtab(i), 1).ToUpper & Mid(vtab(i), 2).ToLower
                    Else
                        vresult = vresult & " " & Left(vtab(i), 1).ToUpper & Mid(vtab(i), 2).ToLower
                    End If
                Else
                    If vresult = "" Then
                        vresult = Left(vtab(i), 1).ToLower & "'" & Mid(vtab(i), 3, 1).ToUpper & Mid(vtab(i), 4).ToLower
                    Else
                        vresult = vresult & " " & Left(vtab(i), 1).ToLower & "'" & Mid(vtab(i), 3, 1).ToUpper & Mid(vtab(i), 4).ToLower
                    End If
                End If

            Else
                If vresult = "" Then
                    vresult = vtab(i).ToString.ToLower
                Else
                    vresult = vresult & " " & vtab(i).ToString.ToLower
                End If
            End If
        Next
        Return vresult
    End Function
End Module
