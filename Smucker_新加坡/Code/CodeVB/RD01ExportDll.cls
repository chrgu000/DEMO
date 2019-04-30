VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "RD01ExportDll"
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

'导出采购入库单
Public Function RunCommand(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, _
                            ByVal sKey As String, ByVal VarentValue As Variant, ByVal other As String)
    


On Error GoTo Errs
    
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
       Dim i As Integer
    Dim j As Integer
    
    
    sUserID = objLogin.cUserId
    sUserName = objLogin.cUserName
'    slogDate = objLogin.slogDate
    iYear = objLogin.cIYear
    
    ServerName = objLogin.dbServerName
    sSqlUser = "sa"
    SPass = objLogin.SysPassword
    sDtbase = "UFDATA_" & objLogin.cAcc_Id & "_" & iYear
    
    m_cDataBase = objLogin.UfCurrentDb
    
    
        If objVoucher Is Nothing Then
            writelog "objVoucher Is Nothing   ", App.Path & "\log"
        Else
            objVoucher.getVoucherDataXML domh, domb
            
            For i = 0 To objVoucher.HeadInfoCount
                fieldname = objVoucher.ItemState(i, siHeader).sFieldName
'                MsgBox fieldname & "  " & objVoucher.headerText(i)
'
                If fieldname = "ccode" Then
                    sCode = objVoucher.headerText(i)
                    Exit For
                    
                End If
            Next i
        End If
        
        Dim sSQL As String
        sSQL = "select b.cInvCode as 货号,cast(b.iQuantity as decimal(16,2)) as 数量, isnull(com.cComUnitName,'') as 计量单位,isnull(inv.cAddress,'') as 原产国  ,isnull(inv.cInvDefine13,'') as 重量 ,isnull(b.ioriSum,'') as 货值,isnull(cExch_Name,'') as 币制, isnull(CONVERT(char(10),b.dVDate, 120),'') as [保质截止日（yyyy-mm-dd）],isnull(b.cbMemo,'') as 货物备注  " & _
"from rdrecord01 a inner join rdrecords01 b on a.id = b.id inner join Inventory inv on b.cInvCode = inv.cInvCode inner join ComputationUnit com on com.cComunitCode = inv.cComunitCode  " & _
"where a.cCode = '@cCode'  " & _
"order by b.autoid"
        sSQL = Replace(sSQL, "@cCode", sCode)
        Dim RS As ADODB.Recordset
        Set RS = ExecuteSql(sSQL)
    
    If RS.RecordCount = 0 Then
        MsgBox "没有数据可导出！", vbExclamation, "导出"
        Exit Function
    End If
    

'    MsgBox "将把数据导出到EXCLE里，请稍等.......", vbExclamation, "导出"
    Screen.MousePointer = vbHourglass
 
    
    Dim xlApp As Object
    
    Dim xlBook As Object
    Dim xlSheet As Object
    
    Set xlApp = CreateObject("Excel.Application")
    Set xlBook = xlApp.Workbooks.Add
    Set xlSheet = xlBook.Worksheets(1)
    ' xlSheet.Cells.Columns.  '.AutoFit
        Screen.MousePointer = 11
        With xlSheet
                'EXCLE第一列的宽度
                .Columns(1).ColumnWidth = 20
                .Columns(2).ColumnWidth = 12
                .Columns(3).ColumnWidth = 12
                .Columns(4).ColumnWidth = 12
                .Columns(5).ColumnWidth = 12
                .Columns(6).ColumnWidth = 12
                .Columns(7).ColumnWidth = 12
                .Columns(8).ColumnWidth = 30
                .Columns(9).ColumnWidth = 12
'                '字体 边框  居中
'                .Cells.Font.Size = 9
'                .Cells(1, 1).Borders.LineStyle = 1 '边框
'                .Cells(1, 2).Borders.LineStyle = 1
'                .Cells(1, 3).Borders.LineStyle = 1
'                .Cells(1, 4).Borders.LineStyle = 1
'                .Cells(1, 5).Borders.LineStyle = 1
'                .Cells.HorizontalAlignment = xlCenter
                .Cells.WrapText = True  '自动换行
                .Cells.EntireColumn.AutoFit  '行高根据内容自动调整
                .Cells.EntireRow.AutoFit
               
                '文件名称
                .Name = CStr(Date)  '时间为名称
               
                '标题列名称
                .Cells(1, 1) = "货号"
                .Cells(1, 2) = "数量"
                .Cells(1, 3) = "计量单位"
                .Cells(1, 4) = "原产国"
                .Cells(1, 5) = "重量"
                .Cells(1, 6) = "货值"
                .Cells(1, 7) = "币制"
                .Cells(1, 8) = "保质截止日（yyyy-mm-dd）"
                .Cells(1, 9) = "货物备注"
        End With
        
    RS.MoveFirst
       
       i = 0
     While Not RS.EOF
        i = i + 1
        For j = 0 To 8
            Dim Str As String
            
             Str = Trim(CStr(RS(j)))
             '去掉空格 回车符
             Str = Replace(Str, vbCr, "")
             Str = Replace(Str, vbLf, "")
             xlSheet.Cells(i + 1, j + 1) = Trim(Str)
            '加边框
'                xlSheet.Cells(i + 1, j).Borders.LineStyle = 1
            '内容靠底部
'             xlSheet.Range(xlSheet.Cells(i + 1, j), xlSheet.Cells(i + 1, j)).VerticalAlignment = 3
'             xlSheet.Range(xlSheet.Cells(i + 1, j), xlSheet.Cells(i + 1, j)).HorizontalAlignment = 3
    
        Next
        RS.MoveNext
     Wend
    Screen.MousePointer = 0
'    MsgBox "数据已经成功导出！", vbExclamation, "导出"
  
    xlApp.Visible = True
    Set xlApp = Nothing 'Excel 处于当前窗体
    Set xlBook = Nothing
    Set xlSheet = Nothing
    
Exit Function

Errs:
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




