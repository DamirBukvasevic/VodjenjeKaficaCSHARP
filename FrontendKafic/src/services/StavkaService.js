import { HttpService } from "./HttpService"

async function get(){
    return await HttpService.get('/Stavka')
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return odgovor.data;
    })
    .catch((e)=>{console.error(e)})
}

async function obrisi(sifra) {
    return await HttpService.delete('/Stavka/' + sifra)
    .then((odgovor)=>{
        //console.log(odgovor);
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Stavka se ne može obrisati!'}
    })
}

async function dodaj(Stavka) {
    return await HttpService.post('/Stavka',Stavka)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        switch (e.status) {
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke += kljuc + ': ' + e.response.data.errors[kljuc][0] + '\n';
                }
                return {greska: true, poruka: poruke}
            default:
                return {greska: true, poruka: 'Stavka se ne može dodati!'}
        }
    })
}

async function promjena(sifra,Stavka) {
    return await HttpService.put('/Stavka/' + sifra,Stavka)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        switch (e.status) {
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke += kljuc + ': ' + e.response.data.errors[kljuc][0] + '\n';
                }
                console.log(poruke)
                return {greska: true, poruka: poruke}
            default:
                return {greska: true, poruka: 'Stavka se ne može promjeniti!'}
        }
    })
}

async function getNabave(sifraNabave){
    return await HttpService.get('/Stavka/Nabave/'+ sifraNabave)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{return {greska: true, poruka: 'Problem kod dohvaćanja nabave'}})
}

async function dodajNabavu(stavka,nabava) {
    return await HttpService.post('/Stavka/' + stavka + '/dodaj/'+nabava)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
                return {greska: true, poruka: 'Nabava se ne može dodati u stavku'}
    })
}

async function obrisiNabavu(stavka,nabava) {
    return await HttpService.delete('/Stavka/' + stavka + '/obrisi/'+nabava)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
                return {greska: true, poruka: 'Nabava se ne može obrisati iz stavke'}
    })
}

async function getArtikli(sifraArtikla){
    return await HttpService.get('/Stavka/Artikli/'+ sifraArtikla)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{return {greska: true, poruka: 'Problem kod dohvaćanja artikla'}})
}

async function dodajArtikl(stavka,artikl) {
    return await HttpService.post('/Stavka/' + stavka + '/dodaj/'+artikl)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
                return {greska: true, poruka: 'Artikl se ne može dodati u stavku'}
    })
}

async function obrisiArtikl(stavka,artikl) {
    return await HttpService.delete('/Stavka/' + stavka + '/obrisi/'+artikl)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
                return {greska: true, poruka: 'Artikl se ne može obrisati iz stavke'}
    })
}

export default{
    get,
    obrisi,
    dodaj,
    promjena,

    getNabave,
    dodajNabavu,
    obrisiNabavu,

    getArtikli,
    dodajArtikl,
    obrisiArtikl
}