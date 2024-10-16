import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import NavBarKafic from './components/NavBarKafic'
import { Route, Routes } from 'react-router-dom'
import { RoutesNames } from './constants'
import Pocetna from './pages/Pocetna'
import ArtikliPregled from './pages/artikli/ArtikliPregled'
import ArtikliDodaj from './pages/artikli/ArtikliDodaj'
import ArtikliPromjena from './pages/artikli/ArtikliPromjena'
import { Container } from 'react-bootstrap'
import DobavljaciPregled from './pages/dobavljaci/DobavljaciPregled'
import DobavljaciDodaj from './pages/dobavljaci/DobavljaciDodaj'
import DobavljaciPromjena from './pages/dobavljaci/DobavljaciPromjena'
import NabavePregled from './pages/nabave/NabavePregled'
import NabaveDodaj from './pages/nabave/NabaveDodaj'
import NabavePromjena from './pages/nabave/NabavePromjena'

import LoadingSpinner from './components/LoadingSpinner'
import ErrorModal from './components/ErrorModal';
import useError from "./hooks/useError"
import Login from "./pages/Login"
import useAuth from "./hooks/useAuth"


function App() {

  const { errors, prikaziErrorModal, sakrijError } = useError();
  const { isLoggedIn } = useAuth();

  function godina(){
    const pocenta = 2024;
    const trenutna = new Date().getFullYear();
    if(pocenta===trenutna){
      return trenutna;
    }
    return pocenta + ' - ' + trenutna;
  }

  return (
    <>
      <LoadingSpinner />
      <ErrorModal show={prikaziErrorModal} errors={errors} onHide={sakrijError} />
      <Container className='visina'>
        <NavBarKafic />
        <Routes>
          <Route path={RoutesNames.HOME} element={<Pocetna />} />
          {isLoggedIn ? (
          <>

          <Route path={RoutesNames.ARTIKL_PREGLED} element={<ArtikliPregled />} />
          <Route path={RoutesNames.ARTIKL_NOVI} element={<ArtikliDodaj />} />
          <Route path={RoutesNames.ARTIKL_PROMJENA} element={<ArtikliPromjena />} />

          <Route path={RoutesNames.DOBAVLJAC_PREGLED} element={<DobavljaciPregled />} />
          <Route path={RoutesNames.DOBAVLJAC_NOVI} element={<DobavljaciDodaj />} />
          <Route path={RoutesNames.DOBAVLJAC_PROMJENA} element={<DobavljaciPromjena />} />

          <Route path={RoutesNames.NABAVA_PREGLED} element={<NabavePregled />} />
          <Route path={RoutesNames.NABAVA_NOVI} element={<NabaveDodaj />} />
          <Route path={RoutesNames.NABAVA_PROMJENA} element={<NabavePromjena />} />
          </>
          ) : (
          <>
            <Route path={RoutesNames.LOGIN} element={<Login />} />
          </>
          )}
        </Routes>
        <div className='footer'>
          <h2>Kafic APP v.1.0.1   &copy; All rights reserved {godina()}</h2>
        </div>
      </Container>
    </>
  )
}

export default App
