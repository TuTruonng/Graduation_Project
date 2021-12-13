import { takeLatest } from 'redux-saga/effects';

import { getRealEstates, updateRealEstate } from '../reducer';
import {
    handleGetRealEstate,
    handleUpdateRealEstate,
} from './handles';

export default function* RealEstateSagas() {
    yield takeLatest(getRealEstates.type, handleGetRealEstate);
    yield takeLatest(updateRealEstate.type, handleUpdateRealEstate);
}
