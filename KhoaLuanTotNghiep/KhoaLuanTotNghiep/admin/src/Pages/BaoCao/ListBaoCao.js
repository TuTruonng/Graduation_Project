import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import BaoCaoService from "../../Services/BaoCaoService";
import "./BaoCao.css";
import {ExportToExcel} from'./ExportToExcel ';

const ListBaoCao = () => {
  const [report, setreports] = useState([]);
  const [itemSelected, setSelected] = React.useState(null);
  const fileName = "Report file"; // here enter filename for your excel file
  let params = {};
  useEffect(() => {
    params = {     
      query: "",
    };
    _fetchReport();
  }, []);


  const _fetchReport = () => {
    BaoCaoService.getList().then(({ data }) => setreports(data));
  };
  console.log("leduyen");
  const handleCreate = () => setSelected({ Name: "", TypeProductId: 0 });

  const handleDelete = (itemId) => {
    let result = window.confirm("Delete this item?");
    if (result) {
        BaoCaoService.delete(itemId).then((resp) => {
        setreports(_removeViewItem(report, itemId));
      });
    }
  };

  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.reportID !== itemDel);

    const handleSearch = (query) => {
      params.query = query;
      _fetchReport();
    };
  
    const handleSearchKey = () => {
      params.query = "";
      _fetchReport();
    };
  

  return (
    <div class="content-wrapper">
       <br />
      <h3 className=" sidebar-light-primary elevation-2" id="h3"><b>Báo Cáo</b></h3> 
      <br />
      <div className="text-right">
        <div className="row" style={{ marginLeft: "500px" }}>
          <div class="col-sm-6"  >
            <div className="input-group" data-widget="sidebar-search"  >
              <input       
                className="form-control form-control-sidebar"
                type="search"
                placeholder="Tìm Kiếm"
                aria-label="Search"
              />
              <div className="input-group-append" style={{border: "1px dotted #e0dcdc"}}>
                <button className="btn btn-sidebar">
                  <i className="fas fa-search fa-fw"></i>
                </button>             
              </div>
            
            </div>
          </div>        
        </div>
        
      </div>
      <br/>
      <Table className="elevation-2" style ={{backgroundColor : "#e9d8f4", bordercollapse:"collapse",width:"1490px"}}>
     
        <thead>
          <tr style ={{backgroundColor : "#58257b", color:"white", fontSize:"18px"}}>
            <th>STT</th>
            <th>Mã Báo Cáo</th>
            <th>Mã Bất Động Sản</th>
            <th>Trạng Thái</th>
            <th>Địa Chỉ IP</th>
            <th>Thời Gian Tạo</th>
            <th>Thời Gian Cập Nhật</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {report.map(function (item, i) {
            return (
              <tr>
                <th scope="row">{i + 1}</th>
                <td>{item.reportID}</td>
                <td>{item.realEstatetID}</td>
                <td>{item.status}</td>
                <td>{item.ipAddress}</td>
                <td>{item.createTime}</td>
                <td>{item.updateTime}</td>
                {/* <td className="text-right">                
                  <i
                    className="fas fa-trash-alt"
                    style={{
                      marginLeft: "10px",
                      marginRight: "30px",
                      fontSize: "20px",
                      color: "#E54646",
                    }}
                    onClick={() => handleDelete(item.reportID)}
                  ></i>
                </td> */}
              </tr>
            );
          })}
        </tbody>
      </Table>
      <div ><ExportToExcel apiData={report} fileName={fileName} /></div>
    </div>
  );
};

export default ListBaoCao;
