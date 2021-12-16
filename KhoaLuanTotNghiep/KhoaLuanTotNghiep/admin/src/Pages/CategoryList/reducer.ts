import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { SetStatusType } from 'src/constants/status';
import IError from 'src/interfaces/IError';
import IPagedModel from 'src/interfaces/IPagedModel';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import IAsset from 'src/interfaces/Asset/IAsset';
import ICategoryForm from 'src/interfaces/Category/ICategoryForm';
import ICategory from 'src/interfaces/Category/ICategory';

type categoriestate = {
    loading: boolean;
    categoriesResult?: ICategory;
    categories: ICategory | null;
    status?: number;
    error?: IError;
};

export type CreateAction = {
    handleResult: Function;
    formValues: ICategoryForm;
};

const initialState: categoriestate = {
    categories: null,
    loading: false,
};

const CategoryReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        getCategories: (
            state,
            action
        ): categoriestate => {
            return {
                ...state,
                loading: true,
            };
        },
        setCategories: (
            state,
            action: PayloadAction<ICategory>
        ): categoriestate => {
            const categories = action.payload;

            return {
                ...state,
                categories,
                loading: false,
            };
        },
        createCategory: (state, action: PayloadAction<CreateAction>): categoriestate => {
            return {
                ...state,
                loading: true,
            };
        },
        updateCategory: (
            state,
            action: PayloadAction<CreateAction>
        ): categoriestate => {
            return {
                ...state,
                loading: true,
            };
        },
        setCategory: (state, action: PayloadAction<ICategory>): categoriestate => {
            const categoriesResult = action.payload;

            return {
                ...state,
                categoriesResult,
                loading: false,
            };
        },
        setStatus: (
            state,
            action: PayloadAction<SetStatusType>
        ): categoriestate => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            };
        },
        cleanUp: (state): categoriestate => ({
            ...state,
            loading: false,
            categoriesResult: undefined,
            status: undefined,
            error: undefined,
        }),
    },
});

export const {
    setCategories,
    setStatus,
    createCategory,
    cleanUp,
    getCategories,
    setCategory,
    updateCategory,
} = CategoryReducerSlice.actions;

export default CategoryReducerSlice.reducer;
