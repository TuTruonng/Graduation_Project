import { PayloadAction } from '@reduxjs/toolkit';
import { call, put } from 'redux-saga/effects';
import { Status } from 'src/constants/status';
import IError from 'src/interfaces/IError';
import {
    createCustomer,
    setCustomer,
    setStatus,
    cleanUp,
    getCustomers,
    setCustomers,
    updateCustomer,
    disableCustomer,
    CreateAction,
    DisableAction,
} from '../reducer';

import {
    DisableCustomerRequest,
    getCustomersRequest,
} from './requests';
import ICustomer from 'src/interfaces/User/ICustomer';

export function* handleGetCustomers() {
    //const query = action.payload;
    try {
        const { data } = yield call(getCustomersRequest);
        yield put(setCustomers(data));
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

export function* handleDisableCustomer(action: PayloadAction<DisableAction>) {
    const { handleResult, CustomerId } = action.payload;

    try {
        const { data } = yield call(DisableCustomerRequest, CustomerId);

        handleResult(data, '');
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}
