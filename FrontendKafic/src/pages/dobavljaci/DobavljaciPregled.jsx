import { Container, Table } from "react-bootstrap";
import DobavljaciServices from "../../services/DobavljaciServices";
import { useEffect, useState } from "react";


export default function DobavljaciPregled(){

    const[dobavljaci,setDobavljaci] = useState();

    async function dohvatiDobavljace() {
        await DobavljaciServices.get()
        .then((odgovor)=>{
            setDobavljaci(odgovor);
        })
        .catch((e)=>console.error(e));
    }

    useEffect(()=>{
        dohvatiDobavljace();
    },[]);

    return(
        <Container>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Naziv</th>
                        <th>Grad</th>
                        <th>Adresa</th>
                        <th>Oib</th>
                        <th>Šifra</th>
                    </tr>
                </thead>
                <tbody>
                    {dobavljaci && dobavljaci.map((dobavljac,index)=>(
                        <tr key={index}>
                            <td>{dobavljac.naziv}</td>
                            <td>{dobavljac.grad}</td>
                            <td>{dobavljac.adresa}</td>
                            <td>{dobavljac.oib}</td>
                            <td>{dobavljac.sifra}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    )
}