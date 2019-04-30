using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace FrameBaseFunction
{
    /// <summary>
    /// SQL �����װ����
    /// </summary>
    public class ClsSQLFactory
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();
        private static volatile ClsSQLFactory clsSQLFactory = null;
        private static object lockHelper = new object();


        public static ClsSQLFactory Instance()
        {
            if (clsSQLFactory == null)
            {
                lock (lockHelper)
                {
                    if (clsSQLFactory == null)
                    {
                        clsSQLFactory = new ClsSQLFactory();
                    }
                }
            }

            return clsSQLFactory;
        }

        /// <summary>
        /// ��װSQL���
        /// </summary>
        /// <param name="sTableName">������</param>
        /// <param name="dt2">��ֵ</param>
        /// <returns></returns>
        public ArrayList sExecInsertSQL(string sTableName, DataTable dt2)
        {
            ArrayList aList = new ArrayList();
            try
            {
                string sSQL = "select * from information_schema.columns where table_name = '" + sTableName + "'";
                DataTable dt1 = clsSQL.ExecQuery(sSQL);
                if (dt1.Rows.Count < 1)
                {
                    throw new Exception("δ�ҵ������ݿ��ṹ��Ϣ��");
                }

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    bool bFisrt = true;
                    string sSQL1 = "insert into " + dt1.Rows[0]["dtName"].ToString().Trim() + "(";
                    string sSQL2 = "values(";
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        string sColName = dt1.Rows[i]["column_name"].ToString().Trim();
                        int iValueType = iAddCol(dt1.Rows[i]["data_type"].ToString().ToLower().Trim());
                        object oValue = dt2.Rows[j][sColName];
                        if (oValue == null || iValueType == 0)
                        {
                            continue;
                        }

                        if (bFisrt)
                        {
                            sSQL1 = sSQL1 + oValue;
                            if (iValueType == 2)
                            {
                                sSQL2 = sSQL2 + "'" + oValue.ToString().Trim() + "'";
                            }
                            if (iValueType == 1)
                            {
                                sSQL2 = sSQL2 + oValue.ToString().Trim();
                            }
                            bFisrt = false;
                        }
                        else
                        {
                            sSQL1 = sSQL1 + "," + oValue;

                            if (iValueType == 2)
                            {
                                sSQL2 = sSQL2 + ",'" + oValue.ToString().Trim() + "'";
                            }
                            if (iValueType == 1)
                            {
                                sSQL2 = sSQL2 + "," + oValue.ToString().Trim();
                            }
                        }
                    }
                    sSQL1 = sSQL1 + ")";
                    sSQL2 = sSQL2 + ")";
                    aList.Add(sSQL1 + sSQL2);
                }

            }
            catch(Exception ee)
            {
                throw new Exception("��װSQL���ʧ�ܣ�ԭ�����£�\n  " + ee.Message);
            }
            return aList;
        }
        
        /// <summary>
        /// �ж��Ƿ�����ֶΣ�0 ������ֶΣ�1 ����������ֶΣ�2 ����ַ����ֶ�
        /// </summary>
        /// <returns></returns>
        private int iAddCol(string sDataType)
        {
            int i = 0;
            switch (sDataType)
            {
                case "int":
                case "bit":
                case "float":
                case "decimal":
                case "smallint":
                case "numeric":
                case "money":
                    i = 1;
                    break;
                default:
                    i = 2;
                    break;
            }
            return i;
        }
    }
}
