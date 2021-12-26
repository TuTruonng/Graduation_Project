import IOrder from 'src/interfaces/Order/IOrder';
import axios, { AxiosResponse } from 'axios';
import qs from 'qs';
import RequestService from 'src/Services/request';
import EndPoints from 'src/constants/endpoints';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import IOrderForm from 'src/interfaces/Order/IOrderForm';
import IUser from 'src/interfaces/User/IUser';

export function getOrdersRequest(
): Promise<AxiosResponse<IOrder>> {
    console.log('ket qua');
    const username = localStorage.getItem('user');
    console.log(username);
    return RequestService.axios.get(EndPoints.orders, {
        paramsSerializer: (params) => qs.stringify(params),
    });
}

export function UpdateOrderRequest(
    OrderForm: IOrderForm
): Promise<AxiosResponse<IOrder>> {
    const formData = new FormData();
    Object.keys(OrderForm).forEach((key) => {
            formData.append(key, OrderForm[key]);
    });
    console.log('OrderForm.OrderID')
    console.log(OrderForm.orderID)
    return RequestService.axios
        .put(EndPoints.ordersId(OrderForm.orderID ?? -1), formData)
}