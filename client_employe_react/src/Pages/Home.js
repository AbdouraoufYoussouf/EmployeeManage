import React, { useEffect } from 'react'
import linkedine from '../images/linkedine.png'
export const Home = () => {
  //const data = fetch('https://localhost:7088/api/departements').then(res => res.json()).then(e => console.log(e))

  return (
    <div >
      <div>
        <h1 className='text-center mt-3'>Bienvenu à qui veut bouffer un sandwitch</h1>
      </div>
      <div>
        <img className='linkedine' alt='photo' src={linkedine}/>
        
      </div>
    </div>
  )
}
