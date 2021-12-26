
import React, { lazy } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import {
    INFOMANAGER,
} from '../../constants/pages';

const Info = lazy(() => import('./TableFunctions/List'));

const Infos = () => {
    return (
        <>
            <Route exact path={INFOMANAGER} component={Info} />
        </>
    );
};

export default Infos;