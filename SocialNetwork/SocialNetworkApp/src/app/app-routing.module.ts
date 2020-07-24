import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/post-feed' },
  { path: 'post-feed', loadChildren: () => import('./modules/social-network/post-feed/post-feed.module').then(m => m.PostFeedModule) },
  { path: 'friend-feed', loadChildren: () => import('./modules/social-network/friend-feed/friend-feed.module').then(m => m.FriendFeedModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
