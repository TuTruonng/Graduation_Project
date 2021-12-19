import React, { lazy } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import {
    REPORTMANAGER,
} from '../../constants/pages';

const ListReport = lazy(() => import('./TableFunction/List'));

const Reports = () => {
    return (
        <>
            <Route exact path={REPORTMANAGER} component={ListReport} />
        </>
    );
};

export default Reports;
