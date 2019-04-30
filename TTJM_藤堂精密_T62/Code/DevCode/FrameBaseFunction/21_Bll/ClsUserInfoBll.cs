using System;
using System.Collections.Generic;
using System.Text;

namespace FrameBaseFunction.Bll
{
    class ClsUserInfoBll
    {
        FrameBaseFunction.Dal.ClsUserInfoDal clsDal = new FrameBaseFunction.Dal.ClsUserInfoDal();

        #region  成员方法
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string sUserid)
        {
            if (sUserid == "admin" || sUserid == "system")
                throw new Exception("admin/system 是预置帐号不能删除！");

            if (sUserid == FrameBaseFunction.ClsBaseDataInfo.sUid)
                throw new Exception(sUserid + " 是当前登陆帐号不能删除！");

            clsDal.Delete(sUserid);
        }

        #endregion  成员方法
    }
}
