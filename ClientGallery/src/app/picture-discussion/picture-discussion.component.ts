import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from '../../environments/environment';
import { Picture } from '../pictures/picture';
import { PictureService } from '../pictures/picture.service';

@Component({
  selector: 'app-picture-discussion',
  templateUrl: './picture-discussion.component.html',
  styleUrls: ['./picture-discussion.component.css']
})
export class PictureDiscussionComponent implements OnInit {

  pictureId?: number;
  picture!: Picture;

  env = environment;

  /*
  title: string='';
  artistName: string = '';
  imgPath: string = '';
  */
  constructor(private activatedRoute: ActivatedRoute,private pictureService: PictureService) { }

  ngOnInit(): void {

    this.loadPicture();
  }


  loadPicture() {

    var idParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.pictureId = idParam ? +idParam : 0;

    //Send id , to pictureService , that are respons.to get specific Picture
    //by id from api(My backend).
    this.pictureService.getPictureById(this.pictureId).subscribe((result) => {
      this.picture = result;
      this.picture.imgPath = this.env.imgUrl + '/' + result.imgPath;
    }, error => console.error(error));

    //I want to show , that I could not send request to api , to get
    //specific picture , because on main page we getting all pictures with all data
    //that we need (Author name and Title).But in general if we need to get additional data
    //we sending request to pictures/id api , that I created and show that it works.
    /*

    // Get the query parameters
    this.activatedRoute.queryParamMap.subscribe((params) => {
      this.title = params.get('title')!;
      this.artistName = params.get('artistName')!;
      this.imgPath = params.get('imgPath')!;
    });
    */
  }


  

}
