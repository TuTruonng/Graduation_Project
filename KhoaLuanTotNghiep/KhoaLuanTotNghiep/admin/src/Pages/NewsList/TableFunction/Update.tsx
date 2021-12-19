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
import INewsForm from 'src/interfaces/News/INewsForm';
import NewsForm from '../NewsForm';

const UpdateNewsContainer = () => {
    //const { users } = useAppSelector((state) => state.userReducer);
    const [news, setNews] = useState(undefined as INewsForm | undefined);
    const { newsID } = useParams<{ newsID: string }>();
    const { state } = useLocation<{ existNewses: INewsForm }>();
    const { existNewses } = state; // Read values passed on state

    useEffect(() => {
        if (existNewses) {
            console.log(existNewses?.newsID);
            setNews(
                {
                    newsID: existNewses.newsID,
                    //userName: existNews.userName,
                    newsName: existNewses.newsName,
                    img: existNewses.img,
                    description: existNewses.description,
                }
            );
           
        }

    }, [existNewses]);
    console.log(existNewses?.newsID);

    return (
        <div className="ml-5">
            <div className="primaryColor text-title intro-x">Edit News</div>

            <div className="row">
                {/* <UserFormContainer /> */}
                {news && <NewsForm initialNewsForm={news} />}
            </div>
        </div>
    );
};

export default UpdateNewsContainer;
