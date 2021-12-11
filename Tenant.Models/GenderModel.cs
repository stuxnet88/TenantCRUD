using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant.Models
{
    public class GenderModel
    {
        public GenderModel()
        {

        }

        public GenderModel(int genderId,string name)
        {
            this.GenderId = genderId;
            this.Name = name;
        }
        public int GenderId { get; set; }
        public  string Name { get; set; }
    }
}
