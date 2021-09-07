using System.ServiceModel;

namespace DockerWcfDemo
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Hello(string name);
    }
}
