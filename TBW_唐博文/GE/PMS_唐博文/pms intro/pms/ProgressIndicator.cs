using System;
using DevExpress.Services;
using DevExpress.Web.ASPxEditors;
using DevExpress.XtraEditors;

namespace PMMWS
{
    public class ProgressIndicator:IProgressIndicationService
    {
        private ASPxProgressBar _Indica;
        public ASPxProgressBar Indica
        {
            get { return _Indica;}
            set { _Indica = value; }
        }
        public ProgressIndicator(IServiceProvider provider, ASPxProgressBar indicator)
        {
            _Indica = indicator;
        }
        void IProgressIndicationService.Begin(string displayName, int minProgress, int maxProgress, int currentProgress)
        {
            _Indica.Minimum = minProgress;
            _Indica.Maximum = maxProgress;
            _Indica.Value = currentProgress;
            _Indica.Visible = true;
        }
        void IProgressIndicationService.End()
        {
            _Indica.Visible = false; 
        }
        void IProgressIndicationService.SetProgress(int currentProgress)
        {
            _Indica.Value = currentProgress;
        }

    }
}