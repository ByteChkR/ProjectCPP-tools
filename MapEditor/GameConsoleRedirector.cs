using System.IO;
using System.Threading;
using System.Diagnostics;
using ADL;
namespace MapEditor
{
    public class GameConsoleRedirector
    {
        Thread thread = null;
        TextReader cOut;
        Process _engineProc;

        public GameConsoleRedirector()
        {
            //SHIT
        }

        public static GameConsoleRedirector CreateRedirector(StreamReader consoleOut, Process engine)
        {
            GameConsoleRedirector gcr = new GameConsoleRedirector();
            gcr._engineProc = engine;
            gcr.cOut = consoleOut;
            return gcr;
        }

        public void StartThread()
        {
            if (thread == null)
            {
                thread = new Thread(Start);
            }
            else
            {
                thread.Abort();
            }
            thread.Start();
        }

        public void StopThread()
        {
            if (thread == null) return;
            thread.Abort();
        }

        public void Start()
        {
            string txt = "";
            while (!_engineProc.HasExited)
            {
                txt = cOut.ReadLine();

                if (txt != "") ADL.Debug.LogGen(LoggingChannel.MGE_ENGINE_CONSOLE_OUT, txt);
            }
        }

    }
}
