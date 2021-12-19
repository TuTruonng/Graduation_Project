export default interface IOrder {
    orderId?: string;
    realEstateId: string;
    userName: string;
    adminName: string;
    title: string;
    orderDate: Date;
}