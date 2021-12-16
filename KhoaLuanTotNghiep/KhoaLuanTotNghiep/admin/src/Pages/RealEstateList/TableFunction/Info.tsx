import React from 'react';
import { Modal } from 'react-bootstrap';
import IRealEstate from '../../../interfaces/RealEstate/IRealEstate';

type Props = {
    RealEstate: IRealEstate;
    handleClose: () => void;
};

const Info: React.FC<Props> = ({ RealEstate, handleClose }) => {

    return (
        <>
            <Modal show={true} onHide={handleClose} dialogClassName="modal-90w">
                <Modal.Header closeButton>
                    <Modal.Title id="login-modal">
                        Detailed RealEstate Information
                    </Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div>
                        <div className="row -intro-y">
                            <div className="col-4">RealEstate Code:</div>
                            <div>{RealEstate.realEstateID}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">User Name:</div>
                            <div>{RealEstate.userName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Category Name:</div>
                            <div>{RealEstate.categoryName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Title:</div>
                            <div>{RealEstate.title}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Phone:</div>
                            <div>{RealEstate.price}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Salary Basic:</div>
                            <div>{RealEstate.image}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Salary:</div>
                            <div>{RealEstate.description}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Joined Date:</div>
                            <div>{new Date(RealEstate.createTime).toLocaleString(
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
                            <div>{new Date(RealEstate.updateTime).toLocaleString(
                                'en-GB',
                                {
                                    year: 'numeric',
                                    month: 'numeric',
                                    day: 'numeric',
                                }
                            )}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Phone:</div>
                            {/* <div>{getBrandTypeName(RealEstate.type)}</div> */}
                            <div>{RealEstate.phoneNumber}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Approve:</div>
                            {/* <div>{getBrandTypeName(RealEstate.type)}</div> */}
                            <div>{RealEstate.approve}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Loacation:</div>
                            {/* <div>{getBrandTypeName(RealEstate.type)}</div> */}
                            <div>{RealEstate.location}</div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default Info;
