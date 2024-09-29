import { useEffect } from "react";
import { useState } from "react";
import { Button, Table } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import { RoutesNames } from "../../constants";
import moment from "moment";
import Service from "../../services/NabavaService";

export default function NabavePregled(){

    const [nabave,setNabave] = useState();
    let navigate = useNavigate();

    async function dohvatiNabave(){
        await Service.get()
        .then((odgovor)=>{
            setNabave(odgovor);
        })
        .catch((e)=>{console.log(e)});
    }

    async function obrisiNabavu(sifra) {
        const odgovor = await Service.obrisi(sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiNabave();
    }

    useEffect(()=>{
        dohvatiNabave();
    },[]);

    function formatirajDatum(datum){
        if(datum==null){
            return 'Nije definirano';
        }
        return moment.utc(datum).format('DD. MM. YYYY.'); 
    }


    return (

        <>
            <Link className="nabavaDodaj" to={RoutesNames.NABAVA_NOVI}>Unos nove nabave +</Link>
            <Table striped bordered hover responsive>
                <thead className="naslovAPP">
                    <tr>
                        <th>Broj nabave</th>
                        <th>Datum nabave</th>
                        <th>Dobavljač</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody className="bodyAPP">
                    {nabave && nabave.map((entitet,index)=>(
                        <tr key={index}>
                            <td>{entitet.brojNabave}</td>
                            <td>{formatirajDatum(entitet.datumNabave)}</td>
                            <td>{entitet.dobavljacNaziv}</td>
                            <td>
                                <Button
                                variant="primary"
                                onClick={()=>{navigate(`/nabave/${entitet.sifra}`)}}>
                                    Promjeni
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                variant="danger"
                                onClick={()=>obrisiNabavu(entitet.sifra)}>
                                    Obriši
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </>

    );

}