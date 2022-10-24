import { Component, EventEmitter, OnInit, Output, Inject } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal, ModalDismissReasons, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import { IProduct } from 'src/app/models/IProduct';
import { ProductService } from '../../../services/products.service';
import { ToastService } from '../../../services/toast.service';
import { Modal } from '../modal';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent extends Modal implements OnInit {
  @Output('OnProductAdded') productAddedEvent: EventEmitter<IProduct> =
    new EventEmitter();

    product: IProduct = {
      id: 0,
      name: '',
      price: 0,
      stock: 0,
      productImageFiles: []
    };
    
  addProductForm= new FormGroup({
    productName:new FormControl("", [Validators.required]),
    productPrice: new FormControl(),
    productStock: new FormControl(),
  });

  
  constructor(private productsService : ProductService,private toastService : ToastService,  modalService: NgbModal,
    @Inject(NgbModal) public data: AddProductComponent | string,) {
    super(modalService);
  }

  ngOnInit(): void {
  }

  get f(): { [key: string]: AbstractControl } {
    return this.addProductForm.controls;
  }

  addproduct(modal: NgbActiveModal){
      this.submitted = true;
      this.product.name = this.addProductForm.value.productName as string,
      this.product.price = this.addProductForm.value.productPrice,
      this.product.stock = this.addProductForm.value.productStock;

      if (this.addProductForm.invalid) {
        return;
      }else{
        this.productsService
        .createProducts(this.product)
        .subscribe(() => {
          this.submitted = false;
          modal.dismiss();
          this.addProductForm.reset();
          this.toastService.showToast({
            icon: 'success',
            title: 'Successfully added.',
          });
          this.productAddedEvent.emit(this.product);
        });
      }
  }
}