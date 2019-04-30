using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallERP.Domain
{


    /// <summary>
    /// 添加账号对象
    /// </summary>
    public class AddAdminDomain
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string UserId { get; set; }

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
        public string RoleId { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
    }

    /// <summary>
    /// 更新账号对象
    /// </summary>
    public class UpdateAdminDomain
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsDisabled
        {
            get
            {
                return IsDisabledText == "on";
            }
        }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用于EasyUI的 SwitchButton，值 on/off/null
        /// </summary>
        public string IsDisabledText { get; set; }
    }

    /// <summary>
    /// 查询账号参数
    /// </summary>
    public class SearchAdminDomain : PagingDomain
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }

    public class AdminResultDomain
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserId { get; set; }

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
        public string RoleId { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

    }

    /// <summary>
    /// 登录用户对象
    /// </summary>
    public class LoginUserDomain
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    /// <summary>
    /// 后台当前登录人员
    /// </summary>
    public class CurrentUserDomain
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string LoginId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }
    }

    public class UserDomain
    {
        public string UserID { get; set; }
        public string Email { get; set; }
    }

}
