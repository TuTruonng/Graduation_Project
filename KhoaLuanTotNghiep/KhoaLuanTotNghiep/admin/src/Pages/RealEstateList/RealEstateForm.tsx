import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import moment, { invalid } from 'moment';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import differenceInYears from 'date-fns/differenceInYears';
import TextAreaField from 'src/components/FormInputs/TextAreaField';
import TextField from 'src/components/FormInputs/TextField';
import DateField from 'src/components/FormInputs/DateField';
import CheckboxField from 'src/components/FormInputs/CheckboxField';
import SelectField from 'src/components/FormInputs/SelectField';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import IAssetForm from 'src/interfaces/Asset/IAssetForm';
import { Status } from 'src/constants/status';
import IRealEstateForm from 'src/interfaces/RealEstate/IRealEstateForm';
import { REALESTATEMANAGER } from 'src/constants/pages';
import { updateRealEstate } from './reducer';
import { stateApprove } from 'src/constants/selectOptions';

const _location = localStorage.getItem('location');

const initialFormValues: IRealEstateForm = {
    realEstateID: '',
    approve: 'True',
    assigned: '',
};

const validationSchema = Yup.object().shape({
    realEstateID: Yup.string().required('Required'),
    approve: Yup.string().required('Required'),
});

type Props = {
    initialRealEstateForm?: IRealEstateForm;
};

const RealEstateFormContainer: React.FC<Props> = ({
    initialRealEstateForm = {
        ...initialFormValues,
    },
}) => {
    const [loading, setLoading] = useState(false);

    const dispatch = useAppDispatch();

    const isUpdate = initialRealEstateForm.realEstateID ? true : false;

    const history = useHistory();

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${
                    isUpdate ? 'Updated' : 'Created'
                } Successful Asset ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000
            );

            setTimeout(() => {
                history.push(REALESTATEMANAGER);
                window.location.reload();
            }, 1000);
        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    };

    return (
        <Formik
            initialValues={initialRealEstateForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {              
                setLoading(true);
                setTimeout(() => {
                    if (isUpdate) {
                        dispatch(
                            updateRealEstate({ handleResult, formValues: values })
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
                            name="realEstateID"
                            label="RealEstate Code"
                            isrequired
                            disabled={isUpdate ? true : false}
                        />
                        {/* <SelectField
                            name="assigned"
                            label="Assign To"
                            options={AssetOptions}
                            isrequired
                            disabled={isUpdate ? true : false}
                        /> */}
                        <CheckboxField
                            name="approve"
                            label="State Approve"
                            options={stateApprove}
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
                                    to={REALESTATEMANAGER}
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

export default RealEstateFormContainer;
