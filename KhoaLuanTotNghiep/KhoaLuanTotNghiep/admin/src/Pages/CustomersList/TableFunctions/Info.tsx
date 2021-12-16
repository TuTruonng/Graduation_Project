import React from 'react';
import { Modal } from 'react-bootstrap';
import ICustomer from '../../../interfaces/User/ICustomer';

type Props = {
    Customer: ICustomer;
    handleClose: () => void;
};

const Info: React.FC<Props> = ({ Customer, handleClose }) => {
    return (
        <>
            <Modal show={true} onHide={handleClose} dialogClassName="modal-90w">
                <Modal.Header closeButton>
                    <Modal.Title id="login-modal">
                        Detailed Customer Information
                    </Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div>
                        <div className="row -intro-y">
                            <div className="col-4">Customer Code:</div>
                            <div>{Customer.userId}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Full Name:</div>
                            <div>{Customer.fullName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Customername:</div>
                            <div>{Customer.username}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Email:</div>
                            <div>{Customer.email}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Phone:</div>
                            <div>{Customer.phoneNumber}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Joined Date:</div>
                            <div>{new Date(Customer.joinedDate).toLocaleString(
                                'en-GB',
                                {
                                    year: 'numeric',
                                    month: 'numeric',
                                    day: 'numeric',
                                }
                            )}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Create Date:</div>
                            <div>{new Date(Customer.createDate).toLocaleString(
                                'en-GB',
                                {
                                    year: 'numeric',
                                    month: 'numeric',
                                    day: 'numeric',
                                }
                            )}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Type:</div>
                            {/* <div>{getBrandTypeName(Customer.type)}</div> */}
                            <div>{Customer.type}</div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default Info;
