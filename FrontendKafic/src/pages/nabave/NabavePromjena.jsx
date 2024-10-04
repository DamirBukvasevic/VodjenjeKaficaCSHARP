import { Link, useNavigate, useParams } from "react-router-dom";
import Service from '../../services/NabavaService';
import DobavljacService from "../../services/DobavljacService";
import { useEffect, useState } from "react";
import { RoutesNames } from "../../constants";
import moment from "moment";
import { Button, Col, Form, Row } from "react-bootstrap";
import ArtiklService from "../../services/ArtiklService";


export default function NabavePromjena(){
    const navigate = useNavigate();
    const routeParams = useParams();

    const [dobavljaci, setDobavljaci] = useState([]);
    const [dobavljacSifra, setDobavljacSifra] = useState(0);
    const [artikli, setArtikli] = useState([]);
    const [pronadeniArtikli, setPronadeniArtikli] = useState([]);

    const [nabava, setNabava] = useState({});

    async function dohvatiDobavljace(){
        const odgovor = await DobavljacService.get();
        setDobavljaci(odgovor);
    }

    async function dohvatiNabava(){
        const odgovor = await Service.getBySifra(routeParams.sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        let nabava = odgovor.poruka;
        setNabava(nabava);
        setDobavljacSifra(nabava.dobavljacSifra);
    }

    async function dohvatiArtikli(){
        const odgovor = await Service.getArtikli(routeParams.sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        setArtikli(odgovor.poruka);
    }

    async function traziArtikl(uvjet) {
        const odgovor = await ArtiklService.traziArtikl(uvjet);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        setPronadeniArtikli(odgovor.poruka);
    }

    async function dodajArtikle(e) {
        const odgovor = await Service.dodajArtikl(routeParams.sifra, e[0].sifra);
        if(odgovor.greska){
            alert(odgovor.podaci);
            return;
        }
        await dohvatiArtikli();
    }

    async function obrisiArtikl(artikl) {
        const odgovor = await Service.obrisiArtikl(routeParams.sifra, artikl);
        if(odgovor.greska){
            alert(odgovor.podaci);
            return;
        }
        await dohvatiArtikli();
    }

    async function dohvatiInicijalnePodatke(){
        await dohvatiDobavljace();
        await dohvatiNabava();
        await dohvatiArtikli();
    }

    useEffect(()=>{
        dohvatiInicijalnePodatke();
    },[]);

    async function promjena(e){
        const odgovor = await Service.promjena(routeParams.sifra,e);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        navigate(RoutesNames.NABAVA_PREGLED);
    }

    function obradiSubmit(e){
        e.preventDefault();

        const podaci = new FormData(e.target);

        promjena({
            brojNabave: podaci.get('brojNabave'),
            datumNabave: moment.utc(podaci.get('datumNabave')),
            dobavljacSifra: parseInt(dobavljacSifra)
        });
    }

    return(
        <>
            <hr />
            Promjena podataka nabave
            <hr />
            <Form onSubmit={obradiSubmit}>
                <Form.Group controlId="brojNabave">
                    <Form.Label>Broj nabave</Form.Label>
                    <Form.Control type="number" name="brojNabave" min={1} max={1000} required defaultValue={nabava.brojNabave}/>
                </Form.Group>
                <hr />
                <Form.Group controlId="datumNabave">
                    <Form.Label>Datum nabave</Form.Label>
                    <Form.Control type="date" name="datumNabave" defaultValue={nabava.datumNabave}/>
                </Form.Group>
                <hr />
                <Form.Group controlId="dobavljac">
                    <Form.Label>Dobavljač</Form.Label>
                    <Form.Select
                    value={dobavljacSifra}
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
                        className="btn btn-danger siroko">
                        Odustani
                    </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="siroko">
                        Promjeni podatke nabave
                    </Button>
                    </Col>
                </Row>
            </Form>
        </>
    );
}