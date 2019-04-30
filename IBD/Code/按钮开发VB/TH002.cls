VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "TH002"
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

' 根据表体自定义项获得采购单价


Public Function RunCommand(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, _
                            ByVal sKey As String, ByVal VarentValue As Variant, ByVal other As String)
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
    
    If Now > "2019-06-01" Then
        MsgBox "Error"
        Exit Function
    End If
        
    
    'sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_2016"
    
    m_cDataBase = objLogin.UfCurrentDb
    
'   If objVoucher Is Nothing Then
'            writelog "objVoucher Is Nothing   ", App.Path & "\log"
'        Else
'            objVoucher.getVoucherDataXML domh, domb
'
'               domh.save App.Path & "\log\domh.xml"
'
'       domb.save App.Path & "\log\domb.xml"
    
'
'            For i = 0 To objVoucher.HeadInfoCount
'                fieldname = objVoucher.ItemState(i, siHeader).sFieldName
''                MsgBox fieldname & "  " & objVoucher.headerText(i)
''
'                If fieldname = "cpoid" Then
'                    sCode = objVoucher.headerText(i)
'                    Exit For
'
'                End If
'            Next i
'   End If
    objVoucher.getVoucherDataXML domh, domb
    Dim s As String
    Dim c As Object
    
    Dim DomNode As IXMLDOMNode
    
    Dim NodChilds As IXMLDOMNode
    
    Dim iRowCou As Integer
    iRowCou = domb.childNodes.Item(0).childNodes.Item(1).childNodes.length
    
    
    Dim sInvCode As String
    Dim sVenName As String
    Dim sCexch_name As String
    
'Kenyu:
'"Me: 供应商：销售报价单表体(sa_quodetails.cdefine31)
'币种: 销售报价单表体 (sa_quodetails.cdefine32)
'按销售报价表体的存货编码?供应商和币种关联到供应商存货价格表中取出采购价格后反写到销售报价单表体 (sa_quodetails.cdefine26)
'供应商是供应商名称

    
    
    For i = 0 To iRowCou - 1
    
        sInvCode = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cinvcode").Text
        sVenName = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cdefine31").Text
        sCexch_name = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cdefine32").Text
        
        Dim sSQL As String
        sSQL = "select iUnitPrice from Ven_Inv_Price a inner join Vendor v on a.cVenCode = v.cVenCode Where v.cVenName = N'" & sVenName & "' and a.cInvCode = N'" & sInvCode & "' and a.cExch_Name = '" + sCexch_name + "' and isnull(a.dDisableDate,'2099-12-31') >= getdate() and a.dEnableDate < getdate() order by a.Autoid desc"
        Dim rs As ADODB.Recordset
        Set rs = ExecuteSql(sSQL)
        
        
        If rs.RecordCount > 0 Then
            Dim iPrice As Double
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cdefine26").Text = rs("iUnitPrice")
        Else
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cdefine26").Text = ""
        End If
    Next
      
    objVoucher.setVoucherDataXML domh, domb
Exit Function

errs:
    MsgBox "Error"
     
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






