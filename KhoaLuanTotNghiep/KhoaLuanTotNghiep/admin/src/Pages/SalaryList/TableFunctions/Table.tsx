import React, { useState } from 'react';
import { PencilFill, XCircle } from 'react-bootstrap-icons';
import { useHistory } from 'react-router';
import ButtonIcon from 'src/components/ButtonIcon';
import { NotificationManager } from 'react-notifications';
import "../../../styles/BDS.css"
import { Button, Table } from "reactstrap";
import Info from './Info';
import IInfo from 'src/interfaces/Info/IInfo';
import { useAppDispatch } from 'src/hooks/redux';

type Props = {
    infos: IInfo | null;
    fetchData: Function;
};

const InfoTable = ({ infos, fetchData }) => {
    const dispatch = useAppDispatch();

    const [showDetail, setShowDetail] = useState(false);
    const [InfoDetail, setInfoDetail] = useState(null as IInfo | null);
    const [disableState, setDisableState] = useState({
        isOpen: false,
        id: 0,
        title: '',
        message: '',
        isDisable: true,
    });

    const handleShowInfo = (userId: string) => {
            if (infos.userId === userId) {
                const info = infos;
                if (info) {
                    setInfoDetail(info);
                    setShowDetail(true);
                }
            }
          };
    
    const handleCloseDetail = () => {
        setShowDetail(false);
    };
    
    return (
        console.log('Infos object'),
        console.log(infos),
        
        <>
        
            <Table responsive>
                <thead>
                    <tr
                        style={{ fontWeight: 'normal', fontSize: '18px', textAlign: 'center' }}
                        className="title-table"
                    >
                        <th style={{ width: "15%" }}>User Code</th>
                        <th style={{ width: "10%" }}>Full Name</th>
                        <th style={{ width: "10%" }}>User Name</th>
                        <th style={{ width: "10%" }}>Salary Basic</th>
                        <th style={{ width: "10%" }}>Salary</th>
                        <th style={{ width: "13%" }}>Total Quantity RealEstate</th>
                        <th style={{ width: "15%" }}>Quantity RealEstate Waiting Accept</th>
                        <th style={{ width: "15%" }}>Quantity RealEstate Ordered</th>
                    </tr>
                </thead>
                <tbody className='body'>
                {infos && (
                        <tr
                            style={{ fontWeight: 'normal', fontSize: '14px' }}
                            key={infos.userId}
                            onClick={() => handleShowInfo(infos.userId)}
                        >
                            <td>{infos.userId}</td>                    
                            <td>{infos.fullName}</td>
                            <td>{infos.username}</td>
                            <td>{infos.salaryBasic}</td>
                            <td>{infos.salary}</td>
                            <td>{infos.quantityRealEstate}</td>
                            <td>{infos.quantityRealEstateWaitingAccept}</td>
                            <td>{infos.quantityRealEstateSelled}</td>
                        </tr>
             )}
                </tbody>
            </Table>

            {InfoDetail && showDetail && (
                <Info infos={InfoDetail} handleClose={handleCloseDetail} />
            )}
        </>
    );
};

export default InfoTable;
