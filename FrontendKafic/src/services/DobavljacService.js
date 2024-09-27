import { HttpService } from "./HttpService"


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
    .catch(()=>{
        return {greska: true, poruka: 'Dobavljac ne postoji!'}
    })
}

async function obrisi(sifra) {
    return await HttpService.delete('/Dobavljac/' + sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data.poruka}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Dobavljac se ne može obrisati!'}
    })
}

async function dodaj(dobavljac) {
    return await HttpService.post('/Dobavljac/' ,dobavljac)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        switch (e.status) 
        {
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors)
                {
                    poruke+= kljuc +': ' + e.response.data.errors[kljuc] [0] + '\n';
                }
                return {greska: true, poruka: poruke}
                default:
                return {greska: true, poruka: 'Dobavljač se ne može dodati!'}
        }
    })
}

async function promjena(sifra,dobavljac) {
    return await HttpService.put('/Dobavljac/' + sifra,dobavljac)
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
                return {greska: true, poruka: 'Dobavljač se ne može promjeniti!'}
        }
    })
}

export default{
    get,
    getBySifra,
    obrisi,
    dodaj,
    promjena
}