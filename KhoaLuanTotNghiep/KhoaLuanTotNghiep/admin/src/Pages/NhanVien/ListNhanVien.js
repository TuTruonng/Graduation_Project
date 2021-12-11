import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import NhanVienService from '../../Services/NhanVienService';
import "./NhanVien.css";


const ListNhanVien = () => {
    const [Users, setUsers] = useState([]);

    useEffect(() => {
        fetchUser();
    }, []);

    const fetchUser = () => {
        NhanVienService.getList().then(({ data }) => setUsers(data));
    };

    const handleDelete =(itemId) =>{
        let result = window.confirm("Delete this item ?");
        if(result){
            NhanVienService.delete(itemId).then((resp) =>{
                setUsers(_removeViewItem(Users,itemId));

            });
        }
    };

    const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.id !== itemDel);
  
    return (
        <div class="content-wrapper">
          <br />
      <h3 className=" sidebar-light-primary elevation-2" id="h3"><b>Danh sách nhân viên</b></h3> 
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
              <div className="col-sm-2 " style={{ marginLeft: "100px" }}>
                <Link to={`/CreateUser/`}>
                  <Button className="create elevation-2" >
                    Thêm
                  </Button>
                </Link>
              </div>
            </div>
            
          </div>
          <br/>
          <Table className="elevation-2"  style ={{backgroundColor : "#e9d8f4", bordercollapse:"collapse",width:"1300px", marginLeft:"100px"}}>
         
            <thead>
              <tr style ={{backgroundColor : "#58257b", color:"white",fontSize:"19px"}}>
                <th>STT</th>
                <th>Mã Nhân Viên</th>
                <th>Tên Nhân Viên</th>
                <th>Email</th>
                <th>Số Điện Thoại</th>
                <th>Ngày Tham Gia</th>
                <th>Lương Cơ Bản</th>
                <th>Điểm</th>
                <th>Lương</th>
                <th></th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {Users.map(function (item, i) {
                return (
                  <tr>
                    <th scope="row">{i + 1}</th>
                    <td >{item.userId}</td>
                    <td>{item.userName}</td>
                    <td >{item.email}</td>
                    <td >{item.phoneNumber}</td>
                    <td>{item.joinedDate}</td>
                    <td>{item.initialsalary}</td>
                    <td>{item.point}</td>
                    <td >{item.salary}</td>
                
                    <td >
                      <Link to={`/EditUser/${item.userId}`}>
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
                    onClick={() => handleDelete(item.userId)}
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

export default ListNhanVien;