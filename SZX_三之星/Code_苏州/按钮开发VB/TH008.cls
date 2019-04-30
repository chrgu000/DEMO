VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "TH008"
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
'   苏州三之星直运销售发票控制（根据采购发票）
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
        
    sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_2016"
    
    m_cDataBase = objLogin.UfCurrentDb

    objVoucher.getVoucherDataXML domh, domb
    
    
'    domh.save App.Path & "\log\domh.xml"
'    domb.save App.Path & "\log\domb.xml"
    
    Dim sBusType As String
    sBusType = Trim(domh.childNodes.Item(0).childNodes.Item(1).childNodes.Item(0).Attributes.getNamedItem("cbustype").Text)
    If sBusType <> "直运销售" Then
        Exit Function
    End If


    Dim s As String
    Dim c As Object
    
    Dim DomNode As IXMLDOMNode
    
    Dim NodChilds As IXMLDOMNode
    
    Dim iRowCou As Integer
    iRowCou = domb.childNodes.Item(0).childNodes.Item(1).childNodes.length
    
    
    Dim sInvCode As String
    Dim sBarCode  As String
    Dim sErr As String
    Dim sRow As String
    
    
    For i = iRowCou - 1 To 0 Step -1
    
        Dim sisosid As String
        Dim sBillCode As String
        Dim soid As String
        
        sisosid = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("isosid").Text
        sBillCode = domh.childNodes.Item(0).childNodes.Item(1).childNodes.Item(0).Attributes.getNamedItem("csbvcode").Text
        soid = domh.childNodes.Item(0).childNodes.Item(1).childNodes.Item(0).Attributes.getNamedItem("sbvid").Text
        
        Dim dQuantity As Double
        dQuantity = CSng(domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("iquantity").Text)
            
        Dim sSQL As String
        sSQL = "select sos.isosid, sos.iQuantity,bills.iQty as BillQty,POs.iQty as POQty " & _
"    ,isnull(POs.iQty,0) - isnull(bills.iQty,0) as iQty " & _
"from so_somain so inner join SO_SODetails sos on so.id = sos.id " & _
"    left join ( " & _
"        select sum(iQuantity) as iQty,b.iSOsID " & _
"        from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID " & _
"        where a.sbvid <> '@sBillID' " & _
"        group by b.iSOsID " & _
"    ) bills on bills .iSOsID = sos.isosid " & _
"    Left Join     ( " & _
"        select  sum(iInvQTY) as iQty,isosid from PO_Podetails group by isosid " & _
"    )POs on POs.isosid = sos.isosid " & _
"where sos.isosid =  @iSOsID "
     
        sSQL = Replace(sSQL, "@iSOsID", sisosid)
        sSQL = Replace(sSQL, "@sBillID", soid)
        Dim rs As ADODB.Recordset
        Set rs = ExecuteSql(sSQL)
        
        
        If Not rs.EOF Then
            rs.MoveFirst
            
            Dim dQty As Double
'            Dim dQuantity As Double
'
'            dQuantity = CSng(domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("iquantity").Text)
            dQty = CSng(rs("iQty"))
            If dQty < dQuantity Then
                sErr = "单据未按采购开票" & vbCrLf
                Exit For
            End If
        End If
        
    Next
    
    If Len(sErr) > 0 Then
        MsgBox sErr
        
        Cancel = True
    End If
    
    
      
    objVoucher.setVoucherDataXML domh, domb
Exit Function

errs:
    MsgBox "判断按订单开票失败！"
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










