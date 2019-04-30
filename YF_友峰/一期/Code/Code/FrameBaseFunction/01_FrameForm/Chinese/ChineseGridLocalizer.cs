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

                    case GridStringId.MenuColumnSortAscending: return "��������";
                    case GridStringId.MenuColumnSortDescending: return "��������";
                    case GridStringId.MenuColumnGroup: return "���� ";
                    case GridStringId.MenuColumnUnGroup: return "ȡ������";
                    case GridStringId.MenuColumnColumnCustomization: return "�Զ���";
                    case GridStringId.MenuColumnBestFit: return "���ʿ��";
                    case GridStringId.MenuColumnFilter: return "����";
                    case GridStringId.MenuColumnClearFilter: return "���";
                    case GridStringId.MenuColumnBestFitAllColumns: return "���ʿ�ȣ������У�";
                    case GridStringId.MenuColumnGroupBox: return "��ͷ";
                    case GridStringId.MenuFooterAverage: return "ƽ��";
                    case GridStringId.MenuFooterAverageFormat: return "��ʽ";
                    case GridStringId.MenuFooterCount: return "����";
                    case GridStringId.MenuFooterCountFormat: return "��ʽ";
                    case GridStringId.MenuFooterMax: return "���";
                    case GridStringId.MenuFooterMaxFormat: return "��ʽ";
                    case GridStringId.MenuFooterMin: return "��С";
                    case GridStringId.MenuFooterMinFormat: return "��ʽ";
                    case GridStringId.MenuFooterNone: return "��";
                    case GridStringId.MenuFooterSum: return "�ܺ�";
                    case GridStringId.MenuFooterSumFormat: return "��ʽ";
                    case GridStringId.MenuGroupPanelClearGrouping: return "��ԭ";
                    case GridStringId.MenuGroupPanelFullCollapse: return "�ۺ�";
                    case GridStringId.MenuGroupPanelFullExpand: return "չ��";
                    case GridStringId.CardViewNewCard: return "����";
                    case GridStringId.CardViewQuickCustomizationButton: return "��ť";
                    case GridStringId.CardViewQuickCustomizationButtonFilter: return "����";
                    case GridStringId.CardViewQuickCustomizationButtonSort: return "����";
                    case GridStringId.ColumnViewExceptionMessage: return "����";
                    // case GridStringId.CustomFilterDialog2FieldCheck: return "";
                    case GridStringId.CustomFilterDialogCancelButton: return "ȡ��";
                    case GridStringId.CustomFilterDialogCaption: return "����";
                    case GridStringId.CustomFilterDialogClearFilter: return "���";
                    case GridStringId.CustomFilterDialogConditionBlanks: return "�հ�";
                    case GridStringId.CustomFilterDialogConditionEQU: return "����";
                    case GridStringId.CustomFilterDialogConditionGT: return "����";
                    case GridStringId.CustomFilterDialogConditionGTE: return "���ڵ���";
                    case GridStringId.CustomFilterDialogConditionLike: return "����";
                    case GridStringId.CustomFilterDialogConditionLT: return "С��";
                    case GridStringId.CustomFilterDialogConditionLTE: return "С�ڵ���";
                    case GridStringId.CustomFilterDialogConditionNEQ: return "������";
                    case GridStringId.CustomFilterDialogConditionNonBlanks: return "�ǿ�";
                    case GridStringId.CustomFilterDialogConditionNotLike: return "������";
                    case GridStringId.CustomFilterDialogFormCaption: return "����";
                    case GridStringId.CustomFilterDialogOkButton: return "ȷ��";
                    case GridStringId.CustomFilterDialogRadioAnd: return "��";
                    case GridStringId.CustomFilterDialogRadioOr: return "����";
                    case GridStringId.CustomizationBands: return "�Զ���";
                    case GridStringId.CustomizationCaption: return "����";
                    case GridStringId.CustomizationColumns: return "";
                    case GridStringId.FileIsNotFoundError: return "�ļ�δ�ҵ�";
                    // case GridStringId.GridGroupPanelText: return "����ı�";
                    case GridStringId.GridNewRowText: return "�����ı�";
                    case GridStringId.GridOutlookIntervals: return "���";
                    case GridStringId.PopupFilterAll: return "ȫ��";
                    case GridStringId.PopupFilterBlanks: return "��";
                    case GridStringId.PopupFilterCustom: return "�Զ���";
                    case GridStringId.PopupFilterNonBlanks: return "�ǿ�";
                    case GridStringId.PrintDesignerBandedView: return "��״��ͼ";
                    case GridStringId.PrintDesignerBandHeader: return "����";
                    case GridStringId.PrintDesignerCardView: return "��Ƭ��ͼ";
                    case GridStringId.PrintDesignerDescription: return "����";
                    case GridStringId.PrintDesignerGridView: return "������ͼ";
                    case GridStringId.WindowErrorCaption: return "����";
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
