using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Base
{
    public partial class Frm杜乐耗材档案Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string scInvCode = "";

        public Frm杜乐耗材档案Edit()
        {
            InitializeComponent();

            setLookUp();
        }

        public Frm杜乐耗材档案Edit(string s)
        {
            InitializeComponent();

            setLookUp();

            scInvCode = s;
        }

        private void SetValue()
        {
            string sSQL = @"
select cast(0 as bit) as 选择, *
from UFDLImport..InventoryHC
where 1=1
order by cInvCode";

            sSQL = sSQL.Replace("1=1", "1=1 and cInvCode = '" + scInvCode + "'");
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtcInvcode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                txtcInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                txtcInvAbbName.Text = dt.Rows[0]["cInvAbbName"].ToString().Trim();
                txtCreateUid.Text = dt.Rows[0]["CreateUid"].ToString().Trim();
                txtcInvStd.Text = dt.Rows[0]["cInvStd"].ToString().Trim();
                txtRemark1.Text = dt.Rows[0]["Remark1"].ToString().Trim();
                lookUpEditcVenCode.EditValue = dt.Rows[0]["Remark2"];
                txtRemark3.Text = dt.Rows[0]["Remark3"].ToString().Trim();
                txtRemark4.Text = dt.Rows[0]["Remark4"].ToString().Trim();
                txtRemark5.Text = dt.Rows[0]["Remark5"].ToString().Trim();
                txtRemark6.Text = dt.Rows[0]["Remark6"].ToString().Trim();
                txtRemark7.Text = dt.Rows[0]["Remark7"].ToString().Trim();
                txtRemark8.Text = dt.Rows[0]["Remark8"].ToString().Trim();
                txtUpdateUid.Text = dt.Rows[0]["UpdateUid"].ToString().Trim();
                lookUpEditInvcodeClassHC.EditValue = dt.Rows[0]["cInvCCode"].ToString().Trim();

                if (dt.Rows[0]["CreateDate"].ToString().Trim() != "")
                    dtmCreate.Text = dt.Rows[0]["CreateDate"].ToString().Trim();

                if (dt.Rows[0]["UpdateDate"].ToString().Trim() != "")
                    dtmUpdate.Text = dt.Rows[0]["UpdateDate"].ToString().Trim();
            }
        }

        private void SetNull()
        {
            txtcInvcode.Text = "";
            txtcInvName.Text = "";
            txtcInvAbbName.Text = "";
            txtCreateUid.Text = "";
            txtcInvStd.Text = "";
            txtRemark1.Text = "";
            lookUpEditcVenCode.EditValue = DBNull.Value;
            txtRemark3.Text = "";
            txtRemark4.Text = "";
            txtRemark5.Text = "";
            txtRemark6.Text = "";
            txtRemark7.Text = "";
            txtRemark8.Text = "";
            txtUpdateUid.Text = "";
            dtmCreate.Text = "";
            dtmUpdate.Text = "";
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcInvcode.Text.Trim() == "")
                {
                    txtcInvcode.Focus();
                    throw new Exception("存货编码不能为空");
                }
                if (txtcInvName.Text.Trim() == "")
                {
                    txtcInvName.Focus();
                    throw new Exception("存货名称不能为空");
                }
                if (lookUpEditInvcodeClassHC.Text.Trim() == "")
                {
                    txtcInvName.Focus();
                    throw new Exception("存货分类不能为空");
                }

                string sSQL = "";
                if (scInvCode.Trim() != "")
                {
                    sSQL = "select count(1) from @u8.Inventory where cInvCode = '" + txtcInvcode.Text.Trim() + "'";
                    int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                        throw new Exception("供应商编码不能与U8重复");
                }

                ArrayList aList = new ArrayList();

                if (scInvCode.Trim() == "")
                {
                    sSQL = " INSERT INTO [UFDLImport].[dbo].[InventoryHC]([cInvCode] ,[cInvName] ,[cInvAbbName]  ,[cInvStd] " +
                                        ",[Remark1] ,[Remark2] ,[Remark3] " +
                                       ",[Remark4],[Remark5] ,[Remark6] ,[Remark7] ,[Remark8]  ,[CreateUid] ,[CreateDate] ,[UpdateUid]  ,[UpdateDate],cInvCCode) " +
                                " VALUES " +
                                       "(N'" + txtcInvcode.Text.Trim() + "'  ,N'" + txtcInvName.Text.Trim() + "'  ,N'" + txtcInvAbbName.Text.Trim() + "' ,N'" + txtcInvStd.Text.Trim() + "'" +
                                       ",N'" + txtRemark1.Text.Trim() + "'  ,N'" + lookUpEditcVenCode.Text.Trim() + "',N'" + txtRemark3.Text.Trim() + "',N'" + txtRemark4.Text.Trim() + "' " +
                                       ",N'" + txtRemark5.Text.Trim() + "' ,N'" + txtRemark6.Text.Trim() + "' ,N'" + txtRemark7.Text.Trim() + "'   ,N'" + txtRemark8.Text.Trim() + "'  ,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "'  ,getdate()  ,null,null,'" + lookUpEditInvcodeClassHC.EditValue.ToString().Trim() + "')  ";
                }
                else
                {
                    sSQL = @"
UPDATE [UFDLImport].[dbo].[InventoryHC] " +
   "SET [cInvName] = N'" + txtcInvName.Text.Trim() + "' " +
   "   ,[cInvAbbName] =  N'" + txtcInvAbbName.Text.Trim() + "' " +
   "   ,[cInvStd] =  N'" + txtcInvStd.Text.Trim() + "' " +
   "   ,[cInvCCode] =  '" + lookUpEditInvcodeClassHC.EditValue.ToString().Trim() + "' " +
   "   ,[Remark1] =  N'" + txtRemark1.Text.Trim() + "' " +
   "   ,[Remark2] =  N'" + lookUpEditcVenCode.Text.Trim() + "' " +
   "   ,[Remark3] =  N'" + txtRemark3.Text.Trim() + "' " +
   "   ,[Remark4] =  N'" + txtRemark4.Text.Trim() + "' " +
   "   ,[Remark5] =  N'" + txtRemark5.Text.Trim() + "' " +
   "   ,[Remark6] =  N'" + txtRemark6.Text.Trim() + "' " +
   "   ,[Remark7] =  N'" + txtRemark7.Text.Trim() + "' " +
   "   ,[Remark8] =  N'" + txtRemark8.Text.Trim() + "' " +
   "   ,[UpdateUid] =  N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' " +
   "   ,[UpdateDate] =  getdate() " +
"where cInvCode = N'" + scInvCode.Trim() + "'";
                }
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功");

                    SetEnable(false);
                    btn保存.Enabled = false;

                    SetNull();

                    btn保存.Enabled = true;

                    SetEnable(true);
                    scInvCode = "";

                    txtcInvcode.Focus();
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }



        private void btn退出_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void Frm杜乐耗材供应商Edit_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;

                string sSQL = @"
SELECT     cInvCCode, cInvCName, cInvCCodeUp
FROM         UFDLImport..InvcodeClassHC
WHERE     cInvCCode NOT IN
                          (SELECT     cInvCCodeUp
                            FROM          UFDLImport..InvcodeClassHC AS a)
ORDER BY cInvCCode
";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEditInvcodeClassHC.Properties.DataSource = dt;
                lookUpEditInvcodeClassNameHC.Properties.DataSource = dt; 

                this.StartPosition = FormStartPosition.CenterParent;

                SetNull();

                if (scInvCode.Trim() != "")
                {
                    SetValue();
                }

                SetEnable(true);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        
        private void SetEnable(bool b)
        {
            if (scInvCode.Trim() != "")
                txtcInvcode.Enabled = b;
            else
                txtcInvcode.Enabled = b;

            txtcInvName.Enabled = b;
            txtcInvAbbName.Enabled = b;
            txtCreateUid.Enabled = false;
            txtcInvStd.Enabled = b;
            txtRemark1.Enabled = b;
            lookUpEditcVenCode.Enabled = b;
            lookUpEditcVenName.Enabled = b;
            txtRemark3.Enabled = b;
            txtRemark4.Enabled = b;
            txtRemark5.Enabled = b;
            txtRemark6.Enabled = b;
            txtRemark7.Enabled = b;
            txtRemark8.Enabled = b;
            txtUpdateUid.Enabled = false;
            dtmCreate.Enabled = false;
            dtmUpdate.Enabled = false;
            lookUpEditInvcodeClassHC.Enabled = b;
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcInvcode.Text.Trim() == "")
                {
                    txtcInvcode.Focus();
                    throw new Exception("存货编码不能为空");
                }
                if (txtcInvName.Text.Trim() == "")
                {
                    txtcInvName.Focus();
                    throw new Exception("存货名称不能为空");
                }
                if (lookUpEditInvcodeClassHC.Text.Trim() == "")
                {
                    txtcInvName.Focus();
                    throw new Exception("存货分类不能为空");
                }

                string sSQL = "";
                if (scInvCode.Trim() != "")
                {
                    sSQL = "select count(1) from @u8.Inventory where cInvCode = '" + txtcInvcode.Text.Trim() + "'";
                    int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                        throw new Exception("供应商编码不能与U8重复");
                }

                ArrayList aList = new ArrayList();

                if (scInvCode.Trim() == "")
                {
                    sSQL = " INSERT INTO [UFDLImport].[dbo].[InventoryHC]([cInvCode] ,[cInvName] ,[cInvAbbName]  ,[cInvStd] " +
                                        ",[Remark1] ,[Remark2] ,[Remark3] " +
                                       ",[Remark4],[Remark5] ,[Remark6] ,[Remark7] ,[Remark8]  ,[CreateUid] ,[CreateDate] ,[UpdateUid]  ,[UpdateDate],cInvCCode) " +
                                " VALUES " +
                                       "(N'" + txtcInvcode.Text.Trim() + "'  ,N'" + txtcInvName.Text.Trim() + "'  ,N'" + txtcInvAbbName.Text.Trim() + "' ,N'" + txtcInvStd.Text.Trim() + "'" +
                                       ",N'" + txtRemark1.Text.Trim() + "'  ,N'" + lookUpEditcVenCode.Text.Trim() + "',N'" + txtRemark3.Text.Trim() + "',N'" + txtRemark4.Text.Trim() + "' " +
                                       ",N'" + txtRemark5.Text.Trim() + "' ,N'" + txtRemark6.Text.Trim() + "' ,N'" + txtRemark7.Text.Trim() + "'   ,N'" + txtRemark8.Text.Trim() + "'  ,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "'  ,getdate()  ,null,null,'"+ lookUpEditInvcodeClassHC.EditValue.ToString().Trim() +"')  ";

                    aList.Add(sSQL);
                }


                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功");

                    SetNull();
                    txtcInvcode.Focus();
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void setLookUp()
        {
            string sSQL = "select cVenCode,cVenName from UFDLImport..VendorHC order by cVenCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            lookUpEditcVenCode.Properties.DataSource = dt;
            lookUpEditcVenName.Properties.DataSource = dt;
        }

        private void lookUpEditcVenCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditcVenName.EditValue != lookUpEditcVenCode.EditValue)
                    lookUpEditcVenName.EditValue = lookUpEditcVenCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcVenName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditcVenName.EditValue != lookUpEditcVenCode.EditValue)
                    lookUpEditcVenCode.EditValue = lookUpEditcVenName.EditValue;
            }
            catch { }
        }

        private void lookUpEditInvcodeClassHC_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditInvcodeClassHC.EditValue != lookUpEditInvcodeClassNameHC.EditValue)
                {
                    lookUpEditInvcodeClassNameHC.EditValue = lookUpEditInvcodeClassHC.EditValue;
                }
            }
            catch { }
        }

        private void lookUpEditInvcodeClassNameHC_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditInvcodeClassHC.EditValue != lookUpEditInvcodeClassNameHC.EditValue)
                {
                    lookUpEditInvcodeClassHC.EditValue = lookUpEditInvcodeClassNameHC.EditValue;
                }
            }
            catch { }
        }
    }
}