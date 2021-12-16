import INews from 'src/interfaces/News/INews';
import axios, { AxiosResponse } from 'axios';
import qs from 'qs';
import RequestService from 'src/Services/request';
import EndPoints from 'src/constants/endpoints';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import INewsForm from 'src/interfaces/News/INewsForm';
import IUser from 'src/interfaces/User/IUser';

export function createNewsRequest(
    NewsForm: INewsForm,
): Promise<AxiosResponse<INews>> {
    console.log('aaaaaa')
    const username = localStorage.getItem('user');
    return RequestService.axios.post(EndPoints.newsName(username), NewsForm).then((response) => {
        if (response.data) {
            localStorage.setItem("onTopStaffCode", response.data.staffCode)
        }
        return response
    });
}


export function getNewsRequest(
): Promise<AxiosResponse<INews>> {
    const username = localStorage.getItem('user');
    return RequestService.axios.get(EndPoints.newsName(username), {
        paramsSerializer: (params) => qs.stringify(params),
    });
}

export function UpdateNewsRequest(
    NewsForm: INewsForm
): Promise<AxiosResponse<INews>> {
    const formData = new FormData();
    Object.keys(NewsForm).forEach((key) => {
            formData.append(key, NewsForm[key]);
    });
    console.log('NewsForm.NewsID')
    console.log(NewsForm.newsID)
    return RequestService.axios
        .put(EndPoints.newsId(NewsForm.newsID ?? -1), formData)
}

export function DisableNewsRequest(
    id: string
): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.put(EndPoints.disableNewsId(id));
}
