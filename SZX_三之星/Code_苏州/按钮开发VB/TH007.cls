VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "TH007"
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



'销售订单按采购开票
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
    
    
        Dim ssss As String
        Dim ssss2 As String
        
      '订单 - 累计采购数量 - 累计开票  <= 0 认为不需要开票,删除当前行
    For i = domb.childNodes.Item(0).childNodes.Item(1).childNodes.length - 1 To 0 Step -1
        Dim sSQL As String
        Dim sisosid As String
        Dim sBillCode As String
        
        sisosid = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("isosid").Text
        sBillCode = domh.childNodes.Item(0).childNodes.Item(1).childNodes.Item(0).Attributes.getNamedItem("csbvcode").Text
        
        sSQL = "select sos.isosid, sos.iQuantity,bills.iQty as BillQty,POs.iQty as POQty " & _
"    ,isnull(POs.iQty,0) - isnull(bills.iQty,0) as iQty " & _
"from so_somain so inner join SO_SODetails sos on so.id = sos.id " & _
"    left join ( " & _
"        select sum(iQuantity) as iQty,b.iSOsID " & _
"        from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID " & _
"        where a.cSBVCode <> '@sBillCode' " & _
"        group by b.iSOsID " & _
"    ) bills on bills .iSOsID = sos.isosid " & _
"    Left Join     ( " & _
"        select  sum(iInvQTY) as iQty,isosid from PO_Podetails group by isosid " & _
"    )POs on POs.isosid = sos.isosid " & _
"where sos.isosid =  @iSOsID "
     
        sSQL = Replace(sSQL, "@iSOsID", sisosid)
        sSQL = Replace(sSQL, "@sBillCode", sBillCode)
        Dim rs As ADODB.Recordset
        Set rs = ExecuteSql(sSQL)

        rs.MoveFirst
        Dim dQuantity As Double
        Dim dQty As Double
        
        dQuantity = CDbl(Trim(domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("iquantity").Text))
        dQty = CDbl(rs("iQty"))
        
        If dQty <= 0 And Not rs.EOF Then
        
            Dim abc As IXMLDOMNode
            Set abc = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i)
            abc.parentNode.removeChild [abc]
        End If

    Next

    
    Dim iSOsID As Integer
    
      '订单 - 累计采购数量 - 累计开票  > 0 如果单据体数量 = 可开票数量 不需要处理
      '否则按照实际可开票数量刷新单据体,同时刷新金额
    For i = 0 To domb.childNodes.Item(0).childNodes.Item(1).childNodes.length - 1
        
        sisosid = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("isosid").Text
        sBillCode = domh.childNodes.Item(0).childNodes.Item(1).childNodes.Item(0).Attributes.getNamedItem("csbvcode").Text
        
        sSQL = "select sos.isosid, sos.iQuantity,bills.iQty as BillQty,POs.iQty as POQty " & _
"    ,isnull(POs.iQty,0) - isnull(bills.iQty,0) as iQty " & _
"from so_somain so inner join SO_SODetails sos on so.id = sos.id " & _
"    left join ( " & _
"        select sum(iQuantity) as iQty,b.iSOsID " & _
"        from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID " & _
"        where a.cSBVCode <> '@sBillCode' " & _
"        group by b.iSOsID " & _
"    ) bills on bills .iSOsID = sos.isosid " & _
"    Left Join     ( " & _
"        select  sum(iInvQTY) as iQty,isosid from PO_Podetails group by isosid " & _
"    )POs on POs.isosid = sos.isosid " & _
"where sos.isosid =  @iSOsID "
     
        sSQL = Replace(sSQL, "@iSOsID", sisosid)
        sSQL = Replace(sSQL, "@sBillCode", sBillCode)
        Set rs = ExecuteSql(sSQL)

        rs.MoveFirst
        
        
        dQuantity = CDbl(Trim(domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("iquantity").Text))
        dQty = CDbl(rs("iQty"))
       ' dPOQty = CDbl(rs("POQty"))
       ' dSaleQty = CDbl(rs("BillQty"))
        
        If dQty > 0 And Not rs.EOF And dQty <> dQuantity Then
        
           domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("iquantity").Text = dQty

            Dim diUnitPrice  As Double
            Dim diTaxUnitPrice  As Double

            Dim diNatUnitPrice As Double
            Dim diTaxRate  As Double

            diUnitPrice = CDbl(Trim(domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("iunitprice").Text))
            diTaxUnitPrice = CDbl(Trim(domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("itaxunitprice").Text))
            diNatUnitPrice = CDbl(Trim(domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("inatunitprice").Text))
            diTaxRate = CDbl(Trim(domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("itaxrate").Text))

            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("isum").Text = Format(dQty * diTaxUnitPrice, "0.00000")
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("imoney").Text = Format(dQty * diUnitPrice, "0.00000")
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("itax").Text = Format(dQty * diTaxUnitPrice, "0.00000") - Format(dQty * diUnitPrice, "0.00000")


            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("inatsum").Text = Format(dQty * diNatUnitPrice * (1 + diTaxRate / 100), "0.00000")
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("inatmoney").Text = Format(dQty * diNatUnitPrice, "0.00000")
            domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("itax").Text = Format(dQty * diNatUnitPrice * (1 + diTaxRate / 100), "0.00000") - Format(dQty * diNatUnitPrice, "0.00000")

        End If
            
       
    Next
    
    objVoucher.setVoucherDataXML domh, domb
Exit Function

errs:
    MsgBox "刷新按订单开票失败！" & Err.Description
    
    
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














