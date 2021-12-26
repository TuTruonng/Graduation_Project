import IRealEstate from 'src/interfaces/RealEstate/IRealEstate';
import axios, { AxiosResponse } from 'axios';
import qs from 'qs';
import RequestService from 'src/Services/request';
import EndPoints from 'src/constants/endpoints';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import IRealEstateForm from 'src/interfaces/RealEstate/IRealEstateForm';
import IUser from 'src/interfaces/User/IUser';
import IInfo from 'src/interfaces/Info/IInfo';

export function getRealEstatesRequest(
): Promise<AxiosResponse<IRealEstate>> {
    console.log('ket qua');
    const username = localStorage.getItem('user');
    console.log(username);
    return RequestService.axios.get(EndPoints.realEstates(username), {
        paramsSerializer: (params) => qs.stringify(params),
    });
}

export function UpdateRealEstateRequest(
    RealEstateForm: IRealEstateForm
): Promise<AxiosResponse<IRealEstate>> {
    const formData = new FormData();
    Object.keys(RealEstateForm).forEach((key) => {
            formData.append(key, RealEstateForm[key]);
    });
    console.log('RealEstateForm.realEstateID')
    console.log(RealEstateForm.realEstateID)
    return RequestService.axios
        .put(EndPoints.realEstatesId(RealEstateForm.realEstateID ?? -1), formData)
}

export function getInfosRequest(
    ): Promise<AxiosResponse<IInfo>> {
        console.log('ket qua');
        const username = localStorage.getItem('user');
        console.log(username);
        return RequestService.axios.get(EndPoints.infos(username), {
            paramsSerializer: (params) => qs.stringify(params),
        });
    }
    
