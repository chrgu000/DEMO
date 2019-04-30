VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "MOMOrder_Before_Audit"
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
  
  
'  Dim i As Integer
'On Error GoTo errs
'
'
'    Dim ServerName As String
'    Dim sSqlUser As String
'    Dim SPass As String
'    Dim sDtbase As String
'    Dim fieldname As String
'    Dim iYear As Integer
'    Dim sUserID As String
'    Dim sUserName As String
'    Dim slogDate As String
'
'
'
'    sUserID = objLogin.cUserId
'    sUserName = objLogin.cUserName
''    slogDate = objLogin.slogDate
'    iYear = objLogin.cIYear
'
'    ServerName = objLogin.dbServerName
'    sSqlUser = "sa"
'    SPass = objLogin.SysPassword
'    sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_" & iYear
'
'    m_cDataBase = objLogin.UfCurrentDb
'
'    Dim MOCode As String
'    MOCode = ""
'    Dim sReturn As String
'    sReturn = ""
'
'
'        If objVoucher Is Nothing Then
''            writelog "objVoucher Is Nothing   ", App.Path & "\log"
'        Else
'            objVoucher.getVoucherDataXML domh, domb
'
'
'            For i = 0 To objVoucher.HeadInfoCount
'                fieldname = objVoucher.ItemState(i, siHeader).sFieldName
''                MsgBox fieldname & "  " & objVoucher.headerText(i)
''
'                If LCase(fieldname) = "mocode" Then
'                    MOCode = objVoucher.headerText(i)
'                    Exit For
'
'                End If
'            Next i
'        End If
'
'If MOCode <> "" Then
'
'    Dim sSQL As String
'
'    sSQL = "select * from [dbo].[_TH_GET_MOM] where 订单号 = '" & MOCode & "' order by 材料编码"
'    Dim rs As ADODB.Recordset
'    Set rs = ExecuteSql(sSQL)
'
''文件名 格式:
''工单号;数量;制程部门;计划时间yymmddhhmmss;时间戳
''
''
''文件内容
''第一行: 产品物料编码
''第二行：计划时间： YYYY-MM-DD HH:MM:SS （年月日时间）
''第三行：计划完成时间：YYYY-MM-DD HH:MM:SS （年月日时间）
''第四行：计划下达人：工号;姓名
''第五行：主料号 /t 替代料号（无时填null)/t 材料总用量
'
'        If rs.RecordCount > 0 Then
'            rs.MoveFirst
'        End If
'
'
'    Dim sFileName As String
'    sFileName = RTrim(LTrim(CStr(rs("订单号")))) + ";" + CStr(rs("工单数量")) + ";" + RTrim(LTrim(CStr(rs("部门")))) + Format(rs("生产开工时间"), "yymmddHHmmss") + ";" + RTrim(LTrim(CStr(rs("时间戳"))))
'
'         sReturn = sReturn & rs("产品编码") & vbCrLf
'         sReturn = sReturn & Format(rs("生产开工时间"), "YYYY-MM-DD HH:MM:SS") & vbCrLf
'         sReturn = sReturn & Format(rs("生产结束时间"), "YYYY-MM-DD HH:MM:SS") & vbCrLf
'         sReturn = sReturn & rs("工号") & ";" & rs("姓名") & vbCrLf
'
'
'        For i = 0 To rs.RecordCount - 1
'            sReturn = sReturn & rs("材料编码") & _
'                vbTab & CStr(i + 1) & _
'                vbTab & "NULL" & _
'                vbTab & rs("材料数量") & _
'                vbCrLf
'
'            rs.MoveNext
'          Next i
'
' End If
'
'    Open "C:\\ExangeFiles\\" + sFileName + ".txt" For Output As #1
'    Print #1, sReturn
'    Close #1
'
'
'Exit Function
'
'errs:
'    MsgBox "导出文件失败，请确认：" & _
'        vbCrLf + "1. 订单状态" & _
'        vbCrLf "2. 文件夹是否存在！"
'
'    Cancel = True
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


    Dim ServerName As String
    Dim sSqlUser As String
    Dim SPass As String
    Dim sDtbase As String
    Dim fieldname As String
    Dim iYear As Integer
    Dim sUserID As String
    Dim sUserName As String
    Dim slogDate As String
    
    
    
    sUserID = objLogin.cUserId
    sUserName = objLogin.cUserName
'    slogDate = objLogin.slogDate
    iYear = objLogin.cIYear
    
    ServerName = objLogin.dbServerName
    sSqlUser = "sa"
    SPass = objLogin.SysPassword
    sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_" & iYear
    
    m_cDataBase = objLogin.UfCurrentDb
    
    Dim MOCode As String
    MOCode = ""
    Dim sReturn As String
    sReturn = ""
    
    
        If objVoucher Is Nothing Then
'            writelog "objVoucher Is Nothing   ", App.Path & "\log"
        Else
            objVoucher.getVoucherDataXML domh, domb
            
    
            For i = 0 To objVoucher.HeadInfoCount
                fieldname = objVoucher.ItemState(i, siHeader).sFieldName
'                MsgBox fieldname & "  " & objVoucher.headerText(i)
'
                If LCase(fieldname) = "mocode" Then
                    MOCode = objVoucher.headerText(i)
                    Exit For
                    
                End If
            Next i
        End If
    
If MOCode <> "" Then

    Dim sSQL As String
    
    sSQL = "select * from [dbo].[_TH_GET_MOM] where 订单号 = '" & MOCode & "' order by 材料编码"
    Dim rs As ADODB.Recordset
    Set rs = ExecuteSql(sSQL)
    
'文件名 格式:
'工单号;数量;制程部门;计划时间yymmddhhmmss;时间戳
'
'
'文件内容
'第一行: 产品物料编码
'第二行：计划时间： YYYY-MM-DD HH:MM:SS （年月日时间）
'第三行：计划完成时间：YYYY-MM-DD HH:MM:SS （年月日时间）
'第四行：计划下达人：工号;姓名
'第五行：主料号 /t 替代料号（无时填null)/t 材料总用量

        
        If Not rs.EOF And Not rs.BOF Then
            rs.MoveFirst
        End If
        
        
    Dim sFileName As String
    sFileName = RTrim(LTrim(CStr(rs("订单号")))) + ";" + CStr(rs("工单数量")) + ";" + RTrim(LTrim(CStr(rs("部门")))) + Format(rs("生产开工时间"), "yymmddHHmmss") + ";" + RTrim(LTrim(CStr(rs("时间戳"))))
    
         sReturn = sReturn & rs("产品编码") & vbCrLf
         sReturn = sReturn & Format(rs("生产开工时间"), "YYYY-MM-DD HH:MM:SS") & vbCrLf
         sReturn = sReturn & Format(rs("生产结束时间"), "YYYY-MM-DD HH:MM:SS") & vbCrLf
         sReturn = sReturn & rs("工号") & ";" & rs("姓名") & vbCrLf
         

    While Not rs.EOF
             sReturn = sReturn & rs("材料编码") & _
                vbTab & CStr(i + 1) & _
                vbTab & "NULL" & _
                vbTab & rs("材料数量") & _
                vbCrLf

            rs.MoveNext
    Wend
    
 End If
 
    Open "Z:\\" + sFileName + ".txt" For Output As #1
    Print #1, sReturn
    Close #1

    MsgBox "工单输出成功：" & "Z:\\" + sFileName + ".txt"
    
    sSQL = "update mom_order set Define5 = isnull(Define5,0) + 1 where MoCode = '" & RTrim(LTrim(MOCode)) & "' "
    ExecuteSql (sSQL)
    
Exit Function

errs:
    MsgBox "导出文件失败，请确认：" & _
        vbCrLf + "1. 订单状态" & _
        vbCrLf + "2. 文件夹是否存在！" & _
        vbCrLf + "3. 工单是否发料！"
    
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
60          Conn2.Open connectstring
70        End If
80        Conn2.CommandTimeout = 60
90        rst.Open Trim$(Sql), Conn2, adOpenKeyset, adLockOptimistic
100       Set Conn2 = Nothing
110       Set ExecuteSql = rst
End Function




