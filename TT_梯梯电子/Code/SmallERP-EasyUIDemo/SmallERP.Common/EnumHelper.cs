using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallERP.Common
{
    /// <summary>
    /// 枚举自定义的字段
    /// </summary>
    public enum EnumField
    {
        /// <summary>
        /// item项
        /// </summary>
        itemName,

        /// <summary>
        /// item值
        /// </summary>
        itemValue,

        /// <summary>
        /// item项描述
        /// </summary>
        itemDescription

    }


    public class EnumInfo
    {
        private string _itemName;
        private string _itemValue;
        private string _itemDescription;

        /// <summary>
        /// item项
        /// </summary>
        public string itemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        /// <summary>
        /// item值
        /// </summary>
        public string itemValue
        {
            get { return _itemValue; }
            set { _itemValue = value; }
        }

        /// <summary>
        ///  item项描述
        /// </summary>
        public string itemDescription
        {
            get { return _itemDescription; }
            set { _itemDescription = value; }
        }

    }


    /// <summary>
    /// 枚举的帮助类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 枚举字段:item项
        /// </summary>
        public static readonly string EnumFieldItemName = EnumField.itemName.ToString();

        /// <summary>
        /// 枚举字段:item值
        /// </summary>
        public static readonly string EnumFieldItemValue = EnumField.itemValue.ToString();

        /// <summary>
        /// 枚举字段:item项描述
        /// </summary>
        public static readonly string EnumFieldItemDescription = EnumField.itemDescription.ToString();


        /// <summary>
        /// 根据枚举定义的项返回Description
        /// </summary>
        /// <param name="value">枚举定义的项</param>
        /// <returns></returns>
        public static string GetDescription(this System.Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                var Attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (Attributes != null)
                    return Attributes.Length > 0 ? Attributes[0].Description : null;
            }
            return string.Empty;
        }

        /// <summary>
        /// 根据枚举、项的value值返回枚举的Description
        /// </summary>
        /// <param name="enumType">枚举</param>
        /// <param name="enumIntValue">项的value值</param>
        /// <returns></returns>
        public static string GetDescription(Type enumType, int enumIntValue)
        {
            //string nameDesc = System.Enum.GetName(enumType, enumIntValue);
            return GetDescription((System.Enum)System.Enum.ToObject(enumType, enumIntValue));
        }


        /// <summary>
        /// enum TO DataTable
        /// </summary>
        /// <param name="enumType">要操作的枚举对象</param>
        /// <returns>
        /// <para>itemName</para>
        /// <para>itemValue</para>
        /// <para>itemDescription</para>
        /// </returns>
        public static DataTable EnumToDataTable(Type enumType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("itemName", typeof(string)).DefaultValue = string.Empty;
            dt.Columns.Add("itemValue", typeof(int)).DefaultValue = 0;
            dt.Columns.Add("itemDescription", typeof(string)).DefaultValue = string.Empty;

            DataRow dr;
            foreach (int code in System.Enum.GetValues(enumType))
            {
                string itemName = System.Enum.GetName(enumType, code);
                string itemValue = code.ToString();
                string itemDescription = EnumHelper.GetDescription(enumType, code);
                dr = dt.NewRow();
                dr["itemName"] = itemName;
                dr["itemValue"] = itemValue;
                dr["itemDescription"] = itemDescription;
                dt.Rows.Add(dr);
            }
            return dt;
        }


        /// <summary>
        /// enum TO List
        /// </summary>
        /// <param name="enumType">要操作的枚举对象</param>
        /// <returns>List EnumInfo </returns>
        public static List<EnumInfo> EnumToEnumInfoList(Type enumType)
        {
            List<EnumInfo> enumInfoList = new List<EnumInfo>();
            EnumInfo enumInfo;
            foreach (int code in System.Enum.GetValues(enumType))
            {
                try
                {
                    string itemName = System.Enum.GetName(enumType, code);
                    string itemValue = code.ToString();
                    string itemDescription = EnumHelper.GetDescription(enumType, code);

                    enumInfo = new EnumInfo();
                    enumInfo.itemName = itemName;
                    enumInfo.itemValue = itemValue;
                    enumInfo.itemDescription = itemDescription;
                    enumInfoList.Add(enumInfo);
                }
                catch (Exception ex) { }
            }
            return enumInfoList;
        }


        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T Parse<T>(string type)
        {
            return (T)Enum.Parse(typeof(T), type);
        }
    }
}
