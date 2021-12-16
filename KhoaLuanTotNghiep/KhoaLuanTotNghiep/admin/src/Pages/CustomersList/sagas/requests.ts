import ICustomer from 'src/interfaces/User/ICustomer';
import ICustomerForm from 'src/interfaces/User/ICustomerForm';
import axios, { AxiosResponse } from 'axios';
import qs from 'qs';
import RequestService from 'src/Services/request';
import EndPoints from 'src/constants/endpoints';

export function getCustomersRequest(
): Promise<AxiosResponse<ICustomer>> {
    return RequestService.axios.get(EndPoints.customers, {
        paramsSerializer: (params) => qs.stringify(params),
    });
}

export function DisableCustomerRequest(
    id: number
): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.put(EndPoints.disableId(id));
}
