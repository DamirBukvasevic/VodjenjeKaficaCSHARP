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
        <Navbar.Brand href="#home">Kafic 1.0.0 APP</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link onClick={()=>navigate(RoutesNames.HOME)}>Početna</Nav.Link>
            <Nav.Link href="#link">Swagger</Nav.Link>
            <NavDropdown title="Izbornik" id="basic-nav-dropdown">
              <NavDropdown.Item onClick={()=>navigate(RoutesNames.DOBAVLJAC_PREGLED)}>Dobavljaci</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item onClick={()=>navigate(RoutesNames.ARTIKL_PREGLED)}>Artikli</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.3">Nabave</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">Stavke</NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
    );
}