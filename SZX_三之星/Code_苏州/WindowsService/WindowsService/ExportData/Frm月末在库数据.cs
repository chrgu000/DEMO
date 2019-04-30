using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace U8Export
{
    public partial class Frm月末在库数据 : Form
    {
        public Frm月末在库数据()
        {
            InitializeComponent();
        }

        string sFilePath = "";
        string sConn = "";
        public void ExportData(DateTime dtmStart,DateTime dtmEnd,string sPath,string conn)
        {
            try
            {
                sFilePath = sPath;
                sConn = conn;
                dateEdit1.DateTime = dtmStart;
                dateEdit2.DateTime = dtmEnd;

                btnSEL_Click(null, null);
                btnExport_Click(null, null);
            }
            catch (Exception ee)
            {
            
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                DataTable dtDetails = ((DataTable)gridControl1.DataSource).Copy();
                for (int i = dtDetails.Rows.Count - 1; i >= 0; i--)
                {
                    if (!BaseFunction.ReturnBool(dtDetails.Rows[i]["选择"]))
                    {
                        dtDetails.Rows.RemoveAt(i);
                    }
                }

                bool bPeriod = false;   //判断上个月仓库是否结账
                string sSQL = "select bflag_ST  from gl_mend where  iYPeriod = '" + dateEdit1.DateTime.AddMonths(-1).ToString("yyyyMM") + "'";
                DataTable dtPeriod = DbHelperSQL.Query(sSQL);
                if (dtPeriod != null && dtPeriod.Rows.Count > 0)
                {
                    if (BaseFunction.ReturnBool(dtPeriod.Rows[0]["bflag_ST"]))
                    {
                        bPeriod = true;
                    }
                    else
                    {
                        bPeriod = false;
                    }
                }

                string sPath = sFilePath + "bilis_Monthly_Stock_Master.csv";

                System.IO.FileStream fs = new FileStream(sPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
                //Tabel header
                bool bFirst = true;
                for (int i = 0; i < dtDetails.Columns.Count; i++)
                {
                    if (dtDetails.Columns[i].ColumnName == "选择")
                        continue;

                    if (bFirst)
                    {
                        string sCol = "\"" + sColText(dtDetails.Columns[i].ColumnName.ToString().Trim()) + "\"";
                        sw.Write(sCol);
                        bFirst = false;
                    }
                    else
                    {
                        string sCol = ",\"" + sColText(dtDetails.Columns[i].ColumnName.ToString().Trim()) + "\"";
                        sw.Write(sCol);
                    }
                }
                sw.WriteLine("");
                //Table body
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    for (int j = 0; j < dtDetails.Columns.Count; j++)
                    {
                        if (dtDetails.Columns[j].ColumnName == "选择")
                            continue;

                        if (j != dtDetails.Columns.Count - 1)
                        {
                            if (dtDetails.Columns[j].ColumnName == "在库年月")
                            {
                                string s = BaseFunction.ReturnDate(dtDetails.Rows[i][j].ToString().Trim()).ToString("yyyyMM");
                                sw.Write("\"" + s + "\"");
                            }
                            else
                            {
                                sw.Write("\"" + dtDetails.Rows[i][j].ToString() + "\"");
                            }
                        }
                        else
                        {
                            if (dtDetails.Columns[j].ColumnName == "在库年月")
                            {
                                string s = BaseFunction.ReturnDate(dtDetails.Rows[i][j].ToString().Trim()).ToString("yyyyMM");
                                sw.Write("\"" + s + "\"");
                            }
                            else
                            {
                                sw.Write("\"" + dtDetails.Rows[i][j].ToString() + "\"");
                            }
                        }
                        if (j != dtDetails.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine("");
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception ee)
            {

            }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void GetGrid()
        {
            chkAll.Checked = false;
            string sSQL = @"

DECLARE @dDate1 DATETIME
DECLARE @dDate2 DATETIME

SET @dDate1 = 'aaaaaa'
SET @dDate2 = 'bbbbbb'

if object_id(N'TH_Curr_Qty',N'U') is not null 
	DROP TABLE TH_Curr_Qty

IF object_id('tempdb..#rdrecord01') IS NOT NULL 
	DROP TABLE #rdrecord01	
IF object_id('tempdb..#rdrecord09') IS NOT NULL 
	DROP TABLE #rdrecord09
IF object_id('tempdb..#rdrecord10') IS NOT NULL 
	DROP TABLE #rdrecord10
IF object_id('tempdb..#rdrecord11') IS NOT NULL 
	DROP TABLE #rdrecord11
IF object_id('tempdb..#rdrecord32') IS NOT NULL 
	DROP TABLE #rdrecord32
IF object_id('tempdb..#rdrecord34') IS NOT NULL 
	DROP TABLE #rdrecord34


 select id into #rdrecord01 from rdrecord01 RdRecord where 1=1 and  ((RdRecord.dDate < '2015-01-01' And IsNull(RdRecord.bIsSTQc,0) = 1)
 Or (RdRecord.dDate >= '2015-01-01'
 And IsNull(RdRecord.bPUFirst,0) = 0
 And IsNull(RdRecord.bIAFirst,0) = 0
 And IsNull(RdRecord.bOMFirst,0) = 0
 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11))
)
) AND  dDate <= @dDate2 AND  dDate >= '2016-01-01'

 select id into #rdrecord08 from rdrecord08 RdRecord where 1=1 and  ((RdRecord.dDate < '2015-01-01' And IsNull(RdRecord.bIsSTQc,0) = 1)
 Or (RdRecord.dDate >= '2015-01-01'
 And IsNull(RdRecord.bPUFirst,0) = 0
 And IsNull(RdRecord.bIAFirst,0) = 0
 And IsNull(RdRecord.bOMFirst,0) = 0
 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11))
)
) AND  dDate <= @dDate2 AND  dDate >= '2016-01-01'

 select id into #rdrecord09 from rdrecord09 RdRecord where 1=1 and  ((RdRecord.dDate < '2015-01-01' And IsNull(RdRecord.bIsSTQc,0) = 1)
 Or (RdRecord.dDate >= '2015-01-01'
 And IsNull(RdRecord.bPUFirst,0) = 0
 And IsNull(RdRecord.bIAFirst,0) = 0
 And IsNull(RdRecord.bOMFirst,0) = 0
 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11))
)
) AND   dDate <= @dDate2 AND  dDate >= '2016-01-01'


 select id into #rdrecord10 from rdrecord10 RdRecord where 1=1 and  ((RdRecord.dDate < '2015-01-01' And IsNull(RdRecord.bIsSTQc,0) = 1)
 Or (RdRecord.dDate >= '2015-01-01'
 And IsNull(RdRecord.bPUFirst,0) = 0
 And IsNull(RdRecord.bIAFirst,0) = 0
 And IsNull(RdRecord.bOMFirst,0) = 0
 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11))
)
) AND   dDate <= @dDate2 AND  dDate >= '2016-01-01'


 select id into #rdrecord11 from rdrecord11 RdRecord where 1=1 and  ((RdRecord.dDate < '2015-01-01' And IsNull(RdRecord.bIsSTQc,0) = 1)
 Or (RdRecord.dDate >= '2015-01-01'
 And IsNull(RdRecord.bPUFirst,0) = 0
 And IsNull(RdRecord.bIAFirst,0) = 0
 And IsNull(RdRecord.bOMFirst,0) = 0
 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11))
)
) AND  dDate <= @dDate2 AND  dDate >= '2016-01-01'

 select id into #rdrecord32 from rdrecord32 RdRecord where 1=1 and  ((RdRecord.dDate < '2015-01-01' And IsNull(RdRecord.bIsSTQc,0) = 1)
 Or (RdRecord.dDate >= '2015-01-01'
 And IsNull(RdRecord.bPUFirst,0) = 0
 And IsNull(RdRecord.bIAFirst,0) = 0
 And IsNull(RdRecord.bOMFirst,0) = 0
 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11))
)
) AND  dDate <= @dDate2 AND  dDate >= '2016-01-01'

 select id into #rdrecord34 from rdrecord34 RdRecord where 1=1 and  ((RdRecord.dDate < '2015-01-01' And IsNull(RdRecord.bIsSTQc,0) = 1)
 Or (RdRecord.dDate >= '2015-01-01'
 And IsNull(RdRecord.bPUFirst,0) = 0
 And IsNull(RdRecord.bIAFirst,0) = 0
 And IsNull(RdRecord.bOMFirst,0) = 0
 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11))
)
) AND  dDate <= @dDate2 AND  dDate >= '2016-01-01'

Select rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine11,N'') as cDefine11,isnull(RdRecord.cDefine12,N'') as cDefine12,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine29,N'') as cDefine29,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine33,N'') as cDefine33,isnull(RdRecords.cDefine36,Null) as cDefine36,isnull(RdRecords.cDefine37,Null) as cDefine37,
Left(RdRecord.cRdCode,5) As cRdCode, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iquantity, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),iquantity)  as iQCJCSL, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iInQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iinNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as ioutQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as ioutNum, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),iquantity)  as iQMJCSL, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQMJCJS, 
 convert(decimal (38,6),IsNull(Inventory.iInvSPrice,0)) as iUnitCost,  CU_F.cComUnitName as cInvA_Unit ,  (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 1 else 0 end) as bBQFS , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=0 then 1 else 0 end  else 0 end) as bBQCK , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=1 then 1 else 0 end else 0 end) as bBQRK , 
 isnull(Left(RdRecord.cRdCode,5) ,N'')+ convert(nvarchar(1),brdflag)  as newrdflag 
 INTO TH_Curr_Qty
 from 
 rdrecord01 rdrecord left join rdrecords01 rdrecords on rdrecord.id=rdrecords.id 
 left join inventory on rdrecords.cinvcode=inventory.cinvcode 
 left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
 left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
 left join department on rdrecord.cdepcode =department.cdepcode 
 left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
 where 1=0 

 ---------
 INSERT INTO TH_Curr_Qty
