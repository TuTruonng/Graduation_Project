import { takeLatest } from 'redux-saga/effects';

import { createCustomer, getCustomers, updateCustomer, disableCustomer } from '../reducer';
import {
    handleGetCustomers,
    handleDisableCustomer,
} from './handles';

export default function* CustomerSagas() {
    yield takeLatest(getCustomers.type, handleGetCustomers);
    yield takeLatest(disableCustomer.type, handleDisableCustomer);
}
