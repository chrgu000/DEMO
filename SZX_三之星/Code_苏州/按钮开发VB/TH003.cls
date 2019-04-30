VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "TH003"
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

'销售订单刷新预留

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
        
    sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_2016"
    
    m_cDataBase = objLogin.UfCurrentDb
    
    objVoucher.getVoucherDataXML domh, domb
    
'    domh.save App.Path & "\log\domh.xml"
'    domb.save App.Path & "\log\domb.xml"


    Dim s As String
    Dim c As Object
    
    Dim DomNode As IXMLDOMNode
    
    Dim NodChilds As IXMLDOMNode
    
    Dim iRowCou As Integer
    iRowCou = domb.childNodes.Item(0).childNodes.Item(1).childNodes.length
                 
    For i = 0 To iRowCou - 1
    
    
        '未知属性是否存在，现删除，在添加
        domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.removeNamedItem ("cbdefine5")
        domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.removeNamedItem ("cbdefine4")
        domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.removeNamedItem ("cbdefine6")
        
        Dim xmlNode As IXMLDOMNode
        Dim xmlAtt As IXMLDOMAttribute
        Set xmlNode = domb.createAttribute("cbdefine5")
        domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.setNamedItem xmlNode
        Set xmlNode = domb.createAttribute("cbdefine4")
        domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.setNamedItem xmlNode
        Set xmlNode = domb.createAttribute("cbdefine6")
        domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.setNamedItem xmlNode
    
        Dim ssss As String
        ssss = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("autoid").Text
        
        Dim sSQL As String
        sSQL = "select b.iQuantity - isnull(c.iQty,0) - isnull(d.iQty,0) as iQtyDisNeed " & _
"        ,isnull(c.iQty,0) as iQtyPEed " & _
"        ,isnull(e.iQty,0) - isnull(c.iQty,0) - isnull(e.fOutQuantity ,0) as iQtyPECan " & _
"from SO_SOMain a inner join SO_SODetails b on a.id = b.ID " & _
"    left join SO_SODetails_extradefine bb on bb.iSOsID = b.iSOsID " & _
"    left join (select cWhCode,cInvCode,sum(iQuantity) as iQty,iSodid from [ST_PELockedSum] group by cWhCode,cInvCode,iSodid) c on b.iSOsID = c.iSodid " & _
"    left join (select cInvCode,sum(iQuantity) as iQty,iSOsID from DispatchLists group by cInvCode,iSOsID) d on b.iSOsID = d.iSOsID " & _
"    left join (select cInvCode,sum(iQuantity) as iQty,sum(fOutQuantity) as fOutQuantity from CurrentStock group by cInvCode) e on e.cInvCode = b.cInvCode " & _
"where b.autoid = @iSOsID"
        sSQL = Replace(sSQL, "@iSOsID", ssss)
        Dim rs As ADODB.Recordset
        Set rs = ExecuteSql(sSQL)
        If rs.EOF Then
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cbdefine5").Text = 0
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cbdefine4").Text = 0
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cbdefine6").Text = 0
        Else
            rs.MoveFirst
            
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cbdefine6").Text = rs("iQtyPECan")
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cbdefine5").Text = rs("iQtyDisNeed")
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("cbdefine4").Text = rs("iQtyPEed")
        End If
        
       
    Next
      
    objVoucher.setVoucherDataXML domh, domb
Exit Function

errs:
    MsgBox "刷新预留失败！"
    
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








