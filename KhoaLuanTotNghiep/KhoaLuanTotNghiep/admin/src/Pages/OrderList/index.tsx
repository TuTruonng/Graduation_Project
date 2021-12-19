import React, { useEffect, useState } from 'react';

import Orders from 'src/Pages/OrderList/Manager';

const OrderManager = () => {
    return (
        <>
            <div className="primaryColor text-title intro-x">
                <Orders />
            </div>
        </>
    );
};

export default OrderManager;
