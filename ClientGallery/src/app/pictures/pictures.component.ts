import { Component, OnInit } from '@angular/core';
import { PictureService } from './picture.service';
import { Picture } from './picture';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Router } from '@angular/router';



@Component({
  selector: 'app-pictures',
  templateUrl: './pictures.component.html',
  styleUrls: ['./pictures.component.css']
})
export class PicturesComponent implements OnInit {

  constructor(private http: HttpClient,
    private pictureService: PictureService,
    private router: Router) { }

  pictures!: Picture[];
  env = environment;
  searchValue: string = '';

  ngOnInit(): void {
    this.loadPictures();
  }

  loadPictures() {

    this.pictureService.getAllPictures().subscribe(result => {
   
        result.map(picture => {
          picture.imgPath = this.env.imgUrl + '/' + picture.imgPath;
        })
        this.pictures = result;
      
    }, error => console.error(error));

  }



  onSearch() {
    this.pictureService.getPicturesBySearch(this.searchValue).subscribe(result => {

      result.map(picture => {
        picture.imgPath = this.env.imgUrl + '/' + picture.imgPath;
      })
      this.pictures = result;

    }, error => console.error(error));
  }
  onPictureClick(picture: Picture) {

    /* Could send also queryParameters and this way could not send request to api.
    this.router.navigate(['/picture', picture.id], {
      queryParams: {
        title: picture.title,
        artistName: picture.artistName,
        imgPath: picture.imgPath
      },
    });
    */

    //Redirecting and passing picture id,to use it in request to Api.
    this.router.navigate(['/picture', picture.id]);
  }
}
