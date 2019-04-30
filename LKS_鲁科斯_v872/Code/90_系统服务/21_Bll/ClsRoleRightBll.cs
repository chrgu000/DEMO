using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace 系统服务.Bll
{
    class ClsRoleRightBll
    {
        private static readonly 系统服务.Dal.ClsRoleRightDal dal = new 系统服务.Dal.ClsRoleRightDal();

        public ClsRoleRightBll()
		{ }


        public void Add(string sPK,DataTable dt)
        {
            dal.AddSQL(sPK,dt);
        }
    }
}
