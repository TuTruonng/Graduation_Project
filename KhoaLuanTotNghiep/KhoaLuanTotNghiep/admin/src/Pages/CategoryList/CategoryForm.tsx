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
import { CATEGORYMANAGER } from 'src/constants/pages';
import { updateCategory } from './reducer';
import { createCategory } from './reducer';
import ICategoryForm from 'src/interfaces/Category/ICategoryForm';

const _location = localStorage.getItem('location');

const initialFormValues: ICategoryForm = {
    categoryName: '',
    description: '',
};

const validationSchema = Yup.object().shape({
    categoryName: Yup.string().required('Required'),
    description: Yup.string().required('Required'),
});

type Props = {
    initialCategoryForm?: ICategoryForm;
};

const categoryFormContainer: React.FC<Props> = ({
    initialCategoryForm = {
        ...initialFormValues,
    },
}) => {
    const [loading, setLoading] = useState(false);

    const dispatch = useAppDispatch();

    const isUpdate = initialCategoryForm.categoryID ? true : false;

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
                history.push(CATEGORYMANAGER);
                window.location.reload();
            }, 1000);
        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    };

    return (
        <Formik
            initialValues={initialCategoryForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {
                setLoading(true);
                setTimeout(() => {
                    if (isUpdate) {
                        dispatch(
                            updateCategory({ handleResult, formValues: values })
                        );
                    }
                    else {
                        dispatch(
                            createCategory({ handleResult, formValues: values })
                        );
                    }
                    setLoading(false);
                }, 1000);
            }}
        >
            {(formik) => {
                const { isValid, dirty } = formik;
                return (
                    <Form className="intro-y col-lg-6 col-12">
                        <TextField
                            name="categoryName"
                            label="Category Name"
                            isrequired
                            disabled={isUpdate ? false : false}
                        />

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
                                    to={CATEGORYMANAGER}
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

export default categoryFormContainer;
