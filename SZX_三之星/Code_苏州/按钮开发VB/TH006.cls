VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "TH006"
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



'发货单按预留发货
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
    
    
        Dim ssss As String
        Dim ssss2 As String
        
    For i = 0 To domb.childNodes.Item(0).childNodes.Item(1).childNodes.length - 1
    
        ssss = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("isosid").Text
        
        Dim j As Integer
        
        For j = i + 1 To domb.childNodes.Item(0).childNodes.Item(1).childNodes.length - 1
    
            ssss2 = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(j).Attributes.getNamedItem("isosid").Text
            
            If ssss = ssss2 Then
                MsgBox ("已经按照预留发货")
                Exit Function
            End If
        Next
        
    Next

    
    Dim iSOsID As Integer
    
    
    For i = iRowCou - 1 To 0 Step -1
                
        ssss = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("isosid").Text
        
        Dim sSQL As String
        sSQL = "select isnull(c.iQty,0) as iQtyPEed,c.cWhCode,c.cBatch " & _
"from SO_SOMain a inner join SO_SODetails b on a.id = b.ID " & _
"    inner join SO_SODetails_extradefine bb on bb.iSOsID = b.iSOsID " & _
"    inner join (select cWhCode,cInvCode,sum(iQuantity) as iQty,iSodid,cBatch from [ST_PELockedSum] group by cWhCode,cInvCode,iSodid,cBatch) c on b.iSOsID = c.iSodid " & _
"where b.iSOsID = @iSOsID and isnull(c.iQty,0) > 0 "
        sSQL = Replace(sSQL, "@iSOsID", ssss)
        Dim rs As ADODB.Recordset
        Set rs = ExecuteSql(sSQL)
        
        If rs.EOF Then
        
            '取不到预留数据,删除当前行
            Dim abc As IXMLDOMNode
            Set abc = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i)
            abc.parentNode.removeChild [abc]
            
        End If
    Next
    
    Dim xmlLength As Integer
    xmlLength = domb.childNodes.Item(0).childNodes.Item(1).childNodes.length - 1
    
    For i = xmlLength To 0 Step -1
        Dim aaa As IXMLDOMNode
        Set aaa = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i)
        ssss = aaa.Attributes.getNamedItem("isosid").Text

        Dim sSQL2 As String
        sSQL2 = "select isnull(c.iQty,0) as iQtyPEed,c.cWhCode,c.cBatch ,c.cWhName,b.cInvCode,isnull(exch.nflat,1) as iExchRate ,a.cexch_name " & _
"from SO_SOMain a inner join SO_SODetails b on a.id = b.ID " & _
"    inner join SO_SODetails_extradefine bb on bb.iSOsID = b.iSOsID " & _
"    inner join (select a.cWhCode,a.cInvCode,sum(a.iQuantity) as iQty,a.iSodid ,a.cBatch,b.cWhName from [ST_PELockedSum] a inner join Warehouse b on a.cWhCode = b.cWhCode group by a.cWhCode,a.cInvCode,a.iSodid ,a.cBatch,b.cWhName) c on b.iSOsID = c.iSodid " & _
"       left join ( select cexch_name,nflat from exch where itype = 2 and iYear = @iYear and iperiod = @iMonth )exch on exch.cexch_name = a.cexch_name " & _
"where b.iSOsID = @iSOsID and isnull(c.iQty,0) > 0 order by c.cBatch,c.cWhCode "
        sSQL2 = Replace(sSQL2, "@iSOsID", ssss)
        sSQL2 = Replace(sSQL2, "@iYear", Year(CDate(slogDate)))
        sSQL2 = Replace(sSQL2, "@iMonth", Month(CDate(slogDate)))
        
        Dim rs2 As ADODB.Recordset
        Set rs2 = ExecuteSql(sSQL2)

        rs2.MoveFirst
        Dim dQty As Double
        
        dQty = CDbl(Trim(aaa.Attributes.getNamedItem("iquantity").Text))
        
        If dQty > 0 And Not rs2.EOF Then

            Dim dQtyPE As Double
            dQtyPE = CDbl(rs2("iQtyPEed"))

                '未知属性是否存在，现删除，在添加
                aaa.Attributes.removeNamedItem ("cwhcode")
                aaa.Attributes.removeNamedItem ("cwhname")
                aaa.Attributes.removeNamedItem ("cBatch")
                
                 
                 Dim xmlNode As IXMLDOMNode
                 Dim xmlAtt As IXMLDOMAttribute
                 
