import { HttpService } from "./HttpService"


async function get(){
    return await HttpService.get('/Nabava')
    .then((odgovor)=>{
        return odgovor.data;
    })
    .catch((e)=>{console.error(e)})
}

async function getBySifra(sifra){
    return await HttpService.get('/Nabava/' + sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Nabava ne postoji!'}
    })
}

async function obrisi(sifra) {
    return await HttpService.delete('/Nabava/' + sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data.poruka}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Nabava se ne može obrisati!'}
    })
}

async function dodaj(nabava) {
    return await HttpService.post('/Nabava/',nabava)
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
                    poruke += kljuc + ': ' + e.response.data.errors[kljuc][0] + '\n';
                }
                return {greska: true, poruka: poruke}
                }
            default:
                return {greska: true, poruka: 'Nabava se ne može dodati!'}
        }
    })
}

async function promjena(sifra,nabava) {
    return await HttpService.put('/Nabava/' + sifra,nabava)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        switch (e.status) {
            case 400:{
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke += kljuc + ': ' + e.response.data.errors[kljuc][0] + '\n';
                }
                return {greska: true, poruka: poruke}
                }
            default:
                return {greska: true, poruka: 'Nabava se ne može promjeniti!'}
        }
    })
}

async function getArtikli(sifra){
    return await HttpService.get('/Nabava/Stavke/'+ sifra)
    .then((odgovor)=>{
        console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{return {greska: true, poruka: 'Problem kod dohvaćanja artikla'}})
}

async function dodajStavku(stavka) {
    return await HttpService.post('/Nabava/dodajStavku/',stavka)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
                return {greska: true, poruka: 'Artikl se ne može dodati u nabavu'}
    })
}

async function obrisiStavku(sifra) {
    return await HttpService.delete('/Nabava/obrisiStavka/'+sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Artikl se ne može obrisati iz nabave'}
    })
}

async function traziNabavu(uvjet){
    return await HttpService.get('/Nabava/trazi/'+uvjet)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{return {greska: true, poruka: 'Problem kod traženje nabave'}})
}

async function getStranicenje(stranica,uvjet){
    return await HttpService.get('/Nabava/traziStranicenje/'+stranica + '?uvjet=' + uvjet)
    .then((odgovor)=>{return  {greska: false, poruka: odgovor.data};})
    .catch((e)=>{ return {greska: true, poruka: 'Problem kod traženje nabave'}});
  }

export default{
    get,
    getBySifra,
    obrisi,
    dodaj,
    promjena,

    getArtikli,
    dodajStavku,
    obrisiStavku,

    traziNabavu,
    getStranicenje
}