import './App.css'
import { Route, Routes } from 'react-router-dom'
import SignIn from './Sign-in'
import Register from './Register'

function App() {
 
  return (
    <>
      <div className='tms'>
        <Routes>
          <Route path="/" element={<SignIn />} />
          <Route path='sign-in' element={<SignIn />} />
          <Route path='register' element={<Register />} />
        </Routes>

      </div>
    </>
  )
}

export default App
