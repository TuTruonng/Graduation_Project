import React, { useState, useEffect } from "react";
import { Formik, useFormik } from "formik";
import { withRouter } from "react-router-dom";
import NhanVienService from "../../Services/NhanVienService";
import history from "../../Helpers/Help";
import'./NhanVien.css';
import * as Yup from "yup";
import { User } from "oidc-client";

const TinTucForm = ({ match }) => {

  const [UserID, setuserID] = useState(match.params.id);
  const [Users, setUsers] = useState({});
  const [isCreate, setIsCreate] = useState(match.params.id === undefined ? true : false);

  useEffect(() => {
    async function fetchdata() {
      setuserID(match.params.id);
      console.log(setuserID);
      if (UserID !== undefined) {
        await fetchUser(UserID);
        console.log(formik.initialValues);
      } else {
      }
    }
    fetchdata();
  }, [match.params.id]);

  
  console.log("is", Users);

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      userId : Users.userId,
      userName: Users.userName,
      email: Users.email,
      phoneNumber: Users.phoneNumber,
      salary: Users.salary,
      initialsalary: Users.initialsalary,
      point: Users.point,
      joinedDate:Users.joinedDate,
    },

  //   validationSchema : Yup.object().shape({ // Validate form field
  //     newsName: Yup.string()
  //         .required('newsName is required'),
  //     description: Yup.string()
  //         .required('description is required')
  //         .min(15,'Should be 15 character long')
  // }),

    onSubmit: async (values) => {
      let result = window.confirm("Xác Nhận ? ");
      console.log("get value",values);

      if (result) {
        if (isCreate) {
            console.log("Created", values);
          await NhanVienService.create("Create"(values));
          console.log("Get_Created", values);
          history.goBack();
        } else {
          console.log("values edit", values);
          await NhanVienService.edit(UserID,changeFormikValuestoFormData((values)));
          console.log("Get_Edit", values);
          history.goBack();
        }
      }
    },
  });

  const cancelItem_onClick = () => {
      window.history.back();
    };

  const fetchUser = async (itemId) => {
    console.log(NhanVienService.get(itemId),JSON.stringify(itemId.profile));
    setUsers(await (await NhanVienService.get(itemId)).data);
  };

  const changeFormikValuestoFormData = (valueForm)=>{
    const formSubmitDataLocal = new FormData();
    formSubmitDataLocal.append('userId', valueForm.userId);
    formSubmitDataLocal.append('userName', valueForm.userName);
    formSubmitDataLocal.append('email', valueForm.email);
    formSubmitDataLocal.append('phoneNumber', valueForm.phoneNumber);
    formSubmitDataLocal.append('salary', valueForm.salary);
    formSubmitDataLocal.append('initialsalary', valueForm.initialsalary);
    formSubmitDataLocal.append('point', valueForm.point);
    formSubmitDataLocal.append('joinedDate', valueForm.joinedDate);
    console.log("FormData",formSubmitDataLocal);
    return formSubmitDataLocal;
  }


  // console.log("Result", formik.initialValues);

  return (
    <div>
    <h3 className=" sidebar-light-primary elevation-2" id="h4"><b>Nhân Viên</b></h3> 
    <div class="content-wrapper" className="form elevation-2" style={{width:"1000px", height:"1100px",marginLeft:"500px"}}>
      <form onSubmit={formik.handleSubmit}>
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
          <label style={{fontSize:"20px"}} htmlFor="email" className="text">Email:</label>
          <input className="input-form elevation-2"
            id="email"
            name="email"
            placeholder="Email..."
            type="text"           
           {...formik.getFieldProps('email')}
           defaultValue={formik.values.email
          }
          />
           {formik.errors.description && formik.touched.description && (
            <p>{formik.errors.description}</p>
          )}
        </div>
        <div className="form-group">
          <label style={{fontSize:"20px"}}  htmlFor="phoneNumber" className="text">Số Điện Thoại:</label>
          <input className="input-form elevation-2"
            id="phoneNumber"
            name="phoneNumber"
            placeholder="Số Điện Thoại..."
            type="text"
           {...formik.getFieldProps('phoneNumber')}
           defaultValue={formik.values.phoneNumber}
          />
               {formik.errors.newsName && formik.touched.newsName && (
            <p>{formik.errors.newsName}</p>
          )}
        </div>
        <div className="form-group">
          <label style={{fontSize:"20px"}}  htmlFor="joinedDate" className="text">Ngày Tham Gia:</label>
          <input className="input-form elevation-2"
            id="joinedDate"
            name="joinedDate"
            placeholder="Ngày Tham Gia..."
            type="text"
             {...formik.getFieldProps('joinedDate')}
             defaultValue={formik.values.joinedDate}
          />
        </div>
        <div className="form-group">
          <label style={{fontSize:"20px"}}  htmlFor="initialsalary" className="text">Lương Cơ Bản:</label>
          <input className="input-form elevation-2"
            id="initialsalary"
            name="initialsalary"
            placeholder="Lương Cơ Bản..."
            type="text"
             {...formik.getFieldProps('initialsalary')}
             defaultValue={formik.values.initialsalary}
          />
        </div>  
        <div className="form-group">
          <label htmlFor="point" className="text">Điểm:</label>
          <input className="input-form elevation-2"
            id="point"
            name="point"
            placeholder="Điểm..."
            type="text"
             {...formik.getFieldProps('point')}
             defaultValue={formik.values.point}
          />
        </div>   
        <div className="form-group">
          <label style={{fontSize:"20px"}}  htmlFor="salary" className="text">Lương:</label>
          <input className="input-form elevation-2"
            id="salary"
            name="salary"
            placeholder="Lương..."
            type="text"
             {...formik.getFieldProps('salary')}
             defaultValue={formik.values.salary}
          />
        </div>       
        <button type="cancel" style={{marginRight:"10px",marginTop:"18px"}}   onClick={cancelItem_onClick} className="cancel">Hủy</button>
        <button type="submit" className="submit " >Lưu</button> 
      </form>
      </div>
    </div>
  );
};

export default withRouter(TinTucForm);

