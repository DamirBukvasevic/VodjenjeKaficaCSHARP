import { useEffect, useState } from "react";
import { Button, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import { FaEdit, FaTrash } from "react-icons/fa";
import Service from "../../services/StavkaService";


export default function StavkePregled(){
    const [stavke,setStavke] = useState();
    let navigate = useNavigate();

    async function dohvatiStavke(){
        await StavkeService.get()
        .then((odgovor)=>{
            setStavke(odgovor);
        })
        .catch((e)=>{console.log(e)});
    }

    async function obrisiStavku(sifra) {
        const odgovor = await Service.obrisi(sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiStavke();
    }

    useEffect(()=>{
        dohvatiStavke();
    },[]);

    return (
        <>
            <div className="UnosDiv">
            <Link className="stavkaDodaj" to={RoutesNames.STAVKA_NOVI}>Unos nove stavke +</Link>
            </div>
            <div className="PregledDiv">
            <Table striped bordered hover responsive>
                <thead className="naslovAPP">
                    <tr>
                        <th>Broj nabave</th>
                        <th>Naziv artikla</th>
                        <th>Količina</th>
                        <th>Cijena</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody className="bodyAPP">
                    {stavke && stavke.map((stavka,index)=>(
                        <tr key={index}>
                            <td>{stavka.brojNabave}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            </div>
        </>
    );
}