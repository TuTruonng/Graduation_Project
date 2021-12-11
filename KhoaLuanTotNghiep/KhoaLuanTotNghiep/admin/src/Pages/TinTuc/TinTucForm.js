import React, { useState, useEffect } from "react";
import { Formik, useFormik } from "formik";
import { withRouter } from "react-router-dom";
import TinTucService from "../../Services/TinTucService";
import history from "../../Helpers/Help";
import'./TinTuc.css';
import * as Yup from "yup";

const TinTucForm = ({ match }) => {

  const [newsID, setNewsID] = useState(match.params.id);
  const [userID, setUserID] = useState(match.params.id);
  const [News, setnews] = useState({});
  const [img, setImg] = useState("");
  const [isCreate, setIsCreate] = useState(match.params.id === undefined ? true : false);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    async function fetchdata() {
      setNewsID(match.params.id);
      setUserID(match.params.id); 
      console.log("NewsID",newsID);
      if (newsID !== undefined) {
        await fetchNews(newsID);
      }

    }
    
    fetchdata();
  }, [match.params.id]);
  
  console.log("is", News);

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      newsID : News.newsID,
      newsName: News.newsName,
      userName: News.userName,
      description: News.description,
      userID: News.userID,
      img: News.img,
    },

    validationSchema : Yup.object().shape({ // Validate form field
      newsName: Yup.string()
          .required('News Name is required'),
      description: Yup.string()
          .required('Description is required')
          .min(15,'Should be 15 character long')
  }),

    onSubmit: async (values) => {
      let result = window.confirm("Xác nhận ?");
      console.log("get value",values);
      console.log(img);
      if (result) {
        if (isCreate) {
            console.log("Created", values);
          await TinTucService.create((values));
          console.log("Get_Created", values);
          history.goBack();
        } else {
          console.log("values edit", values);
          await TinTucService.edit(newsID, (changeFormikValuestoFormData(values)));
          history.goBack();
        }
      }
    },
  });


  const fetchNews = async (itemId) => {
    console.log(TinTucService.get(itemId), JSON.stringify(itemId.profile));
    setnews(await (await TinTucService.get(itemId)).data);
  };

  const uploadImage = async (e) => {
    const files = e.target.files;/*get infor file*/ 
    const data = new FormData();
    data.append("file", files[0]);  
    data.append("upload_preset", "Source");
    setLoading(true);
    console.log("acb",loading);
    const res = await fetch(
    " https://api.cloudinary.com/v1_1/dusq8k6rj/image/upload",
      {
        method: "POST",
        body: data,
      }
    );
    const file = await res.json();
    setImg(file.secure_url);
    setLoading(false);
    if (isCreate) {
      formik.values.img =file.secure_url;
    }
    else {
      formik.values.img = file.secure_url;
    }
  };

  const changeFormikValuestoFormData = (valueForm) => {
    const formSubmitDataLocal = new FormData();
    formSubmitDataLocal.append('newsID', valueForm.newsID);
    formSubmitDataLocal.append('newsName', valueForm.newsName);
    formSubmitDataLocal.append('description', valueForm.description);
    formSubmitDataLocal.append('userID', valueForm.userID);
    formSubmitDataLocal.append('userName', valueForm.userName);
    formSubmitDataLocal.append('img', valueForm.img);
    console.log("FormData",formSubmitDataLocal);
    return formSubmitDataLocal;
  }

  console.log("Result", formik.initialValues);

  const cancelItem_onClick = () => {
      window.history.back();
    };

  return (
    <div>
    <h3 className=" sidebar-light-primary elevation-2" id="h4"><b>Tin Tức</b></h3> 
    <div class="content-wrapper" className="form elevation-2" style={{width:"1000px", height:"1300px",marginLeft:"500px"}}>
      <form onSubmit={formik.handleSubmit}>
        <div className="form-group">
          <label style={{fontSize:"20px"}}  htmlFor="newsName" className="text">Tên Tin Tức:</label>
          <input className="input-form elevation-2"
            id="newsName"
            name="newsName"
            placeholder="Tên Tin Tức..."
            type="text"
           {...formik.getFieldProps('newsName')}
           defaultValue={formik.values.newsName}
          /><br/>
               {formik.errors.newsName && formik.touched.newsName && (
            <span>{formik.errors.newsName}</span>
          )}
        </div>
        <div className="form-group">
          <label style={{fontSize:"20px"}}  htmlFor="userID" className="text">Mã Nhân Viên:</label>
          <input className="input-form elevation-2"
            id="userID"
            name="userID"
            placeholder="Mã Nhân Viên..."
            type="text"
             {...formik.getFieldProps('userID')}
             defaultValue={formik.values.userID}
          />
        </div>
        <div className="form-group">
          <label style={{fontSize:"20px"}}  htmlFor="userName" className="text">Tên Nhân Viên:</label>
          <input className="input-form elevation-2"
            id="userName"
            name="userName"
            placeholder="Tên Nhân Viên..."
            type="text"
             {...formik.getFieldProps('userName')}
             defaultValue={formik.values.userName}
          />
        </div>
        <div className="form-group">
          <label style={{fontSize:"20px"}}  htmlFor="description" className="text">Mô Tả:</label>         
          <input className="input-form elevation-2"
            id="description"
            name="description"
            placeholder="Mô Tả..."
            type="text"     
           {...formik.getFieldProps('description')}
           defaultValue={formik.values.description}
          /><br/>
           {formik.errors.description && formik.touched.description && (
            <span>{formik.errors.description}</span>
          )}
        </div>
        <div className="form-group">
          <label style={{fontSize:"20px"}}  htmlFor="img" className="text">Hình Ảnh:</label>
          <input className="input-form "
            type="file"
            id="img"
            name="img"
            placeholder="Upload an image"
            onChange={uploadImage}
            style={{ display: "block", paddingLeft:"200px" }}
          />
          {
            loading ? (
              <h3>Đang tải...</h3>
            ) : (
              <img src={img} style={{ width: "400px" }} alt="News-image" />
            )
          }
        </div>
        <button type="cancel" style={{marginRight:"10px",marginTop:"20px"}}  onClick={cancelItem_onClick} className="cancel">Hủy</button>
        <button type="submit" className="submit " >Lưu</button> 
      </form>
    </div>
    </div>
  );
};

export default withRouter(TinTucForm);

