using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerdysoftWebAPI.Database.Dto_s;
using NerdysoftWebAPI.Database.Interfaces;
using NerdysoftWebAPI.Database.Models;

namespace NerdysoftWebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnnouncementController : ControllerBase
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IMapper _mapper;

    public AnnouncementController(IAnnouncementRepository announcementRepository, IMapper mapper)
    {
        _announcementRepository = announcementRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddAnnouncement(AnnouncementModelDTO modelDTO)
    {
        var model = _mapper.Map<AnnouncementModel>(modelDTO);

        return Ok(await _announcementRepository.AddAnnouncement(model));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAnnouncement(long id)
    {
        await _announcementRepository.DeleteAnnouncement(id);

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAnnouncement(AnnouncementModelDTO modelDTO)
    {
        var announcementModel = _mapper.Map<AnnouncementModel>(modelDTO);

        var result = await _announcementRepository.UpdateAnnouncement(announcementModel);

        return Ok(_mapper.Map<AnnouncementModelDTO>(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allAnnouncements = await _announcementRepository.GetAllAnnouncements();

        var result = allAnnouncements.Select(x => _mapper.Map<AnnouncementModelDTO>(x)).ToList();

        return Ok(result);
    }

    [HttpGet("get-similar")]
    public async Task<IActionResult> GetSelectedOne(long id)
    {
        var allAnnouncements = await _announcementRepository.GetSimilarAnnouncements(id);

        var result = allAnnouncements.Select(x => _mapper.Map<AnnouncementModelDTO>(x)).ToList();

        return Ok(result);
    }
}
