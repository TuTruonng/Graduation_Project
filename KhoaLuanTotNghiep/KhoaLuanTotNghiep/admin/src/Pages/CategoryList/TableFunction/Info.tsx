import React from 'react';
import { Modal } from 'react-bootstrap';
import ICategory from '../../../interfaces/Category/ICategory';

type Props = {
    category: ICategory;
    handleClose: () => void;
};

const Info: React.FC<Props> = ({ category, handleClose }) => {
    return (
        <>
            <Modal show={true} onHide={handleClose} dialogClassName="modal-90w">
                <Modal.Header closeButton>
                    <Modal.Title id="login-modal">
                        Detailed Category Information
                    </Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div>
                        <div className="row -intro-y">
                            <div className="col-4">Category Code:</div>
                            <div>{category.categoryID}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Category Name:</div>
                            <div>{category.categoryName}</div>
                        </div>

                        <div className="row -intro-y">
                            <div className="col-4">Description:</div>
                            <div>{category.description}</div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default Info;
