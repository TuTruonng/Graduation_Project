import { takeLatest } from 'redux-saga/effects';

import { getNews, updateNews, createNews, disableNews } from '../reducer';
import {
    handleGetNews,
    handleUpdateNews,
    handleCreateNews,
    handleDisableNews
} from './handles';

export default function* NewsSagas() {
    yield takeLatest(createNews.type, handleCreateNews);
    yield takeLatest(getNews.type, handleGetNews);
    yield takeLatest(updateNews.type, handleUpdateNews);
    yield takeLatest(disableNews.type, handleDisableNews);
}
