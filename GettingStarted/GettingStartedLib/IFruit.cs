using System;
using System.ServiceModel;

namespace GettingStartedLib
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IFruit
    {
        [OperationContract]
        int Add(int n1);
        [OperationContract]
        int Subtract(int n1);
        [OperationContract]
        int Get();
       
    }
}