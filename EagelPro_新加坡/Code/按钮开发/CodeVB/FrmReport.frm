VERSION 5.00
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form FrmReport 
   Caption         =   "信用信息"
   ClientHeight    =   5385
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   10005
   LinkTopic       =   "Form1"
   ScaleHeight     =   5385
   ScaleWidth      =   10005
   StartUpPosition =   2  '屏幕中心
   Begin VB.CommandButton CommandOK 
      Caption         =   "确 定"
      Height          =   375
      Left            =   8520
      TabIndex        =   1
      Top             =   4920
      Width           =   1095
   End
   Begin RichTextLib.RichTextBox RichTextBox1 
      Height          =   4695
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   9975
      _ExtentX        =   17595
      _ExtentY        =   8281
      _Version        =   393217
      Enabled         =   -1  'True
      Appearance      =   0
      TextRTF         =   $"FrmReport.frx":0000
   End
End
Attribute VB_Name = "FrmReport"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub CommandOK_Click()
    Unload Me
    
End Sub
