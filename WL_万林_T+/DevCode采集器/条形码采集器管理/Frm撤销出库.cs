using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TH.BaseClass;
using System.Data.SqlClient;

namespace BarCode
{
    public partial class Frm撤销出库 : FrmBase
    {
        public Frm撤销出库()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        private void Frm撤销出库_Load(object sender, EventArgs e)
        {
            txt条形码.Focus();
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            { 
                if(e.KeyCode != Keys.Enter)
                    return;

                btnScan_Click(null,null);
            }
            catch { }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt条形码.Text.Trim() == "")
                {
                    MessageBox.Show("请扫描条码");
                    return;
                }

                int iCount = 0;
                SqlConnection conn = new SqlConnection(MobileBaseDLL.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "select getdate()";
                try
                {

                    sSQL = @"
SELECT iID, BarCode, Qty, DetailsID, CreateUid, CreateDate, RePrintUid, RePrintDate, PrintCount, DelUid, DelDate, 
                RdOutIDs, BarCode2
FROM      _BarCodeList
where BarCode = 'aaaaaa' and isnull(RdOutIDs,0) > 0
";
                    sSQL = sSQL.Replace("aaaaaa", txt条形码.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("条码不存在,或未出库，不能撤销");
                    }

                    DialogResult d = MessageBox.Show("确定撤销出库么?\n条形码:" + txt条形码.Text.Trim(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    if (d != DialogResult.Yes)
                    {
                        tran.Rollback();
                        return;
                    }

                    Model.ST_RDRecord_b mods = new BarCode.Model.ST_RDRecord_b();
                    sSQL = @"select * from ST_RDRecord_b where id = aaaaaa";
                    sSQL = sSQL.Replace("aaaaaa", dt.Rows[0]["RdOutIDs"].ToString().Trim());
                    DataTable dtST_RDRecord_b = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DAL.ST_RDRecord_b dal = new BarCode.DAL.ST_RDRecord_b();
                    mods = dal.DataRowToModel(dtST_RDRecord_b.Rows[0]);

                    sSQL = @"delete [ST_LocationDetail] where idRDRecordDetailDTO = aaaaaa";
                    sSQL = sSQL.Replace("aaaaaa", dt.Rows[0]["RdOutIDs"].ToString().Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"delete [ST_RDRecord_b] where id = aaaaaa";
                    sSQL = sSQL.Replace("aaaaaa", dt.Rows[0]["RdOutIDs"].ToString().Trim());
                    iCount = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update  _BarCodeList set RdOutIDs = null where BarCode = 'aaaaaa'";
                    sSQL = sSQL.Replace("aaaaaa", txt条形码.Text.Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //现存量
                    sSQL = @"
UPDATE  ST_CurrentStock SET otherForDispatchBaseQuantity = ISNULL(otherForDispatchBaseQuantity,0) - @qty, otherForDispatchSubQuantity = ISNULL(otherForDispatchSubQuantity,0) -  @num
where  isnull(freeItem0,'') = '@freeItem0' and isnull(freeItem1,'') = '@freeItem1' and isnull(freeItem2,'') ='@freeItem2' and isnull(freeItem3,'') = '@freeItem3' 
    and isnull(freeItem4,'') = '@freeItem4' and isnull(freeItem5,'') = '@freeItem5' and isnull(freeItem6,'') = '@freeItem6' 
    and  idinventory = @idinventory and  idwarehouse = @idwarehouse
";
                    sSQL = sSQL.Replace("@qty", mods.quantity.ToString());
                    sSQL = sSQL.Replace("@num", mods.quantity2.ToString());
                    sSQL = sSQL.Replace("@freeItem0", mods.freeItem0);
                    sSQL = sSQL.Replace("@freeItem1", mods.freeItem1);
                    sSQL = sSQL.Replace("@freeItem2", mods.freeItem2);
                    sSQL = sSQL.Replace("@freeItem3", mods.freeItem3);
                    sSQL = sSQL.Replace("@freeItem4", mods.freeItem4);
                    sSQL = sSQL.Replace("@freeItem5", mods.freeItem5);
                    sSQL = sSQL.Replace("@freeItem6", mods.freeItem6);
                    sSQL = sSQL.Replace("@baseQuantity", mods.baseQuantity.ToString());
                    sSQL = sSQL.Replace("@subQuantity", mods.subQuantity.ToString());
                    sSQL = sSQL.Replace("@idinventory", mods.idinventory.ToString());
                    sSQL = sSQL.Replace("@idwarehouse", mods.idwarehouse.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount > 0)
                    {
                        MessageBox.Show("撤销成功");
                    }
                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                txt条形码.Text = "";
                txt条形码.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}