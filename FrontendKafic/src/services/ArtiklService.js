import { HttpService } from "./HttpService";


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
    .catch((e)=>{
        return {greska: true, poruka: 'Artikl ne postoji!'}
    })
}

async function obrisi(sifra) {
    return await HttpService.delete('/Artikl/' + sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data.poruka}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Artikl se ne može obrisati!'}
    })
}

async function dodaj(artikl) {
    return await HttpService.post('/Artikl/' ,artikl)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Artikl se ne može dodati!'}
    })
}

async function promjena(sifra,artikl) {
    return await HttpService.put('/Artikl/' + sifra,artikl)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Artikl se ne može promjeniti!'}
    })
}

export default{
    get,
    getBySifra,
    obrisi,
    dodaj,
    promjena
}