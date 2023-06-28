using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NerdysoftWebAPI.Database.Dto_s;
using NerdysoftWebAPI.Database.Models;

namespace NerdysoftWebAPI.Database.Interfaces;
public interface IAnnouncementRepository
{
    Task<long> AddAnnouncement(AnnouncementModel announcementDTO);
    Task<AnnouncementModel> UpdateAnnouncement(AnnouncementModel announcementDTO);
    Task DeleteAnnouncement(long id);

    Task<IEnumerable<AnnouncementModel>> GetAllAnnouncements();
    Task<IEnumerable<AnnouncementModel>> GetSimilarAnnouncements(long id);

}
