import React, { useEffect, useState } from 'react';
import { Redirect, useParams } from 'react-router';
import { useHistory, useLocation } from 'react-router-dom';
import moment, { invalid } from 'moment';
import { NOTFOUND } from 'src/constants/pages';
import { useAppSelector } from 'src/hooks/redux';
import IAssetForm from 'src/interfaces/Asset/IAssetForm';
import { string } from 'yup/lib/locale';
// import Users from '../AssetManager';
// import UserFormContainer from '../AssetForm';
import IRealEstateForm from 'src/interfaces/RealEstate/IRealEstateForm';
import RealEstateForm from '../RealEstateForm';

const UpdateRealEstateContainer = () => {
    //const { users } = useAppSelector((state) => state.userReducer);
    const [realEstate, setRealEstate] = useState(undefined as IRealEstateForm | undefined);
    const { realEstateID } = useParams<{ realEstateID: string }>();
    const { state } = useLocation<{ existRealEstate: IRealEstateForm }>();
    const { existRealEstate } = state; // Read values passed on state

    useEffect(() => {
        if (existRealEstate) {
            console.log(existRealEstate?.realEstateID);
            setRealEstate(
                {
                    realEstateID: existRealEstate?.realEstateID,
                    approve: existRealEstate.approve.toString(),
                    assignTo: existRealEstate.assignTo,
                    userName: existRealEstate.userName
                }
            );
           
        }

    }, [existRealEstate]);
    console.log(existRealEstate?.realEstateID);

    return (
        <div className="ml-5">
            <div className="primaryColor text-title intro-x">Edit RealEstate</div>

            <div className="row">
                {/* <UserFormContainer /> */}
                {realEstate && <RealEstateForm initialRealEstateForm={realEstate} />}
            </div>
        </div>
    );
};

export default UpdateRealEstateContainer;
