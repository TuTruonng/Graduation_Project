import React, { useState } from 'react';
import { PencilFill, XCircle } from 'react-bootstrap-icons';
import { useHistory } from 'react-router';
import ButtonIcon from 'src/components/ButtonIcon';
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import "../../../styles/BDS.css";
import ConfirmModal from 'src/components/ConfirmModal';
import IAsset from 'src/interfaces/Asset/IAsset';
import IColumnOption from 'src/interfaces/IColumnOption';
import IPagedModel from 'src/interfaces/IPagedModel';
import { useAppDispatch } from 'src/hooks/redux';
import IOrder from 'src/interfaces/Order/IOrder';
import { object } from 'yup/lib/locale';
import Info from './Info';

type Props = {
  orders: IOrder | null;
  fetchData: Function;
};

const OrderTable = ({
  orders,
  fetchData,
}) => {
  const dispatch = useAppDispatch();


  const [showDetail, setShowDetail] = useState(false);
  const [OrderDetail, setOrderDetail] = useState(null as IOrder | null);
  const [disableState, setDisableState] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowInfo = (orderId: string) => {
    {
      orders.map((item) => {
        if (item.orderId === orderId) {
          const order = item;
          if (order) {
            setOrderDetail(order);
            setShowDetail(true);
          }
        }
      });
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  return (
    <>
      <Table responsive>
        <thead>
          <tr
            style={{ fontWeight: 'normal', fontSize: '18px' }}
            className="title-table"
          >
            <th style={{ width: "2%" }}>STT</th>
            <th style={{ width: "14%" }}>Order Code</th>
            <th style={{ width: "14%" }}>RealEstate Code</th>
            <th style={{ width: "40%" }}>RealEstate Title</th>
            <th style={{ width: "10%" }}>Customer Name</th>
            <th style={{ width: "10%" }}>Admin Name</th>
            <th style={{ width: "10%" }}>Order Date</th>
          </tr>
        </thead>
        <tbody className='body'>
          {orders && orders.map((data, i) => (
            <tr
              style={{ fontWeight: 'normal', fontSize: '14px' }}
              key={data.orderId}
              onClick={() => handleShowInfo(data.orderId)}
            >
              <th scope="row">{i + 1}</th>
              <td>{data.orderId}</td>
              <td>{data.realEstateId}</td>
              <td>{data.title}</td>
              <td>{data.userName}</td>
              <td>{data.adminName}</td>
        
              <td>
                {new Date(data.orderDate).toLocaleString(
                  'en-GB',
                  {
                    year: 'numeric',
                    month: 'numeric',
                    day: 'numeric',
                  }
                )}
              </td>
              {/* {data.approve == 'False' && (
                <td className="d-flex">
                  <ButtonIcon
                    onClick={() => handleEdit(data.OrderID)}
                  >
                    <PencilFill className="text-black" />
                  </ButtonIcon>
                </td>
              )}
              {data.approve == 'True' && (
                <td><p>Approved</p></td>
              )} */}
            </tr>
          ))}
        </tbody>
      </Table>
      {OrderDetail && showDetail && (
        <Info orders={OrderDetail} handleClose={handleCloseDetail} />
      )}
    </>
  );
};

export default OrderTable;
