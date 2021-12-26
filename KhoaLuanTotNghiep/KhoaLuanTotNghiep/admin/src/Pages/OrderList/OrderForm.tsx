import React, { useEffect, useState } from 'react';
import Select from 'react-select'
import { Formik, Form, Field } from 'formik';
import * as Yup from 'yup';
import moment, { invalid } from 'moment';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import TextAreaField from 'src/components/FormInputs/TextAreaField';
import TextField from 'src/components/FormInputs/TextField';
import DateField from 'src/components/FormInputs/DateField';
import CheckboxField from 'src/components/FormInputs/CheckboxField';
import SelectField from 'src/components/FormInputs/SelectField';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import IOrderForm from 'src/interfaces/Order/IOrderForm';
import { ORDERMANAGER } from 'src/constants/pages';
import { updateOrder } from './reducer';
import { acceptOrder, AssignToOptions, stateApprove } from 'src/constants/selectOptions';
import IOrder from 'src/interfaces/Order/IOrder';
import IPagedModel from 'src/interfaces/IPagedModel';

const _location = localStorage.getItem('location');

const initialFormValues: IOrderForm = {
    orderID: '',
    realEstateID: '',
    status: 'False',
};

const validationSchema = Yup.object().shape({
    orderID: Yup.string().required('Required'),
    realEstateID: Yup.string().required('Required'),
    status: Yup.string().required('Required'),
});

type Props = {
    initialOrderForm?: IOrderForm;
};

const OrderFormContainer: React.FC<Props> = ({
    initialOrderForm = {
        ...initialFormValues,
    },
}) => {

    const [loading, setLoading] = useState(false);
    const dispatch = useAppDispatch();
    const isUpdate = initialOrderForm.orderID ? true : false;
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
                history.push(ORDERMANAGER);
                window.location.reload();
            }, 1000);
        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    };

    return (
        <Formik
            initialValues={initialOrderForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {
                setLoading(true);
                setTimeout(() => {
                    if (isUpdate) {
                        dispatch(
                            updateOrder({ handleResult, formValues: values })
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
                            name="orderID"
                            label="Order Code"
                            isrequired
                            disabled={isUpdate ? true : false}
                        />
                         <TextField
                            name="realEstateID"
                            label="RealEstate Code"
                            isrequired
                            disabled={isUpdate ? true : false}
                        />
                        {/* <Select name="userName" options={options}/> */}
                            
                            {/* {Order.map((data, i) => (
                                <option key={i} value={data.userName}  selected={data.userName}>{data.userName}</option>
                                //console.log(data)
                            ))}; */}
                  
                        <CheckboxField
                            name="status"
                            label="Accept Order"
                            options={acceptOrder}
                            isrequired
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
                                    to={ORDERMANAGER}
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

export default OrderFormContainer;
