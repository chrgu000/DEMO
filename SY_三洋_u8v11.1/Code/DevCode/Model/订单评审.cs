using System;
using System.Collections.Generic;
namespace TH.Model
{
    /// <summary>
    /// 实体类订单评审 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class 订单评审
    {
        public 订单评审()
        { }
        #region Model
        private int _iid;
        private string _存货编码;
        private decimal? _待评审数量;
        private DateTime? _交货日期;
        private decimal? _订单数量;
        private decimal? _已评审数量;
        private string _销售订单子表id;
        private decimal? _数量;
        private string _备注;
        private string _制单人;
        private DateTime? _制单日期;
        private string _评审单据号;
        private string _锁定人;
        private DateTime? _锁定日期;
        private string _审核人;
        private DateTime? _审核日期;
        private string _关闭人;
        private DateTime? _关闭日期;
        private string _下达请购人;
        private DateTime? _下达请购日期;
        private string _下达委外人;
        private DateTime? _下达委外日期;
        private DateTime? _评审单据日期;
        private string _下达生产人;
        private DateTime? _下达生产日期;
        private Guid _guid;
        private string _帐套号;
        private string _销售订单号;
        private string _单据日期;
        private string _客户编码;
        private string _客户简称;
        private string _行号;
        /// <summary>
        /// 
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 存货编码
        {
            set { _存货编码 = value; }
            get { return _存货编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 待评审数量
        {
            set { _待评审数量 = value; }
            get { return _待评审数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 交货日期
        {
            set { _交货日期 = value; }
            get { return _交货日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 订单数量
        {
            set { _订单数量 = value; }
            get { return _订单数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 已评审数量
        {
            set { _已评审数量 = value; }
            get { return _已评审数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 销售订单子表ID
        {
            set { _销售订单子表id = value; }
            get { return _销售订单子表id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 数量
        {
            set { _数量 = value; }
            get { return _数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 制单人
        {
            set { _制单人 = value; }
            get { return _制单人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 制单日期
        {
            set { _制单日期 = value; }
            get { return _制单日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 评审单据号
        {
            set { _评审单据号 = value; }
            get { return _评审单据号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 锁定人
        {
            set { _锁定人 = value; }
            get { return _锁定人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 锁定日期
        {
            set { _锁定日期 = value; }
            get { return _锁定日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 审核人
        {
            set { _审核人 = value; }
            get { return _审核人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 审核日期
        {
            set { _审核日期 = value; }
            get { return _审核日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 关闭人
        {
            set { _关闭人 = value; }
            get { return _关闭人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 关闭日期
        {
            set { _关闭日期 = value; }
            get { return _关闭日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 下达请购人
        {
            set { _下达请购人 = value; }
            get { return _下达请购人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 下达请购日期
        {
            set { _下达请购日期 = value; }
            get { return _下达请购日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 下达委外人
        {
            set { _下达委外人 = value; }
            get { return _下达委外人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 下达委外日期
        {
            set { _下达委外日期 = value; }
            get { return _下达委外日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 评审单据日期
        {
            set { _评审单据日期 = value; }
            get { return _评审单据日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 下达生产人
        {
            set { _下达生产人 = value; }
            get { return _下达生产人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 下达生产日期
        {
            set { _下达生产日期 = value; }
            get { return _下达生产日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 帐套号
        {
            set { _帐套号 = value; }
            get { return _帐套号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 销售订单号
        {
            set { _销售订单号 = value; }
            get { return _销售订单号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 单据日期
        {
            set { _单据日期 = value; }
            get { return _单据日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 客户编码
        {
            set { _客户编码 = value; }
            get { return _客户编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 客户简称
        {
            set { _客户简称 = value; }
            get { return _客户简称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 行号
        {
            set { _行号 = value; }
            get { return _行号; }
        }
        #endregion Model

        private List<订单评审明细> _订单评审明细s;
        /// <summary>
        /// 子类 
        /// </summary>
        public List<订单评审明细> 订单评审明细s
        {
            set { _订单评审明细s = value; }
            get { return _订单评审明细s; }
        }

    }
    /// <summary>
    /// 实体类订单评审明细 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class 订单评审明细
    {
        public 订单评审明细()
        { }
        #region Model
        private int _iid;
        private string _母件计量单位;
        private decimal? _母件损耗率;
        private string _版本代号;
        private string _版本说明;
        private DateTime? _版本日期;
        private string _状态;
        private string _母件属性;
        private string _变更单号;
        private string _行号;
        private string _子件行号;
        private string _评审单据号;
        private string _工序行号;
        private string _子件编码;
        private string _子件名称;
        private string _子件代号;
        private string _子件规格;
        private string _子件计量单位;
        private decimal? _基本用量;
        private decimal? _基础用量;
        private decimal? _子件损耗率;
        private string _固定用量;
        private string _序号;
        private string _供应类型;
        private decimal? _单阶使用数量;
        private decimal? _加成数量;
        private decimal? _换算率;
        private DateTime? _子件生效日;
        private DateTime? _子件失效日;
        private int? _偏置期;
        private decimal? _计划比例;
        private string _产出品;
        private string _产出类型;
        private string _级别;
        private bool _成本相关;
        private bool _可选否;
        private string _选择规则;
        private string _备注;
        private string _子件属性;
        private string _母子关联;
        private string _销售订单号;
        private string _销售订单行号;
        private int? _销售订单子表id;
        private decimal? _需求数量;
        private string _顶级母件编码;
        private decimal? _评审数量;
        private decimal? _本单需求数量;
        private DateTime? _交货日期;
        private DateTime? _开始日期;
        private DateTime? _结束日期;
        private int? _评审采购周期;
        private int? _评审委外周期;
        private decimal? _单件默认生产工时;
        private string _默认产线;
        private decimal? _质检周期;
        private string _母件编码;
        private decimal? _生产准备时间;
        private decimal? _经济批量;
        private decimal? _置办周期;
        private decimal? _生产合计工时;
        private decimal? _默认产线并发生产数;
        private decimal? _仓库存量;
        private decimal? _待入库数量;
        private decimal? _待出库数量;
        private string _销售单号;
        private string _仓库编码;
        private string _母件名称;
        private string _仓库名称;
        private string _领料部门编码;
        private string _生产部门编码;
        private Guid _guidhead;
        private Guid _guid;
        private string _母件代号;
        private string _母件规格;
        /// <summary>
        /// 
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 母件计量单位
        {
            set { _母件计量单位 = value; }
            get { return _母件计量单位; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 母件损耗率
        {
            set { _母件损耗率 = value; }
            get { return _母件损耗率; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 版本代号
        {
            set { _版本代号 = value; }
            get { return _版本代号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 版本说明
        {
            set { _版本说明 = value; }
            get { return _版本说明; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 版本日期
        {
            set { _版本日期 = value; }
            get { return _版本日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 状态
        {
            set { _状态 = value; }
            get { return _状态; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 母件属性
        {
            set { _母件属性 = value; }
            get { return _母件属性; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 变更单号
        {
            set { _变更单号 = value; }
            get { return _变更单号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 行号
        {
            set { _行号 = value; }
            get { return _行号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 子件行号
        {
            set { _子件行号 = value; }
            get { return _子件行号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 评审单据号
        {
            set { _评审单据号 = value; }
            get { return _评审单据号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 工序行号
        {
            set { _工序行号 = value; }
            get { return _工序行号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 子件编码
        {
            set { _子件编码 = value; }
            get { return _子件编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 子件名称
        {
            set { _子件名称 = value; }
            get { return _子件名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 子件代号
        {
            set { _子件代号 = value; }
            get { return _子件代号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 子件规格
        {
            set { _子件规格 = value; }
            get { return _子件规格; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 子件计量单位
        {
            set { _子件计量单位 = value; }
            get { return _子件计量单位; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 基本用量
        {
            set { _基本用量 = value; }
            get { return _基本用量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 基础用量
        {
            set { _基础用量 = value; }
            get { return _基础用量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 子件损耗率
        {
            set { _子件损耗率 = value; }
            get { return _子件损耗率; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 固定用量
        {
            set { _固定用量 = value; }
            get { return _固定用量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 序号
        {
            set { _序号 = value; }
            get { return _序号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 供应类型
        {
            set { _供应类型 = value; }
            get { return _供应类型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 单阶使用数量
        {
            set { _单阶使用数量 = value; }
            get { return _单阶使用数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 加成数量
        {
            set { _加成数量 = value; }
            get { return _加成数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 换算率
        {
            set { _换算率 = value; }
            get { return _换算率; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 子件生效日
        {
            set { _子件生效日 = value; }
            get { return _子件生效日; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 子件失效日
        {
            set { _子件失效日 = value; }
            get { return _子件失效日; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 偏置期
        {
            set { _偏置期 = value; }
            get { return _偏置期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 计划比例
        {
            set { _计划比例 = value; }
            get { return _计划比例; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 产出品
        {
            set { _产出品 = value; }
            get { return _产出品; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 产出类型
        {
            set { _产出类型 = value; }
            get { return _产出类型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 级别
        {
            set { _级别 = value; }
            get { return _级别; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool 成本相关
        {
            set { _成本相关 = value; }
            get { return _成本相关; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool 可选否
        {
            set { _可选否 = value; }
            get { return _可选否; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 选择规则
        {
            set { _选择规则 = value; }
            get { return _选择规则; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 子件属性
        {
            set { _子件属性 = value; }
            get { return _子件属性; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 母子关联
        {
            set { _母子关联 = value; }
            get { return _母子关联; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 销售订单号
        {
            set { _销售订单号 = value; }
            get { return _销售订单号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 销售订单行号
        {
            set { _销售订单行号 = value; }
            get { return _销售订单行号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 销售订单子表ID
        {
            set { _销售订单子表id = value; }
            get { return _销售订单子表id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 需求数量
        {
            set { _需求数量 = value; }
            get { return _需求数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 顶级母件编码
        {
            set { _顶级母件编码 = value; }
            get { return _顶级母件编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 评审数量
        {
            set { _评审数量 = value; }
            get { return _评审数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 本单需求数量
        {
            set { _本单需求数量 = value; }
            get { return _本单需求数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 交货日期
        {
            set { _交货日期 = value; }
            get { return _交货日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 开始日期
        {
            set { _开始日期 = value; }
            get { return _开始日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 结束日期
        {
            set { _结束日期 = value; }
            get { return _结束日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 评审采购周期
        {
            set { _评审采购周期 = value; }
            get { return _评审采购周期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 评审委外周期
        {
            set { _评审委外周期 = value; }
            get { return _评审委外周期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 单件默认生产工时
        {
            set { _单件默认生产工时 = value; }
            get { return _单件默认生产工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 默认产线
        {
            set { _默认产线 = value; }
            get { return _默认产线; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 质检周期
        {
            set { _质检周期 = value; }
            get { return _质检周期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 母件编码
        {
            set { _母件编码 = value; }
            get { return _母件编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 生产准备时间
        {
            set { _生产准备时间 = value; }
            get { return _生产准备时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 经济批量
        {
            set { _经济批量 = value; }
            get { return _经济批量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 置办周期
        {
            set { _置办周期 = value; }
            get { return _置办周期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 生产合计工时
        {
            set { _生产合计工时 = value; }
            get { return _生产合计工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 默认产线并发生产数
        {
            set { _默认产线并发生产数 = value; }
            get { return _默认产线并发生产数; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 仓库存量
        {
            set { _仓库存量 = value; }
            get { return _仓库存量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 待入库数量
        {
            set { _待入库数量 = value; }
            get { return _待入库数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 待出库数量
        {
            set { _待出库数量 = value; }
            get { return _待出库数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 销售单号
        {
            set { _销售单号 = value; }
            get { return _销售单号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 仓库编码
        {
            set { _仓库编码 = value; }
            get { return _仓库编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 母件名称
        {
            set { _母件名称 = value; }
            get { return _母件名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 仓库名称
        {
            set { _仓库名称 = value; }
            get { return _仓库名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 领料部门编码
        {
            set { _领料部门编码 = value; }
            get { return _领料部门编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 生产部门编码
        {
            set { _生产部门编码 = value; }
            get { return _生产部门编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid GUIDHead
        {
            set { _guidhead = value; }
            get { return _guidhead; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid GUID
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 母件代号
        {
            set { _母件代号 = value; }
            get { return _母件代号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 母件规格
        {
            set { _母件规格 = value; }
            get { return _母件规格; }
        }
        #endregion Model

    }
}

