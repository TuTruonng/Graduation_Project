import React, { lazy } from 'react';
import { Edit } from 'react-feather';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import {
    EDIT_NEWS,
    CREATENEWS,
    NEWSMANAGER,
} from '../../constants/pages';

const CreateNews = lazy(() => import('./TableFunction/Create'));
const ListNews = lazy(() => import('./TableFunction/List'));
const EditNews = lazy(() => import('./TableFunction/Update'));

const Categories = () => {
    return (
        <>
            <Route exact path={CREATENEWS} component={CreateNews} />
            <Route exact path={NEWSMANAGER} component={ListNews} />
            <Route path={EDIT_NEWS} component={EditNews} />
        </>
    );
};

export default Categories;
