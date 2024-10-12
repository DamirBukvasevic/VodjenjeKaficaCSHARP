import { Link, useNavigate, useParams } from "react-router-dom";
import Service from '../../services/NabavaService';
import DobavljacService from "../../services/DobavljacService";
import { useEffect, useRef, useState } from "react";
import { RoutesNames } from "../../constants";
import moment from "moment";
import { Button, Col, Form, Row, Table } from "react-bootstrap";
import { AsyncTypeahead } from "react-bootstrap-typeahead";
import ArtiklService from "../../services/ArtiklService";

import useLoading from "../../hooks/useLoading";


export default function NabavePromjena(){
    const navigate = useNavigate();
    const routeParams = useParams();

    const { showLoading, hideLoading } = useLoading();

    const [dobavljaci, setDobavljaci] = useState([]);
    const [dobavljacSifra, setDobavljacSifra] = useState(0);
    const [stavke, setStavke] = useState([]);
    const [pronadeniArtikli, setPronadeniArtikli] = useState([]);
    const [odabraniArtikl,setOdabraniArtikl] = useState({});

    const [nabava, setNabava] = useState({});

    const typeaheadRef = useRef(null);
    const cijenaRef = useRef(null);
    const kolicinaRef = useRef(null);

    const [ukupno, setUkupno] = useState(0);

    function idiNaUnosArtikla() {
        navigate(RoutesNames.ARTIKL_NOVI);
    }

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
        odgovor.poruka.datumNabave = moment.utc(odgovor.poruka.datumNabave).format('yyyy-MM-DD');
        setNabava(nabava);
        setDobavljacSifra(nabava.dobavljacSifra);
    }

    async function dohvatiArtikli(){
        const odgovor = await Service.getArtikli(routeParams.sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        setStavke(odgovor.poruka);
    }

    async function traziArtikl(uvjet) {
        const odgovor = await ArtiklService.traziArtikl(uvjet);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        if (odgovor.poruka.length === 0) {
            const potvrda = window.confirm("Artikl ne postoji. Želite li dodati novi artikl?");
            if (potvrda) {
                idiNaUnosArtikla();
            }
        } else {
            setPronadeniArtikli(odgovor.poruka);
        }
    }

    async function dodajStavku(stavka) {
        showLoading();
        const odgovor = await Service.dodajStavku(stavka);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        await dohvatiArtikli();
        typeaheadRef.current.clear();
        hideLoading();
    }

    async function obrisiStavku(stavka) {
        showLoading();
        const odgovor = await Service.obrisiStavku(stavka);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.podaci);
            return;
        }
        await dohvatiArtikli();
    }

    async function dohvatiInicijalnePodatke(){
        showLoading();
        await dohvatiDobavljace();
        await dohvatiNabava();
        await dohvatiArtikli();
        hideLoading();
    }

    useEffect(()=>{
        dohvatiInicijalnePodatke();
    },[]);

    useEffect(() => {
        const novaUkupna = stavke.reduce((acc, artikl) => acc + (artikl.kolicinaArtikla * artikl.cijena), 0);
        setUkupno(novaUkupna);
    }, [stavke]);

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
            dobavljacSifra: parseInt(dobavljacSifra),
        });
    }

    function obradiSubmit2(e){
        e.preventDefault();

        const podaci = new FormData(e.target);
        console.log(odabraniArtikl);
        dodajStavku({
            sifraNabave: routeParams.sifra,
            sifraArtikla: odabraniArtikl.sifra,
            kolicinaArtikla: podaci.get('kolicinaArtikla'),
            cijena: parseFloat(podaci.get('cijena')),
        });

        kolicinaRef.current.value='';
        cijenaRef.current.value='';

        typeaheadRef.current.clear();
        typeaheadRef.current.focus();
    }

    return(
        <>
            <div className="Col-6-lijevo">
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
            </div>
            <div className="Col-6-lijevo">
                Unos stavki nabave
                <hr />
                <Form onSubmit={obradiSubmit2}>
                <Form.Group controlId="uvjet">
                    <Form.Label>Pretraga artikala</Form.Label>
                    <AsyncTypeahead
                    className='autocomplete'
                    id='uvjet'
                    emptyLabel='Nema rezultata'
                    searchText='Tražim...'
                    labelKey={(artikl) => `${artikl.nazivArtikla}`}
                    minLength={3}
                    options={pronadeniArtikli}
                    onSearch={traziArtikl}
                    placeholder='Upiši dio naziva artikla'
                    renderMenuItemChildren={(artikl) => (
                        <>
                        <span>
                            {artikl.nazivArtikla}
                        </span>
                        </>
                    )}
                    onChange={(e)=>setOdabraniArtikl(e[0])}
                    onKeyDown={(e) => {
                        if (e.key === 'Enter') {
                            e.preventDefault();
                            kolicinaRef.current.focus();
                        }
                    }}
                    ref={typeaheadRef}
                    />
                </Form.Group>
                <hr />
                <Form.Group controlId="kolocinaArtikla">
                    <Form.Label>Količina artikla</Form.Label>
                    <Form.Control type="number" name="kolicinaArtikla" min={1} max={1000} ref={kolicinaRef}
                    required defaultValue={nabava.kolicinaArtikla} placeholder='Min 1 , Max 1000'/>
                </Form.Group>
                <hr />
                <Form.Group controlId="cijena">
                    <Form.Label>Cijena artikla po kom</Form.Label>
                    <Form.Control type="number" name="cijena" step={0.01} ref={cijenaRef}
                    required defaultValue={nabava.cijena} placeholder='0.00'/>
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
                        Dodaj stavku nabave
                    </Button>
                    </Col>
                </Row>
                </Form>
            </div>
            <div className="Col-12-stavke">
                <Table className="table2" striped bordered hover>
                    <thead className="stavka">
                        <tr>
                            <th>Artikli u nabavi</th>
                            <th>Količina</th>
                            <th>Cijena kom</th>
                            <th>Ukupno</th>
                            <th>Akcija</th>
                        </tr>
                    </thead>
                    <tbody className="stavka">
                        {stavke && stavke.map((artikl, index) => (
                            <tr key={index}>
                                <td>
                                    {artikl.artiklaNaziv}
                                </td>
                                <td>
                                    {artikl.kolicinaArtikla}
                                    &nbsp;&nbsp;&nbsp;Kom
                                </td>
                                <td>
                                    {artikl.cijena}
                                    &nbsp;&nbsp;&nbsp;€
                                </td>
                                <td>
                                    {(artikl.kolicinaArtikla * artikl.cijena).toFixed(2)} &nbsp;&nbsp;&nbsp;€
                                </td>
                                <td>
                                    <Button className="siroko" variant="danger" onClick={() =>
                                        obrisiStavku(artikl.sifra)
                                    }>
                                        Obriši
                                    </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
                <h4 className="ukupno">Total: {ukupno.toFixed(2)} €</h4>
            </div>
        </>
    );
}