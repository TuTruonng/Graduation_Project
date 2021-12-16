import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { SetStatusType } from 'src/constants/status';
import IError from 'src/interfaces/IError';
import IPagedModel from 'src/interfaces/IPagedModel';
import ICustomer from 'src/interfaces/User/ICustomer';
import ICustomerForm from 'src/interfaces/User/ICustomerForm';

type CustomerState = {
    loading: boolean;
    CustomerResult?: ICustomer;
    Customers: IPagedModel<ICustomer> | null;
    status?: number;
    error?: IError;
    disable: boolean;
};

export type CreateAction = {
    handleResult: Function;
    formValues: ICustomerForm;
};

export type DisableAction = {
    handleResult: Function;
    CustomerId: number;
};

const initialState: CustomerState = {
    Customers: null,
    loading: false,
    disable: false,
};

const CustomerReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        getCustomers: (
            state,
            action
        ): CustomerState => {
            return {
                ...state,
                loading: true,
            };
        },
        setCustomers: (
            state,
            action: PayloadAction<IPagedModel<ICustomer>>
        ): CustomerState => {
            const Customers = action.payload;

            return {
                ...state,
                Customers,
                loading: false,
            };
        },
        createCustomer: (state, action: PayloadAction<CreateAction>): CustomerState => {
            return {
                ...state,
                loading: true,
            };
        },
        updateCustomer: (state, action: PayloadAction<CreateAction>): CustomerState => {
            return {
                ...state,
                loading: true,
            };
        },
        disableCustomer: (
            state,
            action: PayloadAction<DisableAction>
        ): CustomerState => {
            return {
                ...state,
                loading: true,
            };
        },
        setCustomer: (state, action: PayloadAction<ICustomer>): CustomerState => {
            const CustomerResult = action.payload;

            return {
                ...state,
                CustomerResult,
                loading: false,
            };
        },
        setStatus: (state, action: PayloadAction<SetStatusType>): CustomerState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            };
        },
        cleanUp: (state): CustomerState => ({
            ...state,
            loading: false,
            CustomerResult: undefined,
            status: undefined,
            error: undefined,
        }),
    },
});

export const {
    createCustomer,
    setCustomer,
    setStatus,
    cleanUp,
    getCustomers,
    setCustomers,
    updateCustomer,
    disableCustomer,
} = CustomerReducerSlice.actions;

export default CustomerReducerSlice.reducer;
