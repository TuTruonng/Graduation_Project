import { PayloadAction } from '@reduxjs/toolkit';
import { call, put } from 'redux-saga/effects';
import { Status } from 'src/constants/status';
import IError from 'src/interfaces/IError';
import IOrder from 'src/interfaces/Order/IOrder';
import {
    setStatus,
    setOrders,
    setOrder,
    CreateAction,
} from '../reducer';

import {
    getOrdersRequest, UpdateOrderRequest,
} from './requests';
import IAsset from 'src/interfaces/Asset/IAsset';


export function* handleGetOrder() {
    
    //const query = action.payload;
    try {
        const { data } = yield call(getOrdersRequest);
        yield put(setOrders(data));
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


export function* handleUpdateOrder(action: PayloadAction<CreateAction>) {
    console.log('putAsset')
    const { handleResult, formValues } = action.payload;
    try {
        const { data } = yield call(UpdateOrderRequest, formValues);
        console.log(data)
        if (data) {
            handleResult(true, data.name);
        }
        yield put(setOrder(data));
    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}
