import { Component, ComponentRef } from '@angular/core';
import {
  IModalDialog,
  IModalDialogButton,
  IModalDialogOptions,
} from 'ngx-modal-dialog';

@Component({
  selector: 'app-confirmation-modal',
  templateUrl: './confirmation-modal.component.html',
  styleUrls: ['./confirmation-modal.component.css'],
})
export class ConfirmationModalComponent implements IModalDialog {
  actionButtons: IModalDialogButton[];

  constructor() {
    this.actionButtons = [
      { buttonClass: 'btn btn-secondary', text: 'Cancel' },
      { buttonClass: 'btn btn-danger', text: 'Delete', onAction: () => true },
    ];
  }

  onSave() {
    console.log('Save click');
  }

  dialogInit(
    reference: ComponentRef<IModalDialog>,
    options: Partial<IModalDialogOptions<any>>
  ) {
    // no processing needed
  }
}
