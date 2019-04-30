using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 后台用户
    /// </summary>
    public class AdminEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public int? IsDisabled { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 微信账号
        /// </summary>
        public string Wechat { get; set; }
    }
    public partial class AdminView
    {
        public AdminView()
        { }
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public int? IsDisabled { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 微信账号
        /// </summary>
        public string Wechat { get; set; }
    }
}
