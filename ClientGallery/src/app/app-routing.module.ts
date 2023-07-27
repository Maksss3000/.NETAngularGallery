import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { PicturesComponent } from './pictures/pictures.component';
import { PictureDiscussionComponent } from './picture-discussion/picture-discussion.component';
const routes: Routes = [
  { path: "", component: PicturesComponent, pathMatch: "full" },
  { path: "picture/:id", component: PictureDiscussionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})

export class AppRoutingModule { }
