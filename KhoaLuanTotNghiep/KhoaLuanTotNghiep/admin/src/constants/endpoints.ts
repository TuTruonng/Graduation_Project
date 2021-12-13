const Endpoints = {
    authorize: '/api/Authen',
    me: '/api/Authen/me',
    users: '/api/User',
    changePassword: '/api/User/password',
    disable: '/api/User/disable',
    disableId: (id) => `/api/User/disable/${id}`,
    usersId: (staffCode) => `/api/User/${staffCode}`,
    realEstates: (username) => `/RealEstate/name=${username}`,
    realEstatesId: (realEstateID) => `/RealEstate/${realEstateID}`,
    authentication: '/api/Authen',
};

export default Endpoints;
