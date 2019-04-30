using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMMWS
{
    public class MailNotifyInfo
    {
        public string Title
        {

            get;
            set;

        }



        /// <summary>

        /// 获取或设置稿件的作者名称。

        /// </summary>

        public string Author
        {
            get;
            set;
        }



        /// <summary>

        /// 获取或设置作者的电子邮件地址。

        /// </summary>

        public string EmailAddress
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置稿件的状态。
        /// </summary>

        
    }
}