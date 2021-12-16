const Endpoints = {
    authorize: '/api/Authen',
    me: '/api/Authen/me',
    users: '/api/User',
    customers: '/api/User/user',
    changePassword: '/api/User/password',
    disable: '/api/User/disable',
    disableId: (id) => `/api/User/disable/${id}`,
    usersId: (staffCode) => `/api/User/${staffCode}`,
    realEstates: (username) => `/RealEstate/name=${username}`,
    realEstatesId: (realEstateID) => `/RealEstate/${realEstateID}`,
    categories: `/Category`,
    categoriesId: (categoryID) => `/Category/${categoryID}`,
    newsName: (username) => `/News/name=${username}`,
    news: '/News',
    newsId: (newsID) => `/News/${newsID}`,
    disableNewsId: (id) => `/News/disable/${id}`,
    authentication: '/api/Authen',
};

export default Endpoints;
