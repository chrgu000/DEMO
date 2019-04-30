VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "SaleBill_btnAllowEdit"
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

' 销售普通发票删除前事件

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
        
    
'    sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_" & objLogin
    
    m_cDataBase = objLogin.UfCurrentDb
    
    objVoucher.getVoucherDataXML domh, domb
  
    
    Dim sBillCode As String
    sBillCode = Trim(domh.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("csbvcode").Text)
    Dim sBVID As Long
    sBVID = CLng(Trim(domh.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("sbvid").Text))
    
    Dim sSQL As String
     
    sSQL = "select COUNT(1) as iCou " & _
"from dbo._DispatchLists_SaleBillVouchs _Temp inner join salebillvouchs b on _Temp.SaleBillsID = b.AutoID " & _
"    inner join salebillvouch a on a.SBVID = b.SBVID and _Temp.SaleBillCode = a.cSBVCode " & _
"where _Temp.SaleBillID = " & CStr(sBVID)
      
     Dim rs As ADODB.Recordset
     Set rs = ExecuteSql(sSQL)
     rs.MoveFirst
     
     Dim iCou As Integer
     iCou = CInt(rs(iCou))
     
     If iCou > 0 Then
        MsgBox "The invoice comes from SaleBill(Merge) "
        Cancel = True
     End If
    
Exit Function

errs:
    MsgBox "Error！"
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






