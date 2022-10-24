import { IProductImage } from "./IProductImage";

export interface IProduct{
    id: number,
    name: string;
    price: number;
    stock: number;
    productImageFiles : IProductImage[]
}