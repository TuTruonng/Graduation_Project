import React from 'react';
import { Modal } from 'react-bootstrap';
import IReport from '../../../interfaces/Report/IReport';

type Props = {
    reports: IReport;
    handleClose: () => void;
};

const Info: React.FC<Props> = ({ reports, handleClose }) => {
    return (
        <>
            <Modal show={true} onHide={handleClose} dialogClassName="modal-90w">
                <Modal.Header closeButton>
                    <Modal.Title id="login-modal">
                        Detailed Report Information
                    </Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div>
                        <div className="row -intro-y">
                            <div className="col-4">report Code:</div>
                            <div>{reports.reportID}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">RealEstate Code:</div>
                            <div>{reports.realEstateID}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Content Report:</div>
                            <div>{reports.status}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">IPAdress:</div>
                            <div>{reports.ipAddress}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Create Time:</div>
                            <div>{new Date(reports.createTime).toLocaleString(
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
                            <div>{new Date(reports.updateTime).toLocaleString(
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
