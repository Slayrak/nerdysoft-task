using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdysoftWebAPI.Database.Dto_s;
public class AnnouncementModelDTO
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DateAdded { get; set; }
}
