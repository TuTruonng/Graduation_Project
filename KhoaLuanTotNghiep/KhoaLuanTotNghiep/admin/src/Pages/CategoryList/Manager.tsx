import React, { lazy } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import {
    EDIT_CATEGORY,
    CREATECATEGORY,
    CATEGORYMANAGER,
} from '../../constants/pages';

const CreateCategory = lazy(() => import('./TableFunction/Create'));
const ListCategory = lazy(() => import('./TableFunction/List'));
const EditCategory = lazy(() => import('./TableFunction/Update'));

const Categories = () => {
    return (
        <>
            <Route exact path={CREATECATEGORY} component={CreateCategory} />
            <Route exact path={CATEGORYMANAGER} component={ListCategory} />
            <Route path={EDIT_CATEGORY} component={EditCategory} />
        </>
    );
};

export default Categories;
