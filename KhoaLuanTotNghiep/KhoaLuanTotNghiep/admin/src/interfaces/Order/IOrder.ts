export default interface IOrder {
    orderID?: string;
    realEstateID: string;
    userName: string;
    adminName: string;
    title: string;
    orderDate: Date;
    status: string;
}