import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { PostFeedComponent } from './post-feed.component';
import { PostFeedRoutingModule } from './post-feed-routing.module';
import { GetPostService } from 'src/app/services/social-network/post-feed/get-post.service';

@NgModule({
  declarations: [
    PostFeedComponent
  ],
  imports: [
    PostFeedRoutingModule,
    SharedModule
  ],
  providers: [GetPostService]
})
export class PostFeedModule { }
