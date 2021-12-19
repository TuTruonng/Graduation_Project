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
    getOrdersRequest,
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
