import { PayloadAction } from '@reduxjs/toolkit';
import { call, put } from 'redux-saga/effects';
import { Status } from 'src/constants/status';
import IError from 'src/interfaces/IError';
import INews from 'src/interfaces/News/INews';
import {
    setStatus,
    setNews,
    setNew,
    CreateAction,
    DisableAction,
} from '../reducer';

import {    
    getNewsRequest,
    UpdateNewsRequest,
    createNewsRequest,
    DisableNewsRequest
} from './requests';
import IAsset from 'src/interfaces/Asset/IAsset';

export function* handleCreateNews(action: PayloadAction<CreateAction>) {
   
    const { handleResult, formValues } = action.payload;
    console.log(formValues)
    try {
        const { data } = yield call(createNewsRequest, formValues);
        console.log('handle')
       
        if (data) {
            handleResult(true, data.name);
        }

        yield put(setNew(data));
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleGetNews() {
    try {
        const { data } = yield call(getNewsRequest);
        yield put(setNews(data));
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

export function* handleUpdateNews(action: PayloadAction<CreateAction>) {
    console.log('putAsset')
    const { handleResult, formValues } = action.payload;
    try {
        const { data } = yield call(UpdateNewsRequest, formValues);
        console.log(data)
        if (data) {
            handleResult(true, data.name);
        }
        yield put(setNews(data));
    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}

export function* handleDisableNews(action: PayloadAction<DisableAction>) {
    const { handleResult, newsID } = action.payload;

    try {
        const { data } = yield call(DisableNewsRequest, newsID);

        handleResult(data, '');
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}