import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import TinTucService from "../../Services/TinTucService";
import "./TinTuc.css"

const ListTinTuc = () => {
  const [news, setnews] = useState([]);
  const [itemSelected, setSelected] = React.useState(null);
  let params = {};
  useEffect(() => {
    params = {     
      query: "",
    };
    _fetchNews();
  }, []);


  const _fetchNews = () => {
    TinTucService.getList().then(({ data }) => setnews(data));
  };
  const handleCreate = () => setSelected({ Name: "", TypeProductId: 0 });

  const handleDelete = (itemId) => {
    let result = window.confirm("Delete this item?");
    if (result) {
        TinTucService.delete(itemId).then((resp) => {
        setnews(_removeViewItem(news, itemId));
      });
    }
  };

  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.newsID !== itemDel);

    const handleSearch = (query) => {
      params.query = query;
      _fetchNews();
    };
  
    const handleSearchKey = () => {
      params.query = "";
      _fetchNews();
    };
  

  return (
    <div class="content-wrapper">
      <br />
      <h3 className=" sidebar-light-primary elevation-2" id="h3"><b>Danh sách Tin Tức</b></h3> 
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
              <div className="input-group-append" style={{border: "1px dotted #e0dcdc"}}>
                <button className="btn btn-sidebar">
                  <i className="fas fa-search fa-fw"></i>
                </button>
                
              </div>
            </div>
          </div>
          <div className="col-sm-2" style={{ marginLeft: "100px" }}>
            <Link to={`/CreateTinTuc/`}>
              <Button className="create elevation-2"  style={{ width: "100px"}}>
                Thêm
              </Button>
            </Link>
          </div>
        </div>
        
      </div>
      <br/>
      <Table className="elevation-2" style ={{backgroundColor : "#e9d8f4", bordercollapse:"collapse",width:"1450px", marginLeft:"30px"}}>
     
        <thead>
          <tr style ={{backgroundColor : "#58257b", color:"white", fontSize:"15px"}}>
            <th>STT</th>
            <th>Mã Tin Tức</th>
            <th>Tên Tin Tức</th>
            <th>Mô Tả</th>
            <th>Hình Ảnh</th>
            <th>Mã Nhân Viên</th>
            <th>Tên Nhân Viên</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {news.map(function (item, i) {
            return (
              <tr>
                <th scope="row">{i + 1}</th>
                <td className="td-ID">{item.newsID}</td>
                <td  className="td-Name">{item.newsName}</td>
                <td className="td-Descrip">{item.description}</td>
                <td><img src={item.img} text={item.newsName} style={{height:"100px"}}/></td> 
                <td className="td-ID">{item.userID}</td>
                <td>{item.userName}</td>
                <td >
                  <Link to={`/EditTinTuc/${item.newsID}`}>
                    <i
                      className="fas fa-edit"
                      style={{
                        marginLeft: "5px",
                        marginRight: "10px",
                        fontSize: "20px",  
                        float: "left",           
                      }}
                    >
                      {" "}
                    </i>
                  </Link>
                  <i
                    className="fas fa-trash-alt"
                    style={{
                      marginLeft: "20px",
                      fontSize: "20px",
                      color: "#E54646",
                    }}
                    onClick={() => handleDelete(item.newsID)}
                  ></i>
                </td>
              </tr>
            );
          })}
        </tbody>
      </Table>
    </div>
  );
};

export default ListTinTuc;
