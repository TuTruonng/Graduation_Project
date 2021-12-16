import React from 'react';
import { Modal } from 'react-bootstrap';
import INews from '../../../interfaces/News/INews';

type Props = {
    news: INews;
    handleClose: () => void;
};
const username = localStorage.getItem('user');
const Info: React.FC<Props> = ({ news, handleClose }) => {
    return (
        <>
            <Modal show={true} onHide={handleClose} dialogClassName="modal-90w">
                <Modal.Header closeButton>
                    <Modal.Title id="login-modal">
                        Detailed News Information
                    </Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div>
                        <div className="row -intro-y">
                            <div className="col-4">News Code:</div>
                            <div>{news.newsID}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">News Name:</div>
                            <div>{news.newsName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">User Name:</div>
                            <div>{username}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Description:</div>
                            <div>{news.description}</div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default Info;
