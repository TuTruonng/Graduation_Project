import { takeLatest } from 'redux-saga/effects';

import { getCategories, updateCategory, createCategory } from '../reducer';
import {
    handleGetCategory,
    handleUpdateCategory,
    handleCreateCategory
} from './handles';

export default function* CategorySagas() {
    yield takeLatest(createCategory.type, handleCreateCategory);
    yield takeLatest(getCategories.type, handleGetCategory);
    yield takeLatest(updateCategory.type, handleUpdateCategory);
}
