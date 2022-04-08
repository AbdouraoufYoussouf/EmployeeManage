import './App.css';
import { Home } from './Pages/Home';
import { Employe } from './Pages/Employe';
import { Departement } from './Pages/Departement';
import { NavBar } from './Components/NavBar';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
        <NavBar/>
      <Routes>
        <Route path='/' element={<Home/>} />
        <Route path='/employe' element={<Employe/>} />
        <Route path='/departement' element={<Departement/>} />
      </Routes>
      <div className="container ">
            &copy; 2022 - Abdouraouf Youssouf 
      </div>
    </BrowserRouter>
  );
}

export default App;
