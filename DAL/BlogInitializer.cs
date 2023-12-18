using System.Collections.Generic;
using System;
using System.Data.Entity;

namespace DAL
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<AdminInfo> adminInfos = new List<AdminInfo>();

            adminInfos.Add(new AdminInfo() { Email = "charankovvali@gmail.com", Password = "charan@123" });
            adminInfos.Add(new AdminInfo() { Email = "sai@gmail.com", Password = "sai@123" });

            context.AdminInfos.AddRange(adminInfos);
            context.SaveChanges();

            List<EmpInfo> empInfos = new List<EmpInfo>();
            empInfos.Add(new EmpInfo() { Email = "sahithi@gmail.com", PassCode = 7, DateOfJoining = new DateTime(2019, 01, 05), Name = "Sahithi" });
            empInfos.Add(new EmpInfo() { Email = "sivasai@gmail.com", PassCode = 8, DateOfJoining = new DateTime(2020, 06, 08), Name = "Sivasai" });
            empInfos.Add(new EmpInfo() { Email = "vara@gmail.com", PassCode = 9, DateOfJoining = new DateTime(2020, 10, 05), Name = "vara" });
            context.EmpInfos.AddRange(empInfos);
            context.SaveChanges();

            List<BlogInfo> blogInfos = new List<BlogInfo>();
            blogInfos.Add(new BlogInfo() { Email = "vara@gmail.com", BlogUrl = "https://mercedesblog.com/", DateOfCreation = new DateTime(2021, 06, 10), Subject = "Engine", Title = "Mercedes" });
            blogInfos.Add(new BlogInfo() { Email = "sivasai@gmail.com", BlogUrl = "https://www.digitalcameraworld.com/reviews/canon-rf-200-800mm-f63-9-is-usm-review", DateOfCreation = new DateTime(2020, 04, 11), Subject = "Lens", Title = "Canon" });
            blogInfos.Add(new BlogInfo() { Email = "sahithi@gmail.com", BlogUrl = "https://www.jigsawplanet.com/", DateOfCreation = new DateTime(2021, 02, 04), Subject = "Solving", Title = "Puzzles" });
            context.BlogInfos.AddRange(blogInfos);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}