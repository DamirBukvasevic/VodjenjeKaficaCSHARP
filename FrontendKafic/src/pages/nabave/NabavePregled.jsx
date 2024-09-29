import { useEffect } from "react";
import { useState } from "react";
import { Container, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import moment from "moment";



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
                    </tr>
                </thead>
            </Table>
        </>

    );

}