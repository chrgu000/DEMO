using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Customization;

namespace FrameBaseFunction
{
    public class ChineseLocalizer: BarLocalizer 
    {

        // Overrides the CreateCustomizationControl method.
        protected override CustomizationControl CreateCustomizationControl() { return new CustomizationControl(); }
        // Overrides the GetLocalizedString method.
        public override string GetLocalizedString(BarString id)
        {
            try
            {
                switch (id)
                {
                    case BarString.None: return "";
                    case BarString.AddOrRemove: return "��ӻ��Ƴ�";
                    case BarString.CustomizeButton: return "�Զ���";
                    case BarString.CustomizeWindowCaption: return "�Զ���";
                    case BarString.MenuAnimationFade: return "���뵭��";
                    case BarString.MenuAnimationNone: return "��";
                    case BarString.MenuAnimationRandom: return "���";
                    case BarString.MenuAnimationSlide: return "���� ";
                    case BarString.MenuAnimationSystem: return "ϵͳĬ�� ";
                    case BarString.MenuAnimationUnfold: return "չ��";
                    case BarString.NewToolbarCaption: return "�¹�����";
                    case BarString.NewToolbarCustomNameFormat: return "�Զ���";
                    case BarString.RenameToolbarCaption: return "������������";
                    case BarString.ResetBar: return "�ѹ������ָ���Ĭ��״̬��";
                    case BarString.ResetBarCaption: return "ȷ��";
                    case BarString.ResetButton: return "�ָ�Ĭ��";
                    case BarString.ToolBarMenu: return "�������˵�";
                    case BarString.ToolbarNameCaption: return "����������";
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
