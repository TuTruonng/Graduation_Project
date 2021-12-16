import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import moment, { invalid } from 'moment';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import differenceInYears from 'date-fns/differenceInYears';
import TextAreaField from 'src/components/FormInputs/TextAreaField';
import TextField from 'src/components/FormInputs/TextField';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { updateNews } from './reducer';
import { createNews } from './reducer';
import INewsForm from 'src/interfaces/News/INewsForm';
import { NEWSMANAGER } from 'src/constants/pages';

const _location = localStorage.getItem('location');

const initialFormValues: INewsForm = {
    newsName: '',
    img: '',
    description: '',
};

const validationSchema = Yup.object().shape({
    newsName: Yup.string().required('Required'),
    img: Yup
        .mixed()
        .nullable()
        .notRequired(),
    // status: yup.boolean().required(),
    description: Yup.string().required('Required'),
});

type Props = {
    initialNewsForm?: INewsForm;
};

const NewsFormContainer: React.FC<Props> = ({
    initialNewsForm = {
        ...initialFormValues,
    },
}) => {
    const [loading, setLoading] = useState(false);
    const [loadingImg, setLoadingImg] = useState(false);
    const [img, setImg] = useState("");
    const dispatch = useAppDispatch();
    const isUpdate = initialNewsForm.newsID ? true : false;
    const history = useHistory();

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'
                } Successful Asset ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000
            );

            setTimeout(() => {
                history.push(NEWSMANAGER);
                window.location.reload();
            }, 1000);
        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    };

    const uploadImage = async (e) => {
        const files = e.target.files;/*get infor file*/
        const data = new FormData();
        data.append("file", files[0]);
        data.append("upload_preset", "leduyen");
        //setLoadingImg(true);
        console.log("acb", loadingImg);
        const res = await fetch(
            " https://api.cloudinary.com/v1_1/dusq8k6rj/image/upload",
            {
                method: "POST",
                body: data,
            }
        );
        const file = await res.json();
        setImg(file.secure_url);
        //setLoading(false);
        //img.toString() =file.secure_url;

    };

    return (
        <Formik
            initialValues={initialNewsForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {

                values.img = img;
                setLoading(true);
                setTimeout(() => {
                    console.log(img);
                    if (isUpdate) {
                        console.log('values')
                        dispatch(
                            updateNews({ handleResult, formValues: values })
                        );
                    }
                    else {
                        console.log('values')
                        console.log(values)
                        dispatch(
                            createNews({ handleResult, formValues: values })
                        );
                    }
                    setLoading(false);
                }, 1000);
            }}
        >
            {(formik) => {
                const { isValid, dirty, values } = formik;
                return (
                    <Form className="intro-y col-lg-6 col-12">
                        <TextField
                            name="newsName"
                            label="News Name"
                            isrequired
                            disabled={isUpdate ? false : false}
                        />
                        <div className="form-group">
                            <div className="row">
                                <div className="col-lg-7">
                                    <label style={{ fontSize: "16px" }} htmlFor="img">Image</label>
                                    <input
                                        type="file"
                                        id="img"
                                        name="img"
                                        placeholder="Upload an image"
                                        onChange={uploadImage}
                                        style={{ display: "block", paddingLeft: "180px" }}
                                        disabled={isUpdate ? false : false}
                                    />
                                </div>
                                <div className="col-lg-5">  
                                    <img src={img} style={{ width: "400px", paddingLeft: "200px" }}/>
                                </div>
                                
                            </div>
                        </div>

                        <TextField
                            name="description"
                            label="Description"
                            isrequired
                            disabled={isUpdate ? false : false}
                        />

                        <div className="d-flex">
                            <div className="ml-auto">
                                <button
                                    className="btn btn-danger"
                                    type="submit"
                                    disabled={!dirty || !isValid}
                                >
                                    Save{' '}
                                    {loading && (
                                        <img
                                            src="/oval.svg"
                                            className="w-4 h-4 ml-2 inline-block"
                                        />
                                    )}
                                </button>

                                <Link
                                    to={NEWSMANAGER}
                                    className="btn btn-outline-secondary ml-2"
                                >
                                    Cancel
                                </Link>
                            </div>
                        </div>
                    </Form>
                );
            }}
        </Formik>
    );
};

export default NewsFormContainer;
