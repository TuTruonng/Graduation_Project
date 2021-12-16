export const LOGIN = '/';
export const HOME = '/Home';
export const NOTFOUND = '/notfound';
export const UNAUTHORIZE = '/unauthorization';
export const CHANGEPASSWORD = '/ChangePassword';
// Users
export const USERMANAGER = '/Manager User';
export const CREATEUSER = '/Manager User/Create New User';
export const EDIT_USER = '/Manager User/Edit User/:userId';
export const EDIT_USER_ID = (userId: string | number) =>
    `/Manager User/Edit User/${userId}`;
export const CUSTOMERMANAGER = '/Manager Customer';   
// RealEstates
export const REALESTATEMANAGER = '/Manager RealEstate';
export const CREATEREALESTATE = '/Manager RealEstate/Create New RealEstate';
export const EDIT_REALESTATE = '/Manager RealEstate/Edit RealEstate/:realEstateID';
export const EDIT_REALESTATE_ID = (realEstateID: string | number) =>
    `/Manager RealEstate/Edit RealEstate/${realEstateID}`;
// Categories
export const CATEGORYMANAGER = '/Manager Category';
export const CREATECATEGORY = '/Manager Category/Create New Category';
export const EDIT_CATEGORY = '/Manager Category/Edit Category/:CategoryID';
export const EDIT_CATEGORY_ID = (CategoryID: string | number) =>
    `/Manager Category/Edit Category/${CategoryID}`;
// News
export const NEWSMANAGER = '/Manager News';
export const CREATENEWS = '/Manager News/Create New News';
export const EDIT_NEWS = '/Manager News/Edit News/:newsID';
export const EDIT_NEWS_ID = (newsID: string | number) =>
    `/Manager News/Edit News/${newsID}`;
    // Reports
export const REPORTMANAGER = '/Manager Reports';

    // Orders
export const ORDERMANAGER = '/Manager Orders';

// Not ready to use
export const MANAGEASSIGNMENT = '/Manage AssignMent';
export const REQUEST = '/Request';
export const REPORT = '/Report';
