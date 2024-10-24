import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RoutesNames } from "../../constants";
import ArtiklService from "../../services/ArtiklService";
import { useEffect, useState } from "react";

import useLoading from "../../hooks/useLoading";


export default function ArtikliPromjena(){

    const navigate = useNavigate();
    const routeParams = useParams();
    const [artikl,setArtikl] = useState({});

    const { showLoading, hideLoading } = useLoading();

    async function dohvatiArtikl(){
        showLoading();
        const odgovor = await ArtiklService.getBySifra(routeParams.sifra);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        setArtikl(odgovor.poruka);
    }

    useEffect(()=>{
        dohvatiArtikl();
    },[]);

    async function promjena(artikl){
        showLoading();
        const odgovor = await ArtiklService.promjena(routeParams.sifra,artikl);
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

        promjena({
            nazivArtikla: podaci.get('naziv')
        });
    }

    return(
        <>
            <div className='backgroundDiv'>
                <hr />
                    Promjena artikla
                <hr />
                <Form onSubmit={obradiSubmit}>
                    <Form.Group controlId="naziv">
                        <Form.Label>Naziv</Form.Label>
                        <Form.Control type="text" name="naziv" required defaultValue={artikl.nazivArtikla} />
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
                            Promjeni artikl
                        </Button>
                        </Col>
                    </Row>
                </Form>
                <hr />
            </div>
        </>
    )
}