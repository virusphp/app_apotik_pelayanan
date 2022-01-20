Imports System.Data.SqlClient

Module JamServer
    Public TanggalServer As Date

    Public Sub TglServer()
        CMD = New OleDb.OleDbCommand("Select GETDATE() AS TanggalJam", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        On Error Resume Next
        TanggalServer = DT.Rows(0).Item("TanggalJam")
    End Sub
    Public Function SetTglServer() As Date
        CMD = New OleDb.OleDbCommand("Select GETDATE() AS TanggalJam", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        On Error Resume Next
        SetTglServer = DT.Rows(0).Item("TanggalJam")
    End Function
End Module
