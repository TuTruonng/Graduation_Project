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
import { EDIT_USER_ID } from '../../../constants/pages';
import IUser from 'src/interfaces/User/IUser';
import IColumnOption from 'src/interfaces/IColumnOption';
import IPagedModel from 'src/interfaces/IPagedModel';
import { useAppDispatch } from 'src/hooks/redux';
import { disableUser } from '../reducer';

const columns: IColumnOption[] = [
    { columnName: 'User Code', columnValue: 'userId' },
    { columnName: 'Full Name', columnValue: 'fullName' },
    { columnName: 'User Name', columnValue: 'username' },
    { columnName: 'Email', columnValue: 'email' },
    { columnName: 'Phone', columnValue: 'phoneNumber' },
    { columnName: 'Joined Date', columnValue: 'joinedDate' },
    { columnName: 'Create Date', columnValue: 'createDate' },
    { columnName: 'Type', columnValue: 'Type' },
];

type Props = {
    users: IUser | null;
    fetchData: Function;
};

const UserTable = ({ users, fetchData }) => {
    const dispatch = useAppDispatch();

    const [showDetail, setShowDetail] = useState(false);
    const [userDetail, setUserDetail] = useState(null as IUser | null);
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
            message: 'Do you want to disable this user?',
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
        {users.map((item) => {
            if (item.userId === userId) {
                const user = item;
                if (user) {
                    setUserDetail(user);
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
                `Disable user successful`,
                `Disable successful`,
                2000
            );
        } else {
            setDisableState({
                ...disableState,
                title: 'Can not disable user',
                message,
                isDisable: result,
            });
        }
    };

    const handleSubmitDisable = async () => {
        //const isSuccess = await DisableUserRequest(disableState.id);
        dispatch(
            disableUser({
                handleResult,
                userId: disableState.id
            })
        );
        /*if (isSuccess) {
            console.log("Disable success");
            await handleResult(true, '');
        }*/
    };

    const history = useHistory();
    const handleEdit = (userId: string) => {
        {users.map((item) => {
            if (item.userId === userId) {
              history.push(EDIT_USER_ID(userId), {
                existUser: item,
              });
            }
          })
        }
    };
    
    return (
        console.log('users'),
        console.log(users),
        <>
            <Table responsive>
                <thead>
                    <tr
                        style={{ fontWeight: 'normal', fontSize: '18px', textAlign: 'center' }}
                        className="title-table"
                    >
                        <th style={{ width: "1%" }}>STT</th>
                        <th style={{ width: "15%" }}>User Code</th>
                        {/* <th>Mã Loại</th>
                        <th>Mã Nhân viên</th>
                        <th>Mã Báo Cáo</th> */}
                        <th style={{ width: "10%" }}>Full Name</th>
                        <th style={{ width: "10%" }}>User Name</th>
                        <th style={{ width: "10%" }}>Joined Date</th>
                        {/* <th>Trạng Thái</th> */}
                        <th style={{ width: "3%" }}>Type</th>
                        <th style={{ width: "3%" }}>Action</th>
                    </tr>
                </thead>
                <tbody className='body'>
                    {users && users.map((data, i) => (
                        <tr
                            style={{ fontWeight: 'normal', fontSize: '14px' }}
                            key={data.userId}
                            onClick={() => handleShowInfo(data.userId)}
                        >
                            <th scope="row">{i + 1}</th>
                            <td>{data.userId}</td>
                            {/* <td>{item.categoryID}</td>
                            <td>{item.userID}</td>
                            <td>{item.reportID}</td> */}
                            <td>{data.fullName}</td>
                            <td>{data.username}</td>
                            <td>
                                {new Date(data.joinedDate).toLocaleString(
                                    'en-GB',
                                    {
                                        year: 'numeric',
                                        month: 'numeric',
                                        day: 'numeric',
                                    }
                                )}
                            </td>
                            <td>{data.type}</td>
                            <td className="d-flex">
                                <ButtonIcon onClick={() => handleEdit(data.userId)}>
                                    <PencilFill className="text-black" />
                                </ButtonIcon>
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

            {userDetail && showDetail && (
                <Info user={userDetail} handleClose={handleCloseDetail} />
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

export default UserTable;
