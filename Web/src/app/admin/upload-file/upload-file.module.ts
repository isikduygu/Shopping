import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UploadFileComponent } from './upload-file.component';
import { NgxFileDropModule } from 'ngx-file-drop';



@NgModule({
  declarations: [UploadFileComponent],
  imports: [
    CommonModule,
    NgxFileDropModule
  ],
  exports: [UploadFileComponent]
})
export class UploadFileModule { }
