import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { GetPostService } from 'src/app/services/social-network/post-feed/get-post.service';
import { FriendFeedRoutingModule } from './friend-feed-routing.module';
import { FriendFeedComponent } from './friend-feed.component';

@NgModule({
  declarations: [
    FriendFeedComponent
  ],
  imports: [
    FriendFeedRoutingModule,
    SharedModule
  ],
  providers: [GetPostService]
})
export class FriendFeedModule { }