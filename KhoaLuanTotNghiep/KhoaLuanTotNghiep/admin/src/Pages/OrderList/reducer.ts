import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { SetStatusType } from 'src/constants/status';

import IError from 'src/interfaces/IError';
import IPagedModel from 'src/interfaces/IPagedModel';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import IAsset from 'src/interfaces/Asset/IAsset';
import IOrderForm from 'src/interfaces/Order/IOrderForm';
import IOrder from 'src/interfaces/Order/IOrder';

type OrderState = {
    loading: boolean;
    ordersResult?: IOrder;
    orders: IOrder | null;
    status?: number;
    error?: IError;
};

export type CreateAction = {
    handleResult: Function;
    formValues: IOrderForm;
};

const initialState: OrderState = {
    orders: null,
    loading: false,
};

const OrderReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        getOrders: (
            state,
            action
        ): OrderState => {
            return {
                ...state,
                loading: true,
            };
        },
        setOrders: (
            state,
            action: PayloadAction<IOrder>
        ): OrderState => {
            const orders = action.payload;

            return {
                ...state,
                orders,
                loading: false,
            };
        },
        updateOrder: (
            state,
            action: PayloadAction<CreateAction>
        ): OrderState => {
            return {
                ...state,
                loading: true,
            };
        },
        setOrder: (state, action: PayloadAction<IOrder>): OrderState => {
            const ordersResult = action.payload;

            return {
                ...state,
                ordersResult,
                loading: false,
            };
        },
        setStatus: (
            state,
            action: PayloadAction<SetStatusType>
        ): OrderState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            };
        },
        cleanUp: (state): OrderState => ({
            ...state,
            loading: false,
            ordersResult: undefined,
            status: undefined,
            error: undefined,
        }),
    },
});

export const {
    setOrders,
    setStatus,
    cleanUp,
    getOrders,
    setOrder,
    updateOrder,
} = OrderReducerSlice.actions;

export default OrderReducerSlice.reducer;
