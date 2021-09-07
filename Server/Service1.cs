using System;
using System.Text;

namespace DockerWcfDemo
{
    public class Service1 : IService1
    {
        public string Hello(string name)
        {
            return new StringBuilder(string.Format("Hello '{0}' from Container!", name))
                .AppendLine()
                .Append(nameof(Environment.OSVersion)).Append(": ").AppendLine(Environment.OSVersion.ToString())
                .Append(nameof(Environment.ProcessorCount)).Append(": ").AppendLine(Environment.ProcessorCount.ToString())
                .Append(nameof(Environment.UserName)).Append(": ").AppendLine(Environment.UserName)
                .Append(nameof(Environment.MachineName)).Append(": ").AppendLine(Environment.MachineName)
                .Append("Host").Append(": ").AppendLine(Environment.GetEnvironmentVariable("HOSTNAME"))
                .ToString();
        }
    }

}
