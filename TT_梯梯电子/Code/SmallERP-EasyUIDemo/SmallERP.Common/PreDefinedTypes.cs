using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmallERP.Common
{
    /// <summary>
    /// CLR预定义的一些类型
    /// </summary>
    public static class PreDefinedTypes
    {
        /// <summary>
        /// 类型：String
        /// </summary>
        public readonly static Type String;

        /// <summary>
        /// 类型：Int32
        /// </summary>
        public readonly static Type Int32;

        /// <summary>
        /// 类型：Int64
        /// </summary>
        public readonly static Type Int64;

        /// <summary>
        /// 类型：Int16
        /// </summary>
        public readonly static Type Int16;

        /// <summary>
        /// 类型：DateTime
        /// </summary>
        public readonly static Type DateTime;

        /// <summary>
        /// 类型：Boolean
        /// </summary>
        public readonly static Type Boolean;

        /// <summary>
        /// 类型：Double
        /// </summary>
        public readonly static Type Double;

        /// <summary>
        /// 类型：Decimal
        /// </summary>
        public readonly static Type Decimal;

        /// <summary>
        /// 类型：Single(float)
        /// </summary>
        public readonly static Type Float;

        /// <summary>
        /// 类型：Guid
        /// </summary>
        public readonly static Type Guid;

        /// <summary>
        /// 类型：UInt64
        /// </summary>
        public readonly static Type UInt64;

        /// <summary>
        /// 类型：UInt32
        /// </summary>
        public readonly static Type UInt32;

        /// <summary>
        /// 类型：UInt16
        /// </summary>
        public readonly static Type UInt16;

        /// <summary>
        /// 类型：Char
        /// </summary>
        public readonly static Type Char;

        /// <summary>
        /// 类型：Byte
        /// </summary>
        public readonly static Type Byte;

        /// <summary>
        /// 类型：SByte
        /// </summary>
        public readonly static Type SByte;

        /// <summary>
        /// 类型：Byte[]
        /// </summary>
        public readonly static Type ByteArray;

        /// <summary>
        /// 类型：String[]
        /// </summary>
        public readonly static Type StringArray;

        /// <summary>
        /// 类型：Object
        /// </summary>
        public readonly static Type Object;

        /// <summary>
        /// 类型：void
        /// </summary>
        public readonly static Type Void;

        /// <summary>
        /// 类型：Nullable&lt;&gt;
        /// </summary>
        public readonly static Type NullableGeneric;

        /// <summary>
        /// 类型：Int16?
        /// </summary>
        public readonly static Type NullableInt16;

        /// <summary>
        /// 类型：Int32?
        /// </summary>
        public readonly static Type NullableInt32;

        /// <summary>
        /// 类型：Int64?
        /// </summary>
        public readonly static Type NullableInt64;

        /// <summary>
        /// 类型：UInt16?
        /// </summary>
        public readonly static Type NullableUInt16;

        /// <summary>
        /// 类型：UInt32?
        /// </summary>
        public readonly static Type NullableUInt32;

        /// <summary>
        /// 类型：UInt64?
        /// </summary>
        public readonly static Type NullableUInt64;

        /// <summary>
        /// 类型：DateTime?
        /// </summary>
        public readonly static Type NullableDateTime;

        /// <summary>
        /// 类型：Boolean?
        /// </summary>
        public readonly static Type NullableBoolean;

        /// <summary>
        /// 类型：Double?
        /// </summary>
        public readonly static Type NullableDouble;

        /// <summary>
        /// 类型：Decimal?
        /// </summary>
        public readonly static Type NullableDecimal;

        /// <summary>
        /// 类型：Single? (float?)
        /// </summary>
        public readonly static Type NullableFloat;

        /// <summary>
        /// 类型：Guid?
        /// </summary>
        public readonly static Type NullableGuid;

        /// <summary>
        /// 类型：Byte?
        /// </summary>
        public readonly static Type NullableByte;

        /// <summary>
        /// 类型：SByte?
        /// </summary>
        public readonly static Type NullableSByte;

        /// <summary>
        /// 类型：IEnumerable
        /// </summary>
        public readonly static Type IEnumerable;

        /// <summary>
        /// 类型：IEnumerable&lt;&gt;
        /// </summary>
        public readonly static Type IEnumerableGeneric;

        /// <summary>
        /// 类型：IList&lt;&gt;
        /// </summary>
        public readonly static Type IListGeneric;

        /// <summary>
        /// 类型：List&lt;&gt;
        /// </summary>
        public readonly static Type ListGeneric;

        /// <summary>
        /// 类型：HttpContext
        /// </summary>
        public readonly static Type HttpContext;

        /// <summary>
        /// 类型：HttpRequest
        /// </summary>
        public readonly static Type HttpRequest;

        /// <summary>
        /// <para>简单类型定义：</para>
        /// <para>　　String, Int16,  Int32, Int64, DateTime, Boolean, Double, Decimal, Float, Guid</para>
        /// <para>　　UInt16, UInt32, UInt64, Char, Byte, SByte, Byte[], String[], Nullable&lt;简单类型&gt;</para>
        /// </summary>
        public readonly static Type[] SimpleTypes;

        static PreDefinedTypes()
        {
            PreDefinedTypes.String = typeof(string);
            PreDefinedTypes.Int32 = typeof(int);
            PreDefinedTypes.Int64 = typeof(long);
            PreDefinedTypes.Int16 = typeof(short);
            PreDefinedTypes.DateTime = typeof(DateTime);
            PreDefinedTypes.Boolean = typeof(bool);
            PreDefinedTypes.Double = typeof(double);
            PreDefinedTypes.Decimal = typeof(decimal);
            PreDefinedTypes.Float = typeof(float);
            PreDefinedTypes.Guid = typeof(Guid);
            PreDefinedTypes.UInt64 = typeof(ulong);
            PreDefinedTypes.UInt32 = typeof(uint);
            PreDefinedTypes.UInt16 = typeof(ushort);
            PreDefinedTypes.Char = typeof(char);
            PreDefinedTypes.Byte = typeof(byte);
            PreDefinedTypes.SByte = typeof(sbyte);
            PreDefinedTypes.ByteArray = typeof(byte[]);
            PreDefinedTypes.StringArray = typeof(string[]);
            PreDefinedTypes.Object = typeof(object);
            PreDefinedTypes.Void = typeof(void);
            PreDefinedTypes.NullableGeneric = typeof(Nullable<>);
            PreDefinedTypes.NullableInt16 = typeof(short?);
            PreDefinedTypes.NullableInt32 = typeof(int?);
            PreDefinedTypes.NullableInt64 = typeof(long?);
            PreDefinedTypes.NullableUInt16 = typeof(ushort?);
            PreDefinedTypes.NullableUInt32 = typeof(uint?);
            PreDefinedTypes.NullableUInt64 = typeof(ulong?);
            PreDefinedTypes.NullableDateTime = typeof(DateTime?);
            PreDefinedTypes.NullableBoolean = typeof(bool?);
            PreDefinedTypes.NullableDouble = typeof(double?);
            PreDefinedTypes.NullableDecimal = typeof(decimal?);
            PreDefinedTypes.NullableFloat = typeof(float?);
            PreDefinedTypes.NullableGuid = typeof(Guid?);
            PreDefinedTypes.NullableByte = typeof(byte?);
            PreDefinedTypes.NullableSByte = typeof(sbyte?);
            PreDefinedTypes.IEnumerable = typeof(IEnumerable);
            PreDefinedTypes.IEnumerableGeneric = typeof(IEnumerable<>);
            PreDefinedTypes.IListGeneric = typeof(IList<>);
            PreDefinedTypes.ListGeneric = typeof(List<>);
            PreDefinedTypes.HttpContext = typeof(HttpContext);
            PreDefinedTypes.HttpRequest = typeof(HttpRequest);
            Type[] num = new Type[] { PreDefinedTypes.Int16, PreDefinedTypes.Int32, PreDefinedTypes.Int64, PreDefinedTypes.UInt16, PreDefinedTypes.UInt32, PreDefinedTypes.UInt64, PreDefinedTypes.String, PreDefinedTypes.DateTime, PreDefinedTypes.Boolean, PreDefinedTypes.Double, PreDefinedTypes.Decimal, PreDefinedTypes.Float, PreDefinedTypes.Guid, PreDefinedTypes.Char, PreDefinedTypes.Byte, PreDefinedTypes.SByte, PreDefinedTypes.ByteArray, PreDefinedTypes.StringArray, PreDefinedTypes.NullableInt16, PreDefinedTypes.NullableInt32, PreDefinedTypes.NullableInt64, PreDefinedTypes.NullableUInt16, PreDefinedTypes.NullableUInt32, PreDefinedTypes.NullableUInt64, PreDefinedTypes.NullableDateTime, PreDefinedTypes.NullableBoolean, PreDefinedTypes.NullableDouble, PreDefinedTypes.NullableDecimal, PreDefinedTypes.NullableFloat, PreDefinedTypes.NullableGuid };
            PreDefinedTypes.SimpleTypes = num;
        }
    }
}
