import { PayloadAction } from '@reduxjs/toolkit';
import { call, put } from 'redux-saga/effects';
import { Status } from 'src/constants/status';
import IError from 'src/interfaces/IError';
import ICategory from 'src/interfaces/Category/ICategory';
import {
    setStatus,
    setCategories,
    setCategory,
    CreateAction,
} from '../reducer';

import {    
    getCategoriesRequest,
    UpdateCategoryRequest,
    createCategoryRequest
} from './requests';
import IAsset from 'src/interfaces/Asset/IAsset';

export function* handleCreateCategory(action: PayloadAction<CreateAction>) {
    const { handleResult, formValues } = action.payload;
    try {
        const { data } = yield call(createCategoryRequest, formValues);

        if (data) {
            handleResult(true, data.name);
        }

        yield put(setCategory(data));
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleGetCategory() {
    
    //const query = action.payload;
    try {
        const { data } = yield call(getCategoriesRequest);
        yield put(setCategories(data));
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        console.log(errorModel);
        yield put(
            setStatus({
                status: Status.Failed,
                error: errorModel,
            })
        );
    }
}

export function* handleUpdateCategory(action: PayloadAction<CreateAction>) {
    console.log('putAsset')
    const { handleResult, formValues } = action.payload;
    try {
        const { data } = yield call(UpdateCategoryRequest, formValues);
        console.log(data)
        if (data) {
            handleResult(true, data.name);
        }
        yield put(setCategory(data));
    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}
