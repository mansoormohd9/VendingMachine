export interface DepositDto {
    deposit: number,
    quantity: number
}

export interface BuyDto {
    productId: number,
    amount: number
}

export interface UserBuyDto {
    product: string,
    amount: number,
    priceBoughtAt: number,
    buyDate: Date
}