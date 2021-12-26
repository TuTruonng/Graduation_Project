import React, { useEffect, useState } from 'react';
import { AxiosResponse } from 'axios';
import { Link } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { getInfos } from '../reducer';
import InfoTable from './Table';
import IInfo from 'src/interfaces/Info/IInfo';

type Props = {
    infos: IInfo | null;
    fetchData: Function;
  };

const Info = () => {
    const dispatch = useAppDispatch();
    const [info, setInfo] = useState(undefined as IInfo | undefined);
    const {infos, loading} = useAppSelector((state) => state.infoReducer);

    const fetchData = () => {
        dispatch(getInfos(info as IInfo));
    };

    useEffect(() => {
        fetchData();
    }, []);
    console.log(infos);

    return (
        <div className="content-wrapper" >
            <br />
            <h3 className="invalid"><b>Info List</b></h3>
            <br />
            <div className='tblRealEstate'>
                <InfoTable
                    infos={infos}
                    fetchData={fetchData}
                />
            </div>
        </div>

        // <div className="primaryColor text-title intro-x">Info List</div>
        // <div>

        // </div>

    );
};

export default Info;
