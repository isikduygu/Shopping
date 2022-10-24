import { Component, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import {
  NgbActiveModal,
  NgbModal,
} from '@ng-bootstrap/ng-bootstrap';
import { IProduct } from 'src/app/models/IProduct';
import { ProductService } from 'src/app/services/products.service';
import { ToastService } from 'src/app/services/toast.service';
import Swal from 'sweetalert2';
import { Modal } from '../modal';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css'],
})
export class EditProductComponent extends Modal implements OnInit {
  @Input() updateName!: string;
  @Input() updatePrice!: number;
  @Input() updateStock!: number;
  @Input() ProductId!: number;
  @Output('OnProductAdded') productAddedEvent: EventEmitter<IProduct> =
    new EventEmitter();

  constructor(
    modalService: NgbModal,
    private productsService: ProductService,
    private toastService: ToastService,
    @Inject(NgbModal) public data: EditProductComponent | string){
      super(modalService)
    }

  product: IProduct = {
    id: 0,
    name: '',
    price: 0,
    stock: 0,
    productImageFiles: []
  };

  editProductForm = new FormGroup({
    productName: new FormControl(this.updateName),
    productPrice: new FormControl(this.updatePrice),
    productStock: new FormControl(this.updateStock),
  });

  ngOnInit(): void {}

  update(modal: NgbActiveModal) {
    this.product.id = this.ProductId;
    this.product.name = this.updateName;
    this.product.price = this.updatePrice;
    this.product.stock = this.updateStock;
    this.productsService.updateProducts(this.product).subscribe(() => {
      this.productAddedEvent.emit(this.product);
      modal.dismiss();
      this.toastService.showToast({
        icon: 'success',
        title: 'Successfully updated.',
      });
    });
  }
  delete() {
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
        this.productsService.deleteProducts(this.ProductId).subscribe(() => {
          this.toastService.showToast({
            icon: 'success',
            title: 'Successfully deleted.',
          });
          this.productAddedEvent.emit(this.product);
        });
      }
    })
  }
}
