import { takeLatest } from 'redux-saga/effects';

import { getOrders, updateOrder } from '../reducer';
import {
    handleGetOrder, handleUpdateOrder,
} from './handles';

export default function* OrderSagas() {
    yield takeLatest(getOrders.type, handleGetOrder);
    yield takeLatest(updateOrder.type, handleUpdateOrder);
}
