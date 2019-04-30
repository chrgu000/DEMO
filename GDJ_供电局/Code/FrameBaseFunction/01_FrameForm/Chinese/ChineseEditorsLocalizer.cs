using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Controls;

namespace FrameBaseFunction
{
    public class ChineseEditorsLocalizer : Localizer
    {
        public override string Language { get { return "Deutsch"; } }
        public override string GetLocalizedString(StringId id)
        {
            try
            {
                switch (id)
                {
                    // ...

                    case StringId.PictureEditMenuCut: return "����";
                    case StringId.PictureEditMenuCopy: return "����";
                    case StringId.PictureEditMenuPaste: return "ճ��";
                    case StringId.PictureEditMenuDelete: return "ɾ��";
                    case StringId.PictureEditMenuLoad: return "��ȡ";
                    case StringId.PictureEditMenuSave: return "����";
                    case StringId.CalcButtonBack: return "Back";
                    case StringId.CalcButtonC: return "C";
                    case StringId.CalcButtonCE: return "CE";
                    case StringId.CalcButtonMC: return "MC";
                    case StringId.CalcButtonMR: return "MR";
                    case StringId.CalcButtonMS: return "MS";
                    case StringId.CalcButtonMx: return "M+";
                    case StringId.CalcButtonSqrt: return "sqrt";
                    case StringId.CalcError: return "Error";
                    case StringId.Cancel: return "ȡ��";
                    case StringId.CaptionError: return "Error";
                    case StringId.CheckChecked: return "ѡ��";
                    case StringId.CheckIndeterminate: return "��ȷ��";
                    case StringId.CheckUnchecked: return "δѡ��";
                    case StringId.ColorTabCustom: return "�Զ���";
                    case StringId.ColorTabSystem: return "ϵͳ";
                    case StringId.ColorTabWeb: return "WEB";
                    case StringId.DataEmpty: return "������";
                    case StringId.DateEditClear: return "���";
                    case StringId.DateEditToday: return "����";
                    case StringId.ImagePopupEmpty: return "���գ�";
                    case StringId.ImagePopupPicture: return "��ͼƬ��";
                    case StringId.InvalidValueText: return "��Ч��ֵ";
                    case StringId.LookUpColumnDefaultName: return "����";
                    case StringId.LookUpEditValueIsNull: return "��ֵ";
                    case StringId.LookUpInvalidEditValueType: return "����";
                    case StringId.MaskBoxValidateError: return "�����ֵ���������Ƿ������";
                    case StringId.NavigatorAppendButtonHint: return "���";
                    case StringId.NavigatorCancelEditButtonHint: return "ȡ��";
                    case StringId.NavigatorEditButtonHint: return "�༭";
                    case StringId.NavigatorEndEditButtonHint: return "�༭����";
                    case StringId.NavigatorFirstButtonHint: return "��һ��";
                    case StringId.NavigatorLastButtonHint: return "����";
                    case StringId.NavigatorNextButtonHint: return "��һ��";
                    case StringId.NavigatorNextPageButtonHint: return "��һҳ";
                    case StringId.NavigatorPreviousButtonHint: return "ǰһ��";
                    case StringId.NavigatorPreviousPageButtonHint: return "��һҳ";
                    case StringId.NavigatorRemoveButtonHint: return "ɾ��";
                    case StringId.NavigatorTextStringFormat: return "�ı��ַ�����ʽ";
                    case StringId.None: return "��";
                    case StringId.NotValidArrayLength: return "��Ч���鳤��";
                    case StringId.OK: return "ȷ��";
                    case StringId.PictureEditOpenFileError: return "ͼƬ��ʽ����";
                    case StringId.PictureEditOpenFileErrorCaption: return "��ʧ��";
                    case StringId.PictureEditOpenFileFilter: return "λͼ�ļ�(*.bmp)|*.bmp|GIF�ļ�(*.gif)|*.gif|JPG�ļ�(*.jpg)|*.jpg|ͼ���ļ�(*.ico)|*.ico|����ͼƬ�ļ�|*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|�����ļ�|*.*";
                    case StringId.PictureEditOpenFileTitle: return "��";
                    case StringId.PictureEditSaveFileFilter: return "λͼ�ļ�(*.bmp)|*.bmp|GIF�ļ�(*.gif)|*.gif|JPG�ļ�(*.jpg)|*.jpg";
                    case StringId.PictureEditSaveFileTitle: return "���Ϊ";
                    case StringId.TabHeaderButtonClose: return "�ر�";
                    case StringId.TabHeaderButtonNext: return "��һ��";
                    case StringId.TabHeaderButtonPrev: return "��һ��";
                    case StringId.TextEditMenuCopy: return "����";
                    case StringId.TextEditMenuCut: return "����";
                    case StringId.TextEditMenuDelete: return "ɾ��";
                    case StringId.TextEditMenuPaste: return "ճ��";
                    case StringId.TextEditMenuSelectAll: return "ȫѡ";
                    case StringId.TextEditMenuUndo: return "ȡ��";
                    case StringId.UnknownPictureFormat: return "δ֪ͼƬ��ʽ";
                    case StringId.XtraMessageBoxAbortButtonText: return "����";
                    case StringId.XtraMessageBoxCancelButtonText: return "ȡ��";
                    case StringId.XtraMessageBoxIgnoreButtonText: return "����";
                    case StringId.XtraMessageBoxNoButtonText: return "��";
                    case StringId.XtraMessageBoxOkButtonText: return "ȷ��";
                    case StringId.XtraMessageBoxRetryButtonText: return "����";
                    case StringId.XtraMessageBoxYesButtonText: return "��";
                    // ...
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
    }

}
