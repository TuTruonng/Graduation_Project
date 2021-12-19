import { PayloadAction } from '@reduxjs/toolkit';
import { call, put } from 'redux-saga/effects';
import { Status } from 'src/constants/status';
import IError from 'src/interfaces/IError';
import IReport from 'src/interfaces/Report/IReport';
import {
    setStatus,
    setReports,
    setReport,
    CreateAction,
} from '../reducer';

import {
    getReportsRequest,
} from './requests';
import IAsset from 'src/interfaces/Asset/IAsset';


export function* handleGetReport() {
    
    //const query = action.payload;
    try {
        const { data } = yield call(getReportsRequest);
        yield put(setReports(data));
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
