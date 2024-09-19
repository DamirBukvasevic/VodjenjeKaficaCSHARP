import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { RoutesNames } from '../constants';
import { useNavigate } from 'react-router-dom';

export default function NavBarKafic(){

    const navigate = useNavigate();

    return(
    <Navbar expand="lg" className="bg-body-tertiary">
      <Container>
        <Navbar.Brand href="/">Kafic APP</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link onClick={()=>navigate(RoutesNames.HOME)}>Početna</Nav.Link>
            <Nav.Link onClick={()=>navigate(RoutesNames.DOBAVLJAC_PREGLED)}>Dobavljaci</Nav.Link>
            <Nav.Link onClick={()=>navigate(RoutesNames.ARTIKL_PREGLED)}>Artikli</Nav.Link>
            <Nav.Link href="https://damirbukva-001-site1.gtempurl.com/swagger/index.html" target="_blank">Swagger</Nav.Link> 
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
    );
}