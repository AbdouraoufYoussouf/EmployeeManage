import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";

const baseURL = "https://localhost:7088/api/"; 

const initialState = {
     departements: [],
     addDepartementStatus : "",
     addDepartementError : "",
     getDepartementStatus : "",
     getDepartementError : "",
     updateDepartementStatus : "",
     updateDepartementError : "",
     deleteDepartementStatus : "",
     deleteDepartementError : "",
 };

 export const getDepartements = createAsyncThunk(
    "departements/getDepartements",
    async (id = null, { rejectWithValue }) => {
      try {
        const response = await axios.get(baseURL + "departements");
        return response.data;
      } catch (error) {
        console.log(error);
        return rejectWithValue(error.response?.data);
      }
    }
  );

  export const departeSlice = createSlice({
      name : "departement",
      initialState,
        reducers:{},
        extraReducers:{
            [getDepartements.pending] : (state ,action) => {
                return{
                    ...state,
                    addDepartementStatus : "",
                    addDepartementError : "",
                    getDepartementStatus : "pending",
                    getDepartementError : "",
                    updateDepartementStatus : "",
                    updateDepartementError : "",
                    deleteDepartementStatus : "",
                    deleteDepartementError : "",
                }
            },
            [getDepartements.fulfilled] : (state ,action) => {
                return{
                    ...state,
                    departements : action.payload,
                    addDepartementStatus : "",
                    addDepartementError : "",
                    getDepartementStatus : "success",
                    getDepartementError : "",
                    updateDepartementStatus : "",
                    updateDepartementError : "",
                    deleteDepartementStatus : "",
                    deleteDepartementError : "",
                }
            },
            [getDepartements.rejected] : (state ,action) => {
                return{
                    ...state,
                    addDepartementStatus : "",
                    addDepartementError : "",
                    getDepartementStatus : "rejected",
                    getDepartementError : action.payload,
                    updateDepartementStatus : "",
                    updateDepartementError : "",
                    deleteDepartementStatus : "",
                    deleteDepartementError : "",
                }
            }
        }
  })