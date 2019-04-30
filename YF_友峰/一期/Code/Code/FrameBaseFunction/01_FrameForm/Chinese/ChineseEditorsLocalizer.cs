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

                    case StringId.PictureEditMenuCut: return "剪切";
                    case StringId.PictureEditMenuCopy: return "复制";
                    case StringId.PictureEditMenuPaste: return "粘贴";
                    case StringId.PictureEditMenuDelete: return "删除";
                    case StringId.PictureEditMenuLoad: return "读取";
                    case StringId.PictureEditMenuSave: return "保存";
                    case StringId.CalcButtonBack: return "Back";
                    case StringId.CalcButtonC: return "C";
                    case StringId.CalcButtonCE: return "CE";
                    case StringId.CalcButtonMC: return "MC";
                    case StringId.CalcButtonMR: return "MR";
                    case StringId.CalcButtonMS: return "MS";
                    case StringId.CalcButtonMx: return "M+";
                    case StringId.CalcButtonSqrt: return "sqrt";
                    case StringId.CalcError: return "Error";
                    case StringId.Cancel: return "取消";
                    case StringId.CaptionError: return "Error";
                    case StringId.CheckChecked: return "选中";
                    case StringId.CheckIndeterminate: return "不确定";
                    case StringId.CheckUnchecked: return "未选中";
                    case StringId.ColorTabCustom: return "自定义";
                    case StringId.ColorTabSystem: return "系统";
                    case StringId.ColorTabWeb: return "WEB";
                    case StringId.DataEmpty: return "空数据";
                    case StringId.DateEditClear: return "清空";
                    case StringId.DateEditToday: return "今天";
                    case StringId.ImagePopupEmpty: return "（空）";
                    case StringId.ImagePopupPicture: return "（图片）";
                    case StringId.InvalidValueText: return "无效的值";
                    case StringId.LookUpColumnDefaultName: return "名称";
                    case StringId.LookUpEditValueIsNull: return "空值";
                    case StringId.LookUpInvalidEditValueType: return "类型";
                    case StringId.MaskBoxValidateError: return "输入的值不完整。是否改正？";
                    case StringId.NavigatorAppendButtonHint: return "添加";
                    case StringId.NavigatorCancelEditButtonHint: return "取消";
                    case StringId.NavigatorEditButtonHint: return "编辑";
                    case StringId.NavigatorEndEditButtonHint: return "编辑结束";
                    case StringId.NavigatorFirstButtonHint: return "第一个";
                    case StringId.NavigatorLastButtonHint: return "最后个";
                    case StringId.NavigatorNextButtonHint: return "下一个";
                    case StringId.NavigatorNextPageButtonHint: return "下一页";
                    case StringId.NavigatorPreviousButtonHint: return "前一个";
                    case StringId.NavigatorPreviousPageButtonHint: return "上一页";
                    case StringId.NavigatorRemoveButtonHint: return "删除";
                    case StringId.NavigatorTextStringFormat: return "文本字符串格式";
                    case StringId.None: return "空";
                    case StringId.NotValidArrayLength: return "无效数组长度";
                    case StringId.OK: return "确定";
                    case StringId.PictureEditOpenFileError: return "图片格式错误";
                    case StringId.PictureEditOpenFileErrorCaption: return "打开失败";
                    case StringId.PictureEditOpenFileFilter: return "位图文件(*.bmp)|*.bmp|GIF文件(*.gif)|*.gif|JPG文件(*.jpg)|*.jpg|图标文件(*.ico)|*.ico|所有图片文件|*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|所有文件|*.*";
                    case StringId.PictureEditOpenFileTitle: return "打开";
                    case StringId.PictureEditSaveFileFilter: return "位图文件(*.bmp)|*.bmp|GIF文件(*.gif)|*.gif|JPG文件(*.jpg)|*.jpg";
                    case StringId.PictureEditSaveFileTitle: return "另存为";
                    case StringId.TabHeaderButtonClose: return "关闭";
                    case StringId.TabHeaderButtonNext: return "下一个";
                    case StringId.TabHeaderButtonPrev: return "上一个";
                    case StringId.TextEditMenuCopy: return "复制";
                    case StringId.TextEditMenuCut: return "剪切";
                    case StringId.TextEditMenuDelete: return "删除";
                    case StringId.TextEditMenuPaste: return "粘贴";
                    case StringId.TextEditMenuSelectAll: return "全选";
                    case StringId.TextEditMenuUndo: return "取消";
                    case StringId.UnknownPictureFormat: return "未知图片格式";
                    case StringId.XtraMessageBoxAbortButtonText: return "关于";
                    case StringId.XtraMessageBoxCancelButtonText: return "取消";
                    case StringId.XtraMessageBoxIgnoreButtonText: return "忽略";
                    case StringId.XtraMessageBoxNoButtonText: return "否";
                    case StringId.XtraMessageBoxOkButtonText: return "确定";
                    case StringId.XtraMessageBoxRetryButtonText: return "重试";
                    case StringId.XtraMessageBoxYesButtonText: return "是";
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
