VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "RdRecord10_btnTHPrint"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public Function Init(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, msbar As Object)
    '以下方法可以获得所以单据按钮的Key值
'    Dim i As Integer
'writelog "Function:->Init is true   ", App.Path & "\log"
'    For i = 1 To msbar.buttons.Count
''        Debug.Print msbar.buttons(i).Key
''        Debug.Print msbar.buttons(i).Caption
'        writelog "msbar.buttons(" & i & ").Key   " & msbar.buttons(i).Key, App.Path & "\log"
'        writelog "msbar.buttons(" & i & ").Caption   " & msbar.buttons(i).Caption, App.Path & "\log"
'    Next
End Function

Public Function BeforeRunSysCommand(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, _
                            ByVal sKey As String, ByVal VarentValue As Variant, ByRef Cancel As Boolean, ByVal other As String)
   writelog "Function:->BeforeRunSysCommand is true   ", App.Path & "\log"
    
    
    
    Cancel = False
End Function

'参数说明
'objLogin   登陆对象
'objForm    当前窗体
'objVoucher 当前单据对象
'sKey
'VarentValue
'other
'

Public Function RunCommand(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, _
                            ByVal sKey As String, ByVal VarentValue As Variant, ByVal other As String)
    

Dim i As Integer
On Error GoTo errs

    Dim dLock As Date
    dLock = CDate("2016-11-1")
    Dim dToday As Date
    dToday = DateTime.Now
    If dToday > dLock Then
        GoTo errs
    End If
    
    
    Dim sCode As String
    Dim ServerName As String
    Dim SUsername As String
    Dim SPass As String
    Dim sDtbase As String
    Dim fieldname As String
    ServerName = objLogin.dbServerName
    SUsername = "sa"
    SPass = objLogin.SysPassword
    sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_2015"
    
    m_cDataBase = " Provider = MSDataShape;driver={sql server};" & _
                    " server=" & ServerName & ";" & _
                    " uid=" & SUsername & ";" & _
                    " password=" & SPass & ";" & _
                    " database=" & sDtbase & ";"
    
    
        If objVoucher Is Nothing Then
            writelog "objVoucher Is Nothing   ", App.Path & "\log"
        Else
            objVoucher.getVoucherDataXML domh, domb
            
            For i = 0 To objVoucher.HeadInfoCount
                fieldname = objVoucher.ItemState(i, siHeader).sFieldName
                'MsgBox fieldname
                'MsgBox objVoucher.headerText(i)
                If fieldname = "ccode" Then
                    sCode = objVoucher.headerText(i)
                    Exit For
                    
                End If
            Next i
        End If
    
Dim A As New clsDllForVB.ClaPrintRdRecord


If A.ShowQC10(ServerName, SUsername, SPass, sDtbase, sCode) <> "成功" Then
    'MsgBox "加载失败"
End If


Exit Function

errs:
    MsgBox "加载数据失败！"
End Function


'作用：用来连接到 数据库(查询)
Public Function ExecuteSql(ByVal Sql As String) As ADODB.Recordset
          Dim Conn2 As New ADODB.Connection
          Dim rst As New ADODB.Recordset
          Dim connectstring As String
10        connectstring = m_cDataBase
20        If rst.State <> adStateClosed Then
30           Set rst = Nothing
40        End If
          
      '50
50        If Conn2.State <> 1 Then
60        Conn2.Open connectstring
70        End If
80        Conn2.CommandTimeout = 60
90        rst.Open Trim$(Sql), Conn2, adOpenKeyset, adLockOptimistic
100       Set Conn2 = Nothing
110       Set ExecuteSql = rst
End Function




