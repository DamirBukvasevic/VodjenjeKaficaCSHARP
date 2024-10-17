import { useEffect } from "react";
import { useState } from "react";
import { Button, Form, Pagination, Table } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import { RoutesNames } from "../../constants";
import moment from "moment";
import Service from "../../services/NabavaService";

import useLoading from "../../hooks/useLoading";
import NabavaService from "../../services/NabavaService";


export default function NabavePregled(){

    const [nabave,setNabave] = useState();
    const [stranica, setStranica] = useState(1);
    const [uvjet, setUvjet] = useState('');
    
    let navigate = useNavigate();

    const { showLoading, hideLoading } = useLoading();

    async function dohvatiNabave(){
        showLoading();
        const odgovor = await NabavaService.getStranicenje(stranica,uvjet);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            
            return;
        }
        if(odgovor.poruka.length==0){
            setStranica(stranica-1);
            return;
        }
        setNabave(odgovor.poruka);
        hideLoading();
    }

    useEffect(()=>{
        dohvatiNabave();
    },[stranica, uvjet]);

    async function obrisiNabavu(sifra) {
        showLoading();
        const odgovor = await Service.obrisi(sifra);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiNabave();
    }

    function promjeniUvjet(e) {
        if(e.nativeEvent.key == "Enter"){
            console.log('Enter')
            setStranica(1);
            setUvjet(e.nativeEvent.srcElement.value);
            setNabave([]);
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

    function formatirajDatum(datum){
        if(datum==null){
            return 'Nije definirano';
        }
        return moment.utc(datum).format('DD. MM. YYYY.'); 
    }


    return (
        <>
        <div className='backgroundDiv'>
            <div className="UnosDivTrazilica">
                <Form.Control
                type='text'
                name='trazilica'
                placeholder='Unesite broj nabave, datum ili naziv dobavljača [Enter]'
                maxLength={255}
                defaultValue=''
                onKeyUp={promjeniUvjet}
                />
            </div>
            <div className="UnosDiv">
                {nabave && nabave.length > 0 && (
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
            <div className="UnosDivUnosNabave">
                <Link className="nabavaDodaj" to={RoutesNames.NABAVA_NOVI}>Unos nove nabave +</Link>
            </div>
            <div className="PregledDiv">
            <Table className="table2" striped bordered hover responsive>
                <thead className="naslovAPP">
                    <tr>
                        <th>Broj nabave</th>
                        <th>Datum nabave</th>
                        <th>Dobavljač</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody className="bodyAPP">
                    {Array.isArray(nabave) && nabave.map((n)=>(
                        <tr key={n.sifraNabave}>
                            <td>{n.brojNabave}</td>
                            <td>{formatirajDatum(n.datumNabave)}</td>
                            <td>{n.dobavljacNaziv}</td>
                            <td>
                                <Button
                                variant="primary" className="gumbPromjeniNabaveUnos"
                                onClick={()=>{navigate(`/nabave/${n.sifra}`)}}>
                                    Promjeni / Unos stavki 
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                variant="danger" className="gumbObrisiNabave"
                                onClick={()=>obrisiNabavu(n.sifra)}>
                                    Obriši
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            </div>
        </div>
        </>

    );

}