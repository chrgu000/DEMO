VERSION 5.00
Begin VB.Form FrmReport 
   Caption         =   "������Ϣ"
   ClientHeight    =   5385
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   10005
   LinkTopic       =   "Form1"
   ScaleHeight     =   5385
   ScaleWidth      =   10005
   StartUpPosition =   2  '��Ļ����
   Begin VB.CommandButton CommandOK 
      Caption         =   "ȷ ��"
      Height          =   375
      Left            =   8520
      TabIndex        =   0
      Top             =   4920
      Width           =   1095
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
