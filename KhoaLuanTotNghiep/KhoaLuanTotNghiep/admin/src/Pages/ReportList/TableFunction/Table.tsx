import React, { useState } from 'react';
import { PencilFill, XCircle } from 'react-bootstrap-icons';
import { useHistory } from 'react-router';
import ButtonIcon from 'src/components/ButtonIcon';
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import "../../../styles/BDS.css";
import ConfirmModal from 'src/components/ConfirmModal';
import IAsset from 'src/interfaces/Asset/IAsset';
import IColumnOption from 'src/interfaces/IColumnOption';
import IPagedModel from 'src/interfaces/IPagedModel';
import { useAppDispatch } from 'src/hooks/redux';
import IReport from 'src/interfaces/Report/IReport';
import { object } from 'yup/lib/locale';

import Info from 'src/Pages/ReportList/TableFunction/Info';

type Props = {
  reports: IReport | null;
  fetchData: Function;
};

const ReportTable = ({
  reports,
  fetchData,
}) => {
  const dispatch = useAppDispatch();

  const [report, setreports] = useState([]);
  const [showDetail, setShowDetail] = useState(false);
  const [ReportDetail, setReportDetail] = useState(null as IReport | null);
  const [disableState, setDisableState] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowInfo = (reportID: string) => {
    {
      reports.map((item) => {
        if (item.reportID === reportID) {
          const report = item;
          if (report) {
            setReportDetail(report);
            setShowDetail(true);
          }
        }
      });
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  return (
    <>
      <Table responsive>
        <thead>
          <tr
            style={{ fontWeight: 'normal', fontSize: '18px' }}
            className="title-table"
          >
            <th style={{ width: "2%" }}>STT</th>
            <th style={{ width: "14%" }}>Report Code</th>
            <th style={{ width: "14%" }}>RealEstate Code</th>
            <th style={{ width: "30%" }}>Title</th>
            <th style={{ width: "30%" }}>Content Report</th>
            <th style={{ width: "10%" }}>Create Time</th>
          </tr>
        </thead>
        <tbody className='body'>
          {reports && reports.map((data, i) => (
            <tr
              style={{ fontWeight: 'normal', fontSize: '14px' }}
              key={data.reportID}
              onClick={() => handleShowInfo(data.reportID)}
            >
              <th scope="row">{i + 1}</th>
              <td>{data.reportID}</td>
              <td>{data.realEstateID}</td>
              <td>{data.title}</td>
              <td>{data.status}</td>
              <td>
                {new Date(data.createTime).toLocaleString(
                  'en-GB',
                  {
                    year: 'numeric',
                    month: 'numeric',
                    day: 'numeric',
                  }
                )}
              </td>
                {/* <td className="d-flex">
                  <ButtonIcon
                    onClick={() => handleEdit(data.ReportID)}
                  >
                    <PencilFill className="text-black" />
                  </ButtonIcon>
                </td> */}
            </tr>
          ))}
        </tbody>
      </Table>
   
      {ReportDetail && showDetail && (
        <Info reports={ReportDetail} handleClose={handleCloseDetail} />
      )}
    </>
  );
};

export default ReportTable;
