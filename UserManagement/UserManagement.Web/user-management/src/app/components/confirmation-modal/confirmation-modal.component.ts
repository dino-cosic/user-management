import { Component } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirmation-modal',
  templateUrl: './confirmation-modal.component.html',
  styleUrls: ['./confirmation-modal.component.css'],
})
export class ConfirmationModalComponent {
  constructor(private modalService: NgbActiveModal) {}

  onSave() {
    this.modalService.close('save');
  }
  onClose() {
    this.modalService.close();
  }
}
