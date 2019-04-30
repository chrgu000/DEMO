VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "voucherinterface"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Dim m_oLogin As Object

Public Sub Init(ByVal oLogin As Object)
    If oLogin Is Nothing Then
        writelog "Sub:->Init "
        writelog "oLogin.cAcc_Id    " & oLogin.cAcc_Id
    End If
    Set m_oLogin = oLogin
    
    
End Sub

'表头参照
Public Sub headBrowUser(ByRef Voucher As Object, ByVal Index As Variant, sRet As Variant, ByRef referPara As ReferParameter, ByRef bCancel As Boolean)
'    MsgBox "wo do refer here "
writelog "Sub:->headBrowUser is true "
If Voucher Is Nothing Then
    writelog "Voucher Is Nothing"
Else
    writelog "headertext name " & Voucher.ItemState(Index, siheader).sFieldName & "    Value:" & Voucher.headerText(Index)
End If

    sRet = "test"
    bCancel = True
End Sub


'表体参照
Public Sub bodyBrowUser(ByRef Voucher As Object, ByVal Row As Long, ByVal Col As Long, sRet As Variant, ByRef referPara As ReferParameter, ByRef bCancel As Boolean)

writelog "Sub:->bodyBrowUser is true "
If Voucher Is Nothing Then
    writelog "Voucher Is Nothing"
Else
'voucher.bodyText(row, "cinvcode")
    writelog "bodyText name " & Voucher.ItemState(Col, sibody).sFieldName & "    Value:" & Voucher.bodyText(Row, Col)
End If
'    MsgBox "bodyBrowUser"
'    sRet = "test"
    bCancel = True
End Sub


Public Sub bodyCellCheck(ByRef Voucher As Object, RetValue As Variant, bChanged As Long, ByVal Row As Long, ByVal Col As Long, ByRef referPara As ReferParameter, ByRef bCancel As Boolean)

writelog "Sub:->bodyCellCheck is true "
If Voucher Is Nothing Then
    writelog "Voucher Is Nothing"
Else
    writelog "bodyText name " & Voucher.ItemState(Col, sibody).sFieldName & "    Value:" & Voucher.bodyText(Row, Col)
End If
'    On Error Resume Next
'    MsgBox "wo do refer here "
'    sRet = "test"
    bCancel = True
End Sub


Public Sub headCellCheck(ByRef Voucher As Object, Index As Variant, RetValue As String, bChanged As CheckRet, ByRef referPara As ReferParameter, ByRef bCancel As Boolean)


writelog "Sub:->headCellCheck is true "
If Voucher Is Nothing Then
    writelog "Voucher Is Nothing"
Else
    writelog "headertext name " & Voucher.ItemState(Index, siheader).sFieldName & "    Value:" & Voucher.headerText(Index)
End If
'    MsgBox "wo do refer here "
'    sRet = "test"
    bCancel = True
End Sub


'单据单击
Public Sub Click(ByRef Voucher As Object, section As SectionsConstants, ByVal Index As Long, ByRef bCancel As Boolean)

writelog "Sub:->Click is true "
If Voucher Is Nothing Then
    writelog "Voucher Is Nothing"
Else
    writelog "section " & section
End If


'    MsgBox "wo do refer here "
'    sRet = "test"
'    bCancel = True
End Sub



'单据双击
Public Sub DblClick(ByRef Voucher As Object, section As SectionsConstants, ByVal Index As Long, ByRef bCancel As Boolean)

writelog "Sub:->DblClick is true "
If Voucher Is Nothing Then
    writelog "Voucher Is Nothing"
Else
    writelog "section " & section
End If

'    MsgBox "wo do refer here "
End Sub

