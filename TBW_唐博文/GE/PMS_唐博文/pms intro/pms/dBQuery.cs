using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using System.Collections;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System.Runtime.InteropServices;

namespace PMMWS
{
    public class dBQuery
    {

        public static void DBSuzhouInitialize()
        {
            IConfigurationSource sc = System.Configuration.ConfigurationSettings.GetConfig("activerecord") as IConfigurationSource;

            ActiveRecordStarter.Initialize(sc, typeof(Scanning), typeof(Machine), typeof(CMOrder), typeof(HPOrder), typeof(SMOrder), typeof(MAOrder), typeof(Worker), typeof(MAReport), typeof(MAPOrder), typeof(SMReport), typeof(SMPOrder), typeof(HPReport), typeof(HPPOrder), typeof(CMReport), typeof(CMPOrder), typeof(Worker), typeof(PMSMPlan),typeof(PMSPMPlan),typeof(PMSPMContent),typeof(PMSPMBackup));
        }

   
        public static DataTable GetReflectionResult(string typename, string MethodName, string arguments)
        {
            //取得类信息
            Object obj = System.Reflection.Assembly.Load("PMMWS").CreateInstance(typename);
            Type type = obj.GetType();
            PropertyInfo[] typeInfo = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            Object lists;
            //调用类方法，返回Ilist
            if (arguments != "")
            {
                lists = type.InvokeMember(MethodName, System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { arguments });
            }
            else
            {
                lists = type.InvokeMember(MethodName, System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] {});
            }

                Type t2 = lists.GetType();
            //返回Ilist长度，即查询结果数量
            Object tt = t2.InvokeMember("Length", BindingFlags.GetProperty, null, lists, new object[] { });
            //循环遍历
            int counts = Convert.ToInt32(tt.ToString());
            DataTable dt = new DataTable();
            DataRow row;
            DataColumn column;
            for (int i = 0; i < counts; i++)
            {
                Object mechines = t2.InvokeMember("Get", System.Reflection.BindingFlags.InvokeMethod, null, lists, new object[] { i });
                Type t3 = mechines.GetType();

                row = dt.NewRow();
                for (int j = 0, k = typeInfo.Length; j < k; j++)
                {
                    PropertyInfo listInfo = typeInfo[j];
                    string name = listInfo.Name;
                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, listInfo.PropertyType);
                        dt.Columns.Add(column);
                    }
                    row[name] = t3.InvokeMember(name, BindingFlags.GetProperty, null, mechines, new object[] { });
                }
                dt.Rows.Add(row);
            }
            
            return dt;
        }

        public static void UpdateReflectionResultByDataRow(string typename,string Id, DataRow dr)
        {
            Object obj = System.Reflection.Assembly.Load("PMMWS").CreateInstance(typename);
            Type type = obj.GetType();

            Object lists = type.InvokeMember("Find", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { Id });
            Type t2 = lists.GetType();

            for (int j = 0, k = dr.Table.Columns.Count; j < k; j++)
            {
                if (dr[j].ToString() != "")
                {
                    if (dr[j].ToString() == "0001/1/1 0:00:00")
                    {
                        dr[j] = Convert.ToDateTime("1900/1/1 0:00:00");
                    }
                    type.InvokeMember(dr.Table.Columns[j].Caption, BindingFlags.SetProperty, null, lists, new object[] { dr[j] });
                }
             }
            type.InvokeMember("Update", System.Reflection.BindingFlags.InvokeMethod, null, lists, new object[] { });
        }

        public static DataRow GetReflectionResultProperties(string typename)
        {
            Object obj = System.Reflection.Assembly.Load("PMMWS").CreateInstance(typename);
            if (obj != null)
            {
                Type type = obj.GetType();
                PropertyInfo[] typeInfo = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

                DataTable dt = new DataTable();
                DataRow row = dt.NewRow();
                DataColumn column;

                for (int j = 0, k = typeInfo.Length; j < k; j++)
                {
                    PropertyInfo listInfo = typeInfo[j];
                    string name = listInfo.Name;
                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, listInfo.PropertyType);
                        dt.Columns.Add(column);
                    }
                    if (listInfo.PropertyType.ToString() == "System.DateTime")
                    {
                        row[name] = "2000/1/1 00:00:00";
                    }

                }
                return row;
            }
            else
            {
                return null;
            }

        }

        public static void CreateReflectionResult(string typename, DataRow dr)
        {
            Object obj = System.Reflection.Assembly.Load("PMMWS").CreateInstance(typename);
            Type type = obj.GetType();

            for (int j = 0, k = dr.Table.Columns.Count; j < k; j++)
            {
                if (dr[j].ToString() != "")
                {
                    if ((dr[j].ToString() == "0001/1/1 0:00:00") || (dr[j].ToString() == "0001/1/1 00:00:00"))
                    {
                        dr[j] = Convert.ToDateTime("2000/1/1 0:00:00");
                    }
                    type.InvokeMember(dr.Table.Columns[j].Caption, BindingFlags.SetProperty, null, obj, new object[] { dr[j] });
                }

            }
            type.InvokeMember("Create", System.Reflection.BindingFlags.InvokeMethod, null, obj, new object[] { });
        }


        public static void UpdateReflectionResultByDataRowInt(string typename, int Id, DataRow dr)
        {
            Object obj = System.Reflection.Assembly.Load("PMMWS").CreateInstance(typename);
            Type type = obj.GetType();

            Object lists = type.InvokeMember("Find", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { Id });
            Type t2 = lists.GetType();

            for (int j = 0, k = dr.Table.Columns.Count; j < k; j++)
            {
                if (dr[j].ToString() != "")
                {
                    if (dr[j].ToString() == "0001/1/1 0:00:00")
                    {
                        dr[j] = Convert.ToDateTime("1900/1/1 0:00:00");
                    }
                    type.InvokeMember(dr.Table.Columns[j].Caption, BindingFlags.SetProperty, null, lists, new object[] { dr[j] });
                }
            }
            type.InvokeMember("Update", System.Reflection.BindingFlags.InvokeMethod, null, lists, new object[] { });
        }

        public static void DeleteReflectionResultByDataRowInt(string typeName, int id)
        {
            Object obj = System.Reflection.Assembly.Load("PMMWS").CreateInstance(typeName);
            Type type = obj.GetType();

            Object lists = type.InvokeMember("Find", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { id });
            Type t2 = lists.GetType();

            type.InvokeMember("Delete", System.Reflection.BindingFlags.InvokeMethod, null, lists, new object[] { });

        }



        public static DataRow GetReflectionResultbyId(string typename, string MethodName, string id)
        {
            //取得类信息
            Object obj = System.Reflection.Assembly.Load("PMMWS").CreateInstance(typename);
            Type type = obj.GetType();
            PropertyInfo[] typeInfo = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            //调用类方法，返回Ilist
            Object lists = type.InvokeMember(MethodName, System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { id });
            Type t2 = lists.GetType();

            DataTable dt = new DataTable();
            DataRow row = dt.NewRow();
            DataColumn column;

            for (int j = 0, k = typeInfo.Length; j < k; j++)
            {
                PropertyInfo listInfo = typeInfo[j];
                string name = listInfo.Name;
                if (dt.Columns[name] == null)
                {
                    column = new DataColumn(name, listInfo.PropertyType);
                    dt.Columns.Add(column);
                }
                row[name] = t2.InvokeMember(name, BindingFlags.GetProperty, null, lists, new object[] { });
            }

            return row;
        }

      


        public static DataRow GetReflectionResultbyIntId(string typename, string MethodName, int id)
        {
            //取得类信息
            Object obj = System.Reflection.Assembly.Load("PMMWS").CreateInstance(typename);
            Type type = obj.GetType();
            PropertyInfo[] typeInfo = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            //调用类方法，返回Ilist
            Object lists = type.InvokeMember(MethodName, System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { id });
            Type t2 = lists.GetType();

            DataTable dt = new DataTable();
            DataRow row = dt.NewRow();
            DataColumn column;

            for (int j = 0, k = typeInfo.Length; j < k; j++)
            {
                PropertyInfo listInfo = typeInfo[j];
                string name = listInfo.Name;
                if (dt.Columns[name] == null)
                {
                    column = new DataColumn(name, listInfo.PropertyType);
                    dt.Columns.Add(column);
                }
                row[name] = t2.InvokeMember(name, BindingFlags.GetProperty, null, lists, new object[] { });
            }

            return row;
        }

        public static DataTable GetReflectionResultByDateTimes(string typename, string MethodName, Object[] arguments)
        {
            //取得类信息

            Object obj = System.Reflection.Assembly.Load("PMMWS").CreateInstance(typename);
            Type type = obj.GetType();
            PropertyInfo[] typeInfo = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            //调用类方法，返回Ilist
            Object lists = type.InvokeMember(MethodName, System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { arguments[0], arguments[1] });
            Type t2 = lists.GetType();

            //返回Ilist长度，即查询结果数量
            Object tt = t2.InvokeMember("Length", BindingFlags.GetProperty, null, lists, new object[] { });

            //循环遍历
            int counts = Convert.ToInt32(tt.ToString());
            DataTable dt = new DataTable();
            DataRow row;
            DataColumn column;

            for (int i = 0; i < counts; i++)
            {
                Object mechines = t2.InvokeMember("Get", System.Reflection.BindingFlags.InvokeMethod, null, lists, new object[] { i });
                Type t3 = mechines.GetType();

                row = dt.NewRow();
                for (int j = 0, k = typeInfo.Length; j < k; j++)
                {
                    PropertyInfo listInfo = typeInfo[j];
                    string name = listInfo.Name;
                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, listInfo.PropertyType);
                        dt.Columns.Add(column);
                    }
                    row[name] = t3.InvokeMember(name, BindingFlags.GetProperty, null, mechines, new object[] { });
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}