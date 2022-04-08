import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";

const baseURL = "https://localhost:7088/api/"; 

const initialState = {
     employes: [],
     addEmployeStatus : "",
     addEmployeError : "",
     getEmployeStatus : "",
     getEmployeError : "",
     updateEmployeStatus : "",
     updateEmployeError : "",
     deleteEmployeStatus : "",
     deleteEmployeError : "",
 };
//Actions
export const employesAdd = createAsyncThunk(
    "employes/employesAdd",
    async (employe, { rejectWithValue }) => {
        try {
            const response = await axios.post(baseURL + "Employees", employe);
            return response.data;
        } catch (error) {
            console.log(error);
            return rejectWithValue(error.response.data);
        }
    }
) ;

export const getEmployes = createAsyncThunk(
    "employes/getEmployes",
    async (id = null, { rejectWithValue }) => {
      try {
        const response = await axios.get(baseURL + "employees");
        return response.data;
      } catch (error) {
        console.log(error);
        return rejectWithValue(error.response?.data);
      }
    }
  );


export const updateEmploye = createAsyncThunk(
  "employes/updateEmploye",
  async (employe, {rejectWithValue}) => {
    try {
      const {empId,firstName,lastName,email,dateOfBrith,depId} = employe;
      const response = await axios.put(baseURL + "employes/" + empId ,{
        firstName,lastName,email,dateOfBrith,depId
      });
      return response.data;
    } catch (error) {
      console.log(error);
      return rejectWithValue(error.response.data)
    }
  }
)

export const deleteEmpl = createAsyncThunk(
  "employes/deleteEmploye",
  async (id, { rejectWithValue }) => {
    try {
      const response = await axios.delete(baseURL + "employes/" + id);
      return response.data;
    } catch (error) {
      console.log(error);
      return rejectWithValue(error.response?.data);
    } 
  }
);

//slice

export const employeSlice = createSlice({
    name : "employe",
    initialState,
    reducers:{},
    extraReducers:{
        [employesAdd.pending] : (state , action) =>{
            return{
                ...state,
                addEmployeStatus : "pending",
            };
        },
        [employesAdd.fulfilled] : (state , action) =>{
            return{
                ...state,
                employes : [action.payload, ...state],
                addEmployeStatus : "success",
            };
        },
        [employesAdd.rejected] : (state , action) =>{
            return{
                ...state,
                employes : [action.payload, ...state],
                addEmployeStatus : "rejected",
                addEmployeError : action.payload,
            };
        },
        //Get Employe
        [getEmployes.pending]: (state, action) => {
            return {
              ...state,
                getEmployeStatus : "pending",
                getEmployeError : "",
            };
          },
          [getEmployes.fulfilled]: (state, action) => {
            return {
              ...state,
              employes: action.payload,
              addEmployeStatus : "",
              addEmployeError : "",
              getEmployeStatus : "success",
            };
          },
          [getEmployes.rejected]: (state, action) => {
            return {
              ...state,
              addEmployeStatus : "",
              addEmployeError : "",
              getEmployeStatus : "rejected",
              getEmployeError : action.payload,
            };
          },
          // Update Employe
        [updateEmploye.pending]: (state, action) => {
            return {
              ...state,
              updateEmployeStatus : "pending",
              updateEmployeError : "",
            };
          },
          [updateEmploye.fulfilled]: (state, action) => {
            const updatedEmpl = state.employes.map((empl)=>empl.empId===action.payload.empId ? action.payload : empl)
            return {
              ...state,
              employes: updatedEmpl,
              updateEmployeStatus : "success",
              updateEmployeError : "",
            };
          },
          [updateEmploye.rejected]: (state, action) => {
            return {
              ...state,
              updateEmployeStatus : "rejected",
              updateEmployeError : action.payload,
            };
          },
          // Delete Employe
        [deleteEmpl.pending]: (state, action) => {
            return {
              ...state,
              deleteEmployeStatus : "pending",
              deleteEmployeError : "",
            };
          },
          [deleteEmpl.fulfilled]: (state, action) => {
            const currentTodos = state.employes.filter((empl) => empl.empId !== action.payload.empId);
            state = {
              ...state,
              employes: currentTodos,
              deleteEmployeStatus : "success",
              deleteEmployeError : "",
            };
          },
          [deleteEmpl.rejected]: (state, action) => {
            state = {
              ...state,
              deleteEmployeStatus : "success",
              deleteEmployeError : action.payload,
            };
          },
    }
});


