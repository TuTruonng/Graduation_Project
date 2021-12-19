import React, { useState } from 'react';
import { PencilFill, XCircle } from 'react-bootstrap-icons';
import { useHistory } from 'react-router';
import ButtonIcon from 'src/components/ButtonIcon';
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import "../../../styles/BDS.css";
import ConfirmModal from 'src/components/ConfirmModal';
import IAsset from 'src/interfaces/Asset/IAsset';
import IColumnOption from 'src/interfaces/IColumnOption';
import IPagedModel from 'src/interfaces/IPagedModel';
import { useAppDispatch } from 'src/hooks/redux';
import IRealEstate from 'src/interfaces/RealEstate/IRealEstate';
import { EDIT_REALESTATE_ID } from 'src/constants/pages';
import { object } from 'yup/lib/locale';
import Info from './Info';

type Props = {
  realEstates: IRealEstate | null;
  fetchData: Function;
};

const RealEstateTable = ({
  realEstates,
  fetchData,
}) => {
  const dispatch = useAppDispatch();

  
  const [showDetail, setShowDetail] = useState(false);
  const [realEstateDetail, setrealEstateDetail] = useState(null as IRealEstate | null);
  const [disableState, setDisableState] = useState({
      isOpen: false,
      id: 0,
      title: '',
      message: '',
      isDisable: true,
  });

  const handleShowInfo = (realEstateID: string) => {
      {realEstates.map((item) => {
          if (item.realEstateID === realEstateID) {
              const realEstate = item;
              if (realEstate) {
                  setrealEstateDetail(realEstate);
                  setShowDetail(true);
              }
          }
        });
      } 
  };

  const handleCloseDetail = () => {
      setShowDetail(false);
  };

  const history = useHistory();
  const handleEdit = (realEstateID: string) => {
      {realEstates.map((item) => {
        if (item.realEstateID === realEstateID) {
          history.push(EDIT_REALESTATE_ID(realEstateID), {
            existRealEstate: item,
          });
        }
      })
    }
  };

  return (
    <>
      <Table responsive>
        <thead>
          <tr
            style={{ fontWeight: 'normal', fontSize: '18px' }}
            className="title-table"
          >
            <th style={{ width: "2%" }}>STT</th>
            <th style={{ width: "5%" }}>Realestate Code</th>
            <th style={{ width: "20%" }}>Title</th>
            <th style={{ width: "10%" }}>Price</th>
            <th style={{ width: "30%" }}>Image</th>
            <th style={{ width: "15%" }}>Description</th>
            <th style={{ width: "10%" }}>Location</th>
            <th style={{ width: "5%" }}>Phone</th>
            <th style={{ width: "3%" }}>Approve</th>
          </tr>
        </thead>
        <tbody className='body'>
          {realEstates && realEstates.map((data, i) => (
            <tr
              style={{ fontWeight: 'normal', fontSize: '14px' }}
              key={data.realEstateID}
              onClick={() => handleShowInfo(data.realEstateID)}
            >
              <th scope="row">{i + 1}</th>
              <td>{data.realEstateID}</td>
              <td>{data.title}</td>
              <td>{data.price}</td>
              <td><img className="img" src={data.image} /></td>
              <td>{data.description}</td>
              <td>{data.location}</td>
              <td>{data.phoneNumber}</td>
              {data.approve == 'False' && (
                <td className="d-flex">
                  <ButtonIcon
                    onClick={() => handleEdit(data.realEstateID)}
                  >
                    <PencilFill className="text-black" />
                  </ButtonIcon>
                </td>
              )}
              {data.approve == 'True' && (
                <td><p>Approved</p></td>
              )}
            </tr>
          ))}
        </tbody>
      </Table>
      {realEstateDetail && showDetail && (
                <Info realEstates={realEstateDetail} handleClose={handleCloseDetail} />
            )}
    </>
  );
};

export default RealEstateTable;
