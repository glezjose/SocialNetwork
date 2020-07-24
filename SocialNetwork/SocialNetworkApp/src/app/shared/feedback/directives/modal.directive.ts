import { Directive, Input, HostListener, Output, EventEmitter } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd';
import { CustomModalComponent } from '../modal/custom-modal.component';

@Directive({
  selector: '[appModal]'
})
export class ModalDirective {

  @Input() nzContent: string;

  constructor(private modal: NzModalService) { }

  @HostListener('click', ['$event']) onClick($event) {

    const modal = this.modal.create({
      nzContent: CustomModalComponent,
      nzComponentParams: {
        nzContent: this.nzContent
      },
      nzWidth: 1000,
      nzFooter: null,
      nzOnCancel: () => {
        modal.destroy();
      }
    });
  }
}

