import moment from 'moment';
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { employesAdd, getEmployes } from '../Store/redux';
import './employe.css'

export const Employe = () => {

  const [employe,setEmploye] = useState({
    firstName: "",
    lastName: "",
    email: "",
    dateOfBrith: "1981-12-22T00:00:00",
    photoPath: "images/sam.jpg",
    depId: 1
  });
  const dispatch = useDispatch();
  const employesState = useSelector((state) => state.employesData);
  const emplData = employesState.employes;
  console.log(emplData);
  
  useEffect(() => {
    dispatch(getEmployes());
  }, [dispatch]);

  const handleSubmit = (e) => {
    e.preventDefault();
    //dispatch
    //alert(JSON.stringify(employe));
    dispatch(employesAdd(employe))

    // setEmploye({
    //   FirstName:"",
    //   LastName:"",
    //   Email:"",
    //   DateOfBrith:"",
    // })
  }


  return (
    <div className='container'>
      <div className='header'>
        <button type="button" className="btn btn-primary" data-toggle="modal" data-target="#exampleModal">Add new Departement</button>
      </div>
      <div className='content'>
        <table className='table table-dark '>
          <thead>
            <tr>
              <th>Id</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Email</th>
              <th>Date BrithDay</th>
              <th className='text-center'>Options</th>
            </tr>
          </thead>
          <tbody>
          {
            emplData.map((emp,index)=>{
              return(
                <tr key={index}>
                    <td> {emp.empId} </td>
                    <td>{emp.firstName}</td>
                    <td>{emp.lastName}</td>
                    <td>{emp.email}</td>
                    <td>{moment(emp.dateOfBrith).format("DD/MM/YYYY")}</td>
                    <td className='text-center'>
                      <button className='btn btn-secondary '>Edit</button>
                      <button className='btn btn-danger ms-2'>Delete</button>
                    </td>
                  </tr>
              );
            })
          }
              
                  
          
          
        
          </tbody>
        </table>
      </div>

      {/* <!-- Modal --> */}

      <div className="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div className="modal-dialog" role="document">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title" id="exampleModalLabel">Add new Employee</h5>
              <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div className="modal-body">
              <form onSubmit={ handleSubmit } >
                <div className="form-group">
                  <input
                    value={ employe.firstName }
                    onChange={(e) => setEmploye({ ...employe, firstName: e.target.value})} 
                  type="text" name='firstname' className='form-control mb-2' placeholder='Enter FirstName...'/>
                </div>

                <div className="form-group">
                  <input
                  value={ employe.lastName }
                    onChange={(e) => setEmploye({ ...employe, lastName: e.target.value})}
                  type="text" name='lastname' className='form-control mb-2' placeholder='Enter LastName...'/>
                </div>

                <div className="form-group">
                  <input
                  value={ employe.email }
                    onChange={(e) => setEmploye({ ...employe, email: e.target.value})}
                  type="text" name='email' className='form-control mb-2' placeholder='Enter Email...'/>
                </div>
                <div className="form-group">
                  <input
                  value={ employe.dateOfBrith }
                    onChange={(e) => setEmploye({ ...employe, dateOfBrith: e.target.value})}
                  type="text" name='dateofbrith' className='form-control mb-2' placeholder='Enter DateOfBrith...'/>
                </div>

                <div className="input-group mb-3">
                  <div className="input-group-prepend">
                    <label className="input-group-text" htmlFor="inputGroupSelect01">Departement</label>
                  </div>
                  {/* <select value="moi" defaultValue='DEFAULT' >
                    <option value="DEFAULT" disabled>Choose a salutation ...</option>
                
                  </select> */}
                </div>
                <div className="modal-footer">
                  <button type="button" className="btn btn-secondary" data-dismiss="modal">Cancel</button>
                  <button type='submit' className="btn btn-primary">Save</button>
                </div>
              </form>
            </div>
        
             
          
          </div>
        </div>
      </div>
    </div>
  )
}
