using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Localization;

namespace FrameBaseFunction
{
    public class ChineseGridLocalizer : GridLocalizer
    {
        public override string Language { get { return "Deutsch"; } }
        public override string GetLocalizedString(GridStringId id)
        {
            try
            {
                string ret = "";
                switch (id)
                {
                    // ...

                    case GridStringId.MenuColumnSortAscending: return "升序排列";
                    case GridStringId.MenuColumnSortDescending: return "降序排列";
                    case GridStringId.MenuColumnGroup: return "分组 ";
                    case GridStringId.MenuColumnUnGroup: return "取消分组";
                    case GridStringId.MenuColumnColumnCustomization: return "自定义";
                    case GridStringId.MenuColumnBestFit: return "合适宽度";
                    case GridStringId.MenuColumnFilter: return "过滤";
                    case GridStringId.MenuColumnClearFilter: return "清空";
                    case GridStringId.MenuColumnBestFitAllColumns: return "合适宽度（所有列）";
                    case GridStringId.MenuColumnGroupBox: return "表头";
                    case GridStringId.MenuFooterAverage: return "平均";
                    case GridStringId.MenuFooterAverageFormat: return "格式";
                    case GridStringId.MenuFooterCount: return "条数";
                    case GridStringId.MenuFooterCountFormat: return "格式";
                    case GridStringId.MenuFooterMax: return "最大";
                    case GridStringId.MenuFooterMaxFormat: return "格式";
                    case GridStringId.MenuFooterMin: return "最小";
                    case GridStringId.MenuFooterMinFormat: return "格式";
                    case GridStringId.MenuFooterNone: return "无";
                    case GridStringId.MenuFooterSum: return "总合";
                    case GridStringId.MenuFooterSumFormat: return "格式";
                    case GridStringId.MenuGroupPanelClearGrouping: return "还原";
                    case GridStringId.MenuGroupPanelFullCollapse: return "聚合";
                    case GridStringId.MenuGroupPanelFullExpand: return "展开";
                    case GridStringId.CardViewNewCard: return "新增";
                    case GridStringId.CardViewQuickCustomizationButton: return "按钮";
                    case GridStringId.CardViewQuickCustomizationButtonFilter: return "过滤";
                    case GridStringId.CardViewQuickCustomizationButtonSort: return "分类";
                    case GridStringId.ColumnViewExceptionMessage: return "错误";
                    // case GridStringId.CustomFilterDialog2FieldCheck: return "";
                    case GridStringId.CustomFilterDialogCancelButton: return "取消";
                    case GridStringId.CustomFilterDialogCaption: return "标题";
                    case GridStringId.CustomFilterDialogClearFilter: return "清空";
                    case GridStringId.CustomFilterDialogConditionBlanks: return "空白";
                    case GridStringId.CustomFilterDialogConditionEQU: return "等于";
                    case GridStringId.CustomFilterDialogConditionGT: return "大与";
                    case GridStringId.CustomFilterDialogConditionGTE: return "大于等于";
                    case GridStringId.CustomFilterDialogConditionLike: return "相似";
                    case GridStringId.CustomFilterDialogConditionLT: return "小于";
                    case GridStringId.CustomFilterDialogConditionLTE: return "小于等于";
                    case GridStringId.CustomFilterDialogConditionNEQ: return "不等于";
                    case GridStringId.CustomFilterDialogConditionNonBlanks: return "非空";
                    case GridStringId.CustomFilterDialogConditionNotLike: return "不相似";
                    case GridStringId.CustomFilterDialogFormCaption: return "标题";
                    case GridStringId.CustomFilterDialogOkButton: return "确定";
                    case GridStringId.CustomFilterDialogRadioAnd: return "与";
                    case GridStringId.CustomFilterDialogRadioOr: return "或者";
                    case GridStringId.CustomizationBands: return "自定义";
                    case GridStringId.CustomizationCaption: return "标题";
                    case GridStringId.CustomizationColumns: return "";
                    case GridStringId.FileIsNotFoundError: return "文件未找到";
                    // case GridStringId.GridGroupPanelText: return "面板文本";
                    case GridStringId.GridNewRowText: return "新行文本";
                    case GridStringId.GridOutlookIntervals: return "间隔";
                    case GridStringId.PopupFilterAll: return "全部";
                    case GridStringId.PopupFilterBlanks: return "空";
                    case GridStringId.PopupFilterCustom: return "自定义";
                    case GridStringId.PopupFilterNonBlanks: return "非空";
                    case GridStringId.PrintDesignerBandedView: return "条状视图";
                    case GridStringId.PrintDesignerBandHeader: return "标题";
                    case GridStringId.PrintDesignerCardView: return "卡片视图";
                    case GridStringId.PrintDesignerDescription: return "描述";
                    case GridStringId.PrintDesignerGridView: return "网格视图";
                    case GridStringId.WindowErrorCaption: return "错误";
                    // ...
                    default:
                        ret = "";
                        break;
                }
                return ret;
            }
            catch
            {
                return "";
            }
        }
    }

}
