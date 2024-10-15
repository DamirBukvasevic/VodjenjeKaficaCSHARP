import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { APP_URL, RoutesNames } from '../constants';
import { useNavigate } from 'react-router-dom';

import useAuth from '../hooks/useAuth';

export default function NavBarKafic(){

    const navigate = useNavigate();
    const { logout, isLoggedIn } = useAuth();
    
    function OpenSwaggerURL(){
      window.open(APP_URL + "/swagger/index.html", "_blank")
    }

    return(
    <div id="navbarSticky">
      <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
          <Navbar.Brand href="/">Kafic APP</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link onClick={()=>navigate(RoutesNames.HOME)}>Početna</Nav.Link>
              <Nav.Link onClick={()=>OpenSwaggerURL()}>Swagger</Nav.Link>
            {isLoggedIn ? (
              <>
              <Nav.Link onClick={()=>navigate(RoutesNames.DOBAVLJAC_PREGLED)}>Dobavljači</Nav.Link>
              <Nav.Link onClick={()=>navigate(RoutesNames.ARTIKL_PREGLED)}>Artikli</Nav.Link>
              <Nav.Link onClick={()=>navigate(RoutesNames.NABAVA_PREGLED)}>Nabave</Nav.Link>
              <Nav.Link onClick={logout}>Odjava</Nav.Link>
              </>
            ) : (
              <Nav.Link onClick={() => navigate(RoutesNames.LOGIN)}>
                Prijava
              </Nav.Link>
                )}
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </div>
    );
}