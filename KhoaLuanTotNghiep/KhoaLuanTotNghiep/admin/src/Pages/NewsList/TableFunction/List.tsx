import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import NewsTable from "./Table";
import INews from "src/interfaces/News/INews";
import { getNews, setNews } from "../reducer";
import { CREATENEWS } from "src/constants/pages";

type Props = {
  news: INews | null;
  fetchData: Function;
};

const ListNews = () => {
  const dispatch = useAppDispatch();
  const [New, setNew] = useState([]);
  const {newses, loading } = useAppSelector((state) => state.newsReducer);

  const [itemSelected, setSelected] = React.useState(null);
  // let params = {};

  const fetchData = () => {
    dispatch(getNews(New));
  };

  useEffect(() => {
    fetchData();
  }, []);

  console.log(newses);

  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.newsID !== itemDel);

  return (
    <div className="content-wrapper" >
      <br />
      <h3 className="invalid"><b>News List</b></h3>
      <br />
      <div className='tblNews'>
        <div className="d-flex mb-5 intro-x">
          <div className="d-flex align-items-center ml-3">
            <Link
              to={CREATENEWS}
              type="button"
              className="btn btn-danger"
            >
              Create new News
            </Link>
          </div>
        </div>

        <NewsTable
          newses={newses}
          fetchData={fetchData}
        />
      </div>
    </div>
  );
};

export default ListNews;
