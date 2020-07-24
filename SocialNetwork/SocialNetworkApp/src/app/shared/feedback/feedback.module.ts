import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { ModalDirective } from './directives/modal.directive';
import { CustomModalComponent } from './modal/custom-modal.component';

@NgModule({
  imports: [
    CommonModule,
    NgZorroAntdModule
  ],
  exports:[
    ModalDirective
  ],
  declarations: [
    ModalDirective,
    CustomModalComponent
  ],
  entryComponents: [
    CustomModalComponent
  ]
})
export class FeedbackModule { }
