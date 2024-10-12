import { Button, Pagination, Table, Form } from "react-bootstrap";
import ArtiklService from "../../services/ArtiklService";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import useLoading from "../../hooks/useLoading";


export default function ArtikliPregled(){

    const[artikli,setArtikli] = useState();
    const [stranica, setStranica] = useState(1);
    const [uvjet, setUvjet] = useState('');

    const navigate = useNavigate();

    const { showLoading, hideLoading } = useLoading();

    async function dohvatiArtikle() {
        showLoading();
        const odgovor = await ArtiklService.getStranicenje(stranica,uvjet);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            
            return;
        }
        if(odgovor.poruka.length==0){
            setStranica(stranica-1);
            return;
        }
        setArtikli(odgovor.poruka);
        hideLoading();
    }

    useEffect(()=>{
        dohvatiArtikle();
    },[stranica, uvjet]);

    async function obrisiAsync(sifra) {
        showLoading();
        const odgovor = await ArtiklService.obrisi(sifra);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiArtikle();
    }

    function obrisi(sifra){
        obrisiAsync(sifra);
    }

    function promjeniUvjet(e) {
        if(e.nativeEvent.key == "Enter"){
            console.log('Enter')
            setStranica(1);
            setUvjet(e.nativeEvent.srcElement.value);
            setArtikli([]);
        }
    }

    function povecajStranicu() {
        setStranica(stranica + 1);
      }
    
      function smanjiStranicu() {
        if(stranica==1){
            return;
        }
        setStranica(stranica - 1);
      }

    return(
        <>
            <div className="UnosDivTrazilica">
                <Form.Control
                type='text'
                name='trazilica'
                placeholder='Dio naziva artikla [Enter]'
                maxLength={255}
                defaultValue=''
                onKeyUp={promjeniUvjet}
                />
            </div>
            <div className="UnosDiv">
                {artikli && artikli.length > 0 && (
                    <div style={{ display: "flex", justifyContent: "center" }}>
                        <Pagination size="md">
                        <Pagination.Prev onClick={smanjiStranicu} />
                        <Pagination.Item disabled>{stranica}</Pagination.Item> 
                        <Pagination.Next
                            onClick={povecajStranicu}
                        />
                    </Pagination>
                    </div>
                )}
            </div>
            <div className="UnosDivUnosArtikla">
                <Link className="artiklDodaj" to={RoutesNames.ARTIKL_NOVI} >Unos novog artikla  +</Link>
            </div>
            <div className="PregledDiv">
            <Table className="table2" striped bordered hover responsive>
                <thead className="naslovAPP">
                    <tr>
                        <th className="tablicaArtikli">Naziv Artikla</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody className="bodyAPP">
                    {Array.isArray(artikli) && artikli.map((a) => (
                        <tr key={a.sifra}>
                            <td>{a.nazivArtikla}</td>
                            <td>
                                <Button variant="primary" onClick={() => navigate(`/artikli/${a.sifra}`)}>
                                    Promjeni
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button variant="danger" onClick={() => obrisi(a.sifra)}>
                                    Obriši
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            </div>
        </>
    )
}