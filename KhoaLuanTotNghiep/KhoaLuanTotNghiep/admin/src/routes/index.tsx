import React, { lazy, Suspense, useEffect } from 'react';
import { Route, Switch } from 'react-router-dom';
import {
    CHANGEPASSWORD,
    HOME,
    LOGIN,
    UNAUTHORIZE,
    NOTFOUND,
    REALESTATEMANAGER,
    EDIT_REALESTATE,
    USERMANAGER,
    CREATEUSER,
    EDIT_USER,
    CUSTOMERMANAGER,
    CATEGORYMANAGER,
    CREATECATEGORY,
    EDIT_CATEGORY,
    NEWSMANAGER,
    CREATENEWS,
    EDIT_NEWS,
    ORDERMANAGER,
    REPORTMANAGER,
    EDIT_ORDERS
} from '../constants/pages';
import InLineLoader from '../components/InlineLoader';
import { useAppDispatch, useAppSelector } from '../hooks/redux';
import LayoutRoute from './LayoutRoute';
import LayoutRouteHome from './LayoutRouteHome';
import PrivateRoute from './PrivateRoute';
import ListLoaiBDS from '../Pages/LoaiBatDongSan/ListLoaiBDS.js';
import LoaiBDSForm from '../Pages/LoaiBatDongSan/LoaiBDSForm';
import ListNhanVien from '../Pages/NhanVien/ListNhanVien';
import { LIST_CATEGORY, LIST_USER, CREATE_CATEGORY, UPDATE_CATEGORY, UPDATE_NEWS, CREATE_NEWS, 
  UPDATE_USER, CREATE_USER,LIST_NEWS, LIST_BDS, LIST_REPORT,UPDATE_BDS, CREATE_BDS } from '../Helpers/Router';
import ListTinTuc from '../Pages/TinTuc/ListTinTuc';
import TinTucForm from '../Pages/TinTuc/TinTucForm';
import BDSForm from '../Pages/BatDongSan/BDSForm';
import ListBaoCao from '../Pages/BaoCao/ListBaoCao';
import NhanVienForm from'../Pages/NhanVien/NhanVienForm';
import { AUTH } from "../Constant/pages";
import { me } from 'src/containers/Authorize/reducer';

const ListBDS = lazy(() => import('../Pages/RealEstateList/TableFunction/List'));
const EditBDS = lazy(() => import('../Pages/RealEstateList/TableFunction/Update'));
const Home = lazy(() => import('../containers/Home'));
const Login = lazy(() => import('../containers/Authorize'));
const ChangePassword = lazy(() => import('../containers/ChangePassword'));
const NotFound = lazy(() => import('../containers/NotFound'));
const UnAuthorization = lazy(() => import('../containers/UnAuthorization'));
const CustomerManager = lazy(() => import('../Pages/CustomersList/UserManager'));
const UserManager = lazy(() => import('../Pages/UsersList/UserManager'));
const CreateUser = lazy(
    () => import('../Pages/UsersList/TableFunctions/Create')
);
const EditUser = lazy(
    () => import('../Pages/UsersList/TableFunctions/Update')
);
const CategoryManager = lazy(() => import('../Pages/CategoryList/Manager'));
const CreateCategpry = lazy(
    () => import('../Pages/CategoryList/TableFunction/Create')
);
const EditCategory = lazy(
    () => import('../Pages/CategoryList/TableFunction/Update')
);
const NewsManager = lazy(() => import('../Pages/NewsList/Manager'));
const CreateNews = lazy(
    () => import('../Pages/NewsList/TableFunction/Create')
);
const EditNews = lazy(
    () => import('../Pages/NewsList/TableFunction/Update')
);
const OrdersManager = lazy(() => import('../Pages/OrderList/Manager'));
const EditOrders = lazy(
    () => import('../Pages/OrderList/TableFunction/Update')
);
const ReportsManager = lazy(() => import('../Pages/ReportList/Manager'));

const SusspenseLoading = ({ children }) => (
    <Suspense fallback={<InLineLoader />}>{children}</Suspense>
);


const Routes = () => {
    const { isAuth, account } = useAppSelector((state) => state.authReducer);
    const dispatch = useAppDispatch();

    useEffect(() => {
        dispatch(me());
    }, []);

    return (
        <SusspenseLoading>
            <Switch>
                {/*Use AdminRoute if only admin is allow to access that route*/}
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
                <PrivateRoute exact path={REALESTATEMANAGER}>
                    <ListBDS />
                </PrivateRoute>
                <PrivateRoute exact path={EDIT_REALESTATE}>
                    <EditBDS />
                </PrivateRoute>
                <PrivateRoute exact path={USERMANAGER}>
                    <UserManager />
                </PrivateRoute>
                <PrivateRoute exact path={CREATEUSER}>
                    <CreateUser />
                </PrivateRoute>
                <PrivateRoute exact path={EDIT_USER}>
                    <EditUser />
                </PrivateRoute>
                <PrivateRoute exact path={CUSTOMERMANAGER}>
                    <CustomerManager />
                </PrivateRoute>
                <PrivateRoute exact path={CATEGORYMANAGER}>
                    <CategoryManager />
                </PrivateRoute>
                <PrivateRoute exact path={CREATECATEGORY}>
                    <CreateCategpry />
                </PrivateRoute>
                <PrivateRoute exact path={EDIT_CATEGORY}>
                    <EditCategory />
                </PrivateRoute>
                <PrivateRoute exact path={NEWSMANAGER}>
                    <NewsManager />
                </PrivateRoute>
                <PrivateRoute exact path={CREATENEWS}>
                    <CreateNews />
                </PrivateRoute>
                <PrivateRoute exact path={EDIT_NEWS}>
                    <EditNews />
                </PrivateRoute>
                <PrivateRoute exact path={ORDERMANAGER}>
                    <OrdersManager />
                </PrivateRoute>
                <PrivateRoute exact path={EDIT_ORDERS}>
                    <EditOrders />
                </PrivateRoute>
                <PrivateRoute exact path={REPORTMANAGER}>
                    <ReportsManager />
                </PrivateRoute>
            </Switch>
        </SusspenseLoading>
    );
};

export default Routes;
