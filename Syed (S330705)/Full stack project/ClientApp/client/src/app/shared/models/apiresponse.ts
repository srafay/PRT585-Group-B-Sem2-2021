import { IProduct } from "./product";

export interface IAPIResponse {
    result_set: IProduct[];
    success: boolean;
    userMessage: string;
}
