import React, { useState, useEffect } from "react";
import { Formik, useFormik } from "formik";
import { withRouter } from "react-router-dom";
import history from "../../Helpers/Help";
import'./BDS.css';
import BatDongSanService from "../../Services/BatDongSanService";

const BDSForm = ({ match }) => {

  const [realEstateID, setRealEstateID] = useState(match.params.id);
  const [RealEstate, setRealEstate] = useState({});
  const [img, setImg] = useState("");
  const [isCreate, setIsCreate] = useState(match.params.id === undefined ? true : false);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    async function fetchdata() {
      setRealEstateID(match.params.id);
      console.log("NewsID",realEstateID);
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
      
    }
    ,
    onSubmit: async (values) => {
      let result = window.confirm("Are you sure?");
      console.log("values",values);
      console.log(img);
      if (result) {
        if (isCreate) {
          console.log("values a");
          await BatDongSanService.create( (values));
          console.log("values b");
          history.goBack();
        } else {
          console.log("values edit", values);
          await BatDongSanService.edit(realEstateID, (values));
          history.goBack();
        }
      }
    },
  });


  const fetchRealEstate = async (itemId) => {
    console.log(BatDongSanService.get(itemId));
    setRealEstate(await (await BatDongSanService.get(itemId)).data);
  };

  const changeFormikValuestoFormData = (valueForm) => {
    const formSubmitDataLocal = new FormData();
    formSubmitDataLocal.append('newsName', valueForm.newsName);
    formSubmitDataLocal.append('description', valueForm.description);
    formSubmitDataLocal.append('imageRequest', valueForm.imageRequest);
    console.log("FormData",formSubmitDataLocal);
    return formSubmitDataLocal;
  }

  console.log("run zzzz", formik.initialValues);

  return (
    <div class="content-wrapper"  className="form" style={{width:"1300px", height:"1000px",marginLeft:"300px"}}>
        <h3>Tin tức</h3>
        <br/>
      <form onSubmit={formik.handleSubmit}>
        <div className="form-group">
          <label htmlFor="approve" className="text">approve</label>
          <input className="input-form"
            id="approve"
            name="approve"
            type="text"
           {...formik.getFieldProps('approve')}
           defaultValue={formik.values.approve}
          />
        </div>
       
      
        <button type="submit" className="button">Submit</button>

      </form>
    </div>
  );
};

export default withRouter(BDSForm);

