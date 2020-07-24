import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PostFeedComponent } from './post-feed.component';

const routes: Routes = [
  { path: '', component: PostFeedComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PostFeedRoutingModule { }
