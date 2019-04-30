using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallERP.Entity
{
    /// <summary>
    /// t_common_attachment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_common_attachmentEntity
    {
        public t_common_attachmentEntity()
        { }
        #region Model
        private string _id;
        private string _source_id;
        private string _source_item;
        private string _original_name;
        private string _path;
        private string _value1;
        private string _value2;
        private string _value3;
        private string _createdby;
        private DateTime _createddate;
        /// <summary>
        /// 
        /// </summary>
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string source_id
        {
            set { _source_id = value; }
            get { return _source_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string source_item
        {
            set { _source_item = value; }
            get { return _source_item; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string original_name
        {
            set { _original_name = value; }
            get { return _original_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value1
        {
            set { _value1 = value; }
            get { return _value1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value2
        {
            set { _value2 = value; }
            get { return _value2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value3
        {
            set { _value3 = value; }
            get { return _value3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string createdby
        {
            set { _createdby = value; }
            get { return _createdby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createddate
        {
            set { _createddate = value; }
            get { return _createddate; }
        }
        #endregion Model



    }
}

