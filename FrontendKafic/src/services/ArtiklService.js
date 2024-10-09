import { HttpService } from "./HttpService"


async function get(){
    return await HttpService.get('/Artikl')
    .then((odgovor)=>{
        return odgovor.data;
    })
    .catch((e)=>{console.error(e)})
}

async function getBySifra(sifra){
    return await HttpService.get('/Artikl/' + sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Artikl ne postoji!'}
    })
}

async function obrisi(sifra) {
    return await HttpService.delete('/Artikl/' + sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data.poruka}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Artikl se ne može obrisati!'}
    })
}

async function dodaj(artikl) {
    return await HttpService.post('/Artikl/' ,artikl)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        switch (e.status) 
        {
            case 400:{
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke+= kljuc +': ' + e.response.data.errors[kljuc] [0] + '\n';
                }
                return {greska: true, poruka: poruke}
            }
            default:
                return {greska: true, poruka: 'Artikl se ne može dodati!'}
        }
    })
}

async function promjena(sifra,artikl) {
    return await HttpService.put('/Artikl/' + sifra,artikl)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        switch (e.status) 
        {
            case 400:{
                let poruke='';
                for(const kljuc in e.response.data.errors)
                {
                    poruke+= kljuc +': ' + e.response.data.errors[kljuc] [0] + '\n';
                }
                return {greska: true, poruka: poruke}
                }
                default:
                return {greska: true, poruka: 'Artikl se ne može promjeniti!'}
        }
    })
}

async function traziArtikl(uvjet){
    return await HttpService.get('/Artikl/trazi/'+uvjet)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{return {greska: true, poruka: 'Problem kod traženja artikla'}})
}

export default{
    get,
    getBySifra,
    obrisi,
    dodaj,
    promjena,

    traziArtikl
}