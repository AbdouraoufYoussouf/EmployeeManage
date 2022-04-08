import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { getDepartements } from '../Store/departeSlice';

export const Departement = () => {

  const dispatch = useDispatch();
  const departState = useSelector((state) => state.departementsData);
  const departs = departState.departements;
  console.log("depart",departs);

  useEffect(() => {
    dispatch(getDepartements());
  }, [dispatch]);

 

  return (
    <div className='container'>
      <div className='header'>
        <button type="button" className="btn btn-primary" data-toggle="modal" data-target="#exampleModal">Add new Departement</button>
      </div>
      <div className='content'>
        <table className='table table-bordered '>
          <thead className="thead-dark">
            <tr>
              <th>Id</th>
              <th>Name Departement</th>
              <th>Employee countaint</th>
            
              <th className='text-center'>Options</th>
            </tr>
          </thead>
          <tbody>
            {
              departs.map((dep,index) =>{
                return(
                   <tr key={index}>
                    <td>{dep.depId} </td>
                    <td>{dep.depName}</td>
                    <td>{dep.employees.length} Employe</td>
                    
                    <td className='text-center'>
                      <button className='btn btn-secondary '>Edit</button>
                      <button className='btn btn-danger ms-2'>Delete</button>
                    </td>
                  </tr>
                )
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
              <h5 className="modal-title" id="exampleModalLabel">Add new Departement</h5>
              <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div className="modal-body">
            <form>
              <div className="form-group">
                <label htmlFor="exampleInputEmail1">Name Departement</label>
                <input className='form-control' placeholder='Enter Name...'/>
              </div>
            </form>
            </div>
            <div className="modal-footer">
              <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
              <button type="button" className="btn btn-primary">Save changes</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
