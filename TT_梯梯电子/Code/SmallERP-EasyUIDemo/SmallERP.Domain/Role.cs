using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallERP.Domain
{
    /// <summary>
    /// 添加角色 提交表单数据
    /// </summary>
    public class AddRoleDomain
    {
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// 编辑角色 提交表单数据
    /// </summary>
    public class UpdateRoleDomain
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Description { get; set; }
    }
}
