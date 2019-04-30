using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace 工程
{
    public partial class Frm配电一种工作票 : 系统服务.FrmBaseInfo
    {
        private int Flag;
        private string cCode;
        private bool isNew = false;
        public Frm配电一种工作票(int sFlag,string scCode)
        {
            Flag = sFlag;
            cCode = scCode;
            if (cCode == "")
            {
                isNew = true;
            }
            InitializeComponent();

            dtBingGrid = new DataTable();
            dtBingHead = new DataTable();
        }

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "addrow":
                        btnAddRow();
                        break;
                    case "add":
                        btnAdd();
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "first":
                        btnFirst();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    case "print":
                        btnPrint();
                        break;
                    //case "printset":
                    //    btnPrintSet();
                    //    break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "undo":
                        btnUnDo();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClose();
                        break;
                    case "layout":
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        private void btnAdd()
        {
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                //保存word
                axFramerControl1.Save();

                //获取数据
                Microsoft.Office.Interop.Word._Document doc = axFramerControl1.ActiveDocument as Microsoft.Office.Interop.Word._Document;
                string str = doc.Content.Text;

                string PerGroup = RegexStr(str, "班组：", "2．工作班人员（不包括工作负责人）").Trim();
                string PerName = RegexStr(str, "工作负责人（监护人）", "班组：").Trim();
                string PerNameList = RegexStr(str, "工作班人员（不包括工作负责人）", "共").Trim();
                string[] Plan = RegexStr(str, "计划工作时间：自", "5．安全措施").Trim().Split('至');
                DateTime PlanStartTime = new DateTime();
                DateTime PlanEndTime = new DateTime();
                DateTime.TryParse(Plan[0], out PlanStartTime);
                DateTime.TryParse(Plan[1], out PlanEndTime);
                if (PlanStartTime == DateTime.MinValue || PlanStartTime == DateTime.MinValue)
                {
                    throw new Exception("请填写计划工作时间");
                }

                if (isNew == true)
                {
                    sSQL = @"insert into WorkTicket(Flag, cCode, vchrUid, PerGroup, PerName, PerNameList, PlanStartTime, PlanEndTime) values
                ('" + Flag + "','" + cCode + "','" + 系统服务.ClsBaseDataInfo.sUid + "','" + PerGroup + "','" + PerName + "','" + PerNameList + "','" + PlanStartTime + "','" + PlanEndTime + "')";
                    clsSQLCommond.ExecSql(sSQL);
                }
                else
                {
                    sSQL = @"update WorkTicket set PerGroup='" + PerGroup + "', PerName='" + PerName + "', PerNameList='" + PerNameList + "', PlanStartTime='" + PlanStartTime + "', PlanEndTime='" + PlanEndTime + "'  where cCode='" + cCode + "'";
                    clsSQLCommond.ExecSql(sSQL);
                }
                MessageBox.Show("保存成功");
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败" + ee.Message);
            }
        }

        public string RegexStr(string str, string d1, string d2)
        {
            if (Regex.IsMatch(str, "(?<=(" + d1 + "))[.\\s\\S]*?(?=(" + d2 + "))", RegexOptions.IgnoreCase | RegexOptions.Singleline))
            {
                return new Regex("(?<=(" + d1 + "))[.\\s\\S]*?(?=(" + d2 + "))", RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(str).Value;
            }
            return "";
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {

            throw new NotImplementedException();
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm配电一种工作票_Load(object sender, EventArgs e)
        {
            if (cCode == "")
            {
                sSQL = @"select convert(nvarchar(10),getdate(),120) + '-' + isnull(right('0'+convert(nvarchar,convert(int,max(substring(cCode,12,2)))+1),2) ,'01') +'配'
                from  WorkTicket where cCode like '" + DateTime.Now.ToString("yyyy-MM-dd") + "-%' and cCode like '%配%'";
                cCode = clsSQLCommond.ExecGetScalar(sSQL).ToString();
                string fileold=Application.StartupPath + "\\模板\\配电一种工作票.docm";
                string filenew=Application.StartupPath + "\\" + Flag + "\\" + cCode + ".docm";
                File.Copy(fileold, filenew, true);
                WordStringsReplace(filenew, new ArrayList() { "AAAAAA" }, new ArrayList() { cCode });
                axFramerControl1.Open(filenew);
            }
            else
            {
                axFramerControl1.Open(Application.StartupPath + "\\" + Flag + "\\" + cCode + ".docm");
            }
            //axFramerControl1.Toolbars = false;//是否显示excel标题栏
            axFramerControl1.Titlebar = false;//是否显示excel的菜单栏
            axFramerControl1.Menubar = false;//是否显示excel的工具栏

            axFramerControl1.set_EnableFileCommand(DSOFramer.dsoFileCommandType.dsoFileSave, false);
            axFramerControl1.set_EnableFileCommand(DSOFramer.dsoFileCommandType.dsoFileSaveAs, false);
        }

        ///<summary>
        /// 替换word模板文件内容，包括表格中内容
        /// </summary>
        /// <param name="filePath">文件全路径</param>
        /// <param name="arr_Old">占位符数组</param>
        /// <param name="arr_New">替换字符串数组</param>
        public Microsoft.Office.Interop.Word.Application WordStringsReplace(string filePath, ArrayList arr_Old, ArrayList arr_New)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            object oMissing = System.Reflection.Missing.Value;
            object file = filePath;
            Microsoft.Office.Interop.Word._Document doc = app.Documents.Open(ref file,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            for (int i = 0; i < arr_Old.Count; i++)
            {
                app.Selection.Find.ClearFormatting();
                app.Selection.Find.Replacement.ClearFormatting();
                app.Selection.Find.Text = arr_Old[i].ToString();
                app.Selection.Find.Replacement.Text = arr_New[i].ToString();
                object objReplace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                app.Selection.Find.Execute(ref oMissing, ref oMissing, ref oMissing,
                                           ref oMissing, ref oMissing, ref oMissing,
                                           ref oMissing, ref oMissing, ref oMissing,
                                           ref oMissing, ref objReplace, ref oMissing,
                                           ref oMissing, ref oMissing, ref oMissing);
            }

            //保存
            doc.Save();
            doc.Close(ref oMissing, ref oMissing, ref oMissing);
            app.Quit(ref oMissing, ref oMissing, ref oMissing);
            return app;
            
        }
    }
}