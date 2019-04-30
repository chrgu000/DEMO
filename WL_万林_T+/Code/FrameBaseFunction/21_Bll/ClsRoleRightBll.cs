using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FrameBaseFunction.Bll
{
    class ClsRoleRightBll
    {
        private static readonly FrameBaseFunction.Dal.ClsRoleRightDal dal = new FrameBaseFunction.Dal.ClsRoleRightDal();

        public ClsRoleRightBll()
		{ }


        public void Add(string sPK,DataTable dt)
        {
            dal.AddSQL(sPK,dt);
        }
    }
}
