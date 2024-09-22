import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import ArtiklService from "../../services/ArtiklService";


export default function ArtikliDodaj(){

    const navigate = useNavigate();

    async function dodaj(artikl){
        const odgovor = await ArtiklService.dodaj(artikl);
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
            <hr />
                Unos novog artikla
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
                        className="btn btn-danger siroko">
                        Odustani
                    </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="siroko">
                        Dodaj novi artikl
                    </Button>
                    </Col>
                </Row>
            </Form>
            <hr />
        </>
    )
}