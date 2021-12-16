import ICategory from 'src/interfaces/Category/ICategory';
import axios, { AxiosResponse } from 'axios';
import qs from 'qs';
import RequestService from 'src/Services/request';
import EndPoints from 'src/constants/endpoints';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import ICategoryForm from 'src/interfaces/Category/ICategoryForm';
import IUser from 'src/interfaces/User/IUser';

export function createCategoryRequest(
    CategoryForm: ICategoryForm
): Promise<AxiosResponse<ICategory>> {
    return RequestService.axios.post(EndPoints.categories, CategoryForm).then((response) => {
        if (response.data) {
            localStorage.setItem("onTopStaffCode", response.data.staffCode)
        }
        return response
    });
}


export function getCategoriesRequest(
): Promise<AxiosResponse<ICategory>> {
    return RequestService.axios.get(EndPoints.categories, {
        paramsSerializer: (params) => qs.stringify(params),
    });
}

export function UpdateCategoryRequest(
    CategoryForm: ICategoryForm
): Promise<AxiosResponse<ICategory>> {
    const formData = new FormData();
    Object.keys(CategoryForm).forEach((key) => {
            formData.append(key, CategoryForm[key]);
    });
    console.log('CategoryForm.CategoryID')
    console.log(CategoryForm.categoryID)
    return RequestService.axios
        .put(EndPoints.categoriesId(CategoryForm.categoryID ?? -1), formData)
}

