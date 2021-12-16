import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { SetStatusType } from 'src/constants/status';
import IError from 'src/interfaces/IError';
import IPagedModel from 'src/interfaces/IPagedModel';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import IAsset from 'src/interfaces/Asset/IAsset';
import INewsForm from 'src/interfaces/News/INewsForm';
import INews from 'src/interfaces/News/INews';

type Newstate = {
    loading: boolean;
    newsResult?: INews;
    news: INews | null;
    status?: number;
    error?: IError;
};

export type DisableAction = {
    handleResult: Function;
    newsID: string;
};

export type CreateAction = {
    handleResult: Function;
    formValues: INewsForm;
};

const initialState: Newstate = {
    news: null,
    loading: false,
};

const NewsReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        getNews: (
            state,
            action
        ): Newstate => {
            return {
                ...state,
                loading: true,
            };
        },
        setNews: (
            state,
            action: PayloadAction<INews>
        ): Newstate => {
            const news = action.payload;

            return {
                ...state,
                news,
                loading: false,
            };
        },
        createNews: (state, action: PayloadAction<CreateAction>): Newstate => {
            return {
                ...state,
                loading: true,
            };
        },
        updateNews: (
            state,
            action: PayloadAction<CreateAction>
        ): Newstate => {
            return {
                ...state,
                loading: true,
            };
        },
        setNew: (state, action: PayloadAction<INews>): Newstate => {
            const newsResult = action.payload;

            return {
                ...state,
                newsResult,
                loading: false,
            };
        },
        setStatus: (
            state,
            action: PayloadAction<SetStatusType>
        ): Newstate => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            };
        },
        disableNews: (
            state,
            action: PayloadAction<DisableAction>
        ): Newstate => {
            return {
                ...state,
                loading: true,
            };
        },
        cleanUp: (state): Newstate => ({
            ...state,
            loading: false,
            newsResult: undefined,
            status: undefined,
            error: undefined,
        }),
    },
});

export const {
    setNews,
    setStatus,
    createNews,
    cleanUp,
    getNews,
    setNew,
    updateNews,
    disableNews
} = NewsReducerSlice.actions;

export default NewsReducerSlice.reducer;
