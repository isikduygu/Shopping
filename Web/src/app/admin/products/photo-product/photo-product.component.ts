import { Component, Inject, Input, OnInit, Output } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IProductImage } from 'src/app/models/IProductImage';
import { ProductImageService } from 'src/app/services/product-image.service';
import { ToastService } from 'src/app/services/toast.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { UploadFileOptions } from '../../upload-file/upload-file.component';
import { Modal } from '../modal';

@Component({
  selector: 'app-photo-product',
  templateUrl: './photo-product.component.html',
  styleUrls: ['./photo-product.component.css']
})
export class PhotoProductComponent extends Modal implements OnInit {

  constructor(modalService: NgbModal, private productImageService : ProductImageService, private toastService : ToastService,
    @Inject(NgbModal) public data: PhotoProductComponent | string){
    super(modalService)
  }
  @Input() ProductId!: number;

  @Output() uploadOptions : Partial<UploadFileOptions> = {
    explanation : "Upload a image",
    accept : ".png, .jpg, .jpeg",
  }
  productImages : IProductImage [] = [];

  ngOnInit() {
    this.uploadOptions.url = `${environment.apiUrl}/Products/Upload?id=${this.ProductId}`
  }
   async getImages() {
       (await this.productImageService
        .getProductImage(this.ProductId))
        .subscribe((response: IProductImage[]) => {
          this.productImages = response;
          console.log(this.productImages)
        });
    }

    deleteImage(imageId : number){
      Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#32CD32',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
      }).then((result) => {
        if (result.isConfirmed) {
          this.productImageService
          .deleteProductImage(this.ProductId,imageId)
          .subscribe(() => {
            this.toastService.showToast({
              icon: 'success',
              title: 'Successfully deleted photo.',
            });
            this.getImages();
          }
          );
        }
      })
    }
  }

