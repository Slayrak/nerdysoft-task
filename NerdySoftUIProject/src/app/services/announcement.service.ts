import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AnnouncementDTO } from '../models/dtos/announcement.dto';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementService {

  constructor(private http: HttpClient) { }

  getAllAnnouncements() {
    return this.http.get<Array<AnnouncementDTO>>(`https://localhost:7190/api/Announcement`)
  }

  getSelectedOne(id: number) {
    return this.http.get<Array<AnnouncementDTO>>(`https://localhost:7190/api/Announcement/${id}`)
  }

  updateAnnouncement(announcementModel: AnnouncementDTO)
  {
    return this.http.put<AnnouncementDTO>(`https://localhost:7190/api/Announcement`, announcementModel)
  }

  delete(id: number) {
    return this.http.delete(`https://localhost:7190/api/Announcement/${id}`)
  }

  addAnnouncement(announcementModel: AnnouncementDTO) {
    return this.http.post<number>(`https://localhost:7190/api/Announcement`, announcementModel)
  }
}
