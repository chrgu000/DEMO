using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ϵͳ����.Query
{
    class ClsBuckUpDataBase
    {
        ϵͳ����.ClsDataBase clsSQLCommond;

        public ClsBuckUpDataBase()
        {
            clsSQLCommond = ϵͳ����.ClsDataBaseFactory.Instance();
        }

        public bool BuckUpDataBase(string sPathInfo)
        {
            bool b = false;
            try
            {
                string sSQL = "BACKUP DATABASE [" + ϵͳ����.ClsBaseDataInfo.sDataBaseName + "] TO  DISK = N'" + sPathInfo + "' " +
	                            "WITH NOFORMAT, NOINIT,  NAME = N'TH_Test-���� ���ݿ� ����',  " +
	                            "SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                clsSQLCommond.ExecSql(sSQL);
                b = true;
            }
            catch
            {
                throw new Exception("�������ݿ����ʧ�ܣ�");
            }
            return b;
        }


        public DateTime GetSerTime()
        {
            DateTime dTime;
            try
            {
                string sSQL = "select getdate() as sTime ";
                dTime = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch
            {
                throw new Exception("��÷�����ʱ��ʧ�ܣ�");
            }
            return dTime;
        }

        public DataTable GetSerHostName()
        {
            try
            {
                string sSQL = "select host_name() as sHostName,@@SERVERname as sSerName  ";
                return clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("��÷���������ʧ�ܣ�");
            }
        }
    }
}
