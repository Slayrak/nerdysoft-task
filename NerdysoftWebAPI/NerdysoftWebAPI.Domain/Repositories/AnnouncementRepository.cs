using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NerdysoftWebAPI.Database.Dto_s;
using NerdysoftWebAPI.Database.Interfaces;
using NerdysoftWebAPI.Database.Models;

namespace NerdysoftWebAPI.Database.Repositories;
public class AnnouncementRepository : IAnnouncementRepository
{
    private readonly AppDbContext _appDbContext;
    public AnnouncementRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<long> AddAnnouncement(AnnouncementModel announcementDTO)
    {
        await _appDbContext.AddAsync(announcementDTO);
        await _appDbContext.SaveChangesAsync();

        return announcementDTO.Id;
    }

    public async Task DeleteAnnouncement(long id)
    {
        _appDbContext.Remove(await _appDbContext.Announcements.FirstAsync(x => x.Id == id));
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<AnnouncementModel>> GetAllAnnouncements()
    {
        return await _appDbContext.Announcements.ToListAsync();
    }

    public async Task<IEnumerable<AnnouncementModel>> GetSimilarAnnouncements(long id)
    {
        var announcement = await _appDbContext.Announcements.FirstOrDefaultAsync(x => x.Id == id);

        var result = new List<AnnouncementModel> { announcement };

        var announcementTitleWords = announcement.Title.Split(' ');
        var announcementDescriptionWords = announcement.Description.Split(' ');

        var check = announcementTitleWords.Any(word => _appDbContext.Announcements.ToList()[0].Title.Contains(word));

        var selectedAnnouncements = _appDbContext.Announcements.ToList().Where(obj =>
            announcementTitleWords.Any(word => obj.Title.Split(' ').Contains(word)) &&
            announcementDescriptionWords.Any(word => obj.Description.Split(' ').Contains(word)) &&
            obj.Id != id
        ).Take(3);

        result.AddRange(selectedAnnouncements);

        return result;
    }

    public async Task<AnnouncementModel> UpdateAnnouncement(AnnouncementModel announcement)
    {
        _appDbContext.Announcements.Update(announcement);
        await _appDbContext.SaveChangesAsync();
        return announcement;
    }
}
