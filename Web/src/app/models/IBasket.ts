export interface IBasket {
    id: string,
    items : IBasketItem[]
}
export interface IBasketItem {
    id : number,
    productName : string,
    price : number,
    quantity : number,
    pictureUrl : string
}
export class Basket implements IBasket {
    items: IBasketItem[] = [];
    id: string;
  
    constructor(id: string) {
      this.id = id;
    }
}