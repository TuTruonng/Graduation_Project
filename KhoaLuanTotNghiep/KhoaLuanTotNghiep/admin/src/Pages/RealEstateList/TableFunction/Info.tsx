import React from 'react';
import { Modal } from 'react-bootstrap';
import IRealEstate from '../../../interfaces/RealEstate/IRealEstate';

type Props = {
    realEstates: IRealEstate;
    handleClose: () => void;
};

const Info: React.FC<Props> = ({ realEstates, handleClose }) => {

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
                            <div>{realEstates.realEstateID}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">User Name:</div>
                            <div>{realEstates.userName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Category Name:</div>
                            <div>{realEstates.categoryName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Title:</div>
                            <div>{realEstates.title}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Price:</div>
                            <div>{realEstates.price}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Description:</div>
                            <div>{realEstates.description}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Create Time:</div>
                            <div>{new Date(realEstates.createTime).toLocaleString(
                                'en-GB',
                                {
                                    year: 'numeric',
                                    month: 'numeric',
                                    day: 'numeric',
                                }
                            )}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Update Time:</div>
                            <div>{new Date(realEstates.updateTime).toLocaleString(
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
                            <div>{realEstates.phoneNumber}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Approve:</div>
                            {/* <div>{getBrandTypeName(RealEstate.type)}</div> */}
                            <div>{realEstates.approve}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Loacation:</div>
                            {/* <div>{getBrandTypeName(RealEstate.type)}</div> */}
                            <div>{realEstates.location}</div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default Info;
