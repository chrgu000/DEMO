VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "CreateProRDIn"
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
On Error GoTo ErrorLable

Dim sCode As String
Dim ServerName As String
Dim SUsername As String
Dim SPass As String
Dim sDtbase As String
Dim d0 As String
Dim sRdCodeList As String
Dim sUserID As String


    ServerName = objLogin.dbServerName
    SUsername = objLogin.cSub_Id
    SPass = objLogin.SysPassword
    sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_2012"


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
            If objVoucher.ItemState(i, siHeader).sFieldName = "cdlcode" Then
                sCode = objVoucher.headerText(i)
            End If
        Next i
    End If
'

    Dim sSQL As String
    
If sCode <> "" Then
            
    Dim Conn As New ADODB.Connection
    Dim connectstring As String
    connectstring = m_cDataBase
    
    If Conn.State <> adStateOpen Then
        Conn.Open connectstring
    End If
    
    Conn.CommandTimeout = 60
    Conn.BeginTrans
    
    Dim RST As ADODB.Recordset
        sSQL = "select * " & _
            "from DispatchList a inner join DispatchLists b on a.DLID = b.DLID " & _
            "where a.cDLCode = '" & sCode & "' " & _
            "order by a.DLID,b.cWhCode,b.autoid "
        
         Set RST = ExecuteSql(sSQL)
    
    If RST.EOF Then
    
        MsgBox "获得发货单详细信息失败"
        Exit Function
    
   End If
        
        
    '通过产品入库单记录的ID号判断是否已经导入过单据
    'U8表Rdrecords增加字段DispatchListCode 用于记录来源发货单号
    Dim RS As ADODB.Recordset
    sSQL = "select * from Rdrecords10 where DispatchListCode = '" & sCode & "'"
    Set RS = ExecuteSql(sSQL)
    
    If Not RS.EOF Then
    
        MsgBox "单据已经导入，不能重复"
        Exit Function
        
    
    End If
    
  
    Set RS = Nothing
        

    '获得最大单据号
    Dim iCode As Integer
    Dim sRdCode As String
    sSQL = "select max(cCode) as MaxCode from RdRecord10"
    Set RS = ExecuteSql(sSQL)
    
    
        

    If RS.EOF Then
        iCode = 0
    Else
    
        iCode = RS.fields("MaxCode")
    End If
    
    sRdCode = GetRdCode(iCode)
    
    
        
    
'    sSQL = "select max(AutoID) as AutoID ,max(ID) as ID from rdrecords10 "
'    sSQL = "select iFatherId as ID,iChildId as AutoID from UFSystem.dbo.UA_Identity where cAcc_Id = '222' and cVouchType = 'rd'"

    sSQL = "select max(AutoID) as AutoID ,max(ID) as ID " & _
