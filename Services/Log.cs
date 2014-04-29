using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using log4net;

namespace Services
{
    public class Log
    {
        private static readonly ILog iLog = LogManager.GetLogger("WZNTLogger");


        public static void LOG_START() 
        {
            string caller = string.Empty;
            string method = "LOG_START";

            caller = GetCallingMethod(method);

            string msg = !String.IsNullOrEmpty(caller) ? String.Format("{0} - Started", caller) : String.Format("UNDEFINED - Started", caller);

            iLog.Info(msg);
        }
        public static void LOG_END()
        {
            string caller = string.Empty;
            string method = "LOG_END";

            caller = GetCallingMethod(method);

            string msg = !String.IsNullOrEmpty(caller) ? String.Format("{0} - Ended", caller) : String.Format("UNDEFINED - Ended", caller);

            iLog.Info(msg);
        }

        public static void Debug(string message)
        {
            string caller = string.Empty;
            string method = "Info";

            caller = GetCallingMethod(method);

            string msg = !String.IsNullOrEmpty(caller) ? String.Format("{0} - {1}", caller, message) : String.Format("UNDEFINED - {0}", message);

            iLog.Debug(msg);
        }

        public static void Info(string message)
        {
            string caller = string.Empty;
            string method = "Info";

            caller = GetCallingMethod(method);

            string msg = !String.IsNullOrEmpty(caller) ? String.Format("{0} - {1}", caller, message) : String.Format("UNDEFINED - {0}", message);

            iLog.Info(msg);
        }
        public static void Error(string message)
        {
            string caller = string.Empty;
            string method = "Error";

            caller = GetCallingMethod(method);

            string msg = !String.IsNullOrEmpty(caller) ? String.Format("{0} - {1}", caller, message) : String.Format("UNDEFINED - {0}", message);

            iLog.Error(msg);
        }
        public static void Warning(string message)
        {
            string caller = string.Empty;
            string method = "Warning";

            caller = GetCallingMethod(method);

            string msg = !String.IsNullOrEmpty(caller) ? String.Format("{0} - {1}", caller, message) : String.Format("UNDEFINED - {0}", message);

            iLog.Warn(msg);
        }


        private static string GetCallingMethod(string MethodAfter)
        {
            string str = "";
            try
            {
                StackTrace st = new StackTrace();
                StackFrame[] frames = st.GetFrames();
                for (int i = 0; i < st.FrameCount - 1; i++)
                {
                    if (frames[i].GetMethod().Name.Equals(MethodAfter))
                    {
                        if (!frames[i + 1].GetMethod().Name.Equals(MethodAfter)) // ignores overloaded methods.
                        {
                            str = frames[i + 1].GetMethod().ReflectedType.FullName + "." + frames[i + 1].GetMethod().Name;
                            break;
                        }
                    }
                }
            }
            catch (Exception) { ; }
            return str;
        }

        // RFC - For tests purposes only
        public static float Divide(int a, int b)
        {
            if (a != 0 && b != 0)
            {
                return a / b;
            }
            else
            {
                throw new ArithmeticException();
            }
        }

    }
}
