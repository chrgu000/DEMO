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
    public partial class Frmջ����� : FrameBaseFunction.Frm�б���ģ��
    {
        public Frmջ�����()
        {
            InitializeComponent();
        }



        #region ��ť����
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
                throw new Exception(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message);
            }
        }

     


        #region ��ťģ��

        /// <summary>
        /// ���
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

       
        #endregion

        /// <summary>
        /// ��ѯ
        /// </summary>
        private void btnSel()
        {
            GetGrid();
        }
      
   
        #endregion

        private void FFrmջ�����_Load(object sender, EventArgs e)
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
                MessageBox.Show("���ش���ʧ��\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = "select * from UFDLImport.dbo._Code where vchrType = '1' order by vchrInfo";
            DataTable dtջ�� = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                string sCol = gridView1.Columns[i].FieldName;
                if (sCol.Length > 2 && sCol.Substring(0, 2) == "ջ��")
                {
                    DataRow[] dr = dtջ��.Select("vchrInfo = '" + sCol.Trim() + "'");
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


SELECT a.���̱��� as ���̱���,b.cVenName as ����
      ,sum(-[ջ��1]) as ջ��1
      ,sum(-[ջ��2]) as ջ��2
      ,sum(-[ջ��3]) as ջ��3
      ,sum(-[ջ��4]) as ջ��4
      ,sum(-[ջ��5]) as ջ��5
      ,sum(-[ջ��6]) as ջ��6
      ,sum(-[ջ��7]) as ջ��7
      ,sum(-[ջ��8]) as ջ��8
      ,sum(-[ջ��9]) as ջ��9
      ,sum(-[ջ��10]) as ջ��10
into #a
FROM [UFDLImport].[dbo].ջ�峧���շ��ǼǱ� a  
	left join @u8.vendor b on a. ���̱��� = b.cVenCode
group by a.���̱���,b.cVenName



SELECT '����' as ���̱���,'����' as ����
      ,sum([ջ��1]) as ջ��1
      ,sum([ջ��2]) as ջ��2
      ,sum([ջ��3]) as ջ��3
      ,sum([ջ��4]) as ջ��4
      ,sum([ջ��5]) as ջ��5
      ,sum([ջ��6]) as ջ��6
      ,sum([ջ��7]) as ջ��7
      ,sum([ջ��8]) as ջ��8
      ,sum([ջ��9]) as ջ��9
      ,sum([ջ��10]) as ջ��10
into #b
FROM [UFDLImport].[dbo].ջ��ֿ��շ��ǼǱ� a  


insert into #b
SELECT '����','����', sum([ջ��1]) as ջ��1
	  ,sum([ջ��2]) as ջ��2
	  ,sum([ջ��3]) as ջ��3
	  ,sum([ջ��4]) as ջ��4
	  ,sum([ջ��5]) as ջ��5
	  ,sum([ջ��6]) as ջ��6
	  ,sum([ջ��7]) as ջ��7
	  ,sum([ջ��8]) as ջ��8
	  ,sum([ջ��9]) as ջ��9
	  ,sum([ջ��10]) as ջ��10
FROM [UFDLImport].[dbo].ջ�峧���շ��ǼǱ� a 




insert into #a
select ���̱���,����, sum([ջ��1]) as ջ��1
	  ,sum([ջ��2]) as ջ��2
	  ,sum([ջ��3]) as ջ��3
	  ,sum([ջ��4]) as ջ��4
	  ,sum([ջ��5]) as ջ��5
	  ,sum([ջ��6]) as ջ��6
	  ,sum([ջ��7]) as ջ��7
	  ,sum([ջ��8]) as ջ��8
	  ,sum([ջ��9]) as ջ��9
	  ,sum([ջ��10]) as ջ��10
from #b
group by ���̱���,����

select ���̱���,����
    ,case when isnull( a.ջ��1,0) = 0 then null else a.ջ��1 end as ջ��1
    ,case when isnull( a.ջ��2,0) = 0 then null else a.ջ��2 end  as ջ��2
    ,case when isnull( a.ջ��3,0) = 0 then null else a.ջ��3 end  as ջ��3
    ,case when isnull( a.ջ��4,0) = 0 then null else a.ջ��4 end  as ջ��4
    ,case when isnull( a.ջ��5,0) = 0 then null else a.ջ��5 end  as ջ��5
    ,case when isnull( a.ջ��6,0) = 0 then null else a.ջ��6 end  as ջ��6
    ,case when isnull( a.ջ��7,0) = 0 then null else a.ջ��7 end  as ջ��7
    ,case when isnull( a.ջ��8,0) = 0 then null else a.ջ��8 end  as ջ��8
    ,case when isnull( a.ջ��9,0) = 0 then null else a.ջ��9 end  as ջ��9
    ,case when isnull( a.ջ��10,0) = 0 then null else a.ջ��10 end  as ջ��10
from #a a where 1=1 order by ���̱���

";
            if (txtVenName.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and ���̱��� = '" + txtVenCode.Text.Trim() + "'");
            }
            if (!chk0.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and (isnull(ջ��1,0) <> 0 or isnull(ջ��2,0) <> 0 or isnull(ջ��3,0) <> 0 or isnull(ջ��4,0) <> 0 or isnull(ջ��5,0) <> 0 or isnull(ջ��6,0) <> 0 or isnull(ջ��7,0) <> 0 or isnull(ջ��8,0)+ isnull(ջ��9,0) <> 0 or isnull(ջ��10,0) <> 0)");
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
                MessageBox.Show("���ز���ʧ��");
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
                throw new Exception("��ù�Ӧ����Ϣʧ�ܣ�");
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
                MessageBox.Show("��ù�Ӧ����Ϣʧ�ܣ� " + ee.Message);
            }
        }
    }
}
