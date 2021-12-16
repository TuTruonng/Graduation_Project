import React, { useEffect, useState } from 'react';
import { AxiosResponse } from 'axios';
import { Link } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { getCustomers, setCustomers } from '../reducer';
import CustomerTable from './Table';

const ListCustomers = () => {
    const dispatch = useAppDispatch();
    const [Customer, setCustomer] = useState([]);
    const {Customers, loading } = useAppSelector((state) => state.customerReducer);

    const fetchData = () => {
        dispatch(getCustomers(Customer));
    };

    useEffect(() => {
        fetchData();
        // dispatch(setCustomers(Customers));
    }, []);
    console.log(Customers);

    return (
        <>
            <div className="primaryColor text-title intro-x">Customer List</div>
            <div>
                <CustomerTable
                    Customers={Customers}
                    fetchData={fetchData}
                />
            </div>
        </>
    );
};

export default ListCustomers;
