import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RoutesNames } from "../../constants";
import DobavljacService from "../../services/DobavljacService";
import { useEffect, useState } from "react";

import useLoading from "../../hooks/useLoading";


export default function DobavljaciPromjena(){

    const navigate = useNavigate();
    const routeParams = useParams();
    const [dobavljac,setDobavljac] = useState({});

    const { showLoading, hideLoading } = useLoading();

    async function dohvatiDobavljaca(){
        showLoading();
        const odgovor = await DobavljacService.getBySifra(routeParams.sifra);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        setDobavljac(odgovor.poruka);
    }

    useEffect(()=>{
        dohvatiDobavljaca();
    },[]);

    async function promjena(dobavljac){
        showLoading();
        const odgovor = await DobavljacService.promjena(routeParams.sifra,dobavljac);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        navigate(RoutesNames.DOBAVLJAC_PREGLED);
    }

    function obradiSubmit(e){
        e.preventDefault();

        const podaci = new FormData(e.target);

        promjena({
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
                Promjena podataka dobavljača
            <hr />
            <Form onSubmit={obradiSubmit}>
                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control type="text" name="naziv" required defaultValue={dobavljac.naziv} />
                </Form.Group>
                <hr />    
                <Form.Group controlId="grad">
                    <Form.Label>Grad</Form.Label>
                    <Form.Control type="text" name="grad" required defaultValue={dobavljac.grad} />
                </Form.Group>
                <hr />
                <Form.Group controlId="adresa">
                    <Form.Label>Adresa</Form.Label>
                    <Form.Control type="text" name="adresa" required defaultValue={dobavljac.adresa} />
                </Form.Group>
                <hr />
                <Form.Group controlId="oib">
                    <Form.Label>OIB</Form.Label>
                    <Form.Control type="text" name="oib" required defaultValue={dobavljac.oib} />
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
                        Promjeni podatke dobavljača
                    </Button>
                    </Col>
                </Row>
            </Form>
            <hr />
        </div>
        </>
    )
}