import React, { lazy } from 'react';
import { Edit } from 'react-feather';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import {
    EDIT_REALESTATE,
    HOME,
    REALESTATEMANAGER,
} from '../../constants/pages';

const ListBDS = lazy(() => import('./TableFunction/List'));
const EditBDS = lazy(() => import('./TableFunction/Update'));

const RealEstates = () => {
    return (
        <>
            <Route exact path={REALESTATEMANAGER} component={ListBDS} />
            <Route path={EDIT_REALESTATE} component={EditBDS} />
        </>
    );
};

export default RealEstates;
