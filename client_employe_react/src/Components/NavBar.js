import React from 'react'
import { NavLink } from 'react-router-dom';
import './navbar.css';

export const NavBar = () => {
  return (
        <nav className='navbar'>
            <div className='logo'>
                <NavLink className="active" to="/"><h1>DocRaf</h1> </NavLink>
            </div>
            <form >
                <input className='search' type="text" placeholder='Search...'  />
            </form>
            <ul className='navUl'>
                <NavLink className={(nav) => nav.isActive ? "active" : "navlink"} to='/'><li>Home</li></NavLink>
                <NavLink className={(nav) => nav.isActive ? "active" : "navlink"} to='/employe'><li>Employe</li></NavLink>
                <NavLink className={(nav) => nav.isActive ? "active" : "navlink"} to='/departement'><li>Departement</li></NavLink>
            </ul>
        </nav>
  )
}
