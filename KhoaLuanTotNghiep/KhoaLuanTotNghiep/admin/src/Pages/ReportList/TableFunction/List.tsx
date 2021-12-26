import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import BatDongSanService from "src/Services/BatDongSanService";
import IReport from "src/interfaces/Report/IReport";
import { getReports } from "../reducer";
import ReportTable from "./Table";
import { ExportToExcel } from '../ExportToExcel';

type Props = {
  reports: IReport | null;
  fetchData: Function;
};

const ListBDS = () => {
  const dispatch = useAppDispatch();
  const fileName = "Report file"; // here enter filename for your excel file
  const { reports, loading } = useAppSelector((state) => state.reportReducer);
  const [Report, setReport] = useState([]);
  const [itemSelected, setSelected] = React.useState(null);
  // let params = {};

  const fetchData = () => {
    dispatch(getReports(Report));
  };

  useEffect(() => {
    fetchData();
  }, []);

  console.log(reports);

  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.ReportID !== itemDel);

  return (
    <div className="content-wrapper" >
      <br />
      <h3 className="invalid"><b>Report List</b></h3>
      <br />
      <div className='tblReport'>
        <ReportTable
          reports={reports}
          fetchData={fetchData}
        />
      </div>
      <div>
        <ExportToExcel apiData={reports} fileName={fileName}/>
        </div>
    </div>
  );
};

export default ListBDS;
