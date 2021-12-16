import React, { useState } from 'react';
import { PencilFill, XCircle } from 'react-bootstrap-icons';
import { useHistory } from 'react-router';
import ButtonIcon from 'src/components/ButtonIcon';
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import "../../../styles/BDS.css"
// import Info from './Info';
import { useAppDispatch } from 'src/hooks/redux';
import ICategory from 'src/interfaces/Category/ICategory';
import { EDIT_CATEGORY_ID } from 'src/constants/pages';
import { object } from 'yup/lib/locale';
import Info from 'src/Pages/CategoryList/TableFunction/Info';

type Props = {
  categories: ICategory | null;
  fetchData: Function;
};

const CategoryTable = ({
  categories,
  fetchData,
}) => {
  const dispatch = useAppDispatch();

  const [showDetail, setShowDetail] = useState(false);
  const [categoryDetail, setcategoryDetail] = useState(null as ICategory | null);
  const [disableState, setDisableState] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowInfo = (categoryID: string) => {
    {
      console.log('Info')
      categories.map((item) => {
        if (item.categoryID === categoryID) {
          const category = item;
          console.log(category)
          if (category) {
            setcategoryDetail(category);
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
  const handleEdit = (categoryID: string) => {
    {
      categories.map((item) => {
        if (item.categoryID === categoryID) {
          history.push(EDIT_CATEGORY_ID(categoryID), {
            existCategory: item,
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
            <th style={{ width: "5%" }}>STT</th>
            <th style={{ width: "15%" }}>Category Code</th>
            <th style={{ width: "20%" }}>Category Name</th>
            <th style={{ width: "50%" }}>Description</th>
            <th style={{ width: "10%" }}>Action</th>
          </tr>
        </thead>
        <tbody className='body'>
          {categories && categories.map((data, i) => (
            <tr
              style={{ fontWeight: 'normal', fontSize: '14px' }}
              key={data.categoryID}
              onClick={() => handleShowInfo(data.categoryID)}
            >
              <th scope="row">{i + 1}</th>
              <td>{data.categoryID}</td>
              <td>{data.categoryName}</td>
              <td>{data.description}</td>
              <td className="d-flex">
                <ButtonIcon
                  onClick={() => handleEdit(data.categoryID)}
                >
                  <PencilFill className="text-black" />
                </ButtonIcon>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      {categoryDetail && showDetail && (
                <Info category={categoryDetail} handleClose={handleCloseDetail} />
            )}
    </>
  );
};

export default CategoryTable;
