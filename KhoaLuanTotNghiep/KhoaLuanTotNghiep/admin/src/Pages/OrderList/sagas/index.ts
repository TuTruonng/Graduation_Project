import { takeLatest } from 'redux-saga/effects';

import { getOrders } from '../reducer';
import {
    handleGetOrder,
} from './handles';

export default function* OrderSagas() {
    yield takeLatest(getOrders.type, handleGetOrder);
}
