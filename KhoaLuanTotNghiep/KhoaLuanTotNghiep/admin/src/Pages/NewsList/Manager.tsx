import React, { lazy } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import {
    EDIT_NEWS,
    CREATENEWS,
    NEWSMANAGER,
} from '../../constants/pages';

const CreateNews = lazy(() => import('./TableFunction/Create'));
const ListNews = lazy(() => import('./TableFunction/List'));
const EditNews = lazy(() => import('./TableFunction/Update'));

const News = () => {
    return (
        <>
            <Route exact path={CREATENEWS} component={CreateNews} />
            <Route exact path={NEWSMANAGER} component={ListNews} />
            <Route path={EDIT_NEWS} component={EditNews} />
        </>
    );
};

export default News;
