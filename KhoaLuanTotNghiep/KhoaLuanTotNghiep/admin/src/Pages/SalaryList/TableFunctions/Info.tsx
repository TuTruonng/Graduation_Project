import React from 'react';
import { Modal } from 'react-bootstrap';

import IUser from '../../../interfaces/User/IUser';
// import formatDateTime from 'src/utils/formatDateTime';
// import {
//     NormalBrandType,
//     NormalBrandTypeLabel,
//     LuxuryBrandType,
//     LuxyryBrandTypeLabel,
// } from 'src/constants/Brand/BrandConstants';

type Props = {
    user: IUser;
    handleClose: () => void;
};

const Info: React.FC<Props> = ({ user, handleClose }) => {
    // const getBrandTypeName = (id: number) => {
    //     return id == LuxuryBrandType
    //         ? LuxyryBrandTypeLabel
    //         : NormalBrandTypeLabel;
    // };

    return (
        <>
            <Modal show={true} onHide={handleClose} dialogClassName="modal-90w">
                <Modal.Header closeButton>
                    <Modal.Title id="login-modal">
                        Detailed User Information
                    </Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div>
                        <div className="row -intro-y">
                            <div className="col-4">User Code:</div>
                            <div>{user.userId}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Full Name:</div>
                            <div>{user.fullName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Username:</div>
                            <div>{user.username}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Email:</div>
                            <div>{user.email}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Phone:</div>
                            <div>{user.phoneNumber}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Salary Basic:</div>
                            <div>{user.salaryBasic}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Salary:</div>
                            <div>{user.salary}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Joined Date:</div>
                            <div>{new Date(user.joinedDate).toLocaleString(
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
                            <div>{new Date(user.createDate).toLocaleString(
                                'en-GB',
                                {
                                    year: 'numeric',
                                    month: 'numeric',
                                    day: 'numeric',
                                }
                            )}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Date Of Birth:</div>
                            <div>{new Date(user.dateOfBirth).toLocaleString(
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
                            {/* <div>{getBrandTypeName(user.type)}</div> */}
                            <div>{user.type}</div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default Info;
