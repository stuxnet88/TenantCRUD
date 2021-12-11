using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tenant.Repositories
{
    [Table("TenantPersonnel")]
    public class TenantPersonnel
    {

        public TenantPersonnel(int? tenantId, string firstName, string nickName, string lastName, string middleName, DateTime dOB, bool active, int prefixId,int genderId)
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
        [Key]
        public int? TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string LastName { get; set; }
        [StringLength(50)]
        public virtual string NickName { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual bool Active { get; set; }
        public virtual int PrefixId { get; set; }
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender GenderFk { get; set; }
    }
}

