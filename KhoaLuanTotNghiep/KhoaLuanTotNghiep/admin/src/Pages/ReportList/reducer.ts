import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { SetStatusType } from 'src/constants/status';

import IError from 'src/interfaces/IError';
import IPagedModel from 'src/interfaces/IPagedModel';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import IAsset from 'src/interfaces/Asset/IAsset';
import IReportForm from 'src/interfaces/Report/IReportForm';
import IReport from 'src/interfaces/Report/IReport';

type ReportState = {
    loading: boolean;
    reportsResult?: IReport;
    reports: IReport | null;
    status?: number;
    error?: IError;
};

export type CreateAction = {
    handleResult: Function;
    formValues: IReportForm;
};

const initialState: ReportState = {
    reports: null,
    loading: false,
};

const ReportReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        getReports: (
            state,
            action
        ): ReportState => {
            return {
                ...state,
                loading: true,
            };
        },
        setReports: (
            state,
            action: PayloadAction<IReport>
        ): ReportState => {
            const reports = action.payload;

            return {
                ...state,
                reports,
                loading: false,
            };
        },
        updateReport: (
            state,
            action: PayloadAction<CreateAction>
        ): ReportState => {
            return {
                ...state,
                loading: true,
            };
        },
        setReport: (state, action: PayloadAction<IReport>): ReportState => {
            const reportsResult = action.payload;

            return {
                ...state,
                reportsResult,
                loading: false,
            };
        },
        setStatus: (
            state,
            action: PayloadAction<SetStatusType>
        ): ReportState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            };
        },
        cleanUp: (state): ReportState => ({
            ...state,
            loading: false,
            reportsResult: undefined,
            status: undefined,
            error: undefined,
        }),
    },
});

export const {
    setReports,
    setStatus,
    cleanUp,
    getReports,
    setReport,
    updateReport,
} = ReportReducerSlice.actions;

export default ReportReducerSlice.reducer;
