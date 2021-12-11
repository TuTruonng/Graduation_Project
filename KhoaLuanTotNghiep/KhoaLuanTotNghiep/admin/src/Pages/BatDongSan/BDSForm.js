import React, { useState, useEffect } from "react";
import { Formik, useFormik } from "formik";
import { withRouter } from "react-router-dom";
import history from "../../Helpers/Help";
import "./BDS.css";
import BatDongSanService from "../../Services/BatDongSanService";

const BDSForm = ({ match }) => {
  const [realEstateID, setRealEstateID] = useState(match.params.id);
  const [RealEstate, setRealEstate] = useState({});
  const [img, setImg] = useState("");
  const [isCreate, setIsCreate] = useState(
    match.params.id === undefined ? true : false
  );
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    async function fetchdata() {
      setRealEstateID(match.params.id);
      console.log("NewsID", realEstateID);
      if (realEstateID !== undefined) {
        await fetchRealEstate(realEstateID);
      }
    }

    fetchdata();
  }, [match.params.id]);

  console.log("is creazzzz P", RealEstate);

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      approve: RealEstate.approve,
      status: RealEstate.status,
    },
    onSubmit: async (values) => {
      let result = window.confirm("Are you sure ?");
      console.log("values", values);
      console.log(img);
      if (result) {
        if (isCreate) {
          console.log("values a");
          await BatDongSanService.create(values);
          console.log("values b");
          history.goBack();
        } else {
          console.log("values edit", values);
          await BatDongSanService.edit(realEstateID, values);
          history.goBack();
        }
      }
    },
  });
  const cancelItem_onClick = () => {
      window.history.back();
    };
  const fetchRealEstate = async (itemId) => {
    console.log(BatDongSanService.get(itemId));
    setRealEstate(await (await BatDongSanService.get(itemId)).data);
  };

  console.log("run zzzz", formik.initialValues);

  return (
    <div>
         <h3 className=" sidebar-light-primary elevation-2" id="h4"><b>Bất động sản</b></h3> 
    <div
      class="content-wrapper"
      className="form elevation-3"
      style={{ width: "1000px", height: "500px", marginLeft: "500px" }}
    >
      <form onSubmit={formik.handleSubmit}>
        <div className="form-group">
          <label htmlFor="approve" className="text">
            Xác Nhận
          </label>
          <input
            className="input-form elevation-2"
            id="approve"
            name="approve"
            type="text"
            {...formik.getFieldProps("approve")}
            defaultValue={formik.values.approve}
          />
        </div>

        <div className="form-group">
          <label htmlFor="status" className="text">
            Trạng Thái
          </label>
          <input
            className="input-form elevation-2"
            id="status"
            name="status"
            type="text"
            {...formik.getFieldProps("status")}
            defaultValue={formik.values.status}
          />
        </div>
        <button type="cancel"  style={{marginRight:"10px",marginTop:"20px"}} onClick={cancelItem_onClick} className="cancel">Hủy</button>
        <button type="submit" className="submit " >Lưu</button>  
      </form>
    </div>
    </div>
  );
};

export default withRouter(BDSForm);
