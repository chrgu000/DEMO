using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ϵͳ����.Bll
{
    class ClsRoleRightBll
    {
        private static readonly ϵͳ����.Dal.ClsRoleRightDal dal = new ϵͳ����.Dal.ClsRoleRightDal();

        public ClsRoleRightBll()
		{ }


        public void Add(string sPK,DataTable dt)
        {
            dal.AddSQL(sPK,dt);
        }
    }
}
