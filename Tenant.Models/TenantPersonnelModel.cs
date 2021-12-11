using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant.Models
{
    public class TenantPersonnelModel
    {
        public TenantPersonnelModel()
        {

        }
        public TenantPersonnelModel(int? tenantId, string firstName, string nickName, string lastName,string middleName,DateTime dOB, bool active, int prefixId ,int genderId)
        {
            this.TenantId = tenantId;
            this.FirstName = firstName;
            this.NickName = nickName;
            this.MiddleName = middleName;
            this.DOB = dOB;
            this.Active = active;
            this.PrefixId = prefixId;
            this.LastName = lastName;
            this.GenderId = genderId;
        }
        public int? TenantId { get; set; }
        public  string FirstName { get; set; }
        public string MiddleName { get; set; }
        public  string LastName { get; set; }
        public  string NickName { get; set; }
        public  DateTime DOB { get; set; }
        public  bool Active { get; set; }
        public  int PrefixId { get; set; }
        public  int GenderId { get; set; }
        public GenderModel GenderFk { get; set; }
   
    }
}
