import React from 'react';
import { Modal } from 'react-bootstrap';
import IOrder from '../../../interfaces/Order/IOrder';

type Props = {
    orders: IOrder;
    handleClose: () => void;
};

const Info: React.FC<Props> = ({ orders, handleClose }) => {

    return (
        <>
            <Modal show={true} onHide={handleClose} dialogClassName="modal-90w">
                <Modal.Header closeButton>
                    <Modal.Title id="login-modal">
                        Detailed order Information
                    </Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div>
                        <div className="row -intro-y">
                            <div className="col-4">Order Code:</div>
                            <div>{orders.orderID}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">RealEstate Code:</div>
                            <div>{orders.realEstateID}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">RealEstate Title:</div>
                            <div>{orders.title}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Customer Name:</div>
                            <div>{orders.userName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Admin Name:</div>
                            <div>{orders.adminName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Order Date:</div>
                            <div>{new Date(orders.orderDate).toLocaleString(
                                'en-GB',
                                {
                                    year: 'numeric',
                                    month: 'numeric',
                                    day: 'numeric',
                                }
                            )}</div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default Info;
