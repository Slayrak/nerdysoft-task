using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using NerdysoftWebAPI.Database.Models;

namespace NerdysoftWebAPI.Database;
public static class DataSeed
{
    public static void SeedData(AppDbContext appDbContext)
    {
        if(!appDbContext.Announcements.Any())
        {
            var announcementList = new List<AnnouncementModel>();

            for (int i = 0; i < 15; i++)
            {
                var fake = new Faker<AnnouncementModel>()
                            .RuleFor(x => x.Description, x => x.Lorem.Paragraph());

                var record = fake.Generate();

                record.Id = i;
                record.Title = $"I am Title {i}";
                announcementList.Add(record);
            }

            appDbContext.Announcements.AddRange(announcementList);
            appDbContext.SaveChanges();
        }
    }
}
