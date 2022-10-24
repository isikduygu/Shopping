import { IUser } from "./IUser";

export interface IUserApiResponse{
    succeeded : boolean;
    message : string;
    user: IUser [];
}