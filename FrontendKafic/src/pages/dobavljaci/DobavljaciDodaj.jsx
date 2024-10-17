import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import DobavljacServices from "../../services/DobavljacService";

import useLoading from "../../hooks/useLoading";


export default function DobavljaciDodaj(){

    const navigate = useNavigate();

    const { showLoading, hideLoading } = useLoading();

    async function dodaj(dobavljac){
        showLoading();
        const odgovor = await DobavljacServices.dodaj(dobavljac);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka)
            return;
        }
        navigate(RoutesNames.DOBAVLJAC_PREGLED);
    }

    function obradiSubmit(e){
        e.preventDefault();

        const podaci = new FormData(e.target);

        dodaj({
            naziv: podaci.get('naziv'),
            grad: podaci.get('grad'),
            adresa: podaci.get('adresa'),
            oib: podaci.get('oib')
        });
    }

    return(
        <>
        <div className='backgroundDiv'>
            <hr />
                Unos novog Dobavljača
            <hr />
            <Form onSubmit={obradiSubmit}>
                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control type="text" name="naziv" required />
                </Form.Group>
            <hr />    
                <Form.Group controlId="grad">
                    <Form.Label>Grad</Form.Label>
                    <Form.Control type="text" name="grad" required />
                </Form.Group>
            <hr />
                <Form.Group controlId="adresa">
                    <Form.Label>Adresa</Form.Label>
                    <Form.Control type="text" name="adresa" required />
                </Form.Group>
            <hr />
                <Form.Group controlId="oib">
                    <Form.Label>OIB</Form.Label>
                    <Form.Control type="text" name="oib" required />
                </Form.Group>
            <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                    <Link to={RoutesNames.DOBAVLJAC_PREGLED}
                        className="btn btn-danger sirokoOdustani">
                        Odustani
                    </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="sirokoPromjeniDodaj">
                        Dodaj novog dobavljača
                    </Button>
                    </Col>
                </Row>
            </Form>
            <hr />
        </div>
        </>
    )
}