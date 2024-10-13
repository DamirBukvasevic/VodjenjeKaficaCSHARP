import { Button, Form, Pagination, Table } from "react-bootstrap";
import DobavljacService from "../../services/DobavljacService";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";

import useLoading from "../../hooks/useLoading";


export default function DobavljaciPregled(){

    const[dobavljaci,setDobavljaci] = useState();
    const [stranica, setStranica] = useState(1);
    const [uvjet, setUvjet] = useState('');

    const navigate = useNavigate();

    const { showLoading, hideLoading } = useLoading();

    async function dohvatiDobavljace() {
        showLoading();
        const odgovor = await DobavljacService.getStranicenje(stranica,uvjet);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            
            return;
        }
        if(odgovor.poruka.length==0){
            setStranica(stranica-1);
            return;
        }
        setDobavljaci(odgovor.poruka);
        hideLoading();
    }

    useEffect(()=>{
        dohvatiDobavljace();
    },[stranica, uvjet]);

    async function obrisiAsync(sifra) {
        showLoading();
        const odgovor = await DobavljacService.obrisi(sifra);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiDobavljace();
    }

    function obrisi(sifra){
        obrisiAsync(sifra);
    }

    function promjeniUvjet(e) {
        if(e.nativeEvent.key == "Enter"){
            console.log('Enter')
            setStranica(1);
            setUvjet(e.nativeEvent.srcElement.value);
            setDobavljaci([]);
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
                placeholder='Dio naziva dobavljaca [Enter]'
                maxLength={255}
                defaultValue=''
                onKeyUp={promjeniUvjet}
                />
            </div>
            <div className="UnosDiv">
                {dobavljaci && dobavljaci.length > 0 && (
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
            <div className="UnosDivUnosDobavljaca">
                <Link className="dobavljacDodaj" to={RoutesNames.DOBAVLJAC_NOVI}>Unos novog dobavljaca +</Link>
            </div>
            <div className="PregledDiv">
            <Table className="table2" striped bordered hover responsive>
                <thead className="naslovAPP">
                    <tr>
                        <th>Naziv dobavljača</th>
                        <th>Grad</th>
                        <th>Adresa</th>
                        <th>OIB</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody className="bodyAPP">
                    {Array.isArray(dobavljaci) && dobavljaci.map((d)=>(
                        <tr key={d.sifra}>
                            <td>{d.naziv}</td>
                            <td>{d.grad}</td>
                            <td>{d.adresa}</td>
                            <td>{d.oib}</td>
                            <td>
                                <Button
                                variant="primary"
                                onClick={()=>navigate(`/dobavljaci/${d.sifra}`)}>
                                    Promjeni
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                variant="danger"
                                onClick={()=>obrisi(d.sifra)}>
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