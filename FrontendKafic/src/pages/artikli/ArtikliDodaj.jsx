import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import ArtiklService from "../../services/ArtiklService";

import useLoading from "../../hooks/useLoading";


export default function ArtikliDodaj(){

    const navigate = useNavigate();
    
    const { showLoading, hideLoading } = useLoading();

    async function dodaj(artikl){
        showLoading();
        const odgovor = await ArtiklService.dodaj(artikl);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        navigate(RoutesNames.ARTIKL_PREGLED);
    }

    function obradiSubmit(e){
        e.preventDefault();

        const podaci = new FormData(e.target);

        dodaj({
            nazivArtikla: podaci.get('naziv')
        });
    }

    return(
        <>
        <div className='backgroundDiv'>
            <hr />
                Unos novog Artikla
            <hr />
            <Form onSubmit={obradiSubmit}>
                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control type="text" name="naziv" required />
                </Form.Group>
            <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                    <Link to={RoutesNames.ARTIKL_PREGLED}
                        className="btn btn-danger sirokoOdustani">
                        Odustani
                    </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="sirokoPromjeniDodaj">
                        Dodaj novi artikl
                    </Button>
                    </Col>
                </Row>
            </Form>
            <hr />
        </div>
        </>
    )
}