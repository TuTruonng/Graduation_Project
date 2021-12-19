import React, { lazy } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import {
    ORDERMANAGER,
} from '../../constants/pages';

const ListOrder = lazy(() => import('./TableFunction/List'));

const Orders = () => {
    return (
        <>
            <Route exact path={ORDERMANAGER} component={ListOrder} />
        </>
    );
};

export default Orders;
