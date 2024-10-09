import { Button, Table } from "react-bootstrap";
import DobavljacService from "../../services/DobavljacService";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";

import useLoading from "../../hooks/useLoading";


export default function DobavljaciPregled(){

    const[dobavljaci,setDobavljaci] = useState();

    const navigate = useNavigate();

    const { showLoading, hideLoading } = useLoading();

    async function dohvatiDobavljace() {
        showLoading();
        await DobavljacService.get()
        .then((odgovor)=>{
            setDobavljaci(odgovor);
        })
        .catch((e)=>console.error(e));
        hideLoading();
    }

    useEffect(()=>{
        dohvatiDobavljace();
    },[]);

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

    return(
        <>
            <div className="UnosDiv">
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
                    {dobavljaci && dobavljaci.map((dobavljac,index)=>(
                        <tr key={index}>
                            <td>{dobavljac.naziv}</td>
                            <td>{dobavljac.grad}</td>
                            <td>{dobavljac.adresa}</td>
                            <td>{dobavljac.oib}</td>
                            <td>
                                <Button
                                variant="primary"
                                onClick={()=>navigate(`/dobavljaci/${dobavljac.sifra}`)}>
                                    Promjeni
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                variant="danger"
                                onClick={()=>obrisi(dobavljac.sifra)}>
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