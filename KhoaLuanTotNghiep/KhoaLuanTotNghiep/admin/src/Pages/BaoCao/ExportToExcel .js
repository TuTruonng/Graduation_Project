import React from "react";
import * as FileSaver from "file-saver";
import * as XLSX from "xlsx";
import axios from "axios";
import"../BaoCao/BaoCao.css"

export const ExportToExcel = ({ apiData, fileName }) => {
    const [data, setData] = React.useState([])
   
  
    React.useEffect(() => {
      const fetchData = () =>{
       axios.get('https://localhost:44375/Report/export').then(r => setData(r.data) )
      }
      fetchData()
    }, [])
  const fileType =
    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8"; // loại mime mở rộng/định dạng cho xlsx
  const fileExtension = ".xlsx";

  const exportToCSV = (apiData, fileName) => {
    const ws = XLSX.utils.json_to_sheet(apiData); //chuyển đổi một mảng các đối tượng JavaScript thành một trang tính
    const wb = { Sheets: { data: ws }, SheetNames: ["data"] };
    const excelBuffer = XLSX.write(wb, { bookType: "xlsx", type: "array" });
    const data = new Blob([excelBuffer], { type: fileType });// một giao thức giả để cho phép các đối tượng Blob và File được sử dụng làm nguồn URL cho những thứ như hình ảnh, liên kết tải xuống cho dữ liệu nhị phân
    FileSaver.saveAs(data, fileName + fileExtension);
  };

  return (
    <button className="button-excel elevation-2" onClick={(e) => exportToCSV(apiData, fileName)}><b>Xuất Báo Cáo</b></button>
  );
};