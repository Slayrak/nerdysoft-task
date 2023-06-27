using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NerdysoftWebAPI.Database.Dto_s;

namespace NerdysoftWebAPI.Database.Interfaces;
public interface IAnnouncementRepository
{
    Task<long> AddAnnouncement(AnnouncementModelDTO announcementDTO);
    Task<AnnouncementModelDTO> UpdateAnnouncement(AnnouncementModelDTO announcementDTO);
    Task DeleteAnnouncement(long id);

    Task<IEnumerable<AnnouncementModelDTO>> GetAllAnnouncements();
    Task<IEnumerable<AnnouncementModelDTO>> GetSimilarAnnouncements(AnnouncementModelDTO announcementDTO);

}
