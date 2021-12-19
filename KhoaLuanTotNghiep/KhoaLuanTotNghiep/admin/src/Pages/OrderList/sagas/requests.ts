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
