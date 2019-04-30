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
    public partial class FrmFromBtnInfo : FrameBaseFunction.FrmBaseInfo
    {
        public FrmFromBtnInfo()
        {
            InitializeComponent();
        }

        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();
        private new string sState = "";

        private void FrmFromBtnInfo_Load(object sender, EventArgs e)
        {
            GetTreGrid();
            GetBtnGrid();
            SetBtnEnable(true);
            gridView1.OptionsBehavior.Editable = false;
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
                    case "add":
                        btnAdd();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "undo":
                        btnUnDo();
                        break;
                    default:
                        break;
                }

                if (sBtnName.ToLower() == "add" || sBtnName.ToLower() == "edit")
                {
                    SetBtnEnable(false);
                }
                else
                {
                    SetBtnEnable(true);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnDo()
        {
            SetBtnEnable(true);
            sState = "";
            txtfchrFrmNameID.Properties.ReadOnly = false;
            gridView1.OptionsBehavior.Editable = false;
        }

        private void btnDel()
        {
            sState = "del";
            string sSQL = "";
            ArrayList aList = new ArrayList();

            if (txtfchrFrmNameID.Text.Trim() == string.Empty)
            {
                throw new Exception ("窗体编号不能为空！");
            }
                
            sSQL = "delete dbo._FormBtnInfo where fchrFrmNameID='" + txtfchrFrmNameID.Text.ToString().Trim() + "'";
            aList.Add(sSQL);

            sSQL = "delete dbo._Form where fchrFrmNameID = '" + txtfchrFrmNameID.Text.ToString().Trim() + "'";
            aList.Add(sSQL);

            clsSQL.ExecSqlTran(aList);
          
        }

        private void btnEdit()
        {
            sState = "edit";
            txtfchrFrmNameID.Properties.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = true;
        }

        private void btnAdd()
        {
            sState = "add";
            GetBtnGrid();
            gridView1.OptionsBehavior.Editable = true;
            txtfchrFrmNameID.Text = "";
            txtfchrFrmText.Text = "";
            txtfchrFrmUpName.Visible = true;
            txtfchrFrmUpNameText.Visible = true;
            txtfchrFrmNameID.Properties.ReadOnly = false;
            label4.Visible = true;
            label6.Visible = true;
        }

        private void GetBtnGrid2(string sFrmNameID)
        {
            string sSQL = "select distinct f.vchrBtnID,f.vchrBtnText,f.intOrder,cast(case when isnull(f2.fchrFrmNameID,'0')='0' then 0 else 1 end as bit) as bChoose ,cast(isnull(f2.bEnable,0) as int) as bEnable,cast(isnull(f2.bBtnState,1) as bit) as bBtnState " +
                            "from dbo._FormBtnInfo f left join _FormBtnInfo f2 on f.vchrBtnID = f2.vchrBtnID and f2.fchrFrmNameID = '" + sFrmNameID + "' " +
                            "order by f.intOrder,f.vchrBtnID,f.vchrBtnText";
            DataTable dt2 = clsSQL.ExecQuery(sSQL);
            gridControl1.DataSource = dt2;
        }

        private void btnSave()
        {
            ChkTxtValue();
            ArrayList aList = new ArrayList();
            string sSQL = "";
            gridView1.FocusedRowHandle -= 1;
            DataTable dt3 = (DataTable)gridControl1.DataSource;

            if (sState == "add")
            {
                sSQL = "insert into dbo._Form(fchrFrmNameID,fchrFrmText,fchrNameSpace,fchrFrmUpName,fbitNoUse,fIntOrderID)values('" + txtfchrFrmNameID.Text.Trim() + "','" + txtfchrFrmText.Text.Trim() + "','" + txtfchrNameSpace.Text.Trim() + "','" + txtfchrFrmUpName.Text.Trim() + "',0,'" + txtfIntOrderID.Text.Trim() + "')";
                aList.Add(sSQL);

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i]["bChoose"].ToString().Trim().ToLower() == "true")
                    {
                        sSQL = "insert into dbo._FormBtnInfo(fchrFrmNameID,vchrBtnID,vchrBtnText,bEnable,bBtnState,intOrder)values" +
                            "('" + txtfchrFrmNameID.Text.Trim() + "','" + dt3.Rows[i]["vchrBtnID"].ToString().Trim() + "','" + dt3.Rows[i]["vchrBtnText"].ToString().Trim() + "'," + dt3.Rows[i]["bEnable"].ToString().Trim() + ",0,'" + dt3.Rows[i]["intOrder"].ToString().Trim() + "')";
                        aList.Add(sSQL);
                    }
                }
                clsSQL.ExecSqlTran(aList);


                treView.Nodes.Clear();
                GetTreGrid();
                GetBtnGrid();
            }
            if (sState == "edit")
            {
                sSQL = "update _Form set fchrFrmText='" + txtfchrFrmText.Text.ToString().Trim() + "',fchrNameSpace='" + txtfchrNameSpace.Text.ToString().Trim() + "',fIntOrderID='" + txtfIntOrderID.Text.ToString().Trim() + "' where fchrFrmNameID='" + txtfchrFrmNameID.Text.ToString().Trim() + "'";
                aList.Add(sSQL);

                sSQL = "delete dbo._FormBtnInfo where fchrFrmNameID='" + txtfchrFrmNameID.Text.ToString().Trim() + "'";
                aList.Add(sSQL); for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i]["bChoose"].ToString().Trim().ToLower() == "true")
                    {
                       
                        sSQL = "insert into dbo._FormBtnInfo(fchrFrmNameID,vchrBtnID,vchrBtnText,bEnable,bBtnState,intOrder)values" +
                            "('" + txtfchrFrmNameID.Text.Trim() + "','" + dt3.Rows[i]["vchrBtnID"].ToString().Trim() + "','" + dt3.Rows[i]["vchrBtnText"].ToString().Trim() + "'," + dt3.Rows[i]["bEnable"].ToString().Trim() + ",0,'" + dt3.Rows[i]["intOrder"].ToString().Trim() + "')";
                        aList.Add(sSQL);
                    }
                }
                clsSQL.ExecSqlTran(aList);
            }

            sState = "";
            gridView1.OptionsBehavior.Editable = false;

            MessageBox.Show("菜单保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 确定所有文本框必须有值
        /// </summary>
        private void ChkTxtValue()
        {
            if (txtfchrFrmNameID.Text.Trim() == string.Empty)
            {
                txtfchrFrmNameID.Focus();
                throw new Exception("窗体名称不能为空！");
            }
            if (txtfchrFrmText.Text.Trim() == string.Empty)
            {
                txtfchrFrmText.Focus();
                throw new Exception("窗体标题不能为空！");
            }

            if (sState == "add")
            {
                if (txtfchrFrmUpName.Text.Trim() == string.Empty)
                {
                    txtfchrFrmUpName.Focus();
                    throw new Exception("上级菜单名称不能为空！");
                }
            }
            if (txtfchrNameSpace.Text.Trim() == string.Empty)
            {
                txtfchrNameSpace.Focus();
                throw new Exception("窗体命名空间不能为空！");
            }
            if (txtfIntOrderID.Text.Trim() == string.Empty)
            {
                txtfIntOrderID.Focus();
                throw new Exception("菜单排序不能为空！");
            }
        }

        DataTable dt;
        private void GetTreGrid()
        {
            string sSQL = "SELECT TOP 100 PERCENT * FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0)  ORDER BY fIntOrderID";
            dt = clsSQL.ExecQuery(sSQL);

            InitTree(treView.Nodes, "0");

        }

        private void GetBtnGrid()
        {
            string sSQL = "select distinct cast(0 as bit) as bChoose,vchrBtnID,vchrBtnText,intOrder,bEnable from dbo._FormBtnInfo order by intOrder,vchrBtnID,vchrBtnText";
            DataTable dt2 = clsSQL.ExecQuery(sSQL);
            gridControl1.DataSource = dt2;
        }

        private void InitTree(TreeNodeCollection Nds, string parentId)
        {
            try
            {
                DataView dv = new DataView();
                TreeNode tmpNd;
                string intId;
                dv.Table = dt;
                dv.RowFilter = "fchrFrmUpName='" + parentId + "'";
                foreach (DataRowView drv in dv)
                {
                    tmpNd = new TreeNode();
                    tmpNd.Name = drv["fchrFrmNameID"].ToString().Trim();
                    tmpNd.Text = drv["fchrFrmText"].ToString().Trim();
                    tmpNd.Tag = drv["fchrFrmNameID"].ToString().Trim();
                    Nds.Add(tmpNd);
                    intId = drv["fchrFrmUpName"].ToString().Trim();
                    InitTree(tmpNd.Nodes, tmpNd.Name);
                }
            }
            catch
            {
                throw new Exception("创建功能树失败！");
            }
        }

        private void treView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sState == "add")
                {
                    if (dt.Rows[i]["fchrFrmNameID"].ToString().Trim().ToLower() == e.Node.Name.ToString().ToLower().Trim())
                    {
                        txtfchrFrmUpName.Text = dt.Rows[i]["fchrFrmNameID"].ToString().Trim();
                        txtfchrFrmUpNameText.Text = dt.Rows[i]["fchrFrmText"].ToString().Trim();
                        txtfchrNameSpace.Text = dt.Rows[i]["fchrNameSpace"].ToString().Trim();
                        txtfIntOrderID.Text = dt.Rows[i]["fIntOrderID"].ToString().Trim();
                        label4.Visible = true;
                        label6.Visible = true;
                        txtfchrFrmUpName.Visible = true;
                        txtfchrFrmUpNameText.Visible = true;
                        break;
                    }
                }
                if (sState == "edit" || sState == "del")
                {
                    if (dt.Rows[i]["fchrFrmNameID"].ToString().Trim().ToLower() == e.Node.Name.ToString().ToLower().Trim())
                    {
                        txtfchrFrmNameID.Text = dt.Rows[i]["fchrFrmNameID"].ToString().Trim();
                        txtfchrFrmText.Text = dt.Rows[i]["fchrFrmText"].ToString().Trim();
                        txtfchrNameSpace.Text = dt.Rows[i]["fchrNameSpace"].ToString().Trim();
                        txtfIntOrderID.Text = dt.Rows[i]["fIntOrderID"].ToString().Trim();
                        label4.Visible = false;
                        label6.Visible = false;
                        txtfchrFrmUpName.Visible = false;
                        txtfchrFrmUpNameText.Visible = false;

                        GetBtnGrid2(dt.Rows[i]["fchrFrmNameID"].ToString().Trim());
                        break;
                    }
                }
            }
        }

        private int GetFocRowID()
        {
            int iRow = 0;
            if (gridView1.RowCount > 1)
                iRow = gridView1.FocusedRowHandle;

            return iRow;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }
    }
}