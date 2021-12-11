import Header from './Component/Header';
import Navbar from './Component/Navbar';
import React, { lazy, Suspense, useEffect } from "react";
import './App.css';
import ListLoaiBDS from './Pages/LoaiBatDongSan/ListLoaiBDS.js';
import LoaiBDSForm from './Pages/LoaiBatDongSan/LoaiBDSForm';
import { Router, Route, Switch } from 'react-router';
import history from './Helpers/Help';
import ListNhanVien from './Pages/NhanVien/ListNhanVien';
import { LIST_CATEGORY, LIST_USER, CREATE_CATEGORY, UPDATE_CATEGORY, UPDATE_NEWS, CREATE_NEWS, UPDATE_USER, CREATE_USER,LIST_NEWS, LIST_BDS, LIST_REPORT,UPDATE_BDS, CREATE_BDS } from './Helpers/Router';
import ListTinTuc from './Pages/TinTuc/ListTinTuc';
import TinTucForm from './Pages/TinTuc/TinTucForm';
import ListBDS from './Pages/BatDongSan/ListBDS';
import BDSForm from './Pages/BatDongSan/BDSForm';
import InLineLoader from "./Common/InlineLoader";
import ListBaoCao from './Pages/BaoCao/ListBaoCao';
import NhanVienForm from'./Pages/NhanVien/NhanVienForm';
import { AUTH } from "./Constant/pages";

const Auth = lazy(() => import('./Component/Auth'));

const SusspenseLoading = ({ children }) => (
  <Suspense fallback={<InLineLoader />}>
    {children}
  </Suspense>
);


function App() {
  return (
    <div className="App">
        <Navbar />
        <Header />   
        <Router history={history}>
          <SusspenseLoading>
            <Switch>
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


export default App;
