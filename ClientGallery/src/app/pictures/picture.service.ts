import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Picture } from './picture';

@Injectable({
  providedIn: 'root',
})

export class PictureService {

  constructor(private http: HttpClient) {

  }

  getAllPictures(): Observable<Picture[]> {
    return this.http.get<Picture[]>(environment.baseUrl + "Pictures");
  }

  getPictureById(id:number): Observable<Picture> {
    return this.http.get<Picture>(environment.baseUrl+"Pictures/"+id)
  }

  getPicturesBySearch(query: string): Observable<Picture[]> {
    return this.http.get<Picture[]>(environment.baseUrl + "Pictures" + "/search?query="+query);
  }

}
