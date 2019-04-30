using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using DevExpress.Web.ASPxGridView;

    /// <summary>
    /// TableHelp 的摘要说明
    /// </summary>
public class ASPxGridViewShow
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    public ASPxGridViewShow()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    #region 生成标题
    public void GetTitle(ASPxGridView ASPxGridView1, string tablename)
    {
        PublicClass pc = new PublicClass();
        string ctext = pc.GetLanguageColumn();

        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('" + tablename + "')";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        for (int j = 0; j < ASPxGridView1.Columns.Count; j++)
        {
            if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataTextColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataTextColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataTextColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                DataRow[] dw = dt.Select("COLUMN_NAME='" + field + "'");
                if (dw.Length > 0 && dw[0][ctext].ToString() != "")
                {
                    string caption = dw[0][ctext].ToString();
                    datacolumn.Caption = caption;
                    if (dw[0]["VisibleIndex"].ToString() != "")
                    {
                        datacolumn.VisibleIndex = int.Parse(dw[0]["VisibleIndex"].ToString());
                    }
                    //Label label = (Label).FindControl("Label" + field);
                    //if (label != null)
                    //{
                    //    label.Text = caption;
                    //}
                }
                else
                {
                    datacolumn.Visible = false;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                DataRow[] dw = dt.Select("COLUMN_NAME='" + field + "'");
                if (dw.Length > 0 && dw[0][ctext].ToString() != "")
                {
                    string caption = dw[0][ctext].ToString();
                    datacolumn.Caption = caption;
                    if (dw[0]["VisibleIndex"].ToString() != "")
                    {
                        datacolumn.VisibleIndex = int.Parse(dw[0]["VisibleIndex"].ToString());
                    }
                    //Label label = (Label)form1.FindControl("Label" + field);
                    //if (label != null)
                    //{
                    //    label.Text = caption;
                    //}
                }
                else
                {
                    datacolumn.Visible = false;
                }
            }
            else if(ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                DataRow[] dw = dt.Select("COLUMN_NAME='" + field + "'");
                if (dw.Length > 0 && dw[0][ctext].ToString() != "")
                {
                    string caption = dw[0][ctext].ToString();
                    datacolumn.Caption = caption;
                    if (dw[0]["VisibleIndex"].ToString() != "")
                    {
                        datacolumn.VisibleIndex = int.Parse(dw[0]["VisibleIndex"].ToString());
                    }
                    //Label label = (Label)form1.FindControl("Label" + field);
                    //if (label != null)
                    //{
                    //    label.Text = caption;
                    //}
                }
                else
                {
                    datacolumn.Visible = false;
                }
            }
        }
    }
    #endregion

    #region 得到列的相应标题
    public string GetFieldName(ASPxGridView ASPxGridView1, string fieldID)
    {
        for (int j = 1; j < ASPxGridView1.Columns.Count; j++)
        {
            if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataTextColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataTextColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataTextColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                if (field == fieldID)
                {
                    return datacolumn.Caption;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                if (field == fieldID)
                {
                    return datacolumn.Caption;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                if (field == fieldID)
                {
                    return datacolumn.Caption;
                }
            }
        }
        return "";
    }
    #endregion

    public bool ParameterIsNull(object e)
    {
        if (e == null || e.ToString().Trim() == "" || e.ToString().Trim() == "0001/1/1 0:00:00")
        {
            return true;
        }
        return false;
    }
}