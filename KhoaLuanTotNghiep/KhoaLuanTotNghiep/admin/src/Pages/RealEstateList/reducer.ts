import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { SetStatusType } from 'src/constants/status';

import IError from 'src/interfaces/IError';
import IPagedModel from 'src/interfaces/IPagedModel';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import IAsset from 'src/interfaces/Asset/IAsset';
import IRealEstateForm from 'src/interfaces/RealEstate/IRealEstateForm';
import IRealEstate from 'src/interfaces/RealEstate/IRealEstate';

type RealEstateState = {
    loading: boolean;
    realEstatesResult?: IRealEstate;
    realEstates: IRealEstate | null;
    status?: number;
    error?: IError;
};

export type CreateAction = {
    handleResult: Function;
    formValues: IRealEstateForm;
};

const initialState: RealEstateState = {
    realEstates: null,
    loading: false,
};

const realEstateReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        getRealEstates: (
            state,
            action
        ): RealEstateState => {
            return {
                ...state,
                loading: true,
            };
        },
        setRealEstates: (
            state,
            action: PayloadAction<IRealEstate>
        ): RealEstateState => {
            const realEstates = action.payload;

            return {
                ...state,
                realEstates,
                loading: false,
            };
        },
        updateRealEstate: (
            state,
            action: PayloadAction<CreateAction>
        ): RealEstateState => {
            return {
                ...state,
                loading: true,
            };
        },
        setRealEstate: (state, action: PayloadAction<IRealEstate>): RealEstateState => {
            const realEstatesResult = action.payload;

            return {
                ...state,
                realEstatesResult,
                loading: false,
            };
        },
        setStatus: (
            state,
            action: PayloadAction<SetStatusType>
        ): RealEstateState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            };
        },
        cleanUp: (state): RealEstateState => ({
            ...state,
            loading: false,
            realEstatesResult: undefined,
            status: undefined,
            error: undefined,
        }),
    },
});

export const {
    setRealEstates,
    setStatus,
    cleanUp,
    getRealEstates,
    setRealEstate,
    updateRealEstate,
} = realEstateReducerSlice.actions;

export default realEstateReducerSlice.reducer;
