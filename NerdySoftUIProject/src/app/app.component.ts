import { error } from '@angular/compiler/src/util';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AnnouncementService } from 'src/app/services/announcement.service'
import { AnnouncementDTO } from './models/dtos/announcement.dto';

import { FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'NerdySoftUIProject';
  announcements: AnnouncementDTO[]
  announcementModel: AnnouncementDTO = {
    title: '',
    id: 0,
    description: '',
    dateAdded: new Date()
  }

  constructor(
    private announcementService: AnnouncementService,
    private formBuilder: FormBuilder,
    ) { }

  @ViewChild('addDialog') addDialog!: ElementRef<HTMLDialogElement>;
  
  ngOnInit(): void {
    this.getAll();
  }

  public closeDialog() {
    this.addDialog.nativeElement.close()
  }

  public openDialog() {
    this.addDialog.nativeElement.showModal()
  }

  addAnnouncement() {

    console.log(this.announcementModel);

    this.announcementService.addAnnouncement(this.announcementModel).subscribe(
      response => {
        this.getAll();
        this.closeDialog();
      },
      error => {
        console.error("Error adding a records: ", error);
      }
    )
  }

  getAll() {
    this.announcementService.getAllAnnouncements().subscribe(
      response => {
        this.announcements = response
      },
      error => {
        console.error("Error retrieving all records: ", error);
      }
    );
  }

  refreshPage() {
    this.getAll();
  }
}



