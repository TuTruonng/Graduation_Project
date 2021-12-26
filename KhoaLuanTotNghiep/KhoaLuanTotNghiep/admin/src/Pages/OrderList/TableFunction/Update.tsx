import React, { useEffect, useState } from 'react';
import { Redirect, useParams } from 'react-router';
import { useHistory, useLocation } from 'react-router-dom';
import moment, { invalid } from 'moment';
import { NOTFOUND } from 'src/constants/pages';
import { useAppSelector } from 'src/hooks/redux';
import IAssetForm from 'src/interfaces/Asset/IAssetForm';
import { string } from 'yup/lib/locale';
// import Users from '../AssetManager';
// import UserFormContainer from '../AssetForm';
import IOrderForm from 'src/interfaces/Order/IOrderForm';
import OrderForm from '../OrderForm';

const UpdateOrderContainer = () => {
    //const { users } = useAppSelector((state) => state.userReducer);
    const [order, setOrder] = useState(undefined as IOrderForm | undefined);
    const { orderID } = useParams<{ orderID: string }>();
    const { state } = useLocation<{ existOrder: IOrderForm }>();
    const { existOrder } = state; // Read values passed on state

    useEffect(() => {
        if (existOrder) {
            console.log(existOrder?.orderID);
            setOrder(
                {
                    orderID: existOrder.orderID,
                    realEstateID: existOrder.realEstateID,
                    status: existOrder.status.toString(),
                }
            );
           
        }

    }, [existOrder]);
    console.log(existOrder?.orderID);

    return (
        <div className="ml-5">
            <div className="primaryColor text-title intro-x">Edit Order</div>

            <div className="row">
                {/* <UserFormContainer /> */}
                {order && <OrderForm initialOrderForm={order} />}
            </div>
        </div>
    );
};

export default UpdateOrderContainer;
