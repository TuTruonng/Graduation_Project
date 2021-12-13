import { PayloadAction } from '@reduxjs/toolkit';
import { call, put } from 'redux-saga/effects';
import { Status } from 'src/constants/status';
import IError from 'src/interfaces/IError';
import IRealEstate from 'src/interfaces/RealEstate/IRealEstate';
import {
    setStatus,
    setRealEstates,
    setRealEstate,
    CreateAction,
} from '../reducer';

import {
    getRealEstatesRequest,
    UpdateRealEstateRequest,
} from './requests';
import IAsset from 'src/interfaces/Asset/IAsset';


export function* handleGetRealEstate() {
    
    //const query = action.payload;
    try {
        const { data } = yield call(getRealEstatesRequest);
        yield put(setRealEstates(data));
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

export function* handleUpdateRealEstate(action: PayloadAction<CreateAction>) {
    console.log('putAsset')
    const { handleResult, formValues } = action.payload;
    try {
        const { data } = yield call(UpdateRealEstateRequest, formValues);
        console.log(data)
        if (data) {
            handleResult(true, data.name);
        }
        yield put(setRealEstate(data));
    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}
