import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { getCategories } from "../reducer";
import CategoryTable from "./Table";
import ICategory from "src/interfaces/Category/ICategory";
import { CREATECATEGORY } from "src/constants/pages";

type Props = {
  categories: ICategory | null;
  fetchData: Function;
};

const ListCategories = () => {
  const dispatch = useAppDispatch();
  const { categories, loading } = useAppSelector((state) => state.categoryReducer);
  const [category, setcategory] = useState([]);
  const [itemSelected, setSelected] = React.useState(null);
  // let params = {};

  const fetchData = () => {
    dispatch(getCategories(category));
  };

  useEffect(() => {
    fetchData();
  }, []);

  console.log(categories);

  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.categoryID !== itemDel);

  return (
    <div className="content-wrapper" >
      <br />
      <h3 className="invalid"><b>Category List</b></h3>
      <br />
      <div className='tblcategory'>
        <div className="d-flex mb-5 intro-x">
          <div className="d-flex align-items-center ml-3">
            <Link
              to={CREATECATEGORY}
              type="button"
              className="btn btn-danger"
            >
              Create new category
            </Link>
          </div>
        </div>

        <CategoryTable
          categories={categories}
          fetchData={fetchData}
        />
      </div>
    </div>
  );
};

export default ListCategories;
