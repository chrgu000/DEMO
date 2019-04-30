using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FrameBaseFunction
{
    public partial class FrmUserUFAccInfo : FrameBaseFunction.Frm列表窗体模板
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();

        public FrmUserUFAccInfo()
        {
            InitializeComponent();
        } 

      

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
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

        private void btnSave()
        {
            int iRow = 0;
            if (gridView2.RowCount < 1)
                iRow = 0;
            else
                iRow = gridView2.FocusedRowHandle;

            string sAccID = gridView2.GetRowCellValue(iRow, gridColumn3).ToString().Trim();

            ArrayList aList = new ArrayList();
            string sSQL = "delete dbo._UserUFAcc where vchrUFAcc = '" + sAccID + "'";
            aList.Add(sSQL);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColumn1).ToString().Trim() == "√")
                {
                    sSQL = "insert into _UserUFAcc(vchrUserID,vchrUFAcc)values('" + gridView1.GetRowCellValue(i, colvchrUid).ToString().Trim() + "','" + sAccID + "')";
                    aList.Add(sSQL);
                }
            }

            clsSQL.ExecSqlTran(aList);
            GetUserInfo(sAccID);
        }

        private void FrmUserUFAccInfo_Load(object sender, EventArgs e)
        {

            try
            {
                GetAccInfo();
                GetUserInfo("");
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败！\n    " + ee.Message);
            }
        }

        private void GetAccInfo()
        {
            string sYear = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy");
            string sSQL = "SELECT DISTINCT A.cAcc_Id,'[' + A.cAcc_Id + ']' + A.cAcc_Name as vchrText,'UFDATA_' +A.cAcc_Id + '_' + '" + sYear + "' as sUFDatabase " +
                                "FROM UFSystem.dbo.UA_Account A,UFSystem.dbo.UA_period P   " +
                                "WHERE A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL)  " +
                                "ORDER BY A.cAcc_Id,vchrText";
            DataTable dt = clsSQL.ExecQuery(sSQL);
            gridControl2.DataSource = dt;
        }



        private void GetUserInfo(string sAccID)
        {
            string sSQL = "select (case isnull(vchrUserID,'') when '' then '' else '√' end) as bChoose,vchrUid,vchrName, vchrUserID,vchrUFAcc from dbo._UserInfo  left join dbo._UserUFAcc on _UserUFAcc.vchrUserID = _UserInfo.vchrUid and _UserUFAcc.vchrUFAcc = '" + sAccID + "' where (vchrUid <>'admin' and vchrUid <>'system') order by vchrUid";
            DataTable dt = clsSQL.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView2.RowCount < 1)
                    iRow = 0;
                else
                    iRow = gridView2.FocusedRowHandle;

                string sAccID = gridView2.GetRowCellValue(iRow, gridColumn3).ToString().Trim();
                label1.Text = "帐套：" + gridView2.GetRowCellValue(iRow, gridColumn2).ToString().Trim();
                GetUserInfo(sAccID);

            }
            catch
            { }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            { 
                int iRow = 0;
                if (gridView1.RowCount < 1)
                    iRow = 0;
                else
                    iRow = gridView1.FocusedRowHandle;

                if (gridView1.GetRowCellValue(iRow, gridColumn1).ToString().Trim() == "")
                    gridView1.SetRowCellValue(iRow, gridColumn1, "√");
                else
                    gridView1.SetRowCellValue(iRow, gridColumn1, "");
            }

            catch { }
        }
    }
}