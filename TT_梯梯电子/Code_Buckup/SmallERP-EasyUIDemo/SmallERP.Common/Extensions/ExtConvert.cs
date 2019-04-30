using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmallERP.Common
{
    /// <summary>
    /// 对象映射
    /// </summary>
    public static class ExtConvert
    {
        /// <summary>
        /// 将字符串值转换为指定类型的值。
        /// </summary>
        /// <typeparam name="T">需要转换为指定的类型。</typeparam>
        /// <param name="value">需要转换的字符串。</param>
        /// <returns>转换为指定类型后的结果。如果转换失败，返回指定类型的默认值。</returns>
        /// <remarks>
        /// 该方法提供将字符串转换为指定类型。如果需要判断该方法是否转换成功，请使用<see cref="M:Extensions.To``1(System.String,``0@)" />重载。
        /// 支持以下类型转换：(S)Byte, Decimal, Double, Single, (U)Int16, (U)Int32, (U)Int64, Boolean, Guid, DateTime, Enum。
        /// 另外，字符串"1"/"0", "on"/"off", "true"/"false"(忽略大小写)也支持转换成Boolean类型。对于<see cref="T:System.DateTime" />类型解析，该方法使用<see cref="M:System.DateTime.TryParse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)" />，
        /// 如果需要使用精确格式匹配可以使用<see cref="M:Extensions.To(System.String,System.IFormatProvider,System.String,System.DateTime@)" />重载（使用<see cref="M:System.DateTime.TryParseExact(System.String,System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)" />解析） <br />
        /// </remarks>
        /// <example>
        /// 以下提供一些常见示例：
        /// <code>
        /// // 从隐藏域中获取值并转换为companyId。
        /// Int32 companyId = hfCompanyId.Value.ToSafeString().To&lt;Int32&gt;();
        /// // 从HttpRequest中获取值并转换为articleId。
        /// Int32 articleId = Request["ArticleId"].ToSafeString().To&lt;Int32&gt;();
        /// // "on"转换为Boolean值。
        /// Boolean isTurnedOn = "on".Too&lt;Boolean&gt;();
        /// // GUID类型转换。
        /// Guid id = "8852ad53-d63f-406f-bb94-86b14c254c57".To&lt;Guid&gt;();
        /// </code>
        /// </example>
        public static T To<T>(this string value) where T : struct
        {
            T t;
            value.To<T>(CultureInfo.InvariantCulture, out t);
            return t;
        }

        /// <summary>
        /// 将字符串值转换为指定类型的值， 该方法提供返回值判断是否转换成功。
        /// </summary>
        /// <typeparam name="T">需要转换为指定的类型。</typeparam>
        /// <param name="value">需要转换的字符串。</param>
        /// <param name="result">转换为指定类型后的结果。如果转换失败，返回指定类型的默认值。</param>
        /// <returns>返回值指示该方法是否转换成功。转换成功返回true，否则返回false。</returns>
        /// <remarks>
        /// 该方法提供将字符串转换为指定类型，并提供返回值判断是否转换成功。如果不需要判断该方法是否转换成功，请使用<see cref="M:Extensions.To``1(System.String)" />重载。
        /// 支持以下类型转换：(S)Byte, Decimal, Double, Single, (U)Int16, (U)Int32, (U)Int64, Boolean, Guid, DateTime, Enum。
        /// 另外，字符串"1"/"0", "on"/"off", "true"/"false"(忽略大小写)也支持转换成Boolean类型。对于<see cref="T:System.DateTime" />类型解析，该方法使用<see cref="M:System.DateTime.TryParse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)" />，
        /// 如果需要使用精确格式匹配可以使用<see cref="M:Extensions.To(System.String,System.IFormatProvider,System.String,System.DateTime@)" />重载（使用<see cref="M:System.DateTime.TryParseExact(System.String,System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)" />解析） <br />
        /// </remarks>
        /// <example>
        /// 以下提供一些常见示例：
        /// <code>
        /// // 从隐藏域中获取值并转换为companyId。
        /// Int32 companyId;
        /// Boolean isSuccess = hfCompanyId.Value.ToSafeString().To&lt;Int32&gt;(out companyId);
        /// // 从HttpRequest中获取值并转换为articleId。
        /// Int32 articleId;
        /// isSuccess = Request["ArticleId"].ToSafeString().To&lt;Int32&gt;(out articleId);
        /// </code>
        /// </example>
        public static bool To<T>(this string value, out T result) where T : struct
        {
            return value.To<T>(CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// 将字符串值转换为指定类型的值， 该方法提供返回值判断是否转换成功。
        /// </summary>
        /// <typeparam name="T">需要转换为指定的类型。</typeparam>
        /// <param name="value">需要转换的字符串。</param>
        /// <param name="culture">区域文化信息。传入null值则使用<see cref="P:System.Globalization.CultureInfo.CurrentCulture" /></param>
        /// <param name="result">转换为指定类型后的结果。如果转换失败，返回指定类型的默认值。</param>
        /// <returns>返回值指示该方法是否转换成功。转换成功返回true，否则返回false。</returns>
        /// <remarks>
        /// 该方法提供将字符串转换为指定类型，并提供返回值判断是否转换成功。如果不需要判断该方法是否转换成功，请使用<see cref="M:Extensions.To``1(System.String)" />重载。
        /// 支持以下类型转换：(S)Byte, Decimal, Double, Single, (U)Int16, (U)Int32, (U)Int64, Boolean, Guid, DateTime, Enum。
        /// 另外，字符串"1"/"0", "on"/"off", "true"/"false"(忽略大小写)也支持转换成Boolean类型。对于<see cref="T:System.DateTime" />类型解析，该方法使用<see cref="M:System.DateTime.TryParse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)" />，
        /// 如果需要使用精确格式匹配可以使用<see cref="M:Extensions.To(System.String,System.IFormatProvider,System.String,System.DateTime@)" />重载（使用<see cref="M:System.DateTime.TryParseExact(System.String,System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)" />解析） <br />
        /// </remarks>
        public static bool To<T>(this string value, IFormatProvider culture, out T result) where T : struct
        {
            ValueType valueType;
            result = default(T);
            string str = value;
            object currentCulture = culture;
            if (currentCulture == null)
            {
                currentCulture = CultureInfo.CurrentCulture;
            }
            if (!str.To((IFormatProvider)currentCulture, typeof(T), out valueType))
            {
                return false;
            }
            result = (T)valueType;
            return true;
        }

        /// <summary>
        /// 将字符串值转换为指定类型的值， 该方法提供返回值判断是否转换成功。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <param name="culture">区域文化信息。传入null值则使用<see cref="P:System.Globalization.CultureInfo.CurrentCulture" /></param>
        /// <param name="type">需要转换</param>
        /// <param name="result">转换为指定类型后的结果。如果转换失败，返回指定类型的默认值。</param>
        /// <returns>返回值指示该方法是否转换成功。转换成功返回true，否则返回false。</returns>
        /// <remarks>
        /// 该方法提供将字符串转换为指定类型，并提供返回值判断是否转换成功。如果不需要判断该方法是否转换成功，请使用<see cref="M:Extensions.To``1(System.String)" />重载。
        /// 支持以下类型转换：(S)Byte(?), Decimal(?), Double(?), Single(?), (U)Int16(?), (U)Int32(?), (U)Int64(?), Boolean(?), Guid(?), DateTime(?), Enum(?)。
        /// 另外，字符串"1"/"0", "on"/"off", "true"/"false"(忽略大小写)也支持转换成Boolean类型。对于<see cref="T:System.DateTime" />类型解析，该方法使用<see cref="M:System.DateTime.TryParse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)" />，
        /// 如果需要使用精确格式匹配可以使用<see cref="M:Extensions.To(System.String,System.IFormatProvider,System.String,System.DateTime@)" />重载（使用<see cref="M:System.DateTime.TryParseExact(System.String,System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)" />解析） <br />
        /// </remarks>
        public static bool To(this string value, IFormatProvider culture, Type type, out ValueType result)
        {
            byte num;
            sbyte num1;
            decimal num2;
            double num3;
            float single;
            short num4;
            int num5;
            long num6;
            ushort num7;
            uint num8;
            ulong num9;
            bool flag;
            DateTime dateTime;
            result = 0;
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                if (!type.IsGenericType)
                {
                    return false;
                }
                result = null;
                return true;
            }
            if ((type == PreDefinedTypes.Byte || type == typeof(byte?)) && byte.TryParse(value, NumberStyles.Any, culture, out num))
            {
                result = num;
                return true;
            }
            if ((type == PreDefinedTypes.SByte || type == typeof(sbyte?)) && sbyte.TryParse(value, NumberStyles.Any, culture, out num1))
            {
                result = num1;
                return true;
            }
            if ((type == PreDefinedTypes.Decimal || type == typeof(decimal?)) && decimal.TryParse(value, NumberStyles.Any, culture, out num2))
            {
                result = num2;
                return true;
            }
            if ((type == PreDefinedTypes.Double || type == typeof(double?)) && double.TryParse(value, NumberStyles.Any, culture, out num3))
            {
                result = num3;
                return true;
            }
            if ((type == PreDefinedTypes.Float || type == typeof(float?)) && float.TryParse(value, NumberStyles.Any, culture, out single))
            {
                result = single;
                return true;
            }
            if ((type == PreDefinedTypes.Int16 || type == typeof(short?)) && short.TryParse(value, NumberStyles.Any, culture, out num4))
            {
                result = num4;
                return true;
            }
            if ((type == PreDefinedTypes.Int32 || type == typeof(int?)) && int.TryParse(value, NumberStyles.Any, culture, out num5))
            {
                result = num5;
                return true;
            }
            if ((type == PreDefinedTypes.Int64 || type == typeof(long?)) && long.TryParse(value, NumberStyles.Any, culture, out num6))
            {
                result = num6;
                return true;
            }
            if ((type == PreDefinedTypes.UInt16 || type == typeof(ushort?)) && ushort.TryParse(value, NumberStyles.Any, culture, out num7))
            {
                result = num7;
                return true;
            }
            if ((type == PreDefinedTypes.UInt32 || type == typeof(uint?)) && uint.TryParse(value, NumberStyles.Any, culture, out num8))
            {
                result = num8;
                return true;
            }
            if ((type == PreDefinedTypes.UInt64 || type == typeof(ulong?)) && ulong.TryParse(value, NumberStyles.Any, culture, out num9))
            {
                result = num9;
                return true;
            }
            if (type == PreDefinedTypes.Boolean || type == typeof(bool?))
            {
                result = false;
                if (bool.TryParse(value, out flag))
                {
                    result = flag;
                }
                else if (value.Trim().Equals("1", StringComparison.OrdinalIgnoreCase) || value.Trim().Equals("on", StringComparison.OrdinalIgnoreCase) || value.Trim().Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    result = true;
                }
                else
                {
                    if (!value.Trim().Equals("0", StringComparison.OrdinalIgnoreCase) && !value.Trim().Equals("off", StringComparison.OrdinalIgnoreCase) && !value.Trim().Equals("false", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                    result = false;
                }
                return true;
            }
            if (type == PreDefinedTypes.DateTime || type == typeof(DateTime?))
            {
                string str = value;
                object currentCulture = culture;
                if (currentCulture == null)
                {
                    currentCulture = CultureInfo.CurrentCulture;
                }
                if (DateTime.TryParse(str, (IFormatProvider)currentCulture, DateTimeStyles.None, out dateTime))
                {
                    result = dateTime;
                    return true;
                }
                result = DateTime.MinValue;
                return false;
            }
            return false;
        }

        /// <summary>
        /// DataTable 转换为实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this DataTable dataTable) where T : class,new()
        {
            //创建一个属性的列表
            var prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口
            Type t = typeof(T);
            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表 
            Array.ForEach(t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                , p =>
                {
                    if (dataTable.Columns.Contains(p.Name))
                        prlist.Add(p);
                });
            //创建返回的集合
            //创建TResult的实例
            var ob = new T();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //找到对应的数据  并赋值
                    DataRow row1 = row;
                    prlist.ForEach(p => { if (row1[p.Name] != DBNull.Value) p.SetValue(ob, row1[p.Name], null); });
                }
            }
            return ob;
        }

        /// <summary>
        /// DbDataReader 转换为实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this DbDataReader dataReader) where T : class,new()
        {
            T t = default(T);
            using (dataReader)
            {
                if (dataReader.Read())
                {
                    t = new T();
                    foreach (var pi in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        var obj = new object();
                        try
                        {
                            obj = dataReader[pi.Name];
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        if (obj == DBNull.Value || obj == null)
                            continue;
                        var si = pi.GetSetMethod();
                        if (si == null)
                            continue;

                        if (pi.PropertyType == typeof(int))
                            obj = Convert.ToInt32(obj);
                        if (pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(float) || pi.PropertyType == typeof(double))
                            obj = Convert.ToDecimal(obj);
                        if (pi.PropertyType == typeof(DateTime))
                            obj = Convert.ToDateTime(obj);
                        if (pi.PropertyType == typeof(float))
                            obj = Convert.ToDecimal(obj);
                        if (pi.PropertyType == typeof(bool))
                            obj = Convert.ToBoolean(obj);
                        if (pi.PropertyType.IsEnum)
                            obj = Enum.Parse(pi.PropertyType, obj.ToString());

                        pi.SetValue(t, obj, null);
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// DataTable 转换为List 集合
        /// </summary>
        /// <typeparam name="TResult">类型</typeparam>
        /// <param name="dataTable">DataTable</param>
        /// <returns></returns>
        public static List<TResult> ToList<TResult>(this DataTable dataTable) where TResult : class,new()
        {

            //创建一个属性的列表
            var prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口
            Type t = typeof(TResult);
            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表 
            Array.ForEach(t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty), p => { if (dataTable.Columns.Contains(p.Name)) prlist.Add(p); });
            //创建返回的集合
            var oblist = new List<TResult>();

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //创建TResult的实例
                    var ob = new TResult();
                    //找到对应的数据  并赋值
                    DataRow row1 = row;
                    prlist.ForEach(p => { if (row1[p.Name] != DBNull.Value) p.SetValue(ob, row1[p.Name], null); });
                    //放入到返回的集合中.
                    oblist.Add(ob);
                }
            }


            return oblist;
        }



        /// <summary>
        /// DataTable 转换为List 集合
        /// </summary>
        /// <typeparam name="TResult">类型</typeparam>
        /// <param name="dataTable">DataTable</param>
        /// <returns></returns>
        public static List<string> ToStringList(this DataTable dt)
        {
            List<string> list = new List<string>();
            var obj = from n in dt.AsEnumerable() select n[0].ToString();
            if (obj != null)
            {
                list = obj.ToList<string>();
            }
            return list;
        }

        /// <summary>
        /// DataTable 转换为List 集合
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dataTable">DataTable</param>
        /// <returns></returns>
        public static List<T> ToEntityList<T>(this DataTable dataTable) where T : class,new()
        {
            //创建一个属性的列表
            var prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口
            Type t = typeof(T);
            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表 
            Array.ForEach(t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty), p => { if (dataTable.Columns.Contains(p.Name)) prlist.Add(p); });
            //创建返回的集合
            var oblist = new List<T>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //创建TResult的实例
                    var ob = new T();
                    //找到对应的数据  并赋值
                    DataRow row1 = row;
                    prlist.ForEach(p =>
                    {
                        if (row1[p.Name] != DBNull.Value)
                        {
                            try
                            {
                                object value = new object();
                                if (p.PropertyType == typeof(int) || p.PropertyType == typeof(int?))
                                    value = Convert.ToInt32(row1[p.Name]);
                                if (p.PropertyType == typeof(float) || p.PropertyType == typeof(double)
                                  || p.PropertyType == typeof(float?) || p.PropertyType == typeof(double?))
                                    value = Convert.ToDouble(row1[p.Name]);
                                if (p.PropertyType == typeof(decimal) || p.PropertyType == typeof(decimal?))
                                    value = Convert.ToDecimal(row1[p.Name]);
                                if (p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?))
                                    value = Convert.ToDateTime(row1[p.Name]);
                                if (p.PropertyType == typeof(bool) || p.PropertyType == typeof(bool?))
                                    value = Convert.ToBoolean(row1[p.Name]);
                                if (p.PropertyType == typeof(string))
                                    value = row1[p.Name].ToString();
                                if (p.PropertyType.IsEnum)
                                    value = Enum.Parse(p.PropertyType, row1[p.Name].ToString());
                                p.SetValue(ob, value, null);
                            }
                            catch
                            {
                                p.SetValue(ob, row1[p.Name].ToString(), null);
                            }
                        }
                    });
                    //放入到返回的集合中.
                    oblist.Add(ob);
                }
            }
            return oblist;
        }

        /// <summary>
        /// DbDataReader 转换为List 集合
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dataReader">DataTable</param>
        /// <returns></returns>
        public static List<T> ToEntityList<T>(this DbDataReader dataReader) where T : class,new()
        {
            List<T> listT = new List<T>();
            using (dataReader)
            {
                while (dataReader.Read())
                {
                    T inst = new T();
                    foreach (var pi in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        var obj = new object();
                        try
                        {
                            obj = dataReader[pi.Name];
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        if (obj == DBNull.Value || obj == null)
                            continue;
                        var si = pi.GetSetMethod();
                        if (si == null)
                            continue;

                        if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(int?))
                            obj = Convert.ToInt32(obj);
                        if (pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(float) || pi.PropertyType == typeof(double)
                            || pi.PropertyType == typeof(decimal?) || pi.PropertyType == typeof(float?) || pi.PropertyType == typeof(double?))
                            obj = Convert.ToDecimal(obj);
                        if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?))
                            obj = Convert.ToDateTime(obj);
                        if (pi.PropertyType == typeof(float) || pi.PropertyType == typeof(float?))
                            obj = Convert.ToDecimal(obj);
                        if (pi.PropertyType == typeof(bool) || pi.PropertyType == typeof(bool?))
                            obj = Convert.ToBoolean(obj);
                        if (pi.PropertyType.IsEnum)
                            obj = Enum.Parse(pi.PropertyType, obj.ToString());

                        pi.SetValue(inst, obj, null);
                    }
                    listT.Add(inst);
                }
            }
            return listT;
        }

        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <param name="data">要验证的对象</param>
        public static bool IsNullOrEmpty(this object data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data is string)
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data is DBNull)
            {
                return true;
            }

            //不为空
            return false;
        }

        #region 转换为整型


        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt32(this object obj)
        {
            if (obj == null)
                return 0;
            if (Equals(obj, DBNull.Value))
                return 0;
            if (Equals(obj.ToString().ToLower().Trim(), "system.object"))
                return 0;
            if (Equals(obj.ToString().Trim(), String.Empty))
                return 0;
            int i;
            if (Int32.TryParse(obj.ToString(), out i))
            {
                return i;
            }
            return 0;
        }

        public static int ToInt32(this String obj)
        {
            if (String.IsNullOrEmpty(obj) || Equals(obj.Trim(), String.Empty))
                return 0;
            if (Equals(obj, DBNull.Value))
                return 0;
            if (String.IsNullOrEmpty(obj.Trim()))
                return 0;
            if (Equals(obj.ToLower().Trim(), "system.object"))
                return 0;
            int i;
            if (Int32.TryParse(obj.Trim(), out i))
            {
                return i;
            }
            return 0;
        }


        public static int ToInt32(this float obj)
        {
            return Convert.ToInt32(obj);
        }

        public static int ToInt32(this double obj)
        {
            return Convert.ToInt32(obj);
        }

        public static int ToInt32(this UInt32 obj)
        {
            return Convert.ToInt32(obj);
        }

        public static int ToInt32(this long obj)
        {
            return Convert.ToInt32(obj);
        }

        public static int ToInt32(this decimal obj)
        {
            return Convert.ToInt32(obj);
        }


        #endregion

        #region 转换为长整型

        /// <summary>
        /// 转换为长整型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ToLong(this object obj)
        {
            if (obj == null)
                return 0;
            if (Equals(obj.ToString(), String.Empty))
                return 0;
            if (Equals(obj, DBNull.Value))
                return 0;
            if (Equals(obj.ToString().ToLower().Trim(), "system.object"))
                return 0;
            long i;
            if (Int64.TryParse(obj.ToString(), out i))
            {
                return i;
            }
            return 0;
        }

        public static long ToLong(this String obj)
        {
            if (obj == null)
                return 0;
            if (Equals(obj.Trim(), String.Empty))
                return 0;
            if (Equals(obj, DBNull.Value))
                return 0;
            if (Equals(obj.ToLower().Trim(), "system.object"))
                return 0;
            long i;
            if (Int64.TryParse(obj, out i))
            {
                return i;
            }
            return 0;
        }

        public static long ToLong(this int obj)
        {
            return Convert.ToInt64(obj);
        }

        public static long ToLong(this float obj)
        {
            return Convert.ToInt64(obj);
        }

        public static long ToLong(this double obj)
        {
            return Convert.ToInt64(obj);
        }

        public static long ToLong(this UInt32 obj)
        {
            return Convert.ToInt64(obj);
        }

        #endregion

        #region 转换为浮点型

        /// <summary>
        /// 转换为浮点型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float ToFloat(this object obj)
        {
            if (obj == null)
                return 0;
            if (Equals(obj.ToString(), String.Empty))
                return 0;
            if (Equals(obj, DBNull.Value))
                return 0;
            if (Equals(obj.ToString().ToLower().Trim(), "system.object"))
                return 0;
            float i;
            if (float.TryParse(obj.ToString(), out i))
            {
                return i;
            }
            return 0;
        }

        public static float ToFloat(this String obj)
        {
            if (obj == null)
                return 0;
            if (Equals(obj.Trim(), String.Empty))
                return 0;
            if (Equals(obj, DBNull.Value))
                return 0;
            if (Equals(obj.ToLower().Trim(), "system.object"))
                return 0;
            float i;
            if (float.TryParse(obj, out i))
            {
                return i;
            }
            return 0;
        }

        public static float ToFloat(this int obj)
        {
            return Convert.ToInt64(obj);
        }

        public static float ToFloat(this double obj)
        {
            return Convert.ToInt64(obj);
        }

        public static float ToFloat(this UInt32 obj)
        {
            return Convert.ToInt64(obj);
        }

        public static long ToFloat(this long obj)
        {
            return Convert.ToInt64(obj);
        }
        #endregion

        #region 转化成双精度类型

        /// <summary>
        /// 转化成double类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDouble(this object obj)
        {
            if (obj == null)
                return 0;
            if (obj == DBNull.Value)
                return 0;
            if (obj.ToString().ToLower().Trim() == "system.object")
                return 0;
            if (String.IsNullOrEmpty(obj.ToString().Trim()))
                return 0;
            double i;
            if (double.TryParse(obj.ToString(), out i))
            {
                return i;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDouble(this String obj)
        {
            if (obj == null)
                return 0;
            if (String.IsNullOrEmpty(obj))
                return 0;
            if (obj.ToLower().Trim() == "system.object")
                return 0;
            if (String.IsNullOrEmpty(obj.Trim()))
                return 0;
            double i;
            if (double.TryParse(obj, out i))
            {
                return i;
            }
            return 0;
        }

        public static double ToDouble(this int obj)
        {
            return Convert.ToDouble(obj);
        }

        public static double ToDouble(this float obj)
        {
            return Convert.ToDouble(obj);
        }

        public static double ToDouble(this UInt32 obj)
        {
            return Convert.ToDouble(obj);
        }

        public static double ToDouble(this long obj)
        {
            return Convert.ToDouble(obj);
        }

        #endregion

        #region 转换为高精度型

        /// <summary>
        /// 转换为高精度型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object obj)
        {
            if (obj == null)
                return 0;
            if (obj == DBNull.Value)
                return 0;
            if (obj.ToString().ToLower().Trim() == "system.object")
                return 0;
            if (String.IsNullOrEmpty(obj.ToString().Trim()))
                return 0;
            decimal i;
            if (decimal.TryParse(obj.ToString(), out i))
            {
                return i;
            }
            return 0;
        }

        /// <summary>
        /// 转换为高精度型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this String obj)
        {
            if (obj == null)
                return 0;
            if (String.IsNullOrEmpty(obj.Trim()))
                return 0;
            if (obj.ToLower().Trim() == "system.object")
                return 0;
            decimal i;
            if (decimal.TryParse(obj, out i))
            {
                return i;
            }
            return 0;
        }

        public static string ToDecimalStringEX(this String obj, int num = 4, bool isEmpty = true)
        {
            if (obj.IsNullOrEmpty())
            {
                return obj;
            }
            decimal i;
            if (decimal.TryParse(obj, out i))
            {
                if (i == 0 && isEmpty == true)
                {
                    return "";
                }
                else
                {
                    string decimalNum = "#0.";
                    for (int j = 1; j <= num; j++)
                    {
                        decimalNum = decimalNum + "0";
                    }
                    return i.ToString(decimalNum);
                }
            }
            return obj;
        }

        //如果传入参数为空则不进行转换
        public static object ToDecimalEX(this String obj)
        {
            if (obj.IsNullOrEmpty())
            {
                return obj;
            }
            else
            {
                return obj.ToDecimal();
            }
        }

        public static decimal ToDecimal(this int obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static decimal ToDecimal(this float obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static decimal ToDecimal(this double obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static decimal ToDecimal(this UInt32 obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static decimal ToDecimal(this long obj)
        {
            return Convert.ToDecimal(obj);
        }

        #endregion

        #region 日期转字符

        /// <summary>
        /// 日期转字符
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>如果日期是1753/01/01 00:00:00（数据库最小时间）则返回空字符串；其他情况返回yyyy-MM-dd格式日期字符串</returns>
        public static String ToDateString(this object obj, string dateFormat = "yyyy-MM-dd")
        {
            if (SqlDateTime.MinValue.Value == obj.ToDateTime() || DateTime.MinValue == obj.ToDateTime())
            {
                return string.Empty;
            }
            return obj.ToDateTime().ToString(dateFormat);
        }

        /// <summary>
        /// 日期转字符
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>如果日期是1753/01/01 00:00:00（数据库最小时间）则返回空字符串；其他情况返回yyyy-MM-dd格式日期字符串</returns>
        public static String ToDateString(this DateTime obj, string dateFormat = "yyyy-MM-dd")
        {
            if (SqlDateTime.MinValue.Value == obj || DateTime.MinValue == obj)
            {
                return string.Empty;
            }
            return obj.ToString(dateFormat);
        }

        /// <summary>
        /// 日期转字符
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>如果日期是1753/01/01 00:00:00（数据库最小时间）则返回空字符串；其他情况返回yyyy-MM-dd格式日期字符串</returns>
        public static String ToYearMonthDateString(this DateTime obj)
        {
            if (SqlDateTime.MinValue.Value == obj || DateTime.MinValue == obj)
            {
                return string.Empty;
            }
            return obj.ToString("yyyy-MM");
        }

        #endregion

        #region 转换为日期型

        /// <summary>
        /// 转换为日期型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>转换失败是返回1753/01/01 00:00:00（数据库最小时间）</returns>
        public static DateTime ToDateTime(this object obj)
        {
            if (obj == null)
                return SqlDateTime.MinValue.Value;
            if (obj == DBNull.Value)
                return SqlDateTime.MinValue.Value;
            if (obj.ToString().ToLower().Trim() == "system.object")
                return SqlDateTime.MinValue.Value;
            if (String.IsNullOrEmpty(obj.ToString().Trim()))
                return SqlDateTime.MinValue.Value;
            DateTime i;
            if (DateTime.TryParse(obj.ToString(), out i))
            {
                return i;
            }
            return SqlDateTime.MinValue.Value;
        }

        /// <summary>
        /// 转换为日期型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>如果是1753/01/01 00:00:00（数据库最小时间），则返回空值</returns>
        public static DateTime? ToDateTime(this DateTime obj)
        {
            if (obj == SqlDateTime.MinValue.Value || obj == new DateTime(1, 1, 1))
                return null;
            return obj;
        }

        /// <summary>
        /// 转换为日期型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>转换失败是返回1753/01/01 00:00:00（数据库最小时间）</returns>
        public static DateTime ToDateTime(this String obj)
        {
            if (obj == null)
                return SqlDateTime.MinValue.Value;
            if (String.IsNullOrEmpty(obj.Trim()))
                return SqlDateTime.MinValue.Value;
            if (obj.ToLower().Trim() == "system.object")
                return SqlDateTime.MinValue.Value;
            DateTime i;
            if (DateTime.TryParse(obj, out i))
            {
                return i;
            }
            return SqlDateTime.MinValue.Value;
        }

        /// <summary>
        /// 转换为日期型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>为空时返回为空</returns>
        public static DateTime? ToDateTimes(this String obj)
        {
            if (obj == null)
                return null;
            if (String.IsNullOrEmpty(obj.Trim()))
                return null;
            if (obj.ToLower().Trim() == "system.object")
                return null;
            DateTime i;
            if (DateTime.TryParse(obj, out i))
            {
                return i;
            }
            return null;
        }

        #endregion

        #region 转换为小数

        /// <summary>
        /// 保留四位小数
        /// </summary>
        /// <param name="dblData"></param>
        /// <returns></returns>
        public static string ToFormartNumerFourData(object dblData)
        {
            return String.Format("{0:N4}", dblData);
        }

        /// <summary>
        /// 保留两位小数
        /// </summary>
        /// <param name="dblData"></param>
        /// <returns></returns>
        public static string ToFormartNumerTwoDataValue(object dblData)
        {
            return String.Format("{0:N2}", dblData);
        }

        #endregion

        #region 转换成String类型

        /// <summary>
        /// 日期型默认值
        /// </summary>
        public static readonly DateTime DateTimeDefaultValue = new DateTime(1900, 1, 1);
        /// <summary>
        /// 转换为String
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return "";
            }
            else
            {
                return inputValue;
            }
        }



        /// <summary>
        /// 转换为String
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(short inputValue)
        {
            return inputValue.ToString();
        }

        /// <summary>
        /// 转换为String
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(int inputValue)
        {
            return inputValue.ToString();
        }

        /// <summary>
        /// 转换为String
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(long inputValue)
        {
            return inputValue.ToString();
        }

        /// <summary>
        /// 转换为String
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(decimal inputValue)
        {
            return inputValue.ToString();
        }

        /// <summary>
        /// 转换为String
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(float inputValue)
        {
            return inputValue.ToString();
        }

        /// <summary>
        /// 转换为String
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(double inputValue)
        {
            return inputValue.ToString();
        }

        /// <summary>
        /// 转换为String
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(bool inputValue)
        {
            return inputValue.ToString();
        }

        /// <summary>
        /// 转换为String
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(object inputValue)
        {
            try
            {
                if (inputValue == null || inputValue == DBNull.Value)
                {
                    return "";
                }
                else
                {
                    return ToString(inputValue.ToString());
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 将枚举项转换为String类型(返回枚举索引值)
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(Enum inputValue)
        {
            return ToString(ToInt32(inputValue));
        }

        /// <summary>
        /// 将char数组转换为String类型
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToString(char[] inputValue)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                foreach (char c in inputValue)
                {
                    str.Append(c.ToString());
                }
                return str.ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 字符串型默认值
        /// </summary>
        public static readonly String StringDefaultValue = String.Empty;

        /// <summary>
        /// IsNullOrEmpty封装
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }


        /// <summary>
        /// object类型转化为string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String ToStringEx(this object obj)
        {
            if (obj == null || Equals(obj.ToString().ToLower().Trim(), "system.object"))
                return String.Empty;


            return obj.ToString().Trim();
        }

        ///   <summary> 
        ///   将指定字符串按指定长度进行截取并加上指定的后缀
        ///   </summary> 
        ///   <param   name= "oldStr "> 需要截断的字符串 </param> 
        ///   <param   name= "maxLength "> 字符串的最大长度 </param> 
        ///   <param   name= "endWith "> 超过长度的后缀 </param> 
        ///   <returns> 如果超过长度，返回截断后的新字符串加上后缀，否则，返回原字符串 </returns> 
        public static string ToStringOmit(this object obj, int Len = 30, string StrMore = "......")
        {
            if (obj == null || Equals(obj.ToString().ToLower().Trim(), "system.object"))
                return String.Empty;
            string outstr = string.Empty;
            int n = 0;
            foreach (char ch in obj.ToStringEx())
            {
                n += System.Text.Encoding.Default.GetByteCount(ch.ToString());
                if (n > Len)
                {
                    if (StrMore != null)
                        outstr += StrMore;
                    break;
                }
                else
                    outstr += ch;
            }
            return outstr;
        }
        /// <summary>
        /// 获取object类型的length长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Int32 LengthEx(this object obj)
        {
            if (obj == null || Equals(obj.ToString().ToLower().Trim(), "system.object"))
                return 0;

            return obj.ToString().Trim().Length;
        }
        #endregion

        #region 将List<string>转换成Json格式

        public static string ToJson(this List<string> dtlist)
        {
            if (dtlist == null || dtlist.Count == 0)
            {
                return "[]";
            }

            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            foreach (var s in dtlist)
            {
                jsonBuilder.Append("\"" + s + "\"");
                jsonBuilder.Append(",");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("];");
            return jsonBuilder.ToString();
        }

        #endregion

        /// <summary>
        /// 判断字符串是否包含某些内容
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool IsContainsWords(this string source, params string[] args)
        {
            if (string.IsNullOrWhiteSpace(source) || args.Length == 0) return false;

            return args.Any(source.Contains);
        }

        /// <summary>
        /// 判断字符串是否不包含某些内容
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool NotContainsWords(this string source, params string[] args)
        {
            if (string.IsNullOrWhiteSpace(source) || args.Length == 0) return true;

            return args.All(p => !source.Contains(p));
        }

        /// <summary>
        /// 判断是不是身份证号码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsCardNumber(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, @"^\d{18}|\d{17}x$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 隐藏身份证号码部分数字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string DealWithCardNumber(this string source)
        {
            if (string.IsNullOrEmpty(source)) return source;

            source = source.Trim();

            if (!IsCardNumber(source)) return source;

            return source.Substring(0, 10) + "****" + source.Substring(14);
        }

        /// <summary>
        /// 判断是否为数字字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNumber(this string source)
        {
            return !string.IsNullOrEmpty(source) && Regex.IsMatch(source, @"^\d{1,9}$");
        }

        /// <summary>
        /// 字符串中的数字是否大于或等于被比较字符串中的数字
        /// </summary>
        /// <param name="source"></param>
        /// <param name="compareValue"></param>
        /// <returns></returns>
        public static bool IsGreaterThanOrEqualTo(this string source, string compareValue)
        {
            if (!source.IsNumber() || !compareValue.IsNumber()) return false;

            return int.Parse(source) >= int.Parse(compareValue);
        }

        /// <summary>
        /// 是否为空字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// 是否不为空字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNullOrWhiteSpace(this string source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// 从JSON字符串获取类型别表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(this string source) where T : class
        {
            if (source.IsNullOrWhiteSpace()) return null;

            return JsonConvert.DeserializeObject<List<T>>(source);
        }

        public static List<string> GetList(this string source, string split)
        {
            if (source.IsNullOrWhiteSpace()) return null;
            return new List<string>(source.Split(new string[] { split }, StringSplitOptions.RemoveEmptyEntries));
        }


        /// <summary>
        /// 连接字符串列表
        /// </summary>
        /// <param name="source"></param> 
        /// <returns></returns>
        public static string ConvertToString(this List<string> source)
        {
            return source.ConvertToString("|||");
        }

        /// <summary>
        /// 连接字符串列表
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ConvertToString(this List<string> source, string separator)
        {
            return (source == null || source.Count == 0) ? string.Empty : string.Join(separator, source);
        }



        /// <summary>
        /// 转换列表成Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertToJson<T>(this List<T> source) where T : class
        {
            return source.IsNullOrEmpty() ? null : JsonConvert.SerializeObject(source);
        }

        /// <summary>
        /// 判断列表是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this List<T> source) where T : class
        {
            return source == null || source.Count == 0;
        }

        /// <summary>
        /// 判断列表是否不为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty<T>(this List<T> source) where T : class
        {
            return !source.IsNullOrEmpty();
        }

        /// <summary>
        /// 获取指定长度的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetSubstring(this string str, int num)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            int length = str.Length;
            if (length > num)
            {
                length = num;
                return str.Substring(0, length);
            }
            else
            {
                return str;
            }
        }
    }
}
