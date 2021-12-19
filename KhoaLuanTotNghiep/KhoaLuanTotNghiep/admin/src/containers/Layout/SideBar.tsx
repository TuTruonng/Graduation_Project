import React from 'react';
import { NavLink } from 'react-router-dom';
import {
    HOME,
    MANAGEASSIGNMENT,
    REPORT,
    REQUEST,
    USERMANAGER,
    REALESTATEMANAGER,
    CUSTOMERMANAGER,
    CATEGORYMANAGER,
    NEWSMANAGER,
    REPORTMANAGER,
    ORDERMANAGER
} from 'src/constants/pages';
import Roles from 'src/constants/roles';
import { LIST_BDS } from 'src/Helpers/Router';
import { useAppSelector } from 'src/hooks/redux';

const SideBar = () => {
    const { account } = useAppSelector((state) => state.authReducer);

    return (
        <div className="nav-left mb-5">
            <img src="/images/logo.jpeg" style={{ width: '200px', height: '150px' }} alt="logo" />
            {/* <p className="brand intro-x">Online Asset Management</p> */}

            <NavLink className="navItem intro-x" exact to={HOME}>
                <button className="btnCustom">Home</button>
            </NavLink>
            <NavLink className="navItem intro-x" to={CATEGORYMANAGER}>
                <button className="btnCustom">Manage Category</button>
            </NavLink>
            <NavLink className="navItem intro-x" to={REALESTATEMANAGER}>
                <button className="btnCustom">Manage RealEstate</button>
            </NavLink>
            <NavLink className="navItem intro-x" to={CUSTOMERMANAGER}>
                <button className="btnCustom">Manage Customer</button>
            </NavLink>
            <NavLink className="navItem intro-x" to={NEWSMANAGER}>
                <button className="btnCustom">Manage News</button>
            </NavLink>
            <NavLink className="navItem intro-x" to={REPORTMANAGER}>
                <button className="btnCustom">Manage Report</button>
            </NavLink>
            {/* account?.role === Roles.Admin && ( */}
            {localStorage.getItem('role') === 'ADMIN' && (
                <div>
                    <NavLink className="navItem intro-x" to={USERMANAGER}>
                        <button className="btnCustom">
                            Manage Employee
                        </button>
                    </NavLink>
                    <NavLink className="navItem intro-x" to={ORDERMANAGER}>
                        <button className="btnCustom">Manage Order</button>
                    </NavLink>
                </div>
            )}
            {/* ) */}
        </div>
    );
};

export default SideBar;
