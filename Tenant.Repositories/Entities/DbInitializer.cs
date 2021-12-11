using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenant.Repositories
{
    public static class DbInitializer
    {
        public static void Initialize(TenantContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Gender.Any())
            {
                return;   // DB has been seeded
            }

            var genders = new Gender[]
            {
                new Gender{Name = "Male"},
                 new Gender{Name = "Female"}
            };

            context.Gender.AddRange(genders);
            context.SaveChanges();
        }
    }
}