"From " & _
"( " & _
"select max(AutoID) as AutoID ,max(ID) as ID from rdrecords01 " & _
"Union All " & _
"select max(AutoID) as AutoID ,max(ID) as ID from rdrecords08 " & _
"Union All " & _
"select max(AutoID) as AutoID ,max(ID) as ID from rdrecords09 " & _
"Union All " & _
"select max(AutoID) as AutoID ,max(ID) as ID from rdrecords10 " & _
"Union All " & _
"select max(AutoID) as AutoID ,max(ID) as ID from rdrecords11 " & _
"Union All " & _
"select max(AutoID) as AutoID ,max(ID) as ID from rdrecords32 " & _
")a "

    Set RS = ExecuteSql(sSQL)
    
    
        

    Dim ID As Long
    Dim AutoID As Long
    If RS.EOF Then
        ID = 0
        AutoID = 0
    Else
        ID = ConvertNullToLng(RS.fields("ID").Value)
        AutoID = ConvertNullToLng(RS.fields("AutoID").Value)
    End If
     
    Dim sWhCode As String
    Dim iRowNo As Integer
    
        
        
    While Not RST.EOF
    
    '判断是否需要新生成单据
        
        If sWhCode = "" Or sWhCode <> ConvertNullToString(RST.fields("cWhCode").Value) Then
            ID = ID + 1
            
            sWhCode = ConvertNullToString(RST.fields("cWhCode").Value)
            
            iCode = iCode + 1
            sRdCode = GetRdCode(iCode)
            
            
            Dim SoCode As String
            SoCode = RST.fields("cSOCode").Value
            If Len(SoCode) > 20 Then
                SoCode = ""
            End If
            
            
        

            
        Dim lCodeID As Long
        lCodeID = ID
        
    
            sSQL = "insert into rdrecord10 " & _
                        "(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode" & _
                        ",cmaker,cdefine3,bpufirst,biafirst,vt_id,bisstqc,iproorderid,bomfirst,iswfcontrolled,dnmaketime" & _
                        ",dnmodifytime,dnverifytime,iprintcount) " & _
                    "values (N'" & lCodeID & "',N'1',N'10',N'成品入库',N'库存',N'" + sWhCode + "','" & RST.fields("dDate").Value & "',N'" + sRdCode + "',N'102',N'03'" & _
                    ",N'" & RST.fields("cMaker").Value & "',N'" & RST.fields("cSOCode").Value & "',0,0,63,0,N'0',0,0, getdate()" & _
                    ", Null , Null ,0)"

            Conn.Execute sSQL
            
            
            sRdCodeList = sRdCodeList & vbCrLf & sRdCode
            iRowNo = 0
        End If
        

        AutoID = AutoID + 1
        iRowNo = iRowNo + 1
        
        Dim sNum As String
        sNum = ConvertNullToString(RST.fields("iNum").Value)
        If sNum = "" Then
            sNum = "0"
        End If
        
        sNum = "null"
        
        
        sSQL = "Insert Into rdrecords10(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,ipunitcost,ipprice,cbatch" & _
                    ",cvouchcode,cinvouchcode,cinvouchtype,isoutquantity,isoutnum,cfree1,cfree2,ifnum,ifquantity,dvdate " & _
                    ",cposition,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,citem_class,citemcode,cname" & _
                    ",citemcname,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode" & _
                    ",inquantity,innum,cassunit,dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32" & _
                    ",cdefine33,cdefine34,cdefine35,cdefine36,cdefine37,impoids,icheckids,cbvencode,ccheckcode,icheckidbaks" & _
                    ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,cmassunit,cmolotcode,brelated,cmworkcentercode,cbaccounter,dbkeepdate" & _
                    ",bcosting,bvmiused,ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,iinvexchrate,corufts,cmocode,imoseq" & _
                    ",iopseq,copdesc,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,productinids,iorderdid,iordertype" & _
                    ",iordercode,iorderseq,isodid,isotype,csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4" & _
                    ",cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8,cbatchproperty9,cbatchproperty10,cbmemo,irowno,strowguid,cservicecode " & _
                    ",DispatchListCode)" & _
     "Values (" & ConvertNullToString(AutoID) & "," & ConvertNullToString(lCodeID) & ",N'" & RST.fields("cInvCode").Value & "'," & sNum & "," & RST.fields("iQuantity").Value & ",Null,Null,Null,Null,Null" & _
                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" & _
                    ",Null,'" & RST.fields("cdefine22").Value & "','" & RST.fields("cdefine23").Value & "',Null,Null,Null,Null,Null,Null,Null" & _
                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" & _
                    ",Null,Null,Null,Null,Null,'" & RST.fields("cdefine28").Value & "',Null,Null,Null,Null" & _
                    ",'" & RST.fields("cdefine33").Value & "','" & RST.fields("cdefine34").Value & "',Null,Null,Null,Null,Null,Null,Null,Null" & _
                    ",Null,Null,Null,Null,Null,Null,Null,0   ,Null,Null" & _
                    ",1   ,0   ,Null,Null,Null,Null,Null,Null,Null,Null" & _
                    ",Null,Null,0   ,Null,Null,Null,Null,Null,Null,0   " & _
                    ",Null,Null,Null,0   ,Null,Null,Null,Null,Null,Null" & _
                    ",Null,Null,Null,Null,Null,Null,Null,2,Null,Null" & _
                    ",'" & sCode & "')"

        Conn.Execute sSQL
        
        
        sSQL = "insert into IA_ST_UnAccountVouch10(idun,idsun,cvoutypeun,cbustypeun)values " & _
                                "('" & ID & "','" & AutoID & "','10','成品入库')"
        Conn.Execute sSQL
        

        sSQL = "select * from SCM_Item where cInvCode = '" & RST.fields("cInvCode").Value & "' "
        Set RS = ExecuteSql(sSQL)
    

        
        If RS.EOF Then
            sSQL = "insert into SCM_Item(cInvCode,PartId) " & _
                "values('" & RST.fields("cInvCode").Value & "',0)"
            Conn.Execute sSQL
        End If
      
        


        '更新现存量
        sSQL = "declare @itmeid int " & _
                   "select @itmeid = MAX(ItemId) + 1 from CurrentStock " & _
                   "if exists(select * from CurrentStock where cinvcode = '" & RST.fields("cInvCode").Value & "' and cWhCode = '" + sWhCode + "' )" & _
                   "    update CurrentStock set iQuantity = isnull(iQuantity,0) + " & RST.fields("iQuantity").Value & ",iNum = isnull(iNum,0) + " & sNum & " " & _
                   "    where cinvcode = '" & RST.fields("cInvCode").Value & "' and cWhCode = '" + sWhCode + "' " & _
                   "else " & _
                   "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,iNum,ItemId)  " & _
                   "    values('" + sWhCode + "', '" & RST.fields("cInvCode").Value & "'," & RST.fields("iQuantity").Value & "," & sNum & ",@itmeid)"
        Conn.Execute sSQL

'
        RST.MoveNext
        
        
    Wend
    
    
    If ID > 1000000000 Then
        ID = ID - 1000000000
    End If
    If AutoID > 1000000000 Then
        AutoID = AutoID - 1000000000
    End If
        
        sSQL = "update UFSystem.dbo.UA_Identity set iFatherID = " & ConvertNullToString(ID) & ",iChildId = " & ConvertNullToString(AutoID) & " where cAcc_Id = '222' and cVouchType = 'rd'"
        Conn.Execute sSQL

        Conn.CommitTrans
        
        MsgBox "生成产品入库单成功：" + vbCrLf + sRdCodeList, vbOKOnly, "提示"
        Set Conn = Nothing

End If

       Exit Function
       
       
ErrorLable:
    Conn.RollbackTrans
    MsgBox "出错提示如下：" & vbCrLf & Err.Description & vbCrLf & "出错代号：" & Err.Number & vbCrLf & "出错函数『RunCommand』" & vbCrLf & "出错行号：" & Erl, 16, "二次开发"
     

End Function

Public Function GetRdCode(ByVal iCode As Integer)

    Dim sCode As String
    sCode = ConvertNullToString(iCode)
    
    While Len(sCode) < 10
    
        sCode = "0" & sCode
    
    Wend
    
    GetRdCode = sCode

End Function


'作用：用来连接到 数据库(查询)
Public Function ExecuteSql(ByVal Sql As String) As ADODB.Recordset
          Dim Conn2 As New ADODB.Connection
          Dim RST As New ADODB.Recordset
          Dim connectstring As String
10        connectstring = m_cDataBase
20        If RST.State <> adStateClosed Then
30           Set RST = Nothing
40        End If
          
      '50
50        If Conn2.State <> 1 Then
60        Conn2.Open connectstring
70        End If
80        Conn2.CommandTimeout = 60
90        RST.Open Trim$(Sql), Conn2, adOpenKeyset, adLockOptimistic
100       Set Conn2 = Nothing
110       Set ExecuteSql = RST
End Function


