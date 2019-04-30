using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;
using TH.Model;

namespace Base
{
    public partial class Frm杜乐8D改进报告Edit : FrameBaseFunction.Frm列表窗体模板
    {
        //TH.BaseClsInfo.ClsDataBase clsSQLCommond = TH.BaseClsInfo.ClsDataBaseFactory.Instance();
        //FrameBaseFunction.ClsGetSQL clsGetSQL = new FrameBaseFunction.ClsGetSQL();

        long lID = 0;

        public Frm杜乐8D改进报告Edit(long ID)
        {
            InitializeComponent();

            lID = ID;
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "refresh":
                        btnSel();
                        break;
                    //case "sendmail":
                    //    btnSendMail();
                    //    break;
                    case "edit":
                        btnEdit();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "alter":
                        btnPrint();
                        break;
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnPrint()
        {
            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("获得单据ID失败");
            }

            DataTable dt = GetGrid();
            杜乐8D改进报告Report rep = new 杜乐8D改进报告Report();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = rep.dataSet1.Tables[0].NewRow();

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string sColName = dt.Columns[j].ColumnName.Trim();

                    for (int k = 0; k < rep.dataSet1.Tables[0].Columns.Count; k++)
                    {
                        string sColName2 = rep.dataSet1.Tables[0].Columns[k].ColumnName.Trim();
                        if (sColName == sColName2)
                        {
                            if (sColName == "申请日期" || sColName == "调查情况日期" || sColName == "临时措施完成时限" || sColName == "纠正措施完成时限" || sColName == "预防措施完成时限")
                            {
                                if (ReturnObjectToDatetime(dt.Rows[i][sColName]) > ReturnObjectToDatetime("2000-1-1"))
                                {
                                    dr[sColName] = ReturnObjectToDatetime(dt.Rows[i][sColName]).ToString("yyyy-MM-dd");
                                }
                            }
                            else
                            {
                                dr[sColName] = dt.Rows[i][sColName].ToString().Trim();
                            }
                            break;
                        }
                    }
                }

                rep.dataSet1.Tables[0].Rows.Add(dr);
            }


            rep.ShowPreview();
        }

        private void btnUnAudit()
        {
            if (sState == "edit")
            {
                throw new Exception("编辑状态不能发送拒绝");
            }

            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("获得单据ID失败");
            }

            string sSQL = "select * from UFDLImport.._8D报告 where idHead = " + txtIDHead.Text.Trim();
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("获得单据ID失败");
            }
            if (dt.Rows[0]["状态"].ToString().Trim().ToLower() == "false" && dt.Rows[0]["审批人"].ToString().Trim() != "" && dt.Rows[0]["再次提交"].ToString().Trim() == "")
            {
                throw new Exception("单据已经拒绝");
            }

            sSQL = "update UFDLImport.._8D报告 set 再次提交 = null,再次提交日期 = null,状态 = 0 ,审批人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,审批日期 = getdate() where idHead = " + txtIDHead.Text.Trim();
            int iCou = clsSQLCommond.ExecSql(sSQL);
            if (iCou > 0)
            {
                MessageBox.Show("拒绝成功");
                label状态.Text = "拒绝";
            }


            #region 发送邮件给供应商
            sSQL = "select distinct sEMail from UFDLImport.._vendUid where vendCode = '" + txt供应商编码.Text.Trim() + "' and isnull(sEMail,'') <> ''";
            dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
            {
                throw new Exception("获得供应商邮箱失败");
            }

            string sMail = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                {
                    sMail = dt.Rows[i]["sEMail"].ToString().Trim();
                }
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["sEMail"].ToString().Trim();
                }
            }
            if (sMail.Trim() == "")
            {
                throw new Exception("获得供应商邮箱失败");
            }

            string sText =  "杜乐8D改进报告：" + txt编号.Text.Trim() + " 已拒绝";
            if (sMail.Trim() != "")
            {
                btnSendMail(sText, sMail);
            }
            #endregion
        }

        private void btnSave()
        {
            if (sState != "edit")
            {
                throw new Exception("请先点击编辑，并编辑数据后保存");
            }
            if (label状态.Text == "批准")
            {
                throw new Exception("已经批准，不能编辑");
            }

            txtIDHead.Focus();
            TH.Model._8D报告 model = new TH.Model._8D报告();

            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("获得单据ID失败");
            }

            string sSQL = "select * from UFDLImport.._8D报告 where idHead = " + txtIDHead.Text.Trim();
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["状态"].ToString().Trim().ToLower() == "true" && dt.Rows[0]["审批人"].ToString().Trim() != "")
            {
                throw new Exception("单据已经批准");
            }

            model.IDHead = ReturnObjectToLong(txtIDHead.Text.Trim());
            model.TaskID = ReturnObjectToLong(txtTaskID.Text.Trim());

            if (txt组长.Text.Trim() == "" && txt品管部.Text.Trim() == "" && txt工程部.Text.Trim() == "" && txt制造部.Text.Trim() == "")
            {
                throw new Exception("组长，品管部，工程部，制造部 必须至少填写一栏");
            }

            model.组长 = txt组长.Text.Trim();
            model.品管部 = txt品管部.Text.Trim();
            model.工程部 = txt工程部.Text.Trim();
            model.制造部 = txt制造部.Text.Trim();
          
            if(txt调查情况.Text.Trim() == "")
            {
                throw new Exception("调查情况 必输");
            }
            model.调查情况 = txt调查情况.Text.Trim();

            if (txt签名.Text.Trim() == "")
            {
                throw new Exception("签名 必输");
            }
            model.调查情况签名 = txt签名.Text.Trim();

            if (ReturnObjectToDatetime(dtm签名日期.DateTime.ToString("yyyy-MM-dd")) < ReturnObjectToDatetime("2000-1-1"))
            {
                throw new Exception("调查签名日期 必输");
            }
            model.调查情况日期 = ReturnObjectToDatetime(dtm签名日期.DateTime.ToString("yyyy-MM-dd"));

            if (txt临时措施.Text.Trim() == "")
            {
                throw new Exception("临时措施 必输");
            }
            model.临时措施 = txt临时措施.Text.Trim();

            if (txt临时措施责任人.Text.Trim() == "")
            {
                throw new Exception("临时措施责任人 必输");
            }
            model.临时措施责任人 = txt临时措施责任人.Text.Trim();

            if (ReturnObjectToDatetime(dtm临时措施完成时限.DateTime.ToString("yyyy-MM-dd")) < ReturnObjectToDatetime("2000-1-1"))
            {
                throw new Exception("临时措施完成时限 必输");
            }
            model.临时措施完成时限 = ReturnObjectToDatetime(dtm临时措施完成时限.DateTime.ToString("yyyy-MM-dd"));

            if (txt临时措施结果验证.Text.Trim() == "")
            {
                throw new Exception("临时措施结果验证 必输");
            }
            model.临时措施结果验证 = txt临时措施结果验证.Text.Trim();

            if (txt原因分析.Text.Trim() == "")
            {
                throw new Exception("原因分析 必输");
            }
            model.原因分析 = txt原因分析.Text.Trim();

            if (txt纠正措施.Text.Trim() == "")
            {
                throw new Exception("纠正措施 必输");
            }
            model.纠正措施 = txt纠正措施.Text.Trim();

            if (txt纠正措施责任人.Text.Trim() == "")
            {
                throw new Exception("纠正措施责任人 必输");
            }
            model.纠正措施责任人 = txt纠正措施责任人.Text.Trim();

            if (ReturnObjectToDatetime(dtm纠正措施完成时限.DateTime.ToString("yyyy-MM-dd")) < ReturnObjectToDatetime("2000-1-1"))
            {
                throw new Exception("纠正措施完成时限 必输");
            }
            model.纠正措施完成时限 = ReturnObjectToDatetime(dtm纠正措施完成时限.DateTime.ToString("yyyy-MM-dd"));

            if (txt纠正措施结果验证.Text.Trim() == "")
            {
                throw new Exception("纠正措施结果验证 必输");
            }
            model.纠正措施结果验证 = txt纠正措施结果验证.Text.Trim();

            if (txt预防措施.Text.Trim() == "")
            {
                throw new Exception("预防措施 必输");
            }
            model.预防措施 = txt预防措施.Text.Trim();

            if (txt预防措施责任人.Text.Trim() == "")
            {
                throw new Exception("预防措施责任人 必输");
            }
            model.预防措施责任人 = txt预防措施责任人.Text.Trim();

            if (ReturnObjectToDatetime(dtm预防措施完成时限.DateTime.ToString("yyyy-MM-dd")) < ReturnObjectToDatetime("2000-1-1"))
            {
                throw new Exception("预防措施完成时限 必输");
            }
            model.预防措施完成时限 = ReturnObjectToDatetime(dtm预防措施完成时限.DateTime.ToString("yyyy-MM-dd"));

            if (txt预防措施结果验证.Text.Trim() == "")
            {
                throw new Exception("预防措施结果验证 必输");
            }
            model.预防措施结果验证 = txt预防措施结果验证.Text.Trim();
            model.效果 = txt效果.Text.Trim();
            model.效果签名 = txt效果签名.Text.Trim();

            TH.DAL._8D报告 dal = new TH.DAL._8D报告();

            sSQL = "select count(1) from  UFDLImport.._8D报告 where IDHead = " + model.IDHead.ToString();
            dt = clsSQLCommond.ExecQuery(sSQL);
            int iCou = ReturnObjectToInt(dt.Rows[0][0]);
            if (iCou == 0)
            {
                sSQL = dal.Add(model);
            }
            else
            {
                model.再次提交 = sUserName;
                model.再次提交日期 = DateTime.Now;

                sSQL = dal.Update(model);
            }
            iCou = clsSQLCommond.ExecSql(sSQL);
            if (iCou > 0)
            {
                MessageBox.Show("保存成功");
                SetEnable(false);
            }

            #region 发送邮件给品管
            sSQL = @"
