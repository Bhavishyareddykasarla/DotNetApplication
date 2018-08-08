using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProductsAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Software> GetSoftwares();

        [OperationContract]
        int AddSoftware(string Name, string Version, string LicenceType, int Rank);

        [OperationContract]
        Software GetSoftwareById(int id);

        [OperationContract]
        int UpdateSoftware(int Id, string Name, string Version, string LicenceType, int Rank);

        [OperationContract]
        int DeleteSoftwareById(int Id);



        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Software
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public int Rank { get; set; }
        [DataMember]
        public string LicenceType { get; set; }


    }
}
