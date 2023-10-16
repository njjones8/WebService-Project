using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BankSubService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // -------------- bank services ----------------
        [OperationContract]
        bool BankWithdraw(string encryptedCC, double value);


        [OperationContract]
        bool BankDeposit(string encryptedCC, double value);

        // --------------- subscription service -------------
        [OperationContract]
        string[] GetSubs(string username);

        [OperationContract]
        bool AddSub(string username, string subscription);

        [OperationContract]
        bool RemoveSub(string username, string subscription);

        // --------------- wind intensity service -------------
        [OperationContract]
        decimal AvgWindIntensity(decimal longitude, decimal latitude);

        // --------------- news service -------------
        [OperationContract]
        string[] GetNews(string[] topics);
    }
}
