import { IProduct } from "./product";

export interface ICrudResponse {
    result_set: IProduct;
    success: boolean;
    userMessage: string;
}
