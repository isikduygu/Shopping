import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxFileDropEntry } from 'ngx-file-drop';
import { IProductImage } from 'src/app/models/IProductImage';
import { ToastService } from 'src/app/services/toast.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent implements OnInit {

  constructor(private httpClient: HttpClient, private toastService: ToastService) { }

  ngOnInit(): void {
  }

  @Input() options!: Partial<UploadFileOptions> ;
  @Output('OnProductImageAdded') productImageAddedEvent: EventEmitter<IProductImage> =
  new EventEmitter();
  apiUrl: string = environment.apiUrl;
  
  public files!: NgxFileDropEntry[];

  public dropped(files: NgxFileDropEntry[]) {
    this.files = files;
    for (const droppedFile of files) {

        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {

          // Here you can access the real file
          // console.log(droppedFile.relativePath, file);

          // You could upload it like this:
          const formData = new FormData()
          formData.append(file.name, file, droppedFile.relativePath)
          
          const headers = new HttpHeaders({
            'security-token': 'mytoken'
          })
          const url= this.options.url;
          this.httpClient.post(url as any, formData, { headers: headers, responseType: 'blob' })
          .subscribe(data => {
            // Sanitized logo returned from backend
              this.toastService.showToast({
              icon: 'success',
              title: 'Successfully added.',
            });
            this.productImageAddedEvent.emit();
          }
          )
        });
      }
    }
}
export class UploadFileOptions {
  accept? : any;
  explanation? : string;
  url?: string;
}

// we used ngx-file-drop library
