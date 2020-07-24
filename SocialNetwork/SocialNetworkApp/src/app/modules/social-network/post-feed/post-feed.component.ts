import { Component, OnInit } from '@angular/core';
import { GetPostService } from 'src/app/services/social-network/post-feed/get-post.service';
import { Post } from 'src/app/shared/models/posts/post.model';

@Component({
  selector: 'app-post-feed',
  templateUrl: './post-feed.component.html',
  styleUrls: ['./post-feed.component.css']
})
export class PostFeedComponent implements OnInit {

  posts: Post[] = [];
  loading = true;
   
  constructor(private getPostService: GetPostService) { }

  ngOnInit() {
    this.getData();
  }
  
  getData() {
    this.getPostService.getAll().subscribe(
      x => {
        this.posts = [...x];
        console.log(this.posts);
      });
  }
}
