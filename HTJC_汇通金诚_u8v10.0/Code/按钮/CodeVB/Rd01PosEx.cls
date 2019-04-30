VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Rd01PosEx"
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


'参数说明
'objLogin   登陆对象
'objForm    当前窗体
'objVoucher 当前单据对象
'sKey
'VarentValue
'other
'

' 采购入库单清理货位前动作

Public Function BeforeRunSysCommand(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, _
                            ByVal sKey As String, ByVal VarentValue As Variant, ByRef Cancel As Boolean, ByVal other As String)
    

Dim i As Integer
On Error GoTo errs

    
    
    Dim sCode As String
    Dim ServerName As String
    Dim sSqlUser As String
    Dim SPass As String
    Dim sDtbase As String
    Dim fieldname As String
    Dim iYear As Integer
    Dim sUserID As String
    Dim sUserName As String
    Dim slogDate As String
    Dim UFDBName As String
    
    
    sUserID = objLogin.cUserId
    sUserName = objLogin.cUserName
    slogDate = objLogin.CurDate
    iYear = objLogin.cIYear
    
    ServerName = objLogin.dbServerName
    sSqlUser = "sa"
    SPass = objLogin.SysPassword
    UFDBName = objLogin.UFDBName
        
    
    sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_" & iYear
    
    m_cDataBase = objLogin.UfCurrentDb

    objVoucher.getVoucherDataXML domh, domb
    
'
'    domh.save App.Path & "\log\domh.xml"
'    domb.save App.Path & "\log\domb.xml"
    
    Dim lID As String
    Dim RS As ADODB.Recordset
    Dim sSQL As String
    
    lID = domh.childNodes.Item(0).childNodes.Item(1).childNodes.Item(0).Attributes.getNamedItem("id").Text
    
    sSQL = "select isnull(cHandler ,'') as cHandler ,isnull(cAccounter ,'') as cAccounter  from Rdrecord01 where  ID = " & lID
    Set RS = ExecuteSql(sSQL)
    If RS.EOF Then
        MsgBox "获得入库单信息失败"
        Exit Function
    End If
    RS.MoveFirst
    
    If RS("cHandler") <> "" Or RS("cAccounter") <> "" Then
        MsgBox "单据已审核或记账"
        Exit Function
    End If
    
    sSQL = "update Rdrecords01 set BarCode = null where ID = " & lID
    Dim iCou As Integer
    iCou = ExecuteSql2(sSQL)
    If iCou > 0 Then
        Cancel = False
    Else
        MsgBox "未执行清货"
        Cancel = True
        
    End If
Exit Function

errs:
    MsgBox "清货失败！"
    Cancel = True
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
        
50        If Conn2.State <> 1 Then
60        Conn2.Open connectstring
70        End If
80        Conn2.CommandTimeout = 60
90        rst.Open Trim$(Sql), Conn2, adOpenKeyset, adLockOptimistic
100       Set Conn2 = Nothing
110       Set ExecuteSql = rst
End Function





'作用：用来连接到 数据库(单语句执行)
Public Function ExecuteSql2(ByVal Sql As String) As Integer
          Dim Conn2 As New ADODB.Connection
          Dim connectstring As String
          Dim Cmd As New ADODB.Command
          
        connectstring = m_cDataBase
        
        If Conn2.State <> 1 Then
          Conn2.Open connectstring
        End If

        Conn2.CommandTimeout = 60

        Cmd.ActiveConnection = Conn2
        Cmd.CommandText = Sql
        Cmd.Execute
        If Conn2.Errors.Count > 0 Then
            ExecuteSql2 = 0
        Else
            ExecuteSql2 = 1
        End If
       
       
       Set Conn2 = Nothing
       Set Cmd = Nothing
       
End Function




