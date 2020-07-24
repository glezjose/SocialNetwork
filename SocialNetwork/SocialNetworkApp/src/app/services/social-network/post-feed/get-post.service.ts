import { Injectable } from '@angular/core';
import { GetActionService } from 'src/app/core/services/get-action.service';
import { Post } from 'src/app/shared/models/posts/post.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetPostService {

  constructor(private getAction: GetActionService<Post>) { }

  getAll(): Observable<Post[]>{
    return this.getAction.getPostsByUserOrFriends('api/user/','/post', 1);
  }

  getAllFriendsPosts(): Observable<Post[]>{
    return this.getAction.getPostsByUserOrFriends('api/user/','/feed', 1);
  }
}
