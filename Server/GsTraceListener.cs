using System;
using System.Diagnostics;

namespace DockerWcfDemo
{
    public class GsTraceListener : TextWriterTraceListener
    {
        public override void WriteLine(string message)
        {
            base.WriteLine(message);

            Console.WriteLine(message + Environment.NewLine);
        }
    }
}
