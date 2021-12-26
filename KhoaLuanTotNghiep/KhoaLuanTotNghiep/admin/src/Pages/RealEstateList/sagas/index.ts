import { takeLatest } from 'redux-saga/effects';
import { getInfos } from 'src/Pages/SalaryList/reducer';

import { getRealEstates, updateRealEstate } from '../reducer';
import {
    handleGetInfo,
    handleGetRealEstate,
    handleUpdateRealEstate,
} from './handles';

export default function* RealEstateSagas() {
    yield takeLatest(getRealEstates.type, handleGetRealEstate);
    yield takeLatest(updateRealEstate.type, handleUpdateRealEstate);
    yield takeLatest(getInfos.type, handleGetInfo);
}