'                 Set xmlNode = aaa
                 Set xmlNode = domb.createAttribute("cwhcode")
                 aaa.Attributes.setNamedItem xmlNode
                 
                 Set xmlNode = domb.createAttribute("cwhname")
                 aaa.Attributes.setNamedItem xmlNode
                 
                 Set xmlNode = domb.createAttribute("cbatch")
                 aaa.Attributes.setNamedItem xmlNode
                 
            If dQtyPE >= dQty And dQty > 0 Then
                Dim sBatch As String
                sBatch = rs2("cBatch")
                
                Dim sInvCode As String
                sInvCode = rs2("cInvCode")
            
                aaa.Attributes.getNamedItem("cwhcode").Text = rs2("cWhCode")
                aaa.Attributes.getNamedItem("cwhname").Text = rs2("cWhName")
                aaa.Attributes.getNamedItem("cbatch").Text = sBatch
                
                If Trim(sBatch) <> "" Then
                    
                    Dim sSQLBatch As String
                    sSQLBatch = "select dMdate ,dVDate from SA_CurrentStock where cInvCode = 'aaaaaaaa' and cBatch = 'bbbbbbbb'  and dMdate is not null "
                    sSQLBatch = Replace(sSQLBatch, "aaaaaaaa", sInvCode)
                    sSQLBatch = Replace(sSQLBatch, "bbbbbbbb", sBatch)
                    Dim rsBatch As ADODB.Recordset
                    Set rsBatch = ExecuteSql(sSQLBatch)
                    
                    If Not rsBatch.EOF Then
                        rsBatch.MoveFirst
                        
                        aaa.Attributes.removeNamedItem ("dmdate")
                        aaa.Attributes.removeNamedItem ("dvdate")
                        Set xmlNode = domb.createAttribute("dmdate")
                        aaa.Attributes.setNamedItem xmlNode
                        Set xmlNode = domb.createAttribute("dvdate")
                        aaa.Attributes.setNamedItem xmlNode
                 
                        aaa.Attributes.getNamedItem("dmdate").Text = rsBatch("dMdate")
                        aaa.Attributes.getNamedItem("dvdate").Text = rsBatch("dVDate")
                        
                    End If

                    
                End If
            Else

                sBatch = rs2("cBatch")
                sInvCode = rs2("cInvCode")
             
                aaa.Attributes.getNamedItem("iquantity").Text = dQtyPE
                aaa.Attributes.getNamedItem("cwhcode").Text = rs2("cWhCode")
                aaa.Attributes.getNamedItem("cwhname").Text = rs2("cWhName")
                aaa.Attributes.getNamedItem("cbatch").Text = rs2("cBatch")
                

                If Trim(sBatch) <> "" Then
                    
                    sSQLBatch = "select dMdate ,dVDate from SA_CurrentStock where cInvCode = 'aaaaaaaa' and cBatch = 'bbbbbbbb'  and dMdate is not null "
                    sSQLBatch = Replace(sSQLBatch, "aaaaaaaa", sInvCode)
                    sSQLBatch = Replace(sSQLBatch, "bbbbbbbb", sBatch)
                    Set rsBatch = ExecuteSql(sSQLBatch)
                    
                    If Not rsBatch.EOF Then
                        rsBatch.MoveFirst
                        
                        
                        aaa.Attributes.removeNamedItem ("dmdate")
                        aaa.Attributes.removeNamedItem ("dvdate")
                        Set xmlNode = domb.createAttribute("dmdate")
                        aaa.Attributes.setNamedItem xmlNode
                        Set xmlNode = domb.createAttribute("dvdate")
                        aaa.Attributes.setNamedItem xmlNode
                        
                        aaa.Attributes.getNamedItem("dmdate").Text = rsBatch("dMdate")
                        aaa.Attributes.getNamedItem("dvdate").Text = rsBatch("dVDate")
                        
                    End If
                End If
                
                Dim diUnitPrice  As Double
                Dim diTaxUnitPrice  As Double

                Dim diNatUnitPrice As Double
                Dim diTaxRate  As Double



                diUnitPrice = CDbl(Trim(aaa.Attributes.getNamedItem("iunitprice").Text))
                diTaxUnitPrice = CDbl(Trim(aaa.Attributes.getNamedItem("itaxunitprice").Text))
                diNatUnitPrice = CDbl(Trim(aaa.Attributes.getNamedItem("inatunitprice").Text))
                diTaxRate = CDbl(Trim(aaa.Attributes.getNamedItem("itaxrate").Text))

                aaa.Attributes.getNamedItem("isum").Text = Format(dQtyPE * diTaxUnitPrice, "0.00000")
                aaa.Attributes.getNamedItem("imoney").Text = Format(dQtyPE * diUnitPrice, "0.00000")
                aaa.Attributes.getNamedItem("itax").Text = Format(dQtyPE * diTaxUnitPrice, "0.00000") - Format(dQtyPE * diUnitPrice, "0.00000")

                Dim iExchRate  As Double
                iExchRate = Format(rs2("iExchRate"), "0.00000")
                
                aaa.Attributes.getNamedItem("inatsum").Text = Format(Format(dQtyPE * diTaxUnitPrice, "0.00000") * iExchRate, "0.00000")
                aaa.Attributes.getNamedItem("inatmoney").Text = Format(Format(dQtyPE * diUnitPrice, "0.00000") * iExchRate, "0.00000")
                aaa.Attributes.getNamedItem("inattax").Text = Format(Format(dQtyPE * diTaxUnitPrice, "0.00000") * iExchRate, "0.00000") - Format(Format(dQtyPE * diUnitPrice, "0.00000") * iExchRate, "0.00000")
                
            End If
        End If
            
        dQty = dQty - dQtyPE
            
        If Not rs2.EOF Then
             rs2.MoveNext
        End If
           
            
        While dQty > 0 And Not rs2.EOF
        
            dQtyPE = CDbl(rs2("iQtyPEed"))
            
        
            
            Set abc = aaa.cloneNode(True)
            
            Dim dQtyNow As Double
            
            
            If dQtyPE >= dQty Then
                dQtyNow = dQty
                dQty = 0
            Else
            
                dQtyNow = dQtyPE
                dQty = dQty - dQtyPE
            End If
            
            
            abc.Attributes.getNamedItem("iquantity").Text = dQtyNow
            abc.Attributes.getNamedItem("cwhcode").Text = rs2("cWhCode")
            abc.Attributes.getNamedItem("cwhname").Text = rs2("cWhName")
            abc.Attributes.getNamedItem("cbatch").Text = rs2("cBatch")
            
                        
            diUnitPrice = CDbl(Trim(aaa.Attributes.getNamedItem("iunitprice").Text))
            diTaxUnitPrice = CDbl(Trim(aaa.Attributes.getNamedItem("itaxunitprice").Text))
            diNatUnitPrice = CDbl(Trim(aaa.Attributes.getNamedItem("inatunitprice").Text))
            diTaxRate = CDbl(Trim(aaa.Attributes.getNamedItem("itaxrate").Text))

            abc.Attributes.getNamedItem("isum").Text = Format(dQtyNow * diTaxUnitPrice, "0.00000")
            abc.Attributes.getNamedItem("imoney").Text = Format(dQtyNow * diUnitPrice, "0.00000")
            abc.Attributes.getNamedItem("itax").Text = Format(dQtyNow * diTaxUnitPrice, "0.00000") - Format(dQtyNow * diUnitPrice, "0.00000")



            iExchRate = Format(rs2("iExchRate"), "0.00000")
            
            abc.Attributes.getNamedItem("inatsum").Text = Format(Format(dQtyNow * diTaxUnitPrice, "0.00000") * iExchRate, "0.00000")
            abc.Attributes.getNamedItem("inatmoney").Text = Format(Format(dQtyNow * diUnitPrice, "0.00000") * iExchRate, "0.00000")
            abc.Attributes.getNamedItem("inattax").Text = Format(Format(dQtyNow * diTaxUnitPrice, "0.00000") * iExchRate, "0.00000") - Format(Format(dQtyNow * diUnitPrice, "0.00000") * iExchRate, "0.00000")
                
'            abc.Attributes.getNamedItem("inatsum").Text = Format(dQtyNow * diNatUnitPrice * (1 + diTaxRate / 100), "0.00000")
'            abc.Attributes.getNamedItem("inatmoney").Text = Format(dQtyNow * diNatUnitPrice, "0.00000")
'            abc.Attributes.getNamedItem("inattax").Text = Format(dQtyNow * diNatUnitPrice * (1 + diTaxRate / 100), "0.00000") - Format(dQtyNow * diNatUnitPrice, "0.00000")
             
             
            If i = xmlLength Then
                domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(0).parentNode.appendChild [abc]
            Else
                Dim ccc As IXMLDOMNode
                Set ccc = domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i + 1)
                domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).parentNode.insertBefore [abc], [ccc]
            End If
            
            'i = i + 1
            xmlLength = xmlLength + 1
            
            rs2.MoveNext
        Wend
       
'        End If
    Next
    
    For i = 0 To domb.childNodes.Item(0).childNodes.Item(1).childNodes.length - 1
        domb.childNodes.Item(0).childNodes.Item(1).childNodes.Item(i).Attributes.getNamedItem("irowno").Text = i + 1
    Next
    
    objVoucher.setVoucherDataXML domh, domb
Exit Function

errs:
    MsgBox "刷新预留失败！" & Err.Description
    
    
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












