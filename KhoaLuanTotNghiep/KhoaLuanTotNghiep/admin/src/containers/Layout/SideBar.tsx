import React from 'react';
import { NavLink } from 'react-router-dom';
import {
    HOME,
    ASSETMANAGER,
    MANAGEASSIGNMENT,
    REPORT,
    REQUEST,
    USERMANAGER,
} from 'src/constants/pages';
import Roles from 'src/constants/roles';
import { useAppSelector } from 'src/hooks/redux';

const SideBar = () => {
    const { account } = useAppSelector((state) => state.authReducer);

    return (
        <div className="nav-left mb-5">
            <img src="/images/Logo_lk.png" alt="logo" />
            <p className="brand intro-x">Online Asset Management</p>

                    <NavLink className="navItem intro-x" exact to={HOME}>
                        <button className="btnCustom">Home</button>
                    </NavLink>
                    <NavLink className="navItem intro-x" to={USERMANAGER}>
                        <button className="btnCustom">Manage Category RealEstate</button>
                    </NavLink>
                    <NavLink className="navItem intro-x" to={ASSETMANAGER}>
                        <button className="btnCustom">Manage RealEstate</button>
                    </NavLink>
                    <NavLink className="navItem intro-x" to={MANAGEASSIGNMENT}>
                        <button className="btnCustom">Manage Customer</button>
                    </NavLink>
                    <NavLink className="navItem intro-x" to={REPORT}>
                        <button className="btnCustom">Manage News</button>
                    </NavLink>
                    <NavLink className="navItem intro-x" to={REPORT}>
                        <button className="btnCustom">Manage Report</button>
                    </NavLink>
            {/* account?.role === Roles.Admin && ( */}
            {localStorage.getItem('role') === 'Administrator' && (
                <div>
                    <NavLink className="navItem intro-x" to={REQUEST}>
                        <button className="btnCustom">
                            Manage Employee
                        </button>
                    </NavLink>
                </div>
            )}
            {/* ) */}
        </div>
    );
};

export default SideBar;
