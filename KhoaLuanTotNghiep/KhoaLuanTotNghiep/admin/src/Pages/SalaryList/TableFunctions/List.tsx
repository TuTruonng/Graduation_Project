import React, { useEffect, useState } from 'react';
import { AxiosResponse } from 'axios';
import { Link } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { getUsers, setUsers } from '../reducer';
import { CREATEUSER, USERMANAGER } from 'src/constants/pages';
import UserTable from './Table';

// const _location = localStorage.getItem('location');
// const _onTopStaffCodeLocalStoage = localStorage.getItem('onTopStaffCode')
// const _onTopStaffCode = _onTopStaffCodeLocalStoage ? Number(_onTopStaffCodeLocalStoage) : 0
// if (_onTopStaffCodeLocalStoage) {
//     localStorage.removeItem('onTopStaffCode')
// }
const ListUsers = () => {
    const dispatch = useAppDispatch();
    const [user, setUser] = useState([]);
    const { users, loading } = useAppSelector((state) => state.userReducer);

    const fetchData = () => {
        dispatch(getUsers(user));
    };

    useEffect(() => {
        fetchData();
        // dispatch(setUsers(users));
    }, []);
    console.log(users);

    return (
        <>
            <div className="primaryColor text-title intro-x">User List</div>

            <div>
                <div className="d-flex mb-5 intro-x">
                    <div className="d-flex align-items-center ml-3">
                        <Link
                            to={CREATEUSER}
                            type="button"
                            className="btn btn-danger"
                        >
                            Create new user
                        </Link>
                    </div>
                </div>

                <UserTable
                    users={users}
                    fetchData={fetchData}
                />
            </div>
        </>
    );
};

export default ListUsers;
