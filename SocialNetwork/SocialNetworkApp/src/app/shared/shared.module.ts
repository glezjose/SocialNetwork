import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgZorroAntdModule} from 'ng-zorro-antd';
import { FeedbackModule } from './feedback/feedback.module';
import { CustomModalComponent } from './feedback/modal/custom-modal.component';

@NgModule({
  imports: [
    CommonModule,
    NgZorroAntdModule,
    FeedbackModule
  ],
  exports: [
    CommonModule,
    NgZorroAntdModule,
    FeedbackModule
  ],
  declarations: []
})
export class SharedModule { }
