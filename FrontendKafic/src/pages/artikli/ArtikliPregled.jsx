import { Button, Table } from "react-bootstrap";
import ArtiklService from "../../services/ArtiklService";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";

import useLoading from "../../hooks/useLoading";


export default function ArtikliPregled(){

    const[artikli,setArtikli] = useState();

    const navigate = useNavigate();

    const { showLoading, hideLoading } = useLoading();

    async function dohvatiArtikle() {
        showLoading();
        await ArtiklService.get()
        .then((odgovor)=>{
            setArtikli(odgovor);
        })
        .catch((e)=>console.log(e));
        hideLoading();
    }

    useEffect(()=>{
        dohvatiArtikle();
    },[]);

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

    return(
        <>
            <div className="UnosDiv">
            <Link className="artiklDodaj" to={RoutesNames.ARTIKL_NOVI} >Unos novog artikla  +</Link>
            </div>
            <div className="PregledDiv">
            <Table className="table2" striped bordered hover responsive>
                <thead className="naslovAPP">
                    <tr>
                        <th>Naziv Artikla</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody className="bodyAPP">
                    {artikli && artikli.map((artikl,index)=>(
                        <tr key={index}>
                            <td>{artikl.nazivArtikla}</td>
                            <td>
                                <Button
                                variant="primary"
                                onClick={()=>navigate(`/artikli/${artikl.sifra}`)}>
                                    Promjeni
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                variant="danger"
                                onClick={()=>obrisi(artikl.sifra)}>
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