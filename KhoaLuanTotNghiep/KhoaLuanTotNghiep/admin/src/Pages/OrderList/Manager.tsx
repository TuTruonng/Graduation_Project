import React, { lazy } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import {
    EDIT_ORDERS,
    ORDERMANAGER,
} from '../../constants/pages';

const ListOrder = lazy(() => import('./TableFunction/List'));
const EditOrder = lazy(() => import('./TableFunction/Update'));

const Orders = () => {
    return (
        <>
            <Route exact path={ORDERMANAGER} component={ListOrder} />
            <Route path={EDIT_ORDERS} component={EditOrder} />
        </>
    );
};

export default Orders;
