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
                    case BarString.AddOrRemove: return "填加或移除";
                    case BarString.CustomizeButton: return "自定义";
                    case BarString.CustomizeWindowCaption: return "自定义";
                    case BarString.MenuAnimationFade: return "淡入淡出";
                    case BarString.MenuAnimationNone: return "无";
                    case BarString.MenuAnimationRandom: return "随机";
                    case BarString.MenuAnimationSlide: return "滑动 ";
                    case BarString.MenuAnimationSystem: return "系统默认 ";
                    case BarString.MenuAnimationUnfold: return "展开";
                    case BarString.NewToolbarCaption: return "新工具栏";
                    case BarString.NewToolbarCustomNameFormat: return "自定义";
                    case BarString.RenameToolbarCaption: return "重命名工具栏";
                    case BarString.ResetBar: return "把工具栏恢复到默认状态？";
                    case BarString.ResetBarCaption: return "确认";
                    case BarString.ResetButton: return "恢复默认";
                    case BarString.ToolBarMenu: return "工具栏菜单";
                    case BarString.ToolbarNameCaption: return "工具栏名称";
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
