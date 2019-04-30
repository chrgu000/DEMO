using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;
using System.Data.SqlClient;

namespace Base
{
    public partial class FrmInvUpdate : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmInvUpdate()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "add":
                        btnLoad();
                        break;
                    case "save":
                        btnSave();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad()
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [Sheet1$]";

                    FrameBaseFunction.ClsExcel clsExcel = FrameBaseFunction.ClsExcel.Instance();
                    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    for (int i = dtExcel.Rows.Count - 1; i >= 0; i--)
                    {
                        string sInvCode = dtExcel.Rows[i]["存货编码"].ToString().Trim();
                        if (sInvCode == "")
                            dtExcel.Rows.RemoveAt(i);
                    }

                    gridControl1.DataSource = dtExcel;
                }
            }
            catch (Exception ee)
            { }
        }


        private void btnSave()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                ArrayList aList = new ArrayList();
                string sErr = "";

                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString2);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sInvCode = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
                        string sInvName = gridView1.GetRowCellValue(i, gridCol存货名称).ToString().Trim();
                        string sInvStd = gridView1.GetRowCellValue(i, gridCol规格型号).ToString().Trim();

                        if (sInvCode == "")
                            continue;

                        if (sInvName == "")
                        {
                            sErr = sErr + "行 " + (i + 1).ToString().Trim() + " 存货名称不能为空\n";
                        }

                        sSQL = @"
select * from @u8.Inventory where cInvCode = '{0}'
";
                        sSQL = string.Format(sSQL, sInvCode);
                        DataTable dtTemp = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtTemp != null && dtTemp.Rows.Count > 0 && dtTemp.Rows[0][0].ToString().Trim() == sInvCode)
                        {
                            Model.Inventory_History mod = new Base.Model.Inventory_History();
                            mod.cInvCode = sInvCode;
                            mod.cInvNameOld = dtTemp.Rows[0]["cInvName"].ToString().Trim();
                            mod.cInvStdOld = dtTemp.Rows[0]["cInvStd"].ToString().Trim();
                            mod.cInvNameNew = sInvName;
                            mod.cInvStdNew = sInvStd;
                            mod.CreateUid = sUserName;

                            DAL.Inventory_History dal = new Base.DAL.Inventory_History();
                            sSQL = dal.Add(mod);
                            sSQL = sSQL.Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");

                            ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = @"
update @u8.Inventory set cInvName = '{0}' ,cInvStd = '{1}' where cInvCode = '{2}'
";
                            sSQL = string.Format(sSQL, sInvName, sInvStd, sInvCode);
                            sSQL = sSQL.Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");

                            ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        }
                        else
                        {
                            sErr = sErr + "行 " + (i + 1).ToString().Trim() + " 存货编码不存在\n";
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }
                    else
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功！");

                        gridControl1.DataSource = null;
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();

                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {

                throw new Exception(ee.Message);
            }
        }



        private void FrmVendUid_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }


        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

    }
}