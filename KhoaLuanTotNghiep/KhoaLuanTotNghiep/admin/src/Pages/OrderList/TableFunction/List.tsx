import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import BatDongSanService from "src/Services/BatDongSanService";
import IOrder from "src/interfaces/Order/IOrder";
import { getOrders } from "../reducer";
import OrderTable from "./Table";
import { ExportOrderAccepted } from "../ExportOrderAccepted";

type Props = {
  orders: IOrder | null;
  fetchData: Function;
};

const ListBDS = () => {
  const dispatch = useAppDispatch();
  const fileNameOrderAccepted = "Report Orders Accepted"; // here enter filename for your excel file
  const fileNameOrderNotAccepted = "Report Orders Not Accepted"; // here enter filename for your excel file
  const { orders, loading } = useAppSelector((state) => state.orderReducer);
  const [Order, setOrder] = useState([]);
  const [itemSelected, setSelected] = React.useState(null);
  // let params = {};

  const fetchData = () => {
    dispatch(getOrders(Order));
  };

  useEffect(() => {
    fetchData();
  }, []);

  console.log(orders);

  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.OrderID !== itemDel);

  return (
    <div className="content-wrapper" >
      <br />
      <h3 className="invalid"><b>Order List</b></h3>
      <br />
      <div className='tblOrder'>
        <OrderTable
          orders={orders}
          fetchData={fetchData}
        />
      </div>
      <div style={{alignItems: 'center'}}>
        <ExportOrderAccepted apiData={orders} fileName={fileNameOrderAccepted} />
      </div>
    </div>
  );
};

export default ListBDS;
