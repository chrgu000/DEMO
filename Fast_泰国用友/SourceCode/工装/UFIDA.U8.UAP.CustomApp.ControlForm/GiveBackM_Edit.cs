using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;
using System.Data.SqlClient;
using System.IO;
using System.Collections;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class GiveBackM_Edit : Form
    {
        //public string Conn;
        public string sUserName;
        public string sUserID;
        clsUserRigth clsUserRight = new clsUserRigth();

        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\GiveBackMMod.dll";
        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public GiveBackM_Edit(string connectionString, string s_Code)
        {
            InitializeComponent();

            DbHelperSQL.connectionString = connectionString;
            txtCode.Text = s_Code;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 6510))
                    throw new Exception("没有权限");

                if (gridView1.RowCount == 0)
                {
                    throw new Exception("请输入表体");
                }
                string sErr = "";
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                int iCou = 0;

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSerCode = txtCode.Text.Trim();
                    Model._GiveBackM model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._GiveBackM();
                    string sState = "";

                    string sSQL = "select * from  _GiveBackM where cCode = N'" + txtCode.Text.Trim() + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        if (dtTemp.Rows[0]["AuditUserName"].ToString().Trim() != "")
                        {
                            throw new Exception("单据已经审核，不能保存");
                        }
                    }

                    //新增
                    if (txtCode.Text.Trim() == "")
                    {
                        sState = "add";
                        model.CreateUserName = sUserName;
                        model.CreateDate = DateTime.Today;
                        long iCode = 0;

                        sSQL = "select max(cCode) as cCode from [_GiveBackM] where cCode like '111111%'";
                        sSQL = sSQL.Replace("111111", dtmCode.DateTime.ToString("yyMMdd"));
                        DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtCode == null && dtCode.Rows.Count == 0)
                        {
                            iCode = 1;
                        }
                        else
                        {
                            string s = dtCode.Rows[0]["cCode"].ToString().Trim();
                            if (s.Length > 6)
                            {
                                iCode = BaseFunction.ReturnLong(s.Substring(6));
                            }
                            else
                            {
                                iCode = BaseFunction.ReturnLong(s);
                            }
                            iCode += 1;
                        }
                        string sCode = iCode.ToString().Trim();
                        while (sCode.Length < 4)
                        {
                            sCode = "0" + sCode;
                        }
                        sCode = dtmCode.DateTime.ToString("yyMMdd") + sCode;

                        model.cCode = sCode;

                        model.dDate = dtmCode.DateTime;
                        if (lookUpEditPerson.EditValue != null)
                        {
                            model.Person = lookUpEditPerson.EditValue.ToString().Trim();
                        }
                        if (lookUpEditDep.EditValue != null)
                        {
                            model.DepCode = lookUpEditDep.EditValue.ToString().Trim();
                        }
                        model.Remark = txtRemark.Text.Trim();
                        model.CreateUserName = sUserName;
                        model.CreateDate = DateTime.Now;

                        DAL._GiveBackM dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._GiveBackM();

                        sSQL = dal.Add(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        sState = "edit";
                        model.cCode = txtCode.Text.Trim();
                        model.dDate = dtmCode.DateTime;
                        model.Person = lookUpEditPerson.EditValue.ToString().Trim();
                        model.DepCode = lookUpEditDep.EditValue.ToString().Trim();
                        model.Remark = txtRemark.Text.Trim();
                        model.CreateUserName = txtCreateUserName.Text.Trim();
                        model.CreateDate = dtmCreate.DateTime;

                        DAL._GiveBackM dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._GiveBackM();
                        sSQL = dal.Update(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = "delete _GiveBackMs where cCode = N'" + model.cCode + "'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim() != "")
                        {
                            Model._GiveBackMs models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._GiveBackMs();
                            models.cCode = model.cCode;
                            models.SerialNo = gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim();
                            models.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                            models.MaintenancesiID = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColMaintenancesiID));

                            sSQL = @"
select * from _FrockClamp where SerialNo = N'111111'
";
                            sSQL = sSQL.Replace("111111", models.SerialNo);
                            DataTable dtTemp2 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            long lTimes = BaseFunction.ReturnLong(dtTemp2.Rows[0]["Times"]);

                            //if (lTimes > 0)
                            //{
                            //    long lTimesNow = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColTimes));
                            //    if (lTimesNow <= 0)
                            //    {
                            //        sErr = sErr + "行" + (i + 1).ToString() + "请输入使用次数";
                            //        continue;
                            //    }
                            //    models.Times = lTimesNow;
                            //}

                            DAL._GiveBackMs dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._GiveBackMs();
                            sSQL = dals.Add(models);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "select iState from _FrockClamp where SerialNo = N'111111'";
                            sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim());
                            dtTemp = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];
                            if (dtTemp != null && BaseFunction.ReturnInt(dtTemp.Rows[0]["iState"]) == 3)
                            {
                                sSQL = "update _FrockClamp set iState = 1 where SerialNo = N'111111'";
                                sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim());
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "工装不是可用状态\n";
                                continue;
                            }
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n");

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        throw new Exception("no data");
                    }
                }
                catch(Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void SetLookup()
        {
            string sSQL = @"
select cPersonCode,cPersonName from person order by cPersonCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditPerson.Properties.DataSource = dt;

            sSQL = @"
select cDepCode,cDepName from Department where bDepEnd = 1 order by cDepCode 
";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditDep.Properties.DataSource = dt;

            dtmCode.DateTime = DateTime.Today;

            sSQL = @"
select SerialNo,InvName,InvStd from _FrockClamp order by SerialNo
";

            dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditInvName.DataSource = dt;
            ItemLookUpEditInvStd.DataSource = dt;
            ItemLookUpEditSerialNo.DataSource = dt;

            sSQL = @"
select b.iID, a.cCode
from _Maintenance a inner join _Maintenances b on a.cCode=b.cCode
order by b.iID
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditMaintenancesiID.DataSource = dt;
        }

        private void FrmMaintenance_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();

                GetGrid(txtCode.Text.Trim());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid(string sCode)
        {
            string sSQL = @"
select * from _GiveBackMs where cCode = N'111111' order by iID
";
            sSQL = sSQL.Replace("111111", sCode);
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            while (gridView1.RowCount < 10)
            {
                gridView1.AddNewRow();
            }
            gridView1.FocusedRowHandle = 0;

            sSQL = @"
select * from _GiveBackM where cCode = N'111111' order by iID
";
            sSQL = sSQL.Replace("111111", sCode);
            dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCode.Text = dt.Rows[0]["cCode"].ToString().Trim();
                dtmCode.DateTime = BaseFunction.ReturnDate(dt.Rows[0]["dDate"]);
                lookUpEditPerson.EditValue = dt.Rows[0]["Person"].ToString().Trim();
                lookUpEditDep.EditValue = dt.Rows[0]["DepCode"].ToString().Trim();
                txtRemark.EditValue = dt.Rows[0]["Remark"].ToString().Trim();
                txtCreateUserName.Text = dt.Rows[0]["CreateUserName"].ToString().Trim();
                dtmCreate.DateTime = BaseFunction.ReturnDate(dt.Rows[0]["CreateDate"]);
                txtAuditUserName.Text = dt.Rows[0]["AuditUserName"].ToString().Trim();
                dtmAudit.DateTime = BaseFunction.ReturnDate(dt.Rows[0]["AuditDate"]);
                    
            }
        }

        private void btnUnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 6550))
                    throw new Exception("没有权限");

                if (txtCode.Text.Trim() == "")
                {
                    throw new Exception("请选择单据弃审");
                }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select * from  _GiveBackM where cCode = N'" + txtCode.Text.Trim() + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        throw new Exception("单据未保存");
                    }
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        if (dtTemp.Rows[0]["AuditUserName"].ToString().Trim() == "")
                        {
                            throw new Exception("单据未审核");
                        }
                    }

                    sSQL = "update _GiveBackM set AuditUserName = null,AuditDate = null where cCode = N'222222'";
                    sSQL = sSQL.Replace("111111", sUserName);
                    sSQL = sSQL.Replace("222222", txtCode.Text.Trim());
                    int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("弃审成功");

                        GetGrid(txtCode.Text.Trim());
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
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 6540))
                    throw new Exception("没有权限");

                if (txtCode.Text.Trim() == "")
                {
                    throw new Exception("请选择单据审核");
                }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select * from  _GiveBackM where cCode = N'" + txtCode.Text.Trim() + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        throw new Exception("单据未保存");
                    }
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        if (dtTemp.Rows[0]["AuditUserName"].ToString().Trim() != "")
                        {
                            throw new Exception("单据已经审核");
                        }
                    }

                    sSQL = @"update  _FrockClamp set iState = 1 where  SerialNo in (select SerialNo from _GiveBackMs where cCode = N'" + txtCode.Text.Trim() + "') and isnull(Closed,'') = '' ";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update _GiveBackM set AuditUserName = N'111111',AuditDate = getdate() where cCode = N'222222'";
                    sSQL = sSQL.Replace("111111", sUserName);
                    sSQL = sSQL.Replace("222222", txtCode.Text.Trim());
                    int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("审核成功");


                        GetGrid(txtCode.Text.Trim());
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
                MessageBox.Show(ee.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                if (!clsUserRight.chkRight(sUserID, 6530))
                    throw new Exception("没有权限");

                if (txtCode.Text.Trim() == "")
                {
                    throw new Exception("请选择单据");
                }

                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }

                Rep.dsPrint.Tables.Clear();

                string sSQL = @"
select * from  _GiveBackM where cCode = N'111111'
";
                sSQL = sSQL.Replace("111111", txtCode.Text.Trim());
                DataTable dt = DbHelperSQL.Query(sSQL);

                DataTable dtHead = dt.Copy();
                dtHead.TableName = "dtHead";
                Rep.dsPrint.Tables.Add(dtHead);

                sSQL = @"
select * ,b.InvName,b.InvStd
from  _GiveBackMs a left join _FrockClamp b on a.SerialNo = b.SerialNo
where a.cCode = N'111111' 
order by a.iID
";
                sSQL = sSQL.Replace("111111", txtCode.Text.Trim());
                dt = DbHelperSQL.Query(sSQL);
                DataTable dtGrid = dt.Copy();
                dtGrid.TableName = "dtGrid";
                Rep.dsPrint.Tables.Add(dtGrid);



                if (Rep.dsPrint == null)
                    throw new Exception("没有需要打印的数据");

                Rep.ShowPreview();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "打印失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
            
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColSerialNo && e.RowHandle == gridView1.RowCount - 1)
                {
                    gridView1.AddNewRow();
                }
            }
            catch { }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 6520))
                    throw new Exception("没有权限");

                if (txtCode.Text.Trim() == "")
                {
                    throw new Exception("请选择单据删除");
                }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select * from  _GiveBackM where cCode = N'" + txtCode.Text.Trim() + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        throw new Exception("单据未保存");
                    }
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        if (dtTemp.Rows[0]["AuditUserName"].ToString().Trim() != "")
                        {
                            throw new Exception("单据已经审核");
                        }
                    }

                    sSQL = "update _FrockClamp set iState = 2 where SerialNo in (select SerialNo from _GiveBackMs where cCode = N'111111')";
                    sSQL = sSQL.Replace("111111", txtCode.Text.Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "delete _GiveBackMs where cCode = N'111111'";
                    sSQL = sSQL.Replace("111111", txtCode.Text.Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    sSQL = "delete _GiveBackM where cCode = N'111111'";
                   sSQL = sSQL.Replace("111111", txtCode.Text.Trim());
                    int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                
                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("删除成功");

                        this.DialogResult = DialogResult.OK;
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
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.AddNewRow();
            }
            catch { }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
            catch { }
        }

        private void btnPrintSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 6560))
                    throw new Exception("没有权限");

                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");

                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "设置打印模板失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void ItemButtonEditMaintenancesiID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ArrayList aList = new ArrayList();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColMaintenancesiID)) > 0)
                    {
                        aList.Add(gridView1.GetRowCellValue(i, gridColMaintenancesiID).ToString().Trim());
                    }
                }

                GiveBackM_Edit_SEL frm = new GiveBackM_Edit_SEL(DbHelperSQL.connectionString,aList);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    aList = frm.aList;

                    for (int j = 0; j < aList.Count; j++)
                    {
                        bool bHas = false;
                        long lIDs2 = BaseFunction.ReturnLong(aList[j]);
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            long lIDs = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColMaintenancesiID));
                            if (lIDs == lIDs2)
                            {
                                bHas = true;
                                break;
                            }
                        }
                        if (bHas)
                            continue;

                        bool bAddRow = false;
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            long lIDs = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColMaintenancesiID));
                            if (lIDs == 0)
                            {
                                gridView1.SetRowCellValue(i, gridColMaintenancesiID, lIDs2.ToString());
                                string sSQL = @"
select b.*
from _Maintenances a left join [dbo].[_FrockClamp] b on a.SerialNo = b.SerialNo
where a.iID = 111111
";
                                sSQL = sSQL.Replace("111111", lIDs2.ToString());
                                DataTable dtTemp = DbHelperSQL.Query(sSQL);

                                if (dtTemp != null && dtTemp.Rows.Count > 0)
                                {
                                    gridView1.SetRowCellValue(i, gridColSerialNo, dtTemp.Rows[0]["SerialNo"].ToString());
                                }

                                bAddRow = true;
                                break;
                            }
                        }
                        if (!bAddRow)
                        {
                            gridView1.AddNewRow();
                            gridView1.SetRowCellValue(gridView1.RowCount - 1, gridColMaintenancesiID, lIDs2.ToString());
                            string sSQL = @"
select b.*
from _Maintenances a left join [dbo].[_FrockClamp] b on a.SerialNo = b.SerialNo
where iID = 111111
";
                            sSQL = sSQL.Replace("111111", lIDs2.ToString());
                            DataTable dtTemp = DbHelperSQL.Query(sSQL);
                            if (dtTemp != null && dtTemp.Rows.Count > 0)
                            {
                                gridView1.SetRowCellValue(gridView1.RowCount - 1, gridColSerialNo, dtTemp.Rows[0]["SerialNo"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEditPerson_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select cDepCode  from person 
";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt.Rows.Count > 0)
                {
                    lookUpEditDep.EditValue = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
    }
}
