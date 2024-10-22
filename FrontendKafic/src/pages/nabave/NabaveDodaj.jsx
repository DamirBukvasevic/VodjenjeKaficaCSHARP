import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import DobavljacService from "../../services/DobavljacService";
import Service from '../../services/NabavaService';
import { RoutesNames } from "../../constants";
import moment from "moment";
import { Button, Col, Form, Row } from "react-bootstrap";

import useLoading from "../../hooks/useLoading";

import pocetnaSlika from "../../assets/slike/banner-bg.png";

export default function NabaveDodaj(){
    const navigate =useNavigate();
    const { showLoading, hideLoading } = useLoading();

    const [dobavljaci, setDobavljaci] = useState([]);
    const [dobavljacSifra, setDobavljacSifra] = useState(0);

    async function dohvatiDobavljace(){
        showLoading();
        const odgovor = await DobavljacService.get();
        setDobavljaci(odgovor);
        setDobavljacSifra(odgovor[0].sifra);
        hideLoading();
    }

    useEffect(()=>{
        dohvatiDobavljace();
    },[]);

    async function dodaj(e) {
        showLoading();
        const odgovor = await Service.dodaj(e);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        navigate(RoutesNames.NABAVA_PREGLED);
    }

    function obradiSubmit(e){
        e.preventDefault();

        const podaci = new FormData(e.target);

        dodaj({
            brojNabave: podaci.get('brojNabave'),
            datumNabave: moment.utc(podaci.get('datumNabave')),
            dobavljacSifra: parseInt(dobavljacSifra)
        });
    }

    return (
        <>
        <div className='backgroundDiv'>
        <img className="pocetnaSlika2" src={pocetnaSlika} alt="pocetna" />
            <hr />
                Unos nove Nabave
            <hr />
            <Form onSubmit={obradiSubmit}>
                    <Form.Group controlId="brojNabave">
                        <Form.Label>Broj nabave</Form.Label>
                        <Form.Control type="number" name="brojNabave" min={1} max={1000} required/>
                    </Form.Group>
                <hr />
                    <Form.Group controlId="datumNabave">
                        <Form.Label>Datum nabave</Form.Label>
                        <Form.Control type="date" name="datumNabave" required/>
                    </Form.Group>
                <hr />
                    <Form.Group controlId="dobavljac">
                        <Form.Label>Dobavljač</Form.Label>
                        <Form.Select
                        onChange={(e)=>{setDobavljacSifra(e.target.value)}}
                        >
                        {dobavljaci && dobavljaci.map((d,index)=>(
                            <option key={index} value={d.sifra}>
                                {d.naziv}
                            </option>
                        ))}
                        </Form.Select>
                    </Form.Group>
                <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                    <Link to={RoutesNames.NABAVA_PREGLED}
                            className="btn btn-danger sirokoOdustani">
                            Odustani
                    </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="sirokoPromjeniDodaj">
                        Dodaj novu nabavu
                    </Button>
                    </Col>
                </Row>
                <hr />
            </Form>
        </div>
        </>
    );

}