import { takeLatest } from 'redux-saga/effects';

import { getReports } from '../reducer';
import {
    handleGetReport,
} from './handles';

export default function* ReportSagas() {
    yield takeLatest(getReports.type, handleGetReport);
}
