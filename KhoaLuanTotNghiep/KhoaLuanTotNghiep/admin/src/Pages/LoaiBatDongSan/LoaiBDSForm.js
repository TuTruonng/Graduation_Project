import React, { useState, useEffect } from "react";
import {useFormik} from "formik";
import{withRouter} from "react-router-dom";
import LoaiBatDongSanService from "../../Services/LoaiBatDongSanService";
import history from "../../Helpers/Help";
import './LoaiBDS.css';
import { ButtonGroup } from "reactstrap";
import * as Yup from "yup";



const LoaiBDSForm = ({ match }) => {


  const [categoryID, setCategoryID] = useState(match.params.id);
  const [isCreate, setIsCreate] = useState(match.params.id === undefined ? true : false);
  const [Category, setCategory] = useState({});

  useEffect(() => {
    async function fetchdata() {
      setCategoryID(match.params.id);
      console.log(categoryID);
      if (categoryID !== undefined) {
        await fetchCategory(categoryID);
        console.log(formik.initialValues);
      } else {
      }
    }
    fetchdata();
  }, [match.params.id]);

  const formik = useFormik({
    enableReinitialize: true,
      initialValues : {
      categoryName: Category.categoryName,
      categoryID: Category.categoryID,
      description: Category.description,
    },
    
  validationSchema : Yup.object().shape({ // Validate form field
      categoryName: Yup.string()
          .required('Tên Loại Không được trống !')      
  }),
    
    onSubmit : async (values) => {
      let result = window.confirm("Xác Nhận");
      console.log(values);
      if (result) {
        if (isCreate) {
          await LoaiBatDongSanService.create(values);
          history.goBack();
        } else {
          await LoaiBatDongSanService.edit(categoryID,changeFormikValuestoFormData (values));
          history.goBack();
        }
      }     
}
  });

 const cancelItem_onClick = () => {
  // let result = window.confirm("Confirm cancel");
    window.history.back();
  };

  const changeFormikValuestoFormData = (valueForm) => {
    const formSubmitDataLocal = new FormData();
    formSubmitDataLocal.append('categoryName', valueForm.categoryName);
    formSubmitDataLocal.append('categoryID', valueForm.categoryID);
    formSubmitDataLocal.append('description', valueForm.description);
    console.log("FormData",formSubmitDataLocal);
    return formSubmitDataLocal;
  }

  console.log("Result", formik.initialValues);
  const fetchCategory = async (itemId) => {
    console.log(LoaiBatDongSanService.get(itemId),JSON.stringify(itemId.profile));
    setCategory(await (await LoaiBatDongSanService.get(itemId)).data);
  };
  console.log(Category);


    return ( 
      <div>
         <h3 className=" sidebar-light-primary elevation-2" id="h4"><b>Loại bất động sản</b></h3> 
      <div className="content-wrapper " className="form elevation-3" style={{width:"1000px",marginLeft:"500px",height:"550px"}}>
      <form onSubmit={formik.handleSubmit}>
      <div className="form-group">
      <label htmlFor="categoryName" className="text ">Tê Loại Tiêu Đề: </label>
      <br/>
      <input className="input-form  elevation-2" 
        id="categoryName"
        name="categoryName"
        placeholder="Tên Loại..."
        type="text"
        {...formik.getFieldProps('categoryName')}
        defaultValue={formik.values.categoryNamev}
      />
      <br/>
      {formik.errors.categoryName && formik.touched.categoryName && (
            <span>{formik.errors.categoryName}</span>
         )}
      </div>
        &nbsp;
        <br/>
        <div className="form-group ">
        <label htmlFor="description" className="text">Mô Tả: </label>
        <br/>
        <input className="input-form elevation-2"
        id="description"
        name="description"
        placeholder="Mô Tả..."
        type="text"
        {...formik.getFieldProps('description')}
        defaultValue={formik.values.description }
      />
      </div>
        <button type="cancel" style={{marginRight:"10px",marginTop:"20px"}} onClick={cancelItem_onClick} className="cancel">Hủy</button>
        <button type="submit" className="submit " >Lưu</button>    
    </form>
    </div>
    </div>
  );
};

export default withRouter(LoaiBDSForm);