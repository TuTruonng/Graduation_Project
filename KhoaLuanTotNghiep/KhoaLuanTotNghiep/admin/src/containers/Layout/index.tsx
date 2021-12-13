import React from "react";
import { NotificationContainer } from 'react-notifications';

import Header from "./Header";
import SideBar from "./SideBar";

const Layout = ({ children }) => {
  return (
    <>
      <NotificationContainer />
      <Header />

      <div className="container-lg-min container-fluid">
        <div className="row mt-5">

          <div className="col-lg-2 col-md-4 col-sm-5">
            <SideBar />
          </div>

          <div className="col-lg-10 col-md-8 col-sm-7" style={{margin: 0, padding: 0}}>
            {children}
          </div>
        </div>

      </div>
    </>
  );
};

export default Layout;
