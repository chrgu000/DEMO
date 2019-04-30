using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Warehouse.OMBack;

namespace Warehouse
{
    public partial class FrmProxyDoType : Form
    {
        public string FInvCode = "";
        public string DoType = "";
        public string ChangeInvCode = "";
        public string ChangeVenName = "";
        public string ChangeVenCode = "";
        

        public FrmProxyDoType(string fInvCode)
        {

            InitializeComponent();
            FInvCode = fInvCode;
        }

        private void GetBOMInvs()
        {

            string sql = @"
                     set nocount on 
                     if exists ( select *
                                 from   sysobjects
                                 where  name = N'UFTmpTablea33211f4' ) 
                        drop table [dbo].[UFTmpTablea33211f4]

                     --exec Usp_BO_ExpandByParent '{0}', '{0}', 0, 99999999, '2000-01-01', '2099-12-31', '{1}', 1,
                     --   0, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 0, 3, 0, 0, 0, 1, '',
                     -- 'UFTmpTablea33211f4'

                    exec  Usp_BO_ExpandByParent
                     ' and  1=1   And ((c.InvCode >= N''{0}'') And (c.InvCode <= N''{0}''))', 
                     '{1}',1, 0,  0, 3, 0, 0,  0,1, ''   ,'UFTmpTablea33211f4'


                                            
                     select * into #SubInvs
                     from   UFTmpTablea33211f4  where [母件编码]='{0}' 
  
                     select cInvCode ,
                            max(cVenCode) as VenCode ,
                            count(cInvCode) as VenCount
                     into   #InvVen
                     from   ( select    d.cInvCode ,
                                        p.cVenCode
                              from      PO_Pomain p
                                        left join dbo.PO_Podetails d on p.POID = d.POID
                              where     d.cInvCode in ( select  子件编码
                                                        from    #SubInvs )
                              group by  d.cInvCode ,
                                        p.cVenCode

                            union 
                            select  d.cInvCode,
                                    v.cVenCode 
                            from    dbo.OM_MOMain P
                                    left join dbo.OM_MODetails D on P.MOID = D.MOID
                                    left join dbo.Vendor V on p.cVenCode = v.cVenCode
                            where   d.cInvCode in ( select  子件编码
                                                        from    #SubInvs )
                            group by d.cInvCode,v.cVenCode 

                            ) s1
                     group by cInvCode
                     having count(cInvCode) = 1
                
                     select  V.*,VD.cVenCode as VenCode ,VD.cVenName as VenName 
                        from #SubInvs V
                        left join #InvVen VE on V.子件编码 = VE.cInvCode
                        left join dbo.Vendor VD on VE.VenCode = vd.cVenCode 

                     drop table #SubInvs
                     drop table UFTmpTablea33211f4
                     drop table  #InvVen
                    
                    ";
            try
            {
                sql = string.Format(sql, FInvCode, DateTime.Now.ToString("yyyy-MM-dd"));
                DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
                grdDetail.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("无法获得子件信息\n" + error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!rdbDoBack.Checked && !rdbChangeToBack.Checked)
            {
                MessageBox.Show("请选择一个处理方式");
                return;

            }
            if (rdbChangeToBack.Checked && grvDetail.SelectedRowsCount == 0)
            {
                MessageBox.Show("形态转换请选择一个转换后的物料");
                return;
            }
            if (rdbDoBack.Checked)
                DoType = "直接退货";
            if (rdbChangeToBack.Checked)
                DoType = "形态转换退货";
            if (rdbChangeToBack.Checked)
            {
                ChangeInvCode = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colInvCode).ToString();
                ChangeVenCode = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colVenCode) == null ? "" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colVenCode).ToString();
                ChangeVenName  = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colVenName ) == null ? "" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colVenName ).ToString();

            }
            DialogResult = DialogResult.OK;
        }

        private void btnCanle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnLoadBom_Click(object sender, EventArgs e)
        {
            GetBOMInvs();
        }

        private void rdbChangeToBack_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbChangeToBack.Checked)
            {
                GetBOMInvs();
            }
        }

        private void rdbDoBack_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDoBack.Checked)
            {
                grdDetail.DataSource = null;
            }
        }

        private void grvDetail_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOK_Click(null, null);
            }
            catch { };
        }




        private void rpiVenSel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string invCode = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colInvCode).ToString();
            frmVenSel fm = new frmVenSel(invCode);

            if (fm.ShowDialog() != DialogResult.OK)
                return;

            grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenCode, fm.VenCode);
            grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenName, fm.VenName);
        }

        private void FrmProxyDoType_Load(object sender, EventArgs e)
        {
            if (DoType == "直接退货")
            {
                rdbDoBack.Checked = true;
            }

            if (DoType == "形态转换退货")
            {
                rdbChangeToBack.Checked = true;
            }
        }
    }
}
