import {
    configureStore,
    getDefaultMiddleware,
    combineReducers,
} from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';
import authReducer from 'src/containers/Authorize/reducer';
import realEstateReducer from 'src/Pages/RealEstateList/reducer';
import categoryReducer from 'src/Pages/CategoryList/reducer';
import userReducer from 'src/Pages/UsersList/reducer';
import customerReducer from 'src/Pages/CustomersList/reducer';
import orderReducer from 'src/Pages/OrderList/reducer';
import reportReducer from 'src/Pages/ReportList/reducer';
import newsReducer from 'src/Pages/NewsList/reducer';
import rootSaga from './sagas/rootSaga';

const reducer = combineReducers({
    authReducer,
    realEstateReducer,
    userReducer,
    customerReducer,
    categoryReducer,
    newsReducer,
    orderReducer,
    reportReducer
});

const sagaMiddleware = createSagaMiddleware();

const store = configureStore({
    reducer,
    middleware: [
        ...getDefaultMiddleware({
            thunk: false,
            serializableCheck: false,
        }),
        sagaMiddleware,
    ],
});

rootSaga.map((saga) => sagaMiddleware.run(saga)); // Register all sagas

// sagaMiddleware.run(watcherSaga);

export default store;

export type RootState = ReturnType<typeof store.getState>;
export type RootDispatch = typeof store.dispatch;