Select rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine11,N'') as cDefine11,isnull(RdRecord.cDefine12,N'') as cDefine12,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine29,N'') as cDefine29,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine33,N'') as cDefine33,isnull(RdRecords.cDefine36,Null) as cDefine36,isnull(RdRecords.cDefine37,Null) as cDefine37,
Left(RdRecord.cRdCode,5) As cRdCode, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iquantity, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),iquantity)  as iQCJCSL, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iInQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iinNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as ioutQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as ioutNum, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),iquantity)  as iQMJCSL, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQMJCJS, 
 convert(decimal (38,6),IsNull(Inventory.iInvSPrice,0)) as iUnitCost,  CU_F.cComUnitName as cInvA_Unit ,  (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 1 else 0 end) as bBQFS , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=0 then 1 else 0 end  else 0 end) as bBQCK , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=1 then 1 else 0 end else 0 end) as bBQRK , 
 isnull(Left(RdRecord.cRdCode,5) ,N'')+ convert(nvarchar(1),brdflag)  as newrdflag 
 from 
 rdrecord01 rdrecord left join rdrecords01 rdrecords on rdrecord.id=rdrecords.id 
 left join inventory on rdrecords.cinvcode=inventory.cinvcode 
 left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
 left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
 left join department on rdrecord.cdepcode =department.cdepcode 
 left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
 where 
 rdrecord.id in (select id from  #rdrecord01 )
AND (1=1)


------------

 INSERT INTO TH_Curr_Qty
  Select rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine11,N'') as cDefine11,isnull(RdRecord.cDefine12,N'') as cDefine12,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine29,N'') as cDefine29,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine33,N'') as cDefine33,isnull(RdRecords.cDefine36,Null) as cDefine36,isnull(RdRecords.cDefine37,Null) as cDefine37,
