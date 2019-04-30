Attribute VB_Name = "Module1"
'Public
Public m_u8login As U8Login.clsLogin
Public objvouch As UAPVoucherControl85.RecordInfo

Public domh As DOMDocument
Public domb As DOMDocument
Public m_cDataBase As String




Public Sub writelog(logname As String, Optional logpath As String)
Dim filename As String
Dim A, s, S1 As String
filename = CStr(Date) & ".TXT"
If Len(logpath) = 0 Then
    logpath = App.Path & "\log"
End If
Dim FreeNum As Integer
FreeNum = FreeFile
Open logpath & "\" & filename For Append As FreeNum

Print #FreeNum, CStr(Time) & "   " & logname
'Print #FreeNum, S1
Close FreeNum
'关闭文件之后重新以Output的模式打开。
'Print #FreeNum, CStr(Time) & logname
'Close FreeNum

End Sub
