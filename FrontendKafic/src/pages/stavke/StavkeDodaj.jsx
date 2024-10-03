import { useEffect, useState } from "react";
import Service from '../../services/StavkaService';
import { Link, useNavigate } from "react-router-dom";
import NabavaService from "../../services/NabavaService";
import ArtiklService from "../../services/ArtiklService";
import { RoutesNames } from "../../constants";
import {Button, Col, Form, Row } from "react-bootstrap";
import StavkaService from "../../services/StavkaService";


export default function StavkeDodaj() {
    const navigate = useNavigate();

    const [nabave, setNabave] = useState([]);
    const [nabavaSifra, setNabavaSifra] = useState(0);

    const [artikli, setArtikli] = useState([]);
    const [artiklSifra, setArtiklSifra] = useState(0);

    async function dohvatiNabave(){
        const odgovor = await NabavaService.get();
        setNabave(odgovor);
        setNabavaSifra(odgovor[0].sifra);
    }

    async function dohvatiArtikle(){
        const odgovor = await ArtiklService.get();
        setArtikli(odgovor);
        setArtiklSifra(odgovor[0].sifra);
    }

    useEffect(()=>{
        dohvatiNabave();
        dohvatiArtikle();
    },[]);

    async function dodaj(e) {
        const odgovor = await Service.dodaj(e);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
          }
          navigate(RoutesNames.STAVKA_PREGLED);
    }

    function obradiSubmit(e) {
        e.preventDefault();
    
        const podaci = new FormData(e.target);

        dodaj({
            nabavaSifra: parseInt(nabavaSifra),
            artiklSifra: parseInt(artiklSifra),
            kolicina: podaci.get('kolicina'),
            cijena: parseFloat(podaci.get('cijena'))
        });
    }

    return (
        <>
            <hr />
                Unos nove Stavke
            <hr />
            <Form onSubmit={obradiSubmit}>
                <Form.Group controlId="nabavaSifra">
                    <Form.Label>Broj nabave</Form.Label>
                    <Form.Select
                        onChange={(e)=>{setNabavaSifra(e.target.value)}}
                        >
                        {nabave && nabave.map((n,index)=>(
                        <option key={index} value={n.sifraNabave}>
                        {n.brojNabave}
                        </option>
                    ))}
                    </Form.Select>
                </Form.Group>
            <hr />
                <Form.Group controlId="artiklSifra">
                    <Form.Label>Naziv artikla</Form.Label>
                    <Form.Select
                        onChange={(e)=>{setArtiklSifra(e.target.value)}}
                        >
                        {artikli && artikli.map((a,index)=>(
                        <option key={index} value={a.sifraArtikla}>
                        {a.nazivArtikla}
                        </option>
                    ))}
                    </Form.Select>
                </Form.Group>
            <hr />
                <Form.Group controlId="kolicina">
                <Form.Label>Količina</Form.Label>
                <Form.Control type="number" min={1} max={1000} required />
                </Form.Group>
            <hr />
                <Form.Group controlId="cijena">
                    <Form.Label>Cijena</Form.Label>
                    <Form.Control type="number" name="cijena" step={0.01}/>
                </Form.Group>
            <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                    <Link to={RoutesNames.STAVKA_PREGLED}
                        className="btn btn-danger siroko">
                        Odustani
                    </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="siroko">
                        Dodaj novu stavku
                    </Button>
                    </Col>
                </Row>
            </Form>
            <hr />
        </>
    );

}