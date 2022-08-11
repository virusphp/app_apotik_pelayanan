Imports System.Data.OleDb

Public Class FormPengkajianResep

    Public KET As String
    Public NO_PENGKAJIAN_RESEP As String
    Public NO_PENGKAJIAN_RESEP_EDIT As String

    Public Sub isiPengkajian(ByVal no_permintaan As String)
        Dim bdList As New BindingSource
        Dim drwList As DataRowView
        '        DA = New OleDb.OleDbDataAdapter("SELECT rj_pengkajian_resep_obat.id, rj_pengkajian_resep_obat.no_permintaan_obat, rj_pengkajian_resep_obat.kode_pengkajian, master_pengkajian_resep.nama_pengkajian, rj_pengkajian_resep_obat.nilai
        'FROM DBSIMRM.dbo.rj_pengkajian_resep_obat INNER JOIN
        'DBSIMRM.dbo.master_pengkajian_resep ON rj_pengkajian_resep_obat.kode_pengkajian = master_pengkajian_resep.kode_pengkajian
        'WHERE rj_pengkajian_resep_obat.no_permintaan_obat ='" & no_permintaan & "'", CONN)
        DA = New OleDb.OleDbDataAdapter("SELECT 
            rj_pengkajian_resep_header.keterangan,
            rj_pengkajian_resep_detail.id, 
            rj_pengkajian_resep_detail.no_pengkajian_resep, 
            rj_pengkajian_resep_detail.kode_pengkajian, 
            master_pengkajian_resep.nama_pengkajian, 
            rj_pengkajian_resep_detail.nilai
            FROM DBSIMRM.dbo.rj_pengkajian_resep_header
            INNER JOIN DBSIMRM.dbo.rj_pengkajian_resep_detail ON rj_pengkajian_resep_header.no_pengkajian_resep = rj_pengkajian_resep_detail.no_pengkajian_resep
            INNER JOIN DBSIMRM.dbo.master_pengkajian_resep ON rj_pengkajian_resep_detail.kode_pengkajian = master_pengkajian_resep.kode_pengkajian
            WHERE rj_pengkajian_resep_header.no_permintaan_obat ='" & no_permintaan & "'", CONN)
        DS = New DataSet
        DA.Fill(DS, "TPengkajian")
        bdList.DataSource = DS
        bdList.DataMember = "TPengkajian"

        isiChekListBox()
        If bdList.Count > 0 Then
            KET = "EDIT"
            bdList.MoveFirst()
            For i As Integer = 1 To bdList.Count
                drwList = bdList.Current
                For j As Integer = 0 To lstPengkajianResep.Items.Count - 1
                    If Trim(lstPengkajianResep.Items.Item(j)) = drwList.Item("nama_pengkajian").ToString & " ~ " & drwList.Item("kode_pengkajian").ToString Then
                        If drwList.Item("nilai").ToString = "1" Then
                            lstPengkajianResep.SetItemChecked(j, True)
                        Else
                            lstPengkajianResep.SetItemChecked(j, False)
                        End If
                    End If
                Next
                bdList.MoveNext()
            Next
        Else
            KET = "BARU"
            For i As Integer = 0 To lstPengkajianResep.Items.Count - 1
                Dim Vkode_pengkajian As String() = Nothing
                Dim kode_pengkajian As String
                Vkode_pengkajian = Strings.Split(Trim(lstPengkajianResep.Items.Item(i)), "~", -1, CompareMethod.Binary)
                kode_pengkajian = Trim(Vkode_pengkajian(1))
                If kode_pengkajian = "PR002" Or kode_pengkajian = "PR003" Then
                    lstPengkajianResep.SetItemChecked(i, True)
                End If
            Next
        End If
    End Sub

    Sub tampolHeader(ByVal no_permintaan As String)
        Dim bdList As New BindingSource
        Dim drwList As DataRowView
        DA = New OleDb.OleDbDataAdapter("SELECT 
            rj_pengkajian_resep_header.keterangan
            FROM DBSIMRM.dbo.rj_pengkajian_resep_header
            WHERE rj_pengkajian_resep_header.no_permintaan_obat ='" & no_permintaan & "'", CONN)
        DS = New DataSet
        DA.Fill(DS, "TPengkajianHeader")
        bdList.DataSource = DS
        bdList.DataMember = "TPengkajianHeader"

        bdList.MoveFirst()
        drwList = bdList.Current

        If bdList.Count > 0 Then
            rtxtKeterangan.Text = drwList.Item("keterangan").ToString
        End If
    End Sub
    Sub Nopengkajian()
        Try
            CMD = New OleDb.OleDbCommand("select max(no_pengkajian_resep) as no_pengkajian_resep from DBSIMRM.dbo.rj_pengkajian_resep_header where Month(created_at)='" & Format(SetTglServer(), "MM") & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If IsDBNull(DT.Rows(0).Item("no_pengkajian_resep")) Then
                NO_PENGKAJIAN_RESEP = "TL" + Format(SetTglServer(), "yyMMdd") + pkdnota + "001"
            Else
                NO_PENGKAJIAN_RESEP = Microsoft.VisualBasic.Right(DT.Rows(0).Item("no_pengkajian_resep").ToString, 3) + 1
                If Len(NO_PENGKAJIAN_RESEP) = 1 Then
                    NO_PENGKAJIAN_RESEP = "TL" + Format(SetTglServer(), "yyMMdd") + pkdnota + "00" & NO_PENGKAJIAN_RESEP & ""
                ElseIf Len(NO_PENGKAJIAN_RESEP) = 2 Then
                    NO_PENGKAJIAN_RESEP = "TL" + Format(SetTglServer(), "yyMMdd") + pkdnota + "0" & NO_PENGKAJIAN_RESEP & ""
                ElseIf Len(NO_PENGKAJIAN_RESEP) = 3 Then
                    NO_PENGKAJIAN_RESEP = "TL" + Format(SetTglServer(), "yyMMdd") + pkdnota + "" & NO_PENGKAJIAN_RESEP & ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub isiChekListBox()
        Dim bdList As New BindingSource
        Dim drwList As DataRowView
        DA = New OleDb.OleDbDataAdapter("Select * From DBSIMRM.dbo.master_pengkajian_resep where status = '1' order by nama_pengkajian ", CONN)
        DS = New DataSet
        DA.Fill(DS, "TPengkajian")
        bdList.DataSource = DS
        bdList.DataMember = "TPengkajian"
        If bdList.Count > 0 Then
            lstPengkajianResep.Items.Clear()
            bdList.MoveFirst()
            For i As Integer = 1 To bdList.Count
                drwList = bdList.Current
                lstPengkajianResep.Items.Add(drwList.Item("nama_pengkajian").ToString & " ~ " & drwList.Item("kode_pengkajian").ToString)
                bdList.MoveNext()
            Next i
        End If
    End Sub

    Private Function sqlCheklist(ByVal KET_EDIT As String) As String
        sqlCheklist = ""
        Dim strSQL As String
        Dim strSQLHeader As String
        Nopengkajian()
        If KET_EDIT = "BARU" Then
            strSQLHeader = "INSERT INTO DBSIMRM.dbo.rj_pengkajian_resep_header(no_pengkajian_resep, no_permintaan_obat, keterangan, user_id, created_at) 
                       VALUES (
                        '" & NO_PENGKAJIAN_RESEP & "',
                        '" & Trim(txtNoPermintaanResep.Text) & "',
                        '" & rtxtKeterangan.Text & "',
                        '" & Trim(FormLogin.LabelKode.Text) & "',
                        '" & Format(SetTglServer(), "yyyy-MM-dd HH:mm:ss") & "'
                        )"
        Else
            strSQLHeader = "UPDATE DBSIMRM.dbo.rj_pengkajian_resep_header set
                            keterangan =  '" & rtxtKeterangan.Text & "',
                            updated_at = '" & Format(SetTglServer(), "yyyy-MM-dd HH:mm:ss") & "'
                            WHERE no_pengkajian_resep = '" & NO_PENGKAJIAN_RESEP_EDIT & "'"
        End If

        For i As Integer = 0 To lstPengkajianResep.Items.Count - 1
            Dim nilai As String = "0"
            If lstPengkajianResep.GetItemChecked(i) = True Then
                nilai = "1"
            End If
            Dim Vkode_pengkajian As String() = Nothing
            Dim kode_pengkajian As String
            Vkode_pengkajian = Strings.Split(Trim(lstPengkajianResep.Items.Item(i)), "~", -1, CompareMethod.Binary)
            kode_pengkajian = Trim(Vkode_pengkajian(1))

            If KET_EDIT = "BARU" Then
                strSQL = "INSERT INTO DBSIMRM.dbo.rj_pengkajian_resep_detail(no_pengkajian_resep,kode_pengkajian,nilai,created_at) " &
                                 " VALUES ('" & NO_PENGKAJIAN_RESEP & "'," &
                                 "'" & kode_pengkajian & "'," &
                                 "'" & nilai & "'," &
                                 "'" & Format(SetTglServer(), "yyyy-MM-dd HH:mm:ss") & "')"
                sqlCheklist = sqlCheklist & vbCrLf & strSQL
            Else
                strSQL = "Update DBSIMRM.dbo.rj_pengkajian_resep_detail set  " &
                                 " nilai                ='" & nilai & "'," &
                                 " updated_at           ='" & Format(SetTglServer(), "yyyy-MM-dd HH:mm:ss") & "' WHERE " &
                                 " no_pengkajian_resep   ='" & NO_PENGKAJIAN_RESEP_EDIT & "' AND " &
                                 " kode_pengkajian      ='" & kode_pengkajian & "'"
                sqlCheklist = sqlCheklist & vbCrLf & strSQL
            End If
        Next i
        sqlCheklist = strSQLHeader & vbCrLf & sqlCheklist
        Return sqlCheklist
    End Function

    Private Sub cmdSimpan_Click(sender As Object, e As EventArgs) Handles cmdSimpan.Click
        konek()
        Dim SQLnya As String = sqlCheklist(KET)
        Dim Command As OleDbCommand = CONN.CreateCommand()
        Dim Trans As OleDbTransaction
        Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
        Command.Connection = CONN
        Command.Transaction = Trans
        Try
            Command.CommandText = SQLnya
            Command.ExecuteNonQuery()
            Trans.Commit()
            MsgBox("Telaah resep berhasil disimpan", vbInformation, "Informasi")
            Me.Dispose()
        Catch ex2 As Exception
            Try
                Trans.Rollback()
                MsgBox(" Commit Exception Type: {0}" & ex2.GetType.ToString & vbCrLf & " Message: {0}" & ex2.Message, vbCritical, "Kesalahan")
            Catch ex3 As Exception
                MsgBox(" Rollback Exception Type:  {0}" & ex3.GetType.ToString & vbCrLf & " Message: {0}" & ex3.Message, vbCritical, "Kesalahan")
            End Try
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtIteration.TextChanged

    End Sub

    Private Sub cmdBatal_Click(sender As Object, e As EventArgs) Handles cmdBatal.Click
        Dispose()
    End Sub
End Class