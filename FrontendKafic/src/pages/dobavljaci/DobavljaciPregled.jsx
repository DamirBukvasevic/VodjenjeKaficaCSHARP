import { Button, Table } from "react-bootstrap";
import DobavljacService from "../../services/DobavljacService";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";


export default function DobavljaciPregled(){

    const[dobavljaci,setDobavljaci] = useState();

    const navigate = useNavigate();

    async function dohvatiDobavljace() {
        await DobavljacService.get()
        .then((odgovor)=>{
            setDobavljaci(odgovor);
        })
        .catch((e)=>console.error(e));
    }

    useEffect(()=>{
        dohvatiDobavljace();
    },[]);

    async function obrisiAsync(sifra) {
        const odgovor = await DobavljacService.obrisi(sifra);
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
            <Link className="dobavljacDodaj" to={RoutesNames.DOBAVLJAC_NOVI}>Unos novog dobavljaca +</Link>
            <Table striped bordered hover responsive>
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
                                onClick={()=>navigate(`/dobavljac/${dobavljac.sifra}`)}>
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
        </>
    )
}