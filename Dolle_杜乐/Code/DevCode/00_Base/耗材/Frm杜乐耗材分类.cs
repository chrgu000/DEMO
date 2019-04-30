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
    public partial class Frm杜乐耗材分类 : FrameBaseFunction.Frm列表窗体模板
    {  
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm杜乐耗材分类()
        {
            InitializeComponent();
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
                   
                    case "del":
                        btnDel();
                        break;
                    case "save":
                        btnSave();
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

        private void btnSave()
        {
            string sSQL = "";
            DataTable dtTemp = new DataTable();
            string sCode = txt分类编码.Text.Trim();
            if (sCode.Length == 2 || sCode.Length == 4 || sCode.Length == 6 || sCode.Length == 8)
            {
                string sUpCode = sCode.Substring(0, sCode.Length - 2);
                if (sCode.Length == 2)
                {
                    sUpCode = "0";
                }
                else
                {
                    sSQL = "select * from UFDLImport..InvcodeClassHC where cInvCCode = '" + sUpCode + "'";
                    dtTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        txt分类编码.Focus();
                        throw new Exception("上级编码不存在");
                    }
                }

                sSQL = "select count(1) from UFDLImport..InvcodeClassHC where cInvCCode = '" + sCode + "'";
                 dtTemp = clsSQLCommond.ExecQuery(sSQL);
                long iCou = ReturnObjectToLong(dtTemp.Rows[0][0]);
                if (iCou == 0)
                {
                    sSQL = "select count(1) from UFDLImport..InvcodeClassHC where cInvCName = '" + txt分类名称.Text.Trim() + "'";
                    dtTemp = clsSQLCommond.ExecQuery(sSQL);
                    iCou = ReturnObjectToLong(dtTemp.Rows[0][0]);
                    if (iCou > 0)
                    {
                        throw new Exception("名称不能重复");
                    }

                    sSQL = "insert into UFDLImport..InvcodeClassHC(cInvCCode, cInvCName, cInvCCodeUp)" +
                        "values('" + sCode + "','" + txt分类名称.Text.Trim() + "','" + sUpCode + "')";
                }
                else
                {
                    sSQL = "update UFDLImport..InvcodeClassHC set cInvCName = '" + txt分类名称.Text.Trim() + "', cInvCCodeUp = '" + sUpCode + "' where cInvCCode = '" + sCode + "'";
                        
                }
                iCou = clsSQLCommond.ExecSql(sSQL);
                if (iCou == 1)
                {
                    MessageBox.Show("保存成功");
                    btnSel();
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            else
            {
                txt分类编码.Focus();
                throw new Exception("分类编码长度不正确");
            }
        }

        private void btnDel()
        {
            string sCCode = txt分类编码.Text.Trim();
            if (sCCode == "")
                throw new Exception("编码不能为空");

            string sSQL = "select count(1) from UFDLImport..InventoryHC where cInvCCode = '" + sCCode + "'";
            DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
            long iCou = ReturnObjectToLong(dtTemp.Rows[0][0]);
            if (iCou > 0)
            {
                throw new Exception("编码已经使用不能删除");
            }
            sSQL = "select count(1) from UFDLImport..InvcodeClassHC where cInvCCodeUp = '" + sCCode + "'";
            dtTemp = clsSQLCommond.ExecQuery(sSQL);
            iCou = ReturnObjectToLong(dtTemp.Rows[0][0]);
            if (iCou > 0)
            {
                throw new Exception("存在下级编码不能删除");
            }

            sSQL = "delete UFDLImport..InvcodeClassHC where cInvCCode = '" + sCCode + "'";
            iCou = clsSQLCommond.ExecSql(sSQL);

            if (iCou > 0)
            {
                MessageBox.Show("删除成功");
                btnSel();
            }
            else
            {

                MessageBox.Show("删除失败");
            }
        }

        private void btnSel()
        {
            txt分类编码.Enabled = true;
            txt分类名称.Enabled = true;
            txt分类编码.ReadOnly = false;
            txt分类名称.ReadOnly = false;
            SetTree();
            treView.ExpandAll();
        }

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


        DataTable dt = new DataTable();
        private void SetTree()
        {
            try
            {
                treView.Nodes.Clear();

                string sSQL = "SELECT * from UFDLImport..InvcodeClassHC order by cInvCCode";
                dt = clsSQLCommond.ExecQuery(sSQL);

                InitTree(treView.Nodes, "0");
      
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 创建功能树
        /// </summary>
        /// <param name="Nds"></param>
        /// <param name="parentId"></param>
        private void InitTree(TreeNodeCollection Nds, string parentId)
        {
            try
            {
                DataView dv = new DataView();
                TreeNode tmpNd;
                dv.Table = dt;
                dv.RowFilter = "cInvCCodeUp='" + parentId + "'";
                foreach (DataRowView drv in dv)
                {
                    tmpNd = new TreeNode();
                    tmpNd.Name = drv["cInvCCode"].ToString().Trim();
                    tmpNd.Text = drv["cInvCName"].ToString().Trim();
                    tmpNd.Tag = drv["cInvCCodeUp"].ToString().Trim();
                    Nds.Add(tmpNd);
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
            try
            {
                if (e.Node.Name.Trim() != null)
                {
                    txt分类编码.Text = e.Node.Name.Trim();
                    txt分类名称.Text = e.Node.Text.Trim();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}