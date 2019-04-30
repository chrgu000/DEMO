// ===============================================================================
// Microsoft Data Access Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//
// SQLHelper.cs
//
// This file contains the implementations of the SqlHelper and SqlHelperParameterCache
// classes.
//
// For more information see the Data Access Application Block Implementation Overview. 
// ===============================================================================
// Release history
// VERSION	DESCRIPTION
//   2.0	Added support for FillDataset, UpdateDataset and "Param" helper methods
//
// ===============================================================================
// Copyright (C) 2000-2001 Microsoft Corporation
// All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// ==============================================================================

using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.IO;



namespace TH.BaseClass
{

    public abstract class DbHelperXML
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString = "";
        public DbHelperXML()
        {
        }
        public static DataTable ReadFromXml(string address)
        {
            DataTable dt = new DataTable();

            if (!File.Exists(address))
            {
                throw new Exception("文件不存在!");
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(address);


            XmlNode nodes = xmlDoc.SelectNodes("*")[0].ChildNodes[4].ChildNodes[0];

            int b = 0;
            for (int p = 0; p < nodes.ChildNodes.Count; p++)
            {
                XmlNode n = nodes.ChildNodes[p];
                if (n.Name == "Row")
                {
                    if (b == 0)
                    {

                        b = 1;
                    }
                    else if (b == 1)
                    {
                        for (int i = 0; i < n.ChildNodes.Count; i++)
                        {
                            XmlNode nodeh = n.ChildNodes[i].ChildNodes[0];
                            if (nodeh != null)
                            {
                                dt.Columns.Add(nodeh.InnerText);
                            }
                        }
                        b = 2;
                    }
                    else
                    {
                        DataRow dw = dt.NewRow();
                        for (int i = 0; i < n.ChildNodes.Count; i++)
                        {
                            XmlNode nodeb = n.ChildNodes[i].ChildNodes[0];
                            if (nodeb != null)
                            {
                                dw[i] = nodeb.InnerText;
                            }
                        }
                        dt.Rows.Add(dw);
                    }
                }
            }

            return dt;
        }
    }

}
