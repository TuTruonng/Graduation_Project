import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { SetStatusType } from 'src/constants/status';

import IError from 'src/interfaces/IError';
import IPagedModel from 'src/interfaces/IPagedModel';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import IInfo from 'src/interfaces/Info/IInfo';
import IInfoForm from 'src/interfaces/Info/IInfoForm';

type InfoState = {
    loading: boolean;
    infosResult?: IInfo;
    infos?: IInfo | null;
    status?: number;
    error?: IError;
};

export type CreateAction = {
    handleResult: Function;
    formValues: IInfoForm;
};

const initialState: InfoState = {
    infos: null,
    loading: false,
};

const infoReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        getInfos: (
            state,
            action: PayloadAction<IInfo>
           
        ): InfoState => {
         
            return {
                ...state,
                loading: true,
            };
        },
        setInfos: (
            state,
            action: PayloadAction<IInfo>
        ): InfoState => {
            const infos = action.payload;

            return {
                ...state,
                infos,
                loading: false,
            };
        },
        updateInfo: (
            state,
            action: PayloadAction<CreateAction>
        ): InfoState => {
            return {
                ...state,
                loading: true,
            };
        },
        setInfo: (state, action: PayloadAction<IInfo>): InfoState => {
            const infosResult = action.payload;

            return {
                ...state,
                infosResult,
                loading: false,
            };
        },
        setStatus: (
            state,
            action: PayloadAction<SetStatusType>
        ): InfoState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            };
        },
        cleanUp: (state): InfoState => ({
            ...state,
            loading: false,
            infosResult: undefined,
            status: undefined,
            error: undefined,
        }),
    },
});

export const {
    setInfos,
    setStatus,
    cleanUp,
    getInfos,
    setInfo,
    updateInfo,
} = infoReducerSlice.actions;

export default infoReducerSlice.reducer;
