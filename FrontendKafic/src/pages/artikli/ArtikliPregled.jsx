import { Container, Table } from "react-bootstrap";
import ArtiklService from "../../services/ArtiklService";
import { useEffect, useState } from "react";


export default function ArtikliPregled(){

    const[artikli,setArtikli] = useState();

    async function dohvatiArtikle() {
        await ArtiklService.get()
        .then((odgovor)=>{
            setArtikli(odgovor);
        })
        .catch((e)=>console.error(e));
    }

    useEffect(()=>{
        dohvatiArtikle();
    },[]);

    return(
        <Container>
            <Table striped bordered hover responsive>
                <thead class="naslovAPP">
                    <tr>
                        <th>Naziv Artikla</th>
                        <th>Šifra</th>
                    </tr>
                </thead>
                <tbody class="bodyAPP">
                    {artikli && artikli.map((artikl,index)=>(
                        <tr key={index}>
                            <td>{artikl.nazivArtikla}</td>
                            <td>{artikl.sifra}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    )
}