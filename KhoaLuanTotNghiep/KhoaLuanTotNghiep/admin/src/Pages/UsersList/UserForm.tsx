import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import moment, { invalid } from 'moment';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import differenceInYears from 'date-fns/differenceInYears';
import TextField from 'src/components/FormInputs/TextField';
import DateField from 'src/components/FormInputs/DateField';
import CheckboxField from 'src/components/FormInputs/CheckboxField';
import SelectField from 'src/components/FormInputs/SelectField';
import { USERMANAGER } from 'src/constants/pages';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { createUser, updateUser } from './reducer';
import IUserForm from 'src/interfaces/User/IUserForm';
import { Status } from 'src/constants/status';
import { UserOptions } from 'src/constants/selectOptions';

const _location = localStorage.getItem('location');

const initialFormValues: IUserForm = {
    fullName: '',
    joinedDate: undefined,
    type: '',
    phoneNumber: '',
};

const validationSchema = Yup.object().shape({
    fullName: Yup.string().required('Required'),
    joinedDate: Yup.string()
        .nullable()
        .required('Required')
        .test(
            'joinedDate',
            'User under the age of 18 may not join company. Please select a different date',
            (value, ctx) => {
                return (
                    moment(value).diff(
                        moment(ctx.parent.dateOfBirth),
                        'years'
                    ) >= 18
                );
            }
        )
        .test(
            'joinedDate',
            'Joined date is Saturday or Sunday. Please select a different date',
            (value) => {
                return moment(value).format('dddd') != 'Saturday';
            }
        )
        .test(
            'joinedDate',
            'Joined date is Saturday or Sunday. Please select a different date',
            (value) => {
                return moment(value).format('dddd') != 'Sunday';
            }
        ),
    type: Yup.string().required('Required'),
    phoneNumber: Yup.string().required('Required'),
});

type Props = {
    initialUserForm?: IUserForm;
};

const UserFormContainer: React.FC<Props> = ({
    initialUserForm = {
        ...initialFormValues,
    },
}) => {
    const [loading, setLoading] = useState(false);

    const dispatch = useAppDispatch();

    const isUpdate = initialUserForm.staffCode ? true : false;

    const history = useHistory();

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${
                    isUpdate ? 'Updated' : 'Created'
                } Successful User ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000
            );

            setTimeout(() => {
                history.push(USERMANAGER);
                window.location.reload();
            }, 1000);
        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    };

    return (
        <Formik
            initialValues={initialUserForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {
                setLoading(true);
                setTimeout(() => {
                   
                    if (isUpdate) {
                        dispatch(
                            updateUser({ handleResult, formValues: values })
                        );
                    }
                    else {
                        const offset = values.joinedDate?.getTimezoneOffset()
                        values.joinedDate = new Date(moment.utc(values.joinedDate).subtract(offset, 'minutes').format())
                        dispatch(
                            createUser({ handleResult, formValues: values })
                        );
                    }
                    setLoading(false);
                }, 1000);
            }}
        >
            {(formik) => {
                const {
                    isValid,
                    dirty,
                } = formik;
                return (
                    <Form className="intro-y col-lg-6 col-12">
                        <TextField 
                            name="fullName"
                            label="Full Name"
                            isrequired
                            disabled={isUpdate ? true : false}
                        /> 
                        <DateField
                            name="joinedDate"
                            label="Joined Date"
                            isrequired
                            disabled={isUpdate ? true : false}
                        />
                        <SelectField
                            name="type"
                            label="Type"
                            options={UserOptions}
                            isrequired
                        />
                         <TextField 
                            name="phoneNumber"
                            label="Phone Number"
                            isrequired
                            disabled={isUpdate ? true : false}
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
                                    to={USERMANAGER}
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

export default UserFormContainer;
