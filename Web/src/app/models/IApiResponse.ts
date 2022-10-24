import {IProduct} from './IProduct'

export interface IApiResponse {
    totalCount : number,
    products: IProduct []
}