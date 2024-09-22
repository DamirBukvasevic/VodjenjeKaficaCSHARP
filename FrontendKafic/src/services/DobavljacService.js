import { HttpService } from "./HttpService";


async function get(){
    return await HttpService.get('/Dobavljac')
    .then((odgovor)=>{
        return odgovor.data;
    })
    .catch((e)=>{console.error(e)})
}

async function getBySifra(sifra){
    return await HttpService.get('/Dobavljac/' + sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Dobavljac ne postoji!'}
    })
}

async function obrisi(sifra) {
    return await HttpService.delete('/Dobavljac/' + sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data.poruka}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Dobavljac se ne može obrisati!'}
    })
}

async function dodaj(dobavljac) {
    return await HttpService.post('/Dobavljac/' ,dobavljac)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Dobavljac se ne može dodati!'}
    })
}

async function promjena(sifra,dobavljac) {
    return await HttpService.put('/Dobavljac/' + sifra,dobavljac)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Dobavljac se ne može promjeniti!'}
    })
}

export default{
    get,
    getBySifra,
    obrisi,
    dodaj,
    promjena
}