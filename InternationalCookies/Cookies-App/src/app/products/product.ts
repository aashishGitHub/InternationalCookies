import { CheckType } from "@angular/core/src/view";

export interface IProduct {
    productId: number;
    productName: string;
    productCode: string;
    releaseDate: string;
    price: number;
    description: string;
    starRating: CheckType;
    imageUrl: string;
}

