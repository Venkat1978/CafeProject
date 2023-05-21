import React, {useState} from "react";
import Constants from "./utilities/Constants";

export default function App() {

  const [Employees, setEmployees] = useState([]);
  const [Cafes, setCafes] = useState([]);

  function getEmp(){
    setCafes([])
    const url= Constants.API_URL_GET_ALL_Employee;
    fetch(url, {
      method: 'GET'
    })
    .then(response => response.json())
    .then(employeesfromServer =>{
        console.log(employeesfromServer)
        setEmployees(employeesfromServer)
      })
      .catch((error) => {
        console.log(error);
        alert(Error)
      });
  }

  function getCafe(){
    setEmployees([])
    const url= Constants.API_URL_GET_ALL_CAFE;
    fetch(url, {
      method: 'GET'
    })
    .then(response => response.json())
    .then(CafesfromServer =>{
        console.log(CafesfromServer)
        setCafes(CafesfromServer)
      })
      .catch((error) => {
        console.log(error);
        alert(Error)
      });
  }

  return (
    <div className="Container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-colum justify-content-center align-items-center">
        <div>
        <h1>U3 info Assesment - Cafe Employee</h1>
        <div className="mt-5">
          <button className="btn btn-dark btn-lg" onClick={getEmp}>Employees List</button>
          <button className="btn btn-secondary btn-lg" >Add New Employee</button>
          <button className="btn btn-dark btn-lg" onClick={getCafe}>Cafes List</button>         
          <button className="btn btn-secondary btn-lg" >Add New Cafe</button>
        </div>
        </div>        
        </div>  
          <div>
            {(Employees.length > 0) && renderEmployeesTable()}
            {(Cafes.length > 0) && renderCafesTable()}
          </div>      
      </div>
    </div>
  );

  function deleteEmployee(EmployeeId) {
    
    const url= '${Constants.API_URL_DELETE_Employee_BY_ID}/${EmployeeId}'

    fetch(url, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        onEmployeeDeleted(EmployeeId);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  function deleteCafe(CafeId) {
    alert(CafeId)
    
    const url= '${Constants.API_URL_DELETE_CAFE_BY_ID}/${CafeId}';
    fetch(url, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        onCafeDeleted(CafeId);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }
  function onCafeDeleted(deletedCafeId) {
    alert('Cafe successfully deleted. After clicking OK, look at the table below to see your Cafe disappear.');
  }
  function onEmployeeDeleted(deletedEmployeeId) {
    alert('Employee successfully deleted. After clicking OK, look at the table below to see your Employee disappear.');
  }

function renderEmployeesTable(){
  return(
    <div className="table-responsive mt-5">
      <table className="table table-bordered border-dark">
        <thead>
          <tr>
            <th scope="col">
              Employee Id (PK)
            </th>
            <th>
              Name
            </th>
            <th>
              Email address
            </th>
            <th>
              Phone Number
            </th>
            <th>
              Days worked in the café
            </th>
            <th>
              Café name
            </th>
            <th>Edit/Delete </th>
          </tr>      
        </thead>
        <tbody>
          {Employees.map((Employee) => (
                  <tr>
                  <td>{Employee.id}</td>
                  <td>{Employee.name}</td>
                  <td>{Employee.email_address}</td>
                  <td>{Employee.phone_number}</td>
                  <td></td><td></td>
                    <td>
                    <button className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                    <button onClick={() => { if(window.confirm(`Are you sure you want to delete the Employee Named "${Employee.name}"?`)) deleteEmployee(Employee.id) }} className="btn btn-secondary btn-lg">Delete</button>
                
                </td>
                  </tr>
                ))}      
          </tbody>
      </table>
      
    </div>
  );
}

function renderCafesTable(){
  return(
    <div className="table-responsive mt-5">
      <table className="table table-bordered border-dark">
        <thead>
          <tr>
            <th scope="col">
              Cafe Id (PK)
            </th>
            <th>
              Name
            </th>
            <th>
              Description
            </th>
            <th>
              Employees
            </th>
            <th>
              Location
            </th>
            <th>
              Edit/Delete 
            </th>
          </tr>      
        </thead>
        <tbody>
          {Cafes.map((Cafe) => (
                  <tr>
                  <td>{Cafe.id}</td>
                  <td>{Cafe.name}</td>
                  <td>{Cafe.description}</td>
                  <td></td>
                  <td>{Cafe.location}</td>
                  
                    <td>
                    <button className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                    <button onClick={() => { if(window.confirm(`Are you sure you want to delete the Cafe Name "${Cafe.name}"?`)) deleteCafe(Cafe.cafeId) }} className="btn btn-secondary btn-lg">Delete</button>
                
                </td>
                  </tr>
                ))}      
          </tbody>
      </table>
    </div>
  );
}

}