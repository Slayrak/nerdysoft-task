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

            //Bogus does not provide titles so I will go with my set of titles
            var titles = new List<string>
            {
                "Title One",
                "Title Two",
                "Title Three",
                "Powerwolf",
                "Conference today",
                "Random event",
                "Planned event",
                "Title Four",
                "Lorem Ipsum",
                "I don't know what to say"
            };

            for (int i = 0; i < 10; i++)
            {
                var fake = new Faker<AnnouncementModel>()
                            .RuleFor(x => x.Description, x => x.Lorem.Paragraph());

                var record = fake.Generate();

                record.Id = i + 1;
                record.Title = titles[i];
                announcementList.Add(record);
            }

            appDbContext.Announcements.AddRange(announcementList);
            appDbContext.SaveChanges();
        }
    }
}
