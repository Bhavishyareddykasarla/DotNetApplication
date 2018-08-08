using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProductsAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public int AddSoftware(string Name, string Version, string LicenceType, int Rank)
        {
            SoftwaresDBEntities entities = new SoftwaresDBEntities();            
            List list = new List();
            list.Name = Name;
            list.Rank = Rank;
            list.Version = Version;
            list.LicenceType = LicenceType;
            entities.Lists.Add(list);
            int Retval = entities.SaveChanges();
            return Retval;
        }

        public int DeleteSoftwareById(int Id)
        {
            SoftwaresDBEntities entities = new SoftwaresDBEntities();
            Software software = new Software();
            software.Id = Id;
            entities.Entry(software).State = EntityState.Deleted;
            int Retval = entities.SaveChanges();
            return Retval;
        }

        public Software GetSoftwareById(int id)
        {
            SoftwaresDBEntities entities = new SoftwaresDBEntities();
            var softwares = from k in entities.Lists where k.Id == id select k;
            Software usr = new Software();
            foreach (var item in softwares)
            {

                usr.Id = item.Id;
                usr.Name = item.Name;
                usr.Rank = (int)item.Rank;
                usr.Version = item.Version;
                usr.LicenceType = item.LicenceType;


            }

            return usr;
        }

        public List<Software> GetSoftwares()
        {
            List<Software> userlst = new List<Software>();
            SoftwaresDBEntities entities = new SoftwaresDBEntities();
            var softwares = from k in entities.Lists select k;
            foreach (var item in softwares)
            {
                Software usr = new Software();
                usr.Id = item.Id;
                usr.Name = item.Name;
                usr.Version = item.Version;
                usr.Rank = (int)item.Rank;
                usr.LicenceType = item.LicenceType;
                userlst.Add(usr);

            }

            return userlst;
        }

        public int UpdateSoftware(int Id, string Name, string Version, string LicenceType, int Rank)
        {
            SoftwaresDBEntities entities = new SoftwaresDBEntities();
            List software = new List();
            software.Id = Id;
            software.Name = Name;
            software.Rank = Rank;
            software.Version = Version;
            software.LicenceType = LicenceType;
            entities.Entry(software).State = EntityState.Modified;

            int Retval = entities.SaveChanges();
            return Retval;
        }
    }
}