Left(RdRecord.cRdCode,5) As cRdCode, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iquantity, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),iquantity)  as iQCJCSL, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iInQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iinNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as ioutQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as ioutNum, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),iquantity)  as iQMJCSL, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQMJCJS, 
 convert(decimal (38,6),IsNull(Inventory.iInvSPrice,0)) as iUnitCost,  CU_F.cComUnitName as cInvA_Unit ,  (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 1 else 0 end) as bBQFS , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=0 then 1 else 0 end  else 0 end) as bBQCK , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=1 then 1 else 0 end else 0 end) as bBQRK , 
 isnull(Left(RdRecord.cRdCode,5) ,N'')+ convert(nvarchar(1),brdflag)  as newrdflag 
 from 
 rdrecord08 rdrecord left join rdrecords08 rdrecords on rdrecord.id=rdrecords.id 
 left join inventory on rdrecords.cinvcode=inventory.cinvcode 
 left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
 left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
 left join department on rdrecord.cdepcode =department.cdepcode 
 left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
 where 
 rdrecord.id in (select id from  #rdrecord08 )
   and (rdrecord.cbustype <> N'预留入库' or rdrecord.bisstqc=1 ) 

 AND (1=1)




 -------------------------
 
 INSERT INTO TH_Curr_Qty
Select rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine11,N'') as cDefine11,isnull(RdRecord.cDefine12,N'') as cDefine12,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine29,N'') as cDefine29,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine33,N'') as cDefine33,isnull(RdRecords.cDefine36,Null) as cDefine36,isnull(RdRecords.cDefine37,Null) as cDefine37,
Left(RdRecord.cRdCode,5) As cRdCode, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iquantity, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),iquantity)  as iQCJCSL, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iInQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iinNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as ioutQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as ioutNum, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),iquantity)  as iQMJCSL, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQMJCJS, 
 convert(decimal (38,6),IsNull(Inventory.iInvSPrice,0)) as iUnitCost,  CU_F.cComUnitName as cInvA_Unit ,  (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 1 else 0 end) as bBQFS , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=0 then 1 else 0 end  else 0 end) as bBQCK , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=1 then 1 else 0 end else 0 end) as bBQRK , 
 isnull(Left(RdRecord.cRdCode,5) ,N'')+ convert(nvarchar(1),brdflag)  as newrdflag 
 from 
 rdrecord09 rdrecord left join rdrecords09 rdrecords on rdrecord.id=rdrecords.id 
 left join inventory on rdrecords.cinvcode=inventory.cinvcode 
 left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
 left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
 left join department on rdrecord.cdepcode =department.cdepcode 
 left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
 where 
 rdrecord.id in (select id from  #rdrecord09 )
   and ( rdrecord.cbustype <> N'预留出库' or rdrecord.bisstqc=1 ) 

 AND (1=1)

 -------------------
 
 INSERT INTO TH_Curr_Qty
Select rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine11,N'') as cDefine11,isnull(RdRecord.cDefine12,N'') as cDefine12,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine29,N'') as cDefine29,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine33,N'') as cDefine33,isnull(RdRecords.cDefine36,Null) as cDefine36,isnull(RdRecords.cDefine37,Null) as cDefine37,
Left(RdRecord.cRdCode,5) As cRdCode, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iquantity, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),iquantity)  as iQCJCSL, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iInQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iinNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as ioutQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as ioutNum, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),iquantity)  as iQMJCSL, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQMJCJS, 
 convert(decimal (38,6),IsNull(Inventory.iInvSPrice,0)) as iUnitCost,  CU_F.cComUnitName as cInvA_Unit ,  (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 1 else 0 end) as bBQFS , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=0 then 1 else 0 end  else 0 end) as bBQCK , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=1 then 1 else 0 end else 0 end) as bBQRK , 
 isnull(Left(RdRecord.cRdCode,5) ,N'')+ convert(nvarchar(1),brdflag)  as newrdflag 
 from 
 rdrecord10 rdrecord left join rdrecords10 rdrecords on rdrecord.id=rdrecords.id 
 left join inventory on rdrecords.cinvcode=inventory.cinvcode 
 left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
 left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
 left join department on rdrecord.cdepcode =department.cdepcode 
 left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
 where 
 rdrecord.id in (select id from  #rdrecord10 )
  

 AND (1=1)


 ---------------------------------
 
 INSERT INTO TH_Curr_Qty
 Select rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine11,N'') as cDefine11,isnull(RdRecord.cDefine12,N'') as cDefine12,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine29,N'') as cDefine29,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine33,N'') as cDefine33,isnull(RdRecords.cDefine36,Null) as cDefine36,isnull(RdRecords.cDefine37,Null) as cDefine37,
Left(RdRecord.cRdCode,5) As cRdCode, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iquantity, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),iquantity)  as iQCJCSL, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iInQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iinNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as ioutQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as ioutNum, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),iquantity)  as iQMJCSL, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQMJCJS, 
 convert(decimal (38,6),IsNull(Inventory.iInvSPrice,0)) as iUnitCost,  CU_F.cComUnitName as cInvA_Unit ,  (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 1 else 0 end) as bBQFS , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=0 then 1 else 0 end  else 0 end) as bBQCK , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=1 then 1 else 0 end else 0 end) as bBQRK , 
 isnull(Left(RdRecord.cRdCode,5) ,N'')+ convert(nvarchar(1),brdflag)  as newrdflag 
 from 
 rdrecord11 rdrecord left join rdrecords11 rdrecords on rdrecord.id=rdrecords.id 
 left join inventory on rdrecords.cinvcode=inventory.cinvcode 
 left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
 left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
 left join department on rdrecord.cdepcode =department.cdepcode 
 left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
 where 
 rdrecord.id in (select id from  #rdrecord11 )
  

 AND (1=1)


 -------------------
 
 INSERT INTO TH_Curr_Qty
 Select rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine11,N'') as cDefine11,isnull(RdRecord.cDefine12,N'') as cDefine12,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine29,N'') as cDefine29,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine33,N'') as cDefine33,isnull(RdRecords.cDefine36,Null) as cDefine36,isnull(RdRecords.cDefine37,Null) as cDefine37,
Left(RdRecord.cRdCode,5) As cRdCode, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iquantity, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),iquantity)  as iQCJCSL, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iInQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iinNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as ioutQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as ioutNum, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),iquantity)  as iQMJCSL, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQMJCJS, 
 convert(decimal (38,6),IsNull(Inventory.iInvSPrice,0)) as iUnitCost,  CU_F.cComUnitName as cInvA_Unit ,  (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 1 else 0 end) as bBQFS , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=0 then 1 else 0 end  else 0 end) as bBQCK , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=1 then 1 else 0 end else 0 end) as bBQRK , 
 isnull(Left(RdRecord.cRdCode,5) ,N'')+ convert(nvarchar(1),brdflag)  as newrdflag 
 from 
 rdrecord32 rdrecord left join rdrecords32 rdrecords on rdrecord.id=rdrecords.id 
 left join inventory on rdrecords.cinvcode=inventory.cinvcode 
 left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
 left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
 left join department on rdrecord.cdepcode =department.cdepcode 
 left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
 where 
 rdrecord.id in (select id from  #rdrecord32 )
  

 AND (1=1)



 -----------------------------
 
 INSERT INTO TH_Curr_Qty
 Select rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine11,N'') as cDefine11,isnull(RdRecord.cDefine12,N'') as cDefine12,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine29,N'') as cDefine29,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine33,N'') as cDefine33,isnull(RdRecords.cDefine36,Null) as cDefine36,isnull(RdRecords.cDefine37,Null) as cDefine37,
Left(RdRecord.cRdCode,5) As cRdCode, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iquantity, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),iquantity)  as iQCJCSL, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 0 else 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as iInQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iinNum, 
(case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),iquantity)  as ioutQuantity, 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 
      CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as ioutNum, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),iquantity)  as iQMJCSL, 
 ( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else rdrecords.iNum end  )  as iQMJCJS, 
 convert(decimal (38,6),IsNull(Inventory.iInvSPrice,0)) as iUnitCost,  CU_F.cComUnitName as cInvA_Unit ,  (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then 1 else 0 end) as bBQFS , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=0 then 1 else 0 end  else 0 end) as bBQCK , 
 (case when  ( dDate>=@dDate1 and isnull(bisstqc,0)=0) then case when brdflag=1 then 1 else 0 end else 0 end) as bBQRK , 
 isnull(Left(RdRecord.cRdCode,5) ,N'')+ convert(nvarchar(1),brdflag)  as newrdflag 
 from 
 rdrecord34 rdrecord left join rdrecords34 rdrecords on rdrecord.id=rdrecords.id 
 left join inventory on rdrecords.cinvcode=inventory.cinvcode 
 left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
 left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
 left join department on rdrecord.cdepcode =department.cdepcode 
 left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
 where 
 rdrecord.id in (select id from  #rdrecord34 )
  

 AND (1=1)


 -----------------------------------
 
 INSERT INTO TH_Curr_Qty
  Select warehouse.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,a.cinvcode,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,1 as bRdFlag,
isnull(a.cdefine1,N'') as cdefine1,isnull(a.cdefine2,N'') as cdefine2,isnull(a.cdefine3,N'') as cdefine3,isnull(a.cdefine11,N'') as cdefine11,isnull(a.cdefine12,N'') as cdefine12,isnull(a.cdefine22,N'') as cdefine22,isnull(a.cdefine25,N'') as cdefine25,isnull(a.cdefine28,N'') as cdefine28,isnull(a.cdefine29,N'') as cdefine29,isnull(a.cdefine31,N'') as cdefine31,isnull(a.cdefine33,N'') as cdefine33,isnull(a.cdefine36,null) as cdefine36,isnull(a.cdefine37,null) as cdefine37,
Left(a.cRdCode,5) As cRdCode, 
 0  as iquantity, 
 0  as iNum, 
 convert(decimal(38,8),iquantity)  as iQCJCSL, 
 (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else a.iNum end  )  as iQCJCJS, 
 0  as iInQuantity, 
 0  as iinNum, 
 0  as ioutQuantity, 
 0  as ioutNum, 
 convert(decimal(38,8),iquantity)  as iQMJCSL, 
 (case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else a.iNum end  )  as iQMJCJS, 
 convert(decimal (38,6),IsNull(Inventory.iInvSPrice,0)) as iUnitCost,  CU_F.cComUnitName as cInvA_Unit ,  0 as bBQFS , 
 0 as bBQCK , 
 0 as bBQRK , 
 isnull(Left(cRdCode,5) ,N'')+ convert(nvarchar(1),1)  as newrdflag 
 from 
 ST_MonthAccounts  a  left join inventory on a.cinvcode=inventory.cinvcode 
 left join warehouse on a.cWhCode = Warehouse.cWhCode
 left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
 left join department on a.cdepcode =department.cdepcode left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
   where iYear = year(@dDate1) and iMonth = month(@dDate1)
 AND (1=1)



 ----------------


 SELECT cast(1 as bit) as 选择
        ,'41' as 公司编号
        ,a.cWhCode as 仓库编号,A.cInvCode as 产品编号,b.cInvDefine10 as 产品种类,b.cInvDefine7 as 机带种类,d.cEnSingular as 测定单位
		,cast(SUM(iQCJCSL) as decimal(16,0)) AS  前残
        ,getdate() as 在库年月
        ,isnull( CAST(CASE WHEN LEFT(b.cinvccode,2) = '03' THEN g.iUnitPrice ELSE ISNULL(f.cidefine12,0 ) end  as decimal(16,2)) ,0) as [成本合计(单价)]
FROM TH_Curr_Qty A INNER JOIN dbo.Inventory B ON A.CINVCODE = B.cInvCode
    left join (select cWhCode,cInvCode,sum(isnull(iQuantity,0) + isnull(ipeqty,0)) as iQty,sum(isnull(ipeqty,0)) as ipeqty from CurrentStock GROUP BY cWhCode,cInvCode) c on a.cWhCode = c.cWhCode and a.cInvCode = c.cInvCode
    left join ComputationUnit d on d.cComunitCode = b.cComUnitCode 
    LEFT JOIN (SELECT [cInvCode],SUM([iQuantity]) AS iqty FROM [ST_PELockedSum] GROUP BY [cInvCode]) e ON e.cInvCode = a.CINVCODE
    LEFT JOIN 
	    (
		    SELECT a.AutoID,a.cinvcode,a.iMoney / a.iNum as iUnitPrice
		    FROM IA_Summary a
		    INNER JOIN (
			    SELECT MAX(AutoID) AS autoid,cInvCode
			    FROM IA_Summary
			    GROUP BY cInvCode  
				    )b ON a.AutoID = b.autoid 
            where isnull(a.iNum,0) <> 0
	    )	g ON b.cInvCode = g.cinvcode
	LEFT JOIN Inventory_extradefine f ON b.cInvCode = f.cInvCode
where b.cInvCCode like '02%' or b.cInvCCode  like '03%'
GROUP BY a.cWhCode ,  A.cInvCode , b.cInvDefine2,b.cComUnitCode,c.iQty,b.cInvDefine13 ,b.cInvDefine10,b.cInvDefine7,d.cEnSingular,e.iqty,c.ipeqty,b.cinvccode,f.cidefine12,g.iUnitPrice

";
            sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("bbbbbb", dateEdit2.DateTime.ToString("yyyy-MM-dd"));

            DataTable dt = DbHelperSQL.Query(sSQL);


            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string sColName = dt.Columns[i].ColumnName.Trim();
                sColName = sChinaToJap(sColName);
                dt.Columns[i].ColumnName = sColName;
            }

            sSQL = @"
select max(iyperiod) as iyperiod from gl_mend
where isnull(bflag_ST,0) = 1 and isnull(iperiod,0) <> 0
";
            DataTable dtDate = DbHelperSQL.Query(sSQL);
            DateTime dDate = BaseFunction.ReturnDate(dtDate.Rows[0][0].ToString().Substring(0, 4) + "-" + dtDate.Rows[0][0].ToString().Substring(4, 2) + "-01");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["在库年月"] = dDate.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            }


            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.ReadOnly = true;
            }
            gridView1.Columns["选择"].OptionsColumn.ReadOnly = false;
            chkAll.Checked = true;
            gridView1.FocusedRowHandle = 0;
        }
        /// <summary>
        /// 中文转日文
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private string sChinaToJap(object o)
        {
            string s = o.ToString().ToLower().Trim();

            string sReturn = "";
            switch (s)
            {
                case "csocode": sReturn = "受注No."; break;

                default:
                    sReturn = s; break;
            }

            sReturn = sReturn.Replace(".", "");
            return sReturn;
        }

        private string sColText(object o)
        {
            string sReturn = o.ToString().ToLower().Trim();
            switch (sReturn)
            {
                case "公司编号": sReturn = "Company_NO"; break;
                case "仓库编号": sReturn = "Warehouse_No"; break;
                case "产品编号": sReturn = "Item_NO"; break;
                case "产品种类": sReturn = "Item_Class"; break;
                case "机带种类": sReturn = "Item_Kind"; break;
                case "测定单位": sReturn = "UM_Stock"; break;
                case "前残": sReturn = "Opening_Balance"; break;
                case "在库年月": sReturn = "Stock_Date"; break;
                case "成本合计(单价)": sReturn = "Total_Cost"; break;
            }
            return sReturn;
        }
    }
}