select distinct sEMail
from dbo._UserInfo left join UFDLImport.._vendUid on vchrUid=uid and accid = 200 and accyear = 111111 
	left join @u8.vendor on cVenCode = vendCode 
	left join @u8.Department d on d.cDepCode=_UserInfo.cDepCode 
where d.cdepcode = '6'and isnull(sEMail,'') <> ''
            ";
            sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
            {
                throw new Exception("获得品管邮箱失败");
            }

            string sMail = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                {
                    sMail = dt.Rows[i]["sEMail"].ToString().Trim();
                }
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["sEMail"].ToString().Trim();
                }
            }
            if (sMail.Trim() == "")
            {
                throw new Exception("获得供应商邮箱失败");
            }

            string sText = "杜乐8D改进报告：" + txt编号.Text.Trim() + " 已拒绝";
            if (sMail.Trim() != "")
            {
                btnSendMail(sText, sMail);
            }
            #endregion
        }

        private void btnSendMail(string sMailText,string sMailAddress)
        {
            try
            {
                string sHead = "杜乐8D改进报告：" + txt编号.Text.Trim();
                string sText = sMailText;

                //Base.FrmSendMail fSendMail = new FrmSendMail(sMailAddress, sHead, sText);
                //fSendMail.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("邮件发送失败！ " + ee.Message);
            }
        }

        private void btnAudit()
        {
            if (sState == "edit")
            {
                throw new Exception("编辑状态不能发送批准");
            }

            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("获得单据ID失败");
            }

            string sSQL = "select * from UFDLImport.._8D报告 where idHead = " + txtIDHead.Text.Trim();
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("获得单据ID失败");
            }
            if (dt.Rows[0]["状态"].ToString().Trim().ToLower() == "true" && dt.Rows[0]["审批人"].ToString().Trim() != "")
            {
                throw new Exception("单据已经批准");
            }

            sSQL = "update    UFDLImport.._8D报告 set 状态 = 1 ,审批人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,审批日期 = getdate() where idHead = " + txtIDHead.Text.Trim();
            int iCou = clsSQLCommond.ExecSql(sSQL);
            if (iCou > 0)
            {
                MessageBox.Show("批准成功");
            }

            label状态.Text = "批准";


            #region 发送邮件给供应商

            sSQL = "select distinct sEMail from UFDLImport.._vendUid where vendCode = '" + txt供应商编码.Text.Trim() + "' and isnull(sEMail,'') <> ''";
            dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
            {
                throw new Exception("获得供应商邮箱失败");
            }

            string sMail = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                {
                    sMail = dt.Rows[i]["sEMail"].ToString().Trim();
                }
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["sEMail"].ToString().Trim();
                }
            }
            if (sMail.Trim() == "")
            {
                throw new Exception("获得供应商邮箱失败");
            }

            string sText = "杜乐8D改进报告：" + txt编号.Text.Trim() + " 已批准";
            if (sMail.Trim() != "")
            {
                btnSendMail(sText, sMail);
            }

            #endregion
        }

      

        private void btnEdit()
        {
            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("获得单据ID失败");
            }
            //if (dt.Rows[0]["状态"].ToString().Trim().ToLower() == "true" && dt.Rows[0]["审批人"].ToString().Trim() != "")
            //{
            //    throw new Exception("单据已经批准");
            //}

            SetEnable(true);
        }

        private void btnSel()
        {
            DataTable dt = GetGrid();
            SetValue(dt);

        }

        private DataTable GetGrid()
        {
            string sSQL = @"
select cast(0 as bit) as 选择
    ,* 
from DolleDatabase.dbo._Bai_到货不良品处理流程 a
	left join UFDLImport.._8D报告 b on a.id = b.idhead
where 是否提交8D改进报告 = '是' and 1=1
Order by id
";
            sSQL = sSQL.Replace("1=1", "1=1 and ID = " + lID.ToString());

            return clsSQLCommond.ExecQuery(sSQL);
        }

        private void SetValue(DataTable dt)
        {
            if (dt == null || dt.Rows.Count < 1)
            {
                throw new Exception("获取数据失败");
            }

            SetEnable(false);

            txtIDHead.Text = dt.Rows[0]["ID"].ToString().Trim();
            txtTaskID.Text = dt.Rows[0]["TaskID"].ToString().Trim();
            txt供应商.Text = "[" + dt.Rows[0]["厂商编码"].ToString().Trim() + "]" + dt.Rows[0]["供应商"].ToString().Trim();
            txt订单号.Text = dt.Rows[0]["订单号"].ToString().Trim();
            txt抽样数.Text = dt.Rows[0]["抽样数量"].ToString().Trim();
            txt不良数.Text = dt.Rows[0]["不良数"].ToString().Trim();
            txt物料名称.Text = dt.Rows[0]["物料名称"].ToString().Trim();
            txt物料代号.Text = dt.Rows[0]["物料编码"].ToString().Trim();
            txt批量.Text = dt.Rows[0]["批量"].ToString().Trim();
            txt编号.Text = dt.Rows[0]["单据号"].ToString().Trim();
            txt申请人.Text = dt.Rows[0]["申请人"].ToString().Trim();
            dtm申请日期.Text = dt.Rows[0]["申请日期"].ToString().Trim();
            txt问题描述.Text = dt.Rows[0]["原因"].ToString().Trim();
            txt组长.Text = dt.Rows[0]["组长"].ToString().Trim();
            txt品管部.Text = dt.Rows[0]["品管部"].ToString().Trim();
            txt工程部.Text = dt.Rows[0]["工程部"].ToString().Trim();
            txt制造部.Text = dt.Rows[0]["制造部"].ToString().Trim();
            txt调查情况.Text = dt.Rows[0]["调查情况"].ToString().Trim();
            txt签名.Text = dt.Rows[0]["调查情况签名"].ToString().Trim();
            dtm签名日期.Text = dt.Rows[0]["调查情况日期"].ToString().Trim();
            txt临时措施.Text = dt.Rows[0]["临时措施"].ToString().Trim();
            txt临时措施责任人.Text = dt.Rows[0]["临时措施责任人"].ToString().Trim();
            dtm临时措施完成时限.Text = dt.Rows[0]["临时措施完成时限"].ToString().Trim();
            txt临时措施结果验证.Text = dt.Rows[0]["临时措施结果验证"].ToString().Trim();
            txt原因分析.Text = dt.Rows[0]["原因分析"].ToString().Trim();
            txt纠正措施.Text = dt.Rows[0]["纠正措施"].ToString().Trim();
            txt纠正措施责任人.Text = dt.Rows[0]["纠正措施责任人"].ToString().Trim();
            dtm纠正措施完成时限.Text = dt.Rows[0]["纠正措施完成时限"].ToString().Trim();
            txt纠正措施结果验证.Text = dt.Rows[0]["纠正措施结果验证"].ToString().Trim();
            txt预防措施.Text = dt.Rows[0]["预防措施"].ToString().Trim();
            txt预防措施责任人.Text = dt.Rows[0]["预防措施责任人"].ToString().Trim();
            dtm预防措施完成时限.Text = dt.Rows[0]["预防措施完成时限"].ToString().Trim();
            txt预防措施结果验证.Text = dt.Rows[0]["预防措施结果验证"].ToString().Trim();
            txt效果.Text = dt.Rows[0]["效果"].ToString().Trim();
            txt效果签名.Text = dt.Rows[0]["效果签名"].ToString().Trim();
            txt供应商编码.Text = dt.Rows[0]["厂商编码"].ToString().Trim();

            if (ReturnObjectToInt(dt.Rows[0]["状态"]) == 0 && dt.Rows[0]["审批人"].ToString().Trim() != "")
            {
                label状态.Text = "拒绝";
            }
            else if (ReturnObjectToInt(dt.Rows[0]["状态"]) == 1 && dt.Rows[0]["审批人"].ToString().Trim() != "")
            {
                label状态.Text = "批准";
            }
            else
            {
                label状态.Text = "";
            }

        }

        #region 按钮模板

      
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            //try
            //{
            //    SaveFileDialog sF = new SaveFileDialog();
            //    sF.DefaultExt = "xls";
            //    sF.FileName = this.Text;
            //    sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
            //    DialogResult dRes = sF.ShowDialog();
            //    if (DialogResult.OK == dRes)
            //    {
            //        gridView1.ExportToExcel(sF.FileName);
            //        MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }

      
        #endregion






        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetTxtNull()
        {
            txtIDHead.Text = "";
            txt供应商编码.Text = "";
            txt供应商.Text = "";
            txt订单号.Text = "";
            txt抽样数.Text = "";
            txt不良数.Text = "";
            txt物料名称.Text = "";
            txt物料代号.Text = "";
            txt批量.Text = "";
            txt编号.Text = "";
            txt申请人.Text = "";
            dtm申请日期.Text = "";
            txt问题描述.Text = "";
            txt组长.Text = "";
            txt品管部.Text = "";
            txt工程部.Text = "";
            txt制造部.Text = "";
            txt调查情况.Text = "";
            txt签名.Text = "";
            dtm签名日期.Text = "";
            txt临时措施.Text = "";
            txt临时措施责任人.Text = "";
            dtm临时措施完成时限.Text = "";
            txt临时措施结果验证.Text = "";
            txt原因分析.Text = "";
            txt纠正措施.Text = "";
            txt纠正措施责任人.Text = "";
            dtm纠正措施完成时限.Text = "";
            txt纠正措施结果验证.Text = "";
            txt预防措施.Text = "";
            txt预防措施责任人.Text = "";
            dtm预防措施完成时限.Text = "";
            txt预防措施结果验证.Text = "";
            txt效果.Text = "";
            txt效果签名.Text = "";
        }

        private void SetEnable(bool b)
        {
            txt供应商.Enabled = false;
            txt订单号.Enabled = false;
            txt抽样数.Enabled = false;
            txt不良数.Enabled = false;
            txt物料名称.Enabled = false;
            txt物料代号.Enabled = false;
            txt批量.Enabled = false;
            txt编号.Enabled = false;
            txt申请人.Enabled = false;
            dtm申请日期.Enabled = false;
            txt问题描述.Enabled = false;
            txt组长.Enabled = b;
            txt品管部.Enabled = b;
            txt工程部.Enabled = b;
            txt制造部.Enabled = b;
            txt调查情况.Enabled = b;
            txt签名.Enabled = b;
            dtm签名日期.Enabled = b;
            txt临时措施.Enabled = b;
            txt临时措施责任人.Enabled = b;
            dtm临时措施完成时限.Enabled = b;
            txt临时措施结果验证.Enabled = b;
            txt原因分析.Enabled = b;
            txt纠正措施.Enabled = b;
            txt纠正措施责任人.Enabled = b;
            dtm纠正措施完成时限.Enabled = b;
            txt纠正措施结果验证.Enabled = b;
            txt预防措施.Enabled = b;
            txt预防措施责任人.Enabled = b;
            dtm预防措施完成时限.Enabled = b;
            txt预防措施结果验证.Enabled = b;
            txt效果.Enabled = b;
            txt效果签名.Enabled = b;


            txt供应商.Properties.ReadOnly = !b;
            txt订单号.Properties.ReadOnly = !b;
            txt抽样数.Properties.ReadOnly = !b;
            txt不良数.Properties.ReadOnly = !b;
            txt物料名称.Properties.ReadOnly = !b;
            txt物料代号.Properties.ReadOnly = !b;
            txt批量.Properties.ReadOnly = !b;
            txt编号.Properties.ReadOnly = !b;
            txt申请人.Properties.ReadOnly = !b;
            dtm申请日期.Properties.ReadOnly = !b;
            txt问题描述.ReadOnly = !b;
            txt组长.Properties.ReadOnly = !b;
            txt品管部.Properties.ReadOnly = !b;
            txt工程部.Properties.ReadOnly = !b;
            txt制造部.Properties.ReadOnly = !b;
            txt调查情况.ReadOnly = !b;
            txt签名.Properties.ReadOnly = !b;
            dtm签名日期.Properties.ReadOnly = !b;
            txt临时措施.ReadOnly = !b;
            txt临时措施责任人.Properties.ReadOnly = !b;
            dtm临时措施完成时限.Properties.ReadOnly = !b;
            txt临时措施结果验证.Properties.ReadOnly = !b;
            txt原因分析.ReadOnly = !b;
            txt纠正措施.ReadOnly = !b;
            txt纠正措施责任人.Properties.ReadOnly = !b;
            dtm纠正措施完成时限.Properties.ReadOnly = !b;
            txt纠正措施结果验证.Properties.ReadOnly = !b;
            txt预防措施.ReadOnly = !b;
            txt预防措施责任人.Properties.ReadOnly = !b;
            dtm预防措施完成时限.Properties.ReadOnly = !b;
            txt预防措施结果验证.Properties.ReadOnly = !b;
            txt效果.ReadOnly = !b;
            txt效果签名.Properties.ReadOnly = !b;
        }
    }
}



namespace TH.Model
{
	/// <summary>
	/// _8D报告:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class _8D报告
	{
		public _8D报告()
		{}
		#region Model
		private long? _idhead;
		private long? _taskid;
		private string _组长;
		private string _品管部;
		private string _工程部;
		private string _制造部;
		private string _调查情况;
		private string _调查情况签名;
		private DateTime _调查情况日期;
		private string _临时措施;
		private string _临时措施责任人;
		private DateTime _临时措施完成时限;
		private string _临时措施结果验证;
		private string _原因分析;
		private string _纠正措施;
		private string _纠正措施责任人;
		private DateTime _纠正措施完成时限;
		private string _纠正措施结果验证;
		private string _预防措施;
		private string _预防措施责任人;
		private DateTime _预防措施完成时限;
		private string _预防措施结果验证;
		private string _效果;
		private string _效果签名;
		private bool _状态= false;
		private string _审批人;
        private DateTime? _审批日期;
        private string _再次提交;
        private DateTime? _再次提交日期;
		/// <summary>
		/// 
		/// </summary>
		public long? IDHead
		{
			set{ _idhead=value;}
			get{return _idhead;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? TaskID
		{
			set{ _taskid=value;}
			get{return _taskid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 组长
		{
			set{ _组长=value;}
			get{return _组长;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 品管部
		{
			set{ _品管部=value;}
			get{return _品管部;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 工程部
		{
			set{ _工程部=value;}
			get{return _工程部;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 制造部
		{
			set{ _制造部=value;}
			get{return _制造部;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 调查情况
		{
			set{ _调查情况=value;}
			get{return _调查情况;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 调查情况签名
		{
			set{ _调查情况签名=value;}
			get{return _调查情况签名;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime 调查情况日期
		{
			set{ _调查情况日期=value;}
			get{return _调查情况日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 临时措施
		{
			set{ _临时措施=value;}
			get{return _临时措施;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 临时措施责任人
		{
			set{ _临时措施责任人=value;}
			get{return _临时措施责任人;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime 临时措施完成时限
		{
			set{ _临时措施完成时限=value;}
			get{return _临时措施完成时限;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 临时措施结果验证
		{
			set{ _临时措施结果验证=value;}
			get{return _临时措施结果验证;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 原因分析
		{
			set{ _原因分析=value;}
			get{return _原因分析;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 纠正措施
		{
			set{ _纠正措施=value;}
			get{return _纠正措施;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 纠正措施责任人
		{
			set{ _纠正措施责任人=value;}
			get{return _纠正措施责任人;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime 纠正措施完成时限
		{
			set{ _纠正措施完成时限=value;}
			get{return _纠正措施完成时限;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 纠正措施结果验证
		{
			set{ _纠正措施结果验证=value;}
			get{return _纠正措施结果验证;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 预防措施
		{
			set{ _预防措施=value;}
			get{return _预防措施;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 预防措施责任人
		{
			set{ _预防措施责任人=value;}
			get{return _预防措施责任人;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime 预防措施完成时限
		{
			set{ _预防措施完成时限=value;}
			get{return _预防措施完成时限;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 预防措施结果验证
		{
			set{ _预防措施结果验证=value;}
			get{return _预防措施结果验证;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 效果
		{
			set{ _效果=value;}
			get{return _效果;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 效果签名
		{
			set{ _效果签名=value;}
			get{return _效果签名;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool 状态
		{
			set{ _状态=value;}
			get{return _状态;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 审批人
		{
			set{ _审批人=value;}
			get{return _审批人;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 审批日期
		{
			set{ _审批日期=value;}
			get{return _审批日期;}
        }
        /// <summary>
        /// 
        /// </summary>
        public string 再次提交
        {
            set { _再次提交 = value; }
            get { return _再次提交; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 再次提交日期
        {
            set { _再次提交日期 = value; }
            get { return _再次提交日期; }
        }
		#endregion Model

	}
}


namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:_8D报告
    /// </summary>
    public partial class _8D报告
    {
        public _8D报告()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model._8D报告 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.IDHead != null)
            {
                strSql1.Append("IDHead,");
                strSql2.Append("" + model.IDHead + ",");
            }
            if (model.TaskID != null)
            {
                strSql1.Append("TaskID,");
                strSql2.Append("" + model.TaskID + ",");
            }
            if (model.组长 != null)
            {
                strSql1.Append("组长,");
                strSql2.Append("'" + model.组长 + "',");
            }
            if (model.品管部 != null)
            {
                strSql1.Append("品管部,");
                strSql2.Append("'" + model.品管部 + "',");
            }
            if (model.工程部 != null)
            {
                strSql1.Append("工程部,");
                strSql2.Append("'" + model.工程部 + "',");
            }
            if (model.制造部 != null)
            {
                strSql1.Append("制造部,");
                strSql2.Append("'" + model.制造部 + "',");
            }
            if (model.调查情况 != null)
            {
                strSql1.Append("调查情况,");
                strSql2.Append("'" + model.调查情况 + "',");
            }
            if (model.调查情况签名 != null)
            {
                strSql1.Append("调查情况签名,");
                strSql2.Append("'" + model.调查情况签名 + "',");
            }
            if (model.调查情况日期 != null && model.调查情况日期 != DateTime.MinValue)
            {
                strSql1.Append("调查情况日期,");
                strSql2.Append("'" + model.调查情况日期 + "',");
            }
            if (model.临时措施 != null)
            {
                strSql1.Append("临时措施,");
                strSql2.Append("'" + model.临时措施 + "',");
            }
            if (model.临时措施责任人 != null)
            {
                strSql1.Append("临时措施责任人,");
                strSql2.Append("'" + model.临时措施责任人 + "',");
            }
            if (model.临时措施完成时限 != null && model.临时措施完成时限 != DateTime.MinValue)
            {
                strSql1.Append("临时措施完成时限,");
                strSql2.Append("'" + model.临时措施完成时限 + "',");
            }
            if (model.临时措施结果验证 != null)
            {
                strSql1.Append("临时措施结果验证,");
                strSql2.Append("'" + model.临时措施结果验证 + "',");
            }
            if (model.原因分析 != null)
            {
                strSql1.Append("原因分析,");
                strSql2.Append("'" + model.原因分析 + "',");
            }
            if (model.纠正措施 != null)
            {
                strSql1.Append("纠正措施,");
                strSql2.Append("'" + model.纠正措施 + "',");
            }
            if (model.纠正措施责任人 != null)
            {
                strSql1.Append("纠正措施责任人,");
                strSql2.Append("'" + model.纠正措施责任人 + "',");
            }
            if (model.纠正措施完成时限 != null && model.纠正措施完成时限 != DateTime.MinValue)
            {
                strSql1.Append("纠正措施完成时限,");
                strSql2.Append("'" + model.纠正措施完成时限 + "',");
            }
            if (model.纠正措施结果验证 != null)
            {
                strSql1.Append("纠正措施结果验证,");
                strSql2.Append("'" + model.纠正措施结果验证 + "',");
            }
            if (model.预防措施 != null)
            {
                strSql1.Append("预防措施,");
                strSql2.Append("'" + model.预防措施 + "',");
            }
            if (model.预防措施责任人 != null)
            {
                strSql1.Append("预防措施责任人,");
                strSql2.Append("'" + model.预防措施责任人 + "',");
            }
            if (model.预防措施完成时限 != null && model.预防措施完成时限 != DateTime.MinValue)
            {
                strSql1.Append("预防措施完成时限,");
                strSql2.Append("'" + model.预防措施完成时限 + "',");
            }
            if (model.预防措施结果验证 != null)
            {
                strSql1.Append("预防措施结果验证,");
                strSql2.Append("'" + model.预防措施结果验证 + "',");
            }
            if (model.效果 != null)
            {
                strSql1.Append("效果,");
                strSql2.Append("'" + model.效果 + "',");
            }
            if (model.效果签名 != null)
            {
                strSql1.Append("效果签名,");
                strSql2.Append("'" + model.效果签名 + "',");
            }

            strSql.Append("insert into UFDLImport.._8D报告(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model._8D报告 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UFDLImport.._8D报告 set ");
            if (model.TaskID != null)
            {
                strSql.Append("TaskID=" + model.TaskID + ",");
            }
            else
            {
                strSql.Append("TaskID= null ,");
            }
            if (model.组长 != null)
            {
                strSql.Append("组长='" + model.组长 + "',");
            }
            else
            {
                strSql.Append("组长= null ,");
            }
            if (model.品管部 != null)
            {
                strSql.Append("品管部='" + model.品管部 + "',");
            }
            else
            {
                strSql.Append("品管部= null ,");
            }
            if (model.工程部 != null)
            {
                strSql.Append("工程部='" + model.工程部 + "',");
            }
            else
            {
                strSql.Append("工程部= null ,");
            }
            if (model.制造部 != null)
            {
                strSql.Append("制造部='" + model.制造部 + "',");
            }
            else
            {
                strSql.Append("制造部= null ,");
            }
            if (model.调查情况 != null)
            {
                strSql.Append("调查情况='" + model.调查情况 + "',");
            }
            if (model.调查情况签名 != null)
            {
                strSql.Append("调查情况签名='" + model.调查情况签名 + "',");
            }
            if (model.调查情况日期 != null && model.调查情况日期 != DateTime.MinValue)
            {
                strSql.Append("调查情况日期='" + model.调查情况日期 + "',");
            }
            if (model.临时措施 != null)
            {
                strSql.Append("临时措施='" + model.临时措施 + "',");
            }
            if (model.临时措施责任人 != null)
            {
                strSql.Append("临时措施责任人='" + model.临时措施责任人 + "',");
            }
            if (model.临时措施完成时限 != null && model.临时措施完成时限 != DateTime.MinValue)
            {
                strSql.Append("临时措施完成时限='" + model.临时措施完成时限 + "',");
            }
            if (model.临时措施结果验证 != null)
            {
                strSql.Append("临时措施结果验证='" + model.临时措施结果验证 + "',");
            }
            if (model.原因分析 != null)
            {
                strSql.Append("原因分析='" + model.原因分析 + "',");
            }
            if (model.纠正措施 != null)
            {
                strSql.Append("纠正措施='" + model.纠正措施 + "',");
            }
            if (model.纠正措施责任人 != null)
            {
                strSql.Append("纠正措施责任人='" + model.纠正措施责任人 + "',");
            }
            if (model.纠正措施完成时限 != null && model.纠正措施完成时限 != DateTime.MinValue)
            {
                strSql.Append("纠正措施完成时限='" + model.纠正措施完成时限 + "',");
            }
            if (model.纠正措施结果验证 != null)
            {
                strSql.Append("纠正措施结果验证='" + model.纠正措施结果验证 + "',");
            }
            if (model.预防措施 != null)
            {
                strSql.Append("预防措施='" + model.预防措施 + "',");
            }
            if (model.预防措施责任人 != null)
            {
                strSql.Append("预防措施责任人='" + model.预防措施责任人 + "',");
            }
            if (model.预防措施完成时限 != null && model.预防措施完成时限 != DateTime.MinValue)
            {
                strSql.Append("预防措施完成时限='" + model.预防措施完成时限 + "',");
            }
            if (model.预防措施结果验证 != null)
            {
                strSql.Append("预防措施结果验证='" + model.预防措施结果验证 + "',");
            }
            if (model.效果 != null)
            {
                strSql.Append("效果='" + model.效果 + "',");
            }
            if (model.效果签名 != null)
            {
                strSql.Append("效果签名='" + model.效果签名 + "',");
            }
            if (model.再次提交 != null)
            {
                strSql.Append("再次提交='" + model.再次提交 + "',");
            }
            if (model.再次提交日期 != null && model.再次提交日期 != DateTime.MinValue)
            {
                strSql.Append("再次提交日期='" + model.再次提交日期 + "',");
            }
           
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where IDHead=" + model.IDHead + " ");
            return strSql.ToString();
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

