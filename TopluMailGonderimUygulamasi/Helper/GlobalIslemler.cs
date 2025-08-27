using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopluMailGonderimUygulamasi.Helper
{
    public class GlobalIslemler
    {
        public void tryCatchKullan(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                string EXStr = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                var Logger = NLog.LogManager.GetCurrentClassLogger();
                Logger.Log(LogLevel.Error, EXStr);
            }
        }
    }
}
