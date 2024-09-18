import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import NavBarKafic from './components/NavBarKafic'
import { Route, Routes } from 'react-router-dom'
import { RoutesNames } from './constants'
import Pocetna from './pages/Pocetna'
import ArtikliPregled from './pages/artikli/ArtikliPregled'
import DobavljaciPregled from './pages/dobavljaci/DobavljaciPregled'
import ArtikliDodaj from './pages/artikli/ArtikliDodaj'
import ArtikliPromjena from './pages/artikli/ArtikliPromjena'

function App() {

  return (
    <>
      <NavBarKafic />
      <Routes>
        <Route path={RoutesNames.HOME} element={<Pocetna />} />
        <Route path={RoutesNames.ARTIKL_PREGLED} element={<ArtikliPregled />} />
        <Route path={RoutesNames.ARTIKL_NOVI} element={<ArtikliDodaj />} />
        <Route path={RoutesNames.ARTIKL_PROMJENA} element={<ArtikliPromjena />} />
        <Route path={RoutesNames.DOBAVLJAC_PREGLED} element={<DobavljaciPregled />} />
      </Routes>
    </>
  )
}

export default App
