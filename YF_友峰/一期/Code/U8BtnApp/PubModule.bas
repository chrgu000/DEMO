Attribute VB_Name = "PubModule"
Option Explicit

Public Const ConDefaultStr = ""
Public Const ConDefaultDbl = 0
Public Const ConDefaultLng = 0
Public Const ConDefaultInt = 0
Public Const ConDefaultBoolean = False
Public Const strApplictionCaption = "二次开发"

Public Function ConvertTrueFalseToInt(ByVal InputVal As Variant) As Integer
    If UCase(InputVal) = "TRUE" Then
        ConvertTrueFalseToInt = 1
    ElseIf UCase(InputVal) = "FALSE" Then
        ConvertTrueFalseToInt = 0
    End If
    If InputVal = "是" Then
        ConvertTrueFalseToInt = 1
    ElseIf InputVal = "否" Then
        ConvertTrueFalseToInt = 0
    End If
End Function
Public Function ConvertNullToString(ByVal InputVal As Variant, _
                                    Optional ByVal DefaultValue As String = ConDefaultStr) As String
    
    If IsNull(InputVal) Then
        ConvertNullToString = DefaultValue
    Else
        ConvertNullToString = InputVal
    End If


End Function
Public Function ConvertNullToDbl(ByVal InputVal As Variant, _
                                 Optional ByVal DefaultValue As Double = ConDefaultDbl) As Double

    If IsNull(InputVal) Then
        ConvertNullToDbl = DefaultValue
    Else
        If InputVal = "" Then
            ConvertNullToDbl = 0
        Else
            ConvertNullToDbl = InputVal
        End If
    End If

End Function

'/**************************
'函数名称：ConvertNullToLng
'功能：将Null值转换成指定的Long数据
'参数:
'返回值:

'**************************/
Public Function ConvertNullToLng(ByVal InputVal As Variant, _
                                 Optional ByVal DefaultValue As Long = ConDefaultLng) As Long

    If IsNull(InputVal) Then
        ConvertNullToLng = DefaultValue
    Else
        ConvertNullToLng = InputVal
    End If

End Function
Public Function ConvertNullToInt(ByVal InputVal As Variant, _
                                 Optional ByVal DefaultValue As Integer = ConDefaultInt) As Integer

    If IsNull(InputVal) Then
        ConvertNullToInt = DefaultValue
    Else
        ConvertNullToInt = InputVal
    End If


End Function
Public Function ConvertNullToBoolean(ByVal InputVal As Variant, _
                                     Optional ByVal DefaultValue As Boolean = ConDefaultBoolean) As Boolean

    If IsNull(InputVal) Then
        ConvertNullToBoolean = DefaultValue
    Else
        Select Case InputVal
            Case 1, True, 0, False
                ConvertNullToBoolean = InputVal
            Case "T", "t"
                ConvertNullToBoolean = True
            Case Else
                ConvertNullToBoolean = False
        End Select
    End If

End Function





