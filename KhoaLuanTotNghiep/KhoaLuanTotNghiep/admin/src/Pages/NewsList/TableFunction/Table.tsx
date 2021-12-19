import React, { useState } from 'react';
import { PencilFill, XCircle } from 'react-bootstrap-icons';
import { useHistory } from 'react-router';
import ButtonIcon from 'src/components/ButtonIcon';
import { Button, Table } from "reactstrap";
import { NotificationManager } from 'react-notifications';
import { Link } from "react-router-dom";
import "../../../styles/BDS.css"
// import Info from './Info';
import { useAppDispatch } from 'src/hooks/redux';
import INews from 'src/interfaces/News/INews';
import { object } from 'yup/lib/locale';
import Info from 'src/Pages/NewsList/TableFunction/Info';
import { EDIT_NEWS_ID } from 'src/constants/pages';
import ConfirmModal from 'src/components/ConfirmModal';
import { disableNews } from '../reducer';

type Props = {
  newses: INews | null;
  fetchData: Function;
};

const NewsTable = ({
  newses,
  fetchData,
}) => {
  const dispatch = useAppDispatch();

  const [showDetail, setShowDetail] = useState(false);
  const [NewsDetail, setNewsDetail] = useState(null as INews | null);
  const [disableState, setDisableState] = useState({
    isOpen: false,
    id: '',
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowDisableBox = async (id) => {
    setDisableState({
      id,
      isOpen: true,
      title: 'Are you sure?',
      message: 'Do you want to disable this News?',
      isDisable: true,
    });
  };

  const handleCancelDisable = () => {
    setDisableState({
      isOpen: false,
      id: '',
      title: '',
      message: '',
      isDisable: true,
    });
  };

  const handleResult = async (result, message) => {
    if (result) {
      handleCancelDisable();
      await fetchData();
      NotificationManager.success(
        `Disable News successful`,
        `Disable successful`,
        2000
      );
    } else {
      setDisableState({
        ...disableState,
        title: 'Can not disable News',
        message,
        isDisable: result,
      });
    }
  };

  const handleSubmitDisable = async () => {
    //const isSuccess = await DisableNewsRequest(disableState.id);
    dispatch(
      disableNews({
        handleResult,
        newsID: disableState.id
      })
    );
    /*if (isSuccess) {
        console.log("Disable success");
        await handleResult(true, '');
    }*/
  };

  const handleShowInfo = (newsID: string) => {
    {
      console.log('Info')
      newses.map((item) => {
        if (item.newsID === newsID) {
          const news = item;
          console.log(news)
          if (news) {
            setNewsDetail(news);
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
  const handleEdit = (newsID: string) => {
    {
      newses.map((item) => {
        if (item.newsID === newsID) {
          history.push(EDIT_NEWS_ID(newsID), {
            existNewses: item,
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
            <th style={{ width: "15%" }}>News Code</th>
            <th style={{ width: "20%" }}>News Name</th>
            <th style={{ width: "50%" }}>Image</th>
            <th style={{ width: "10%" }}>Action</th>
          </tr>
        </thead>
        <tbody className='body' style={{}}>
          {newses && newses.map((data, i) => (
            <tr
              style={{ fontWeight: 'normal', fontSize: '14px' }}
              key={data.newsID}
              onClick={() => handleShowInfo(data.newsID)}
            >
              <th scope="row">{i + 1}</th>
              <td>{data.newsID}</td>
              <td>{data.newsName}</td>
              <td><img className="img" src={data.img} style={{ width: '300px', height: '150px' }} /></td>
              <td className="d-flex">
                <ButtonIcon
                  onClick={() => handleEdit(data.newsID)}
                >
                  <PencilFill className="text-black" />
                </ButtonIcon>
                <ButtonIcon
                  onClick={() => handleShowDisableBox(data.newsID)}
                >
                  <XCircle className="text-danger mx-2" />
                </ButtonIcon>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      {NewsDetail && showDetail && (
        <Info newses={NewsDetail} handleClose={handleCloseDetail} />
      )}

      <ConfirmModal
        title={disableState.title}
        isShow={disableState.isOpen}
        onHide={handleCancelDisable}
      >
        <div>
          <div className="text-center">{disableState.message}</div>
          {disableState.isDisable && (
            <div className="text-center mt-3">
              <button
                className="btn btn-danger mr-3"
                onClick={handleSubmitDisable}
                type="button"
              >
                Disable
              </button>

              <button
                className="btn btn-outline-secondary"
                onClick={handleCancelDisable}
                type="button"
              >
                Cancel
              </button>
            </div>
          )}
        </div>
      </ConfirmModal>
    </>
  );
};

export default NewsTable;
