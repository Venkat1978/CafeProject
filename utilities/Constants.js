const API_BASE_URL_DEVELOPMENT = 'https://localhost:7008';
const API_BASE_URL_PRODUCTION = 'https://venkatesan-CafeEmpApi.azurewebsites.net';

const ENDPOINTS = {
    GET_ALL_EmployeeS: 'get-all-Employees',
    GET_Employee_BY_ID: 'get-Employee-by-id',
    CREATE_Employee: 'create-Employee',
    UPDATE_Employee: 'update-Employee',
    DELETE_Employee_BY_ID: 'delete-Employee-by-id'
};

const development = {
    API_URL_GET_ALL_Employees: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_Employees}`,
    API_URL_GET_Employee_BY_ID: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_Employee_BY_ID}`,
    API_URL_CREATE_Employee: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.CREATE_Employee}`,
    API_URL_UPDATE_Employee: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.UPDATE_Employee}`,
    API_URL_DELETE_Employee_BY_ID: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.DELETE_Employee_BY_ID}`
};

const production = {
    API_URL_GET_ALL_Employees: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_Employees}`,
    API_URL_GET_Employee_BY_ID: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_Employee_BY_ID}`,
    API_URL_CREATE_Employee: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.CREATE_Employee}`,
    API_URL_UPDATE_Employee: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.UPDATE_Employee}`,
    API_URL_DELETE_Employee_BY_ID: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.DELETE_Employee_BY_ID}`
};

const Constants = process.env.NODE_ENV === 'development' ? development : production;

export default Constants;
