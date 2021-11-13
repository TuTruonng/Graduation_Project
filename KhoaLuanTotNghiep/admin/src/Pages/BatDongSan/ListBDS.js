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
  const handleCreate = () => setSelected({ Name: "", TypeProductId: 0 });

  const handleDelete = (itemId) => {
    let result = window.confirm("Delete this item?");
    if (result) {
        BatDongSanService.delete(itemId).then((resp) => {
        setrealEstate(_removeViewItem(realEstate, itemId));
      });
    }
  };

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
    <div class="content-wrapper" >
      <br />
      <h3  style={{color:"#58257b", fontSize:"36px"}}>Bất Động Sản</h3>
      <br />
      <div className="text-right">
        <div className="row" style={{ marginLeft: "500px" }}>
          <div class="col-sm-6"  >
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
      <Table responsive="xl">
        <thead>
          <tr className="title-table">
            <th>STT</th>
            <th>RealEstateID</th>
            <th>CategoryID</th>
            <th>UserID</th>
            <th>ReportID</th>
            <th>Title</th>
            <th>Price</th>
            <th>Image</th>
            <th>Description</th>
            <th>Location</th>
            <th>PhoneNumber</th>
            <th>status</th>
            <th>Approve</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {realEstate.map(function (item, i) {
            return (
              <tr>
                <th scope="row">{i + 1}</th>
                <td className="id">{item.realEstateID}</td>
                <td>{item.categoryID}</td>
                <td>{item.userID}</td>
                <td>{item.reportID}</td>
                <td className="title">{item.title}</td>
                <td>{item.price}</td>
                <td><img className="img" src={item.image} text={item.realEstateName}/></td> 
                <td>{item.description}</td>
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
