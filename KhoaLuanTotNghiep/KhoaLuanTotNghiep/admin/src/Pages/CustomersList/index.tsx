import React, { lazy } from 'react';
import { Edit } from 'react-feather';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import {
    HOME,
    USERMANAGER,
    CREATEUSER,
    EDIT_USER,
    CUSTOMERMANAGER,
} from '../../constants/pages';

const ListCustomers = lazy(() => import('./TableFunctions/List'));

const Users = () => {
    return (
        <>
            <Route exact path={CUSTOMERMANAGER} component={ListCustomers} />
        </>
    );
};

export default Users;
