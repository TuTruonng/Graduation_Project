import Header from './Component/Header';
import Navbar from './Component/Navbar';
import React, { lazy, Suspense, useEffect } from "react";
import './App.css';
import { Router, Route, Switch } from 'react-router';
import history from './Helpers/Help';
import ListLoaiBDS from './Pages/LoaiBatDongSan/ListLoaiBDS.js';
import LoaiBDSForm from './Pages/LoaiBatDongSan/LoaiBDSForm';
import ListNhanVien from './Pages/NhanVien/ListNhanVien';
import { LIST_CATEGORY, LIST_USER, CREATE_CATEGORY, UPDATE_CATEGORY, UPDATE_NEWS, CREATE_NEWS, 
  UPDATE_USER, CREATE_USER,LIST_NEWS, LIST_BDS, LIST_REPORT,UPDATE_BDS, CREATE_BDS } from './Helpers/Router';
import ListTinTuc from './Pages/TinTuc/ListTinTuc';
import TinTucForm from './Pages/TinTuc/TinTucForm';
import ListBDS from './Pages/BatDongSan/ListBDS';
import BDSForm from './Pages/BatDongSan/BDSForm';
import InLineLoader from "./Common/InlineLoader";
import ListBaoCao from './Pages/BaoCao/ListBaoCao';
import NhanVienForm from'./Pages/NhanVien/NhanVienForm';
import { AUTH } from "./Constant/pages";
import {
  CHANGEPASSWORD,
  HOME,
  LOGIN,
  UNAUTHORIZE,
  NOTFOUND,
  USERMANAGER,
  CREATEUSER,
  EDIT_USER,
  ASSETMANAGER,
  CREATEASSET,
  EDIT_ASSET
} from './constants/pages';
import LayoutRoute from './routes/LayoutRoute';
import LayoutRouteHome from './routes/LayoutRouteHome';
import PrivateRoute from './routes/PrivateRoute';


const Home = lazy(() => import('../containers/Home'));
const Login = lazy(() => import('../containers/Authorize'));
const ChangePassword = lazy(() => import('../containers/ChangePassword'));
const NotFound = lazy(() => import('../containers/NotFound'));
const UnAuthorization = lazy(() => import('../containers/UnAuthorization'));

const Auth = lazy(() => import('./Component/Auth'));

const SusspenseLoading = ({ children }) => (
  <Suspense fallback={<InLineLoader />}>
    {children}
  </Suspense>
);


function AppIndex() {
  return (
    <div className="App">
        <Navbar />
        <Header />   
        <Router history={history}>
          <SusspenseLoading>
            <Switch>
                <LayoutRouteHome exact path={LOGIN}>
                    <Login />
                </LayoutRouteHome>
                <PrivateRoute exact path={HOME}>
                    <Home />
                </PrivateRoute>
                <LayoutRoute exact path={UNAUTHORIZE}>
                    <UnAuthorization />
                </LayoutRoute>
                <LayoutRoute exact path={NOTFOUND}>
                    <NotFound />
                </LayoutRoute>
              <Route exact path={LIST_CATEGORY} >
                <ListLoaiBDS />
              </Route>

              <Route exact path={CREATE_CATEGORY}>
                <LoaiBDSForm />
              </Route>

              <Route exact path={UPDATE_CATEGORY}>
                <LoaiBDSForm />
              </Route>

              <Route exact path={LIST_USER}>
                <ListNhanVien />
              </Route>
              
              <Route exact path={CREATE_USER}>
                <NhanVienForm/>
              </Route>

              <Route exact path={UPDATE_USER}>
                <NhanVienForm/>
              </Route>

              <Route exact path={LIST_NEWS}>
                <ListTinTuc />
              </Route>

              <Route exact path={CREATE_NEWS}>
                <TinTucForm />
              </Route>

              <Route exact path={UPDATE_NEWS}>
                <TinTucForm />
              </Route>

              <Route exact path={LIST_BDS}>
                <ListBDS />
              </Route>

              <Route exact path={CREATE_BDS}>
                <BDSForm />
              </Route>

              <Route exact path={UPDATE_BDS}>
                <BDSForm />
              </Route>

              <Route exact path={AUTH}>
                <Auth />
              </Route>

              <Route path = {LIST_REPORT}>
               <ListBaoCao />
              </Route>

            </Switch>
          </SusspenseLoading>
        </Router>
    </div>
  );
}


export default AppIndex;
