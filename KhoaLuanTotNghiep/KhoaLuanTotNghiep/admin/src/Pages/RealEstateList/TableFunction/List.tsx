import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import BatDongSanService from "src/Services/BatDongSanService";
import IRealEstate from "src/interfaces/RealEstate/IRealEstate";
import { getRealEstates } from "../reducer";
import RealEstateTable from "./Table";

type Props = {
  realEstates: IRealEstate | null;
  fetchData: Function;
};

const ListBDS = () => {
  const dispatch = useAppDispatch();
  const { realEstates, loading } = useAppSelector((state) => state.realEstateReducer);
  const [realEstate, setrealEstate] = useState([]);
  const [itemSelected, setSelected] = React.useState(null);
  // let params = {};

  const fetchData = () => {
    dispatch(getRealEstates(realEstate));
};

useEffect(() => {
    fetchData();
}, []);

console.log(realEstates);

  // const _fetchBDSs = () => {
  //   BatDongSanService.getList().then(({ data }) => setrealEstate(data));
  // };
//   const handleCreate = () => setSelected({ Name: "", TypeProductId: 0 });

//   const handleDelete = (itemId) => {
//     let result = window.confirm("Delete this item?");
//     if (result) {
//         BatDongSanService.delete(itemId).then((resp) => {
//         setrealEstate(_removeViewItem(realEstate, itemId));
//       });
//     }
//   };

  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.realEstateID !== itemDel);

    // const handleSearch = (query) => {
    //   params.query = query;
    //   _fetchBDSs();
    // };
  
    // const handleSearchKey = () => {
    //   params.query = "";
    //   _fetchBDSs();
    // };

  return (
    <div className="content-wrapper" >
       <br />
      <h3 className="invalid"><b>RealEstate List</b></h3> 
      <br/>
      <div className='tblRealEstate'>
        <RealEstateTable
          realEstates={realEstates}
          fetchData={fetchData}
        />
      </div>
    </div>
  );
};

export default ListBDS;
