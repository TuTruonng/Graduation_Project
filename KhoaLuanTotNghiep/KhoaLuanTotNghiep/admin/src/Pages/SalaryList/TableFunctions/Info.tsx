import React from 'react';
import { Modal } from 'react-bootstrap';
import IInfo from '../../../interfaces/Info/IInfo';

type Props = {
    infos: IInfo;
    handleClose: () => void;
};

const Infos: React.FC<Props> = ({ infos, handleClose }) => {
    return (
        <>
            <Modal show={true} onHide={handleClose} dialogClassName="modal-90w">
                <Modal.Header closeButton>
                    <Modal.Title id="login-modal">
                        Detailed Info Infosrmation
                    </Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div>
                        <div className="row -intro-y">
                            <div className="col-4">User Code:</div>
                            <div>{infos.userId}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Full Name:</div>
                            <div>{infos.fullName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">USername:</div>
                            <div>{infos.username}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Salary Basic:</div>
                            <div>{infos.salaryBasic}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Salary:</div>
                            <div>{infos.salary}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Total Quantity RealEstate:</div>
                            <div>{infos.quantityRealEstate}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Quantity RealEstate Waiting Accept:</div>
                            <div>{infos.quantityRealEstateWaitingAccept}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Quantity RealEstate Ordered:</div>
                            <div>{infos.quantityRealEstateSelled}</div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default Infos;
