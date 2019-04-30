using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Warehouse
{
    public partial class Frm’ª∞Â¥Ê¡ø : FrameBaseFunction.Frm¡–±Ì¥∞ÃÂƒ£∞Â
    {
        public Frm’ª∞Â¥Ê¡ø()
        {
            InitializeComponent();
        }



        #region ∞¥≈•≤Ÿ◊˜
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
             
                    case "sel":
                        btnSel();
                        break;
                    case "export":
                        btnExport();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + "  ß∞‹! \n\n‘≠“Ú:\n  " + ee.Message);
            }
        }

     


        #region ∞¥≈•ƒ£∞Â

        /// <summary>
        ///  ‰≥ˆ
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "ExcelŒƒº˛(*.xls)|*.xls|À˘”–Œƒº˛(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("µº≥ˆExcel≥…π¶\n\t¬∑æ∂£∫" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

       
        #endregion

        /// <summary>
        /// ≤È—Ø
        /// </summary>
        private void btnSel()
        {
            GetGrid();
        }
      
   
        #endregion

        private void FFrm’ª∞Â¥Ê¡ø_Load(object sender, EventArgs e)
        {
            try
            {
                txtVenCode.Properties.ReadOnly = false;

                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin" || dt.Rows.Count == 0)
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    if (dt.Rows[0]["vendCode"].ToString().Trim() == string.Empty)
                    {
                        txtVenCode.Enabled = true;
                    }
                    else
                    {
                        txtVenCode.Enabled = false;
                    }
                    txtVenCode.Text = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("º”‘ÿ¥∞ÃÂ ß∞‹\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = "select * from UFDLImport.dbo._Code where vchrType = '1' order by vchrInfo";
            DataTable dt’ª∞Â = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                string sCol = gridView1.Columns[i].FieldName;
                if (sCol.Length > 2 && sCol.Substring(0, 2) == "’ª∞Â")
                {
                    DataRow[] dr = dt’ª∞Â.Select("vchrInfo = '" + sCol.Trim() + "'");
                    if (dr.Length > 0)
                    {
                        gridView1.Columns[i].Visible = true;
                        gridView1.Columns[i].Caption = dr[0]["vchrRemark"].ToString().Trim();
                    }
                    else
                    {
                        gridView1.Columns[i].Visible = false;
                    }
                }
            }

            int iFocRow = gridView1.FocusedRowHandle;
            sSQL = @"


SELECT a.≥ß…Ã±‡¬Î as ≥ß…Ã±‡¬Î,b.cVenName as ≥ß…Ã
      ,sum(-[’ª∞Â1]) as ’ª∞Â1
      ,sum(-[’ª∞Â2]) as ’ª∞Â2
      ,sum(-[’ª∞Â3]) as ’ª∞Â3
      ,sum(-[’ª∞Â4]) as ’ª∞Â4
      ,sum(-[’ª∞Â5]) as ’ª∞Â5
      ,sum(-[’ª∞Â6]) as ’ª∞Â6
      ,sum(-[’ª∞Â7]) as ’ª∞Â7
      ,sum(-[’ª∞Â8]) as ’ª∞Â8
      ,sum(-[’ª∞Â9]) as ’ª∞Â9
      ,sum(-[’ª∞Â10]) as ’ª∞Â10
into #a
FROM [UFDLImport].[dbo].’ª∞Â≥ß…Ã ’∑¢µ«º«±Ì a  
	left join @u8.vendor b on a. ≥ß…Ã±‡¬Î = b.cVenCode
group by a.≥ß…Ã±‡¬Î,b.cVenName



SELECT '∂≈¿÷' as ≥ß…Ã±‡¬Î,'∂≈¿÷' as ≥ß…Ã
      ,sum([’ª∞Â1]) as ’ª∞Â1
      ,sum([’ª∞Â2]) as ’ª∞Â2
      ,sum([’ª∞Â3]) as ’ª∞Â3
      ,sum([’ª∞Â4]) as ’ª∞Â4
      ,sum([’ª∞Â5]) as ’ª∞Â5
      ,sum([’ª∞Â6]) as ’ª∞Â6
      ,sum([’ª∞Â7]) as ’ª∞Â7
      ,sum([’ª∞Â8]) as ’ª∞Â8
      ,sum([’ª∞Â9]) as ’ª∞Â9
      ,sum([’ª∞Â10]) as ’ª∞Â10
into #b
FROM [UFDLImport].[dbo].’ª∞Â≤÷ø‚ ’∑¢µ«º«±Ì a  


insert into #b
SELECT '∂≈¿÷','∂≈¿÷', sum([’ª∞Â1]) as ’ª∞Â1
	  ,sum([’ª∞Â2]) as ’ª∞Â2
	  ,sum([’ª∞Â3]) as ’ª∞Â3
	  ,sum([’ª∞Â4]) as ’ª∞Â4
	  ,sum([’ª∞Â5]) as ’ª∞Â5
	  ,sum([’ª∞Â6]) as ’ª∞Â6
	  ,sum([’ª∞Â7]) as ’ª∞Â7
	  ,sum([’ª∞Â8]) as ’ª∞Â8
	  ,sum([’ª∞Â9]) as ’ª∞Â9
	  ,sum([’ª∞Â10]) as ’ª∞Â10
FROM [UFDLImport].[dbo].’ª∞Â≥ß…Ã ’∑¢µ«º«±Ì a 




insert into #a
select ≥ß…Ã±‡¬Î,≥ß…Ã, sum([’ª∞Â1]) as ’ª∞Â1
	  ,sum([’ª∞Â2]) as ’ª∞Â2
	  ,sum([’ª∞Â3]) as ’ª∞Â3
	  ,sum([’ª∞Â4]) as ’ª∞Â4
	  ,sum([’ª∞Â5]) as ’ª∞Â5
	  ,sum([’ª∞Â6]) as ’ª∞Â6
	  ,sum([’ª∞Â7]) as ’ª∞Â7
	  ,sum([’ª∞Â8]) as ’ª∞Â8
	  ,sum([’ª∞Â9]) as ’ª∞Â9
	  ,sum([’ª∞Â10]) as ’ª∞Â10
from #b
group by ≥ß…Ã±‡¬Î,≥ß…Ã

select ≥ß…Ã±‡¬Î,≥ß…Ã
    ,case when isnull( a.’ª∞Â1,0) = 0 then null else a.’ª∞Â1 end as ’ª∞Â1
    ,case when isnull( a.’ª∞Â2,0) = 0 then null else a.’ª∞Â2 end  as ’ª∞Â2
    ,case when isnull( a.’ª∞Â3,0) = 0 then null else a.’ª∞Â3 end  as ’ª∞Â3
    ,case when isnull( a.’ª∞Â4,0) = 0 then null else a.’ª∞Â4 end  as ’ª∞Â4
    ,case when isnull( a.’ª∞Â5,0) = 0 then null else a.’ª∞Â5 end  as ’ª∞Â5
    ,case when isnull( a.’ª∞Â6,0) = 0 then null else a.’ª∞Â6 end  as ’ª∞Â6
    ,case when isnull( a.’ª∞Â7,0) = 0 then null else a.’ª∞Â7 end  as ’ª∞Â7
    ,case when isnull( a.’ª∞Â8,0) = 0 then null else a.’ª∞Â8 end  as ’ª∞Â8
    ,case when isnull( a.’ª∞Â9,0) = 0 then null else a.’ª∞Â9 end  as ’ª∞Â9
    ,case when isnull( a.’ª∞Â10,0) = 0 then null else a.’ª∞Â10 end  as ’ª∞Â10
from #a a where 1=1 order by ≥ß…Ã±‡¬Î

";
            if (txtVenName.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and ≥ß…Ã±‡¬Î = '" + txtVenCode.Text.Trim() + "'");
            }
            if (!chk0.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and (isnull(’ª∞Â1,0) <> 0 or isnull(’ª∞Â2,0) <> 0 or isnull(’ª∞Â3,0) <> 0 or isnull(’ª∞Â4,0) <> 0 or isnull(’ª∞Â5,0) <> 0 or isnull(’ª∞Â6,0) <> 0 or isnull(’ª∞Â7,0) <> 0 or isnull(’ª∞Â8,0)+ isnull(’ª∞Â9,0) <> 0 or isnull(’ª∞Â10,0) <> 0)");
            }
            DataTable dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            gridView1.FocusedRowHandle = iFocRow;
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


        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
                if (DialogResult.OK == fVen.ShowDialog())
                {
                    txtVenCode.Text = fVen.sVenCode;
                    txtVenName.Text = fVen.sVenName;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("º”‘ÿ≤Œ’’ ß∞‹");
            }
        }

        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("ªÒµ√π©”¶…Ã–≈œ¢ ß∞‹£°");
            }
        }

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    GetGrid();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("ªÒµ√π©”¶…Ã–≈œ¢ ß∞‹£° " + ee.Message);
            }
        }
    }
}
