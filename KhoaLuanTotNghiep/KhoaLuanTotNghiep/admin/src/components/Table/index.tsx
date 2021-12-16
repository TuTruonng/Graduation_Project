import React from "react";
import { CaretDownFill, CaretUpFill } from "react-bootstrap-icons";
import IColumnOption from "src/interfaces/IColumnOption";

import Paging, { PageType } from "./Paging";

export type SortType = {
  columnValue: string;
  orderBy: string;
};

type ColumnHeaderType = {
  colName: string;
  colValue: string;
}

const ColumnHeader: React.FC<ColumnHeaderType> = ({ colName, colValue }) => {
  return (
    <span style={{ borderBottom: "3px solid grey", display: "block" }}>
      <a className="btn">
        {colName}
      </a>
    </span>
  );
};

type ColumnIconType = {
  colValue: string;
  sortState: SortType;
}


type Props = {
  columns: IColumnOption[];
  children: React.ReactNode;
};

const Table: React.FC<Props> = ({ columns, children }) => {
  // console.log(page)
  return (
    <>
      <div className="table-container">
        {
          <>
            <table className="table">
              <thead>
                <tr>
                  {
                    columns.map((col, i) => (
                      <th key={i}>
                        <ColumnHeader
                          colName={col.columnName}
                          colValue={col.columnValue} />
                      </th>
                    ))
                  }
                </tr>
              </thead>

              <tbody>
                {children}
              </tbody>
            </table>
          </>
        }
      </div>
    </>
  );
};

export default Table;
