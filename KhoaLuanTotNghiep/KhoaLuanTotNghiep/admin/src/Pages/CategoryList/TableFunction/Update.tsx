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
import format from "date-fns/format";
import ICategoryForm from 'src/interfaces/Category/ICategoryForm';
import CategoryForm from '../CategoryForm';

const UpdateCategoryContainer = () => {
    //const { users } = useAppSelector((state) => state.userReducer);
    const [Category, setCategory] = useState(undefined as ICategoryForm | undefined);
    const { categoryID } = useParams<{ categoryID: string }>();
    const { state } = useLocation<{ existCategory: ICategoryForm }>();
    const { existCategory } = state; // Read values passed on state

    useEffect(() => {
        if (existCategory) {
            console.log(existCategory?.categoryID);
            setCategory(
                {
                    categoryID: existCategory.categoryID,
                    categoryName: existCategory.categoryName,
                    description: existCategory.description,
                }
            );
           
        }

    }, [existCategory]);
    console.log(existCategory?.categoryID);

    return (
        <div className="ml-5">
            <div className="primaryColor text-title intro-x">Edit Category</div>

            <div className="row">
                {/* <UserFormContainer /> */}
                {Category && <CategoryForm initialCategoryForm={Category} />}
            </div>
        </div>
    );
};

export default UpdateCategoryContainer;
