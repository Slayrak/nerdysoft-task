import { Component, EventEmitter, Input, OnInit, Output, ViewChild, ElementRef } from '@angular/core';

import { AnnouncementDTO } from 'src/app/models/dtos/announcement.dto'
import { AnnouncementService } from 'src/app/services/announcement.service'

import {deepCopy} from "@angular-devkit/core/src/utils/object";

@Component({
  selector: 'app-announcements',
  templateUrl: './announcements.component.html',
  styleUrls: ['./announcements.component.scss']
})
export class AnnouncementsComponent implements OnInit {

  @Input() announcement: AnnouncementDTO;
  @Output() announcementChange = new EventEmitter<AnnouncementDTO>();

  @Output() refresh: EventEmitter<void> = new EventEmitter<void>();

  @ViewChild('updateDialog') updateDialog!: ElementRef<HTMLDialogElement>;
  @ViewChild('similarDialog') similarDialog!: ElementRef<HTMLDialogElement>;

  announcementModel: AnnouncementDTO = {
    title: '',
    id: 0,
    description: '',
    dateAdded: new Date()
  }

  announcements: AnnouncementDTO[]

  constructor(private announcementService: AnnouncementService) { }
  
  ngOnInit(): void {
    this.announcementModel = deepCopy(this.announcement);
  }

  public closeDialog() {
    this.announcementModel = deepCopy(this.announcement);
    this.updateDialog.nativeElement.close()
  }

  closeSimilarDialog() {
    this.similarDialog.nativeElement.close()
  }

  public openDialog() {
    this.updateDialog.nativeElement.showModal()
  }

  openSimilarDialog() {
    this.showDetails();
    this.similarDialog.nativeElement.showModal()
  }

  updateAnnouncement() {
    this.announcementService.updateAnnouncement(this.announcementModel).subscribe (
      response => {
        this.announcement.description = this.announcementModel.description;
        this.announcement.title = this.announcementModel.title;

        this.announcementChange.emit(this.announcement)

        this.closeDialog();
      },
      error => {
        console.log("Error updating a record: ", error)
      }
    )
  }

  showDetails() {
    this.announcementService.getSelectedOne(this.announcement.id).subscribe(
      response => {
        this.announcements = response

      },
      error => {
        console.log("Error retrieving details: ", error)
      }
    )
  }

  deleteRecord() {
    this.announcementService.delete(this.announcement.id).subscribe (
      response => {
        this.refresh.emit();
      },
      error => {
        console.log("Error deleting a record: ", error)
      }
    )
  }
}
