import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import history from "../../Helpers/Help";
import BatDongSanService from "../../Services/BatDongSanService";
import "./BDS.css"

const ListBDS = () => {
  const [realEstate, setrealEstate] = useState([]);
  const [itemSelected, setSelected] = React.useState(null);
  let params = {};

  useEffect(() => {
    params = {     
      query: "",
    };
    _fetchBDSs();
  }, []);


  const _fetchBDSs = () => {
    BatDongSanService.getList().then(({ data }) => setrealEstate(data));
  };
  // const handleCreate = () => setSelected({ Name: "", TypeProductId: 0 });

  // const handleDelete = (itemId) => {
  //   let result = window.confirm("Delete this item?");
  //   if (result) {
  //       BatDongSanService.delete(itemId).then((resp) => {
  //       setrealEstate(_removeViewItem(realEstate, itemId));
  //     });
  //   }
  // };

  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.realEstateID !== itemDel);

    const handleSearch = (query) => {
      params.query = query;
      _fetchBDSs();
    };
  
    const handleSearchKey = () => {
      params.query = "";
      _fetchBDSs();
    };
  

  return (
    <div className="content-wrapper" >
       <br />
      <h3 className=" sidebar-light-primary elevation-2" id="h3"><b>Danh sách  bất động sản</b></h3> 
      <br />
      <div className="text-right">
        <div className="row" style={{ marginLeft: "500px" }}>
          <div className="col-sm-6"  >
            <div className="input-group" data-widget="sidebar-search"  >
              <input       
                className="form-control form-control-sidebar"
                type="search"
                placeholder="Search"
                aria-label="Search"
              />
              <div className="input-group-append">
                <button className="btn btn-sidebar">
                  <i className="fas fa-search fa-fw"></i>
                </button>              
              </div>
            </div>
          </div>
        </div>    
      </div>

      <br/>

      <Table responsive="xl" >
        <thead>
          <tr className="title-table">
            <th>STT</th>
            <th>Mã BDS</th>
            <th>Mã Loại</th>
            <th>Mã Nhân viên</th>
            <th>Mã Báo Cáo</th>
            <th>Tiêu đề</th>
            <th>Gía</th>
            <th>Hình Ảnh</th>
            <th>Mô Tả</th>
            <th>Vị Trí</th>
            <th>SDT</th>
            <th>Trạng Thái</th>
            <th>Xác Nhận</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody className='body'>
          {realEstate && realEstate?.items?.map((item, i) => {
            return (
              <tr style={{backgroundColor:"#e9d8f4"}}>
                <th scope="row">{i + 1}</th>
                <td className="id">{item.realEstateID}</td>
                <td>{item.categoryID}</td>
                <td>{item.userID}</td>
                <td>{item.reportID}</td>
                <td className="title">{item.title}</td>
                <td>{item.price}</td>
                <td><img className="img" src={item.image} text={item.realEstateName}/></td> 
                <td className="descripion">{item.description}</td>
                <td>{item.location}</td>
                <td>{item.phoneNumber}</td>
                <td>{item.status}</td>
                <td>{item.approve}</td>
                <td className="text-right">
                  <Link to={`EditBDS/${item.realEstateID}`}>
                    <i
                      className="fas fa-edit"
                      style={{
                        marginLeft: "10px",
                        marginRight: "10px",
                        fontSize: "20px",  
                        float: "left",              
                      }}
                    >
                      {" "}
                    </i>
                  </Link>       
                </td>
              </tr>
            );
          })}
        </tbody>
      </Table>
    </div>
  );
};

export default ListBDS;
