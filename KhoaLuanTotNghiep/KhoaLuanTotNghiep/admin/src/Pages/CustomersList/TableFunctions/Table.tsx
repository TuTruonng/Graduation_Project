import React, { useState } from 'react';
import { PencilFill, XCircle } from 'react-bootstrap-icons';
import { useHistory } from 'react-router';
import ButtonIcon from 'src/components/ButtonIcon';
import { NotificationManager } from 'react-notifications';
import "../../../styles/BDS.css"
// import Table, { SortType } from 'src/components/Table';
import { Button, Table } from "reactstrap";
import Info from './Info';
import ConfirmModal from 'src/components/ConfirmModal';
import ICustomer from 'src/interfaces/User/ICustomer';
import IColumnOption from 'src/interfaces/IColumnOption';
import IPagedModel from 'src/interfaces/IPagedModel';
import { useAppDispatch } from 'src/hooks/redux';
import { disableCustomer } from '../reducer';

type Props = {
    Customers: ICustomer | null;
    fetchData: Function;
};

const CustomerTable = ({ Customers, fetchData }) => {
    const dispatch = useAppDispatch();

    const [showDetail, setShowDetail] = useState(false);
    const [CustomerDetail, setCustomerDetail] = useState(null as ICustomer | null);
    const [disableState, setDisableState] = useState({
        isOpen: false,
        id: 0,
        title: '',
        message: '',
        isDisable: true,
    });

    const handleShowDisableBox = async (id) => {
        setDisableState({
            id,
            isOpen: true,
            title: 'Are you sure?',
            message: 'Do you want to disable this Customer?',
            isDisable: true,
        });
    };

    const handleCancelDisable = () => {
        setDisableState({
            isOpen: false,
            id: 0,
            title: '',
            message: '',
            isDisable: true,
        });
    };

    const handleShowInfo = (userId: string) => {
        {Customers.map((item) => {
            if (item.userId === userId) {
                const Customer = item;
                if (Customer) {
                    setCustomerDetail(Customer);
                    setShowDetail(true);
                }
            }
          });
        }
    };

    const handleCloseDetail = () => {
        setShowDetail(false);
    };

    const handleResult = async (result, message) => {
        if (result) {
            handleCancelDisable();
            await fetchData();
            NotificationManager.success(
                `Disable Customer successful`,
                `Disable successful`,
                2000
            );
        } else {
            setDisableState({
                ...disableState,
                title: 'Can not disable Customer',
                message,
                isDisable: result,
            });
        }
    };

    const handleSubmitDisable = async () => {
        //const isSuccess = await DisableCustomerRequest(disableState.id);
        dispatch(
            disableCustomer({
                handleResult,
                CustomerId: disableState.id
            })
        );
        /*if (isSuccess) {
            console.log("Disable success");
            await handleResult(true, '');
        }*/
    };

    return (
        console.log('Customers'),
        console.log(Customers),
        <>
            <Table responsive>
                <thead>
                    <tr
                        style={{ fontWeight: 'normal', fontSize: '18px', textAlign: 'left' }}
                        className="title-table"
                    >
                        <th style={{ width: "5%" }}>STT</th>
                        <th style={{ width: "30%" }}>Customer Code</th>
                        {/* <th>Mã Loại</th>
                        <th>Mã Nhân viên</th>
                        <th>Mã Báo Cáo</th> */}
                        <th style={{ width: "20%" }}>Full Name</th>
                        <th style={{ width: "30%" }}>Customer Name</th>
                        {/* <th>Trạng Thái</th> */}
                        <th style={{ width: "10%" }}>Type</th>
                        <th style={{ width: "5%" }}>Action</th>
                    </tr>
                </thead>
                <tbody className='body'>
                    {Customers && Customers.map((data, i) => (
                        <tr
                            style={{ fontWeight: 'normal', fontSize: '14px' }}
                            key={data.userId}
                            onClick={() => handleShowInfo(data.userId)}
                        >
                            <th scope="row">{i + 1}</th>
                            <td>{data.userId}</td>
                            {/* <td>{item.categoryID}</td>
                            <td>{item.CustomerID}</td>
                            <td>{item.reportID}</td> */}
                            <td>{data.fullName}</td>
                            <td>{data.username}</td>
                            <td>{data.type}</td>
                            <td className="d-flex">
                                <ButtonIcon
                                    onClick={() => handleShowDisableBox(data.userId)}
                                >
                                    <XCircle className="text-danger mx-2" />
                                </ButtonIcon>
                            </td>

                        </tr>
                    ))}
                </tbody>
            </Table>

            {CustomerDetail && showDetail && (
                <Info Customer={CustomerDetail} handleClose={handleCloseDetail} />
            )}
            <ConfirmModal
                title={disableState.title}
                isShow={disableState.isOpen}
                onHide={handleCancelDisable}
            >
                <div>
                    <div className="text-center">{disableState.message}</div>
                    {disableState.isDisable && (
                        <div className="text-center mt-3">
                            <button
                                className="btn btn-danger mr-3"
                                onClick={handleSubmitDisable}
                                type="button"
                            >
                                Disable
                            </button>

                            <button
                                className="btn btn-outline-secondary"
                                onClick={handleCancelDisable}
                                type="button"
                            >
                                Cancel
                            </button>
                        </div>
                    )}
                </div>
            </ConfirmModal>
        </>
    );
};

export default CustomerTable;
