VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "aa_customerbutton"
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

Dim sCode As String
Dim ServerName As String
Dim SUsername As String
Dim SPass As String
Dim sDtbase As String
Dim d0 As String

Dim d1 As Double
Dim d2 As Double
Dim d3 As Double
Dim d4 As Double
Dim d5 As Double
Dim d6 As Double
Dim d7 As Double
Dim d8 As Double
Dim d9 As Double
Dim d10 As Double

     d0 = ""
     d1 = 0 '客户信用余额
     d2 = 0 '客户应收余额
     d3 = 0 '60天
     d4 = 0 '90天
     d5 = 0 '120天
     d6 = 0 '120以上
     d7 = 0 '本订单开票金额多少
     d8 = 0 '该单据保存后超信用多少
     d9 = 0 '该单据保存后应收余额
     d10 = 0 '信用额度
    
    MsgBox ("abc")
    
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
            If objVoucher.ItemState(i, siHeader).sFieldName = "csocode" Then
                sCode = objVoucher.headerText(i)
            End If
        Next i
    End If

If sCode <> "" Then

        Dim sSQL As String
        sSQL = "exec [_GetZlfx] " & "'" & sCode & "'"
        Dim RS As ADODB.Recordset
        Set RS = ExecuteSql(sSQL)
        If RS.RecordCount > 0 Then
           Do While RS.EOF = False
                d0 = "客户：［" & RS.fields("fl").Value & "］" & RS.fields("fl1").Value
                d1 = RS.fields("xyye").Value
                d2 = RS.fields("ye").Value
                d3 = RS.fields("age0").Value + RS.fields("age1").Value + RS.fields("age2").Value + RS.fields("age3").Value + RS.fields("age4").Value + RS.fields("age5").Value + RS.fields("age6").Value
                d4 = RS.fields("age7").Value + RS.fields("age8").Value + RS.fields("age9").Value
                d5 = RS.fields("age10").Value + RS.fields("age11").Value + RS.fields("age12").Value
                d6 = RS.fields("age13").Value + RS.fields("age14").Value + RS.fields("age15").Value + RS.fields("age16").Value
                d7 = RS.fields("iNatSum").Value
                Dim dTemp As Double
                dTemp = (RS.fields("xyye").Value - RS.fields("iNatSum").Value) * -1
                If dTemp < 0 Then
                    dTemp = 0
                End If
                
                d8 = dTemp
                d9 = RS.fields("ye").Value + RS.fields("iNatSum").Value
                d10 = RS.fields("xyed").Value

                RS.MoveNext
           Loop
        End If

    Dim s As String
    s = d0 & Chr(10) + Chr(13)
    s = s & "1、客户信用额度：           " & Str(d10)
    s = s & Chr(10)
    s = s & "   客户信用余额：           " & Str(d1)
    s = s & Chr(10) + Chr(13)
    s = s & "2、客户应收余额：           " & Str(d2)
    s = s & Chr(10)
    s = s & "       60天：               " & Str(d3)
    s = s & Chr(10)
    s = s & "       90天：               " & Str(d4)
    s = s & Chr(10)
    s = s & "       120天：              " & Str(d5)
    s = s & Chr(10)
    s = s & "       120以上：            " & Str(d6)
    s = s & Chr(10) + Chr(13)
    s = s & "3、本订单开票金额多少：     " & Str(d7)
    s = s & Chr(10) + Chr(13)
    s = s & "4、该单据保存后超信用多少： " & Str(d8)
    s = s & Chr(10) + Chr(13)
    s = s & "5、该单据保存后应收余额：   " & Str(d9)
    FrmReport.RichTextBox1.Text = s
    FrmReport.Show 1
Else
    MsgBox "加载数据失败！"
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


