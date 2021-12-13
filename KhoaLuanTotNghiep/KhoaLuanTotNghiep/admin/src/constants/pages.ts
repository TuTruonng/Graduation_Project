export const LOGIN = '/';
export const HOME = '/Home';
export const NOTFOUND = '/notfound';
export const UNAUTHORIZE = '/unauthorization';
export const CHANGEPASSWORD = '/ChangePassword';
// Users
export const USERMANAGER = '/Manager User';
export const CREATEUSER = '/Manager User/Create New User';
export const EDIT_USER = '/Manager User/Edit User/:staffCode';
export const EDIT_USER_ID = (staffCode: string | number) =>
    `/Manager User/Edit User/${staffCode}`;
// Assets
export const REALESTATEMANAGER = '/Manager RealEstate';
export const CREATEREALESTATE = '/Manager RealEstate/Create New RealEstate';
export const EDIT_REALESTATE = '/Manager RealEstate/Edit RealEstate/:realEstateID';
export const EDIT_REALESTATE_ID = (realEstateID: string | number) =>
    `/Manager RealEstate/Edit RealEstate/${realEstateID}`;
// Not ready to use
export const MANAGEASSIGNMENT = '/Manage AssignMent';
export const REQUEST = '/Request';
export const REPORT = '/Report';
