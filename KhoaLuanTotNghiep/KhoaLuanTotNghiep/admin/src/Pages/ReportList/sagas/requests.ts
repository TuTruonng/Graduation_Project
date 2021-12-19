import IReport from 'src/interfaces/Report/IReport';
import axios, { AxiosResponse } from 'axios';
import qs from 'qs';
import RequestService from 'src/Services/request';
import EndPoints from 'src/constants/endpoints';

export function getReportsRequest(
): Promise<AxiosResponse<IReport>> {
    console.log('ket qua');
    const username = localStorage.getItem('user');
    console.log(username);
    return RequestService.axios.get(EndPoints.reports(username), {
        paramsSerializer: (params) => qs.stringify(params),
    });
}
