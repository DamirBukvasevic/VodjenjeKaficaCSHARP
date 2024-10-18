<a name='assembly'></a>
# VodjenjeKaficaCSHARP

## Contents

- [Artikl](#T-VodjenjeKaficaCSHARP-Models-Artikl 'VodjenjeKaficaCSHARP.Models.Artikl')
  - [NazivArtikla](#P-VodjenjeKaficaCSHARP-Models-Artikl-NazivArtikla 'VodjenjeKaficaCSHARP.Models.Artikl.NazivArtikla')
  - [Stavke](#P-VodjenjeKaficaCSHARP-Models-Artikl-Stavke 'VodjenjeKaficaCSHARP.Models.Artikl.Stavke')
- [ArtiklController](#T-VodjenjeKaficaCSHARP-Controllers-ArtiklController 'VodjenjeKaficaCSHARP.Controllers.ArtiklController')
  - [#ctor(context,mapper)](#M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext,AutoMapper-IMapper- 'VodjenjeKaficaCSHARP.Controllers.ArtiklController.#ctor(VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext,AutoMapper.IMapper)')
  - [Delete(Sifra)](#M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-Delete-System-Int32- 'VodjenjeKaficaCSHARP.Controllers.ArtiklController.Delete(System.Int32)')
  - [Get()](#M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-Get 'VodjenjeKaficaCSHARP.Controllers.ArtiklController.Get')
  - [GetBySifra(Sifra)](#M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-GetBySifra-System-Int32- 'VodjenjeKaficaCSHARP.Controllers.ArtiklController.GetBySifra(System.Int32)')
  - [Post(dto)](#M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-Post-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate- 'VodjenjeKaficaCSHARP.Controllers.ArtiklController.Post(VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate)')
  - [Put(Sifra,dto)](#M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-Put-System-Int32,VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate- 'VodjenjeKaficaCSHARP.Controllers.ArtiklController.Put(System.Int32,VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate)')
  - [TraziArtikl(uvjet)](#M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-TraziArtikl-System-String- 'VodjenjeKaficaCSHARP.Controllers.ArtiklController.TraziArtikl(System.String)')
  - [TraziArtiklStranicenje(stranica,uvjet)](#M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-TraziArtiklStranicenje-System-Int32,System-String- 'VodjenjeKaficaCSHARP.Controllers.ArtiklController.TraziArtiklStranicenje(System.Int32,System.String)')
- [ArtiklDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate')
  - [#ctor(NazivArtikla)](#M-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate-#ctor-System-String- 'VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate.#ctor(System.String)')
  - [NazivArtikla](#P-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate-NazivArtikla 'VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate.NazivArtikla')
- [ArtiklDTORead](#T-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTORead 'VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTORead')
  - [#ctor(Sifra,NazivArtikla)](#M-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTORead-#ctor-System-Int32,System-String- 'VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTORead.#ctor(System.Int32,System.String)')
  - [NazivArtikla](#P-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTORead-NazivArtikla 'VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTORead.NazivArtikla')
  - [Sifra](#P-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTORead-Sifra 'VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTORead.Sifra')
- [AutorizacijaController](#T-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController 'VodjenjeKaficaCSHARP.Controllers.AutorizacijaController')
  - [#ctor(context)](#M-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext- 'VodjenjeKaficaCSHARP.Controllers.AutorizacijaController.#ctor(VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext)')
  - [GenerirajToken(operater)](#M-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController-GenerirajToken-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO- 'VodjenjeKaficaCSHARP.Controllers.AutorizacijaController.GenerirajToken(VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO)')
- [Dobavljac](#T-VodjenjeKaficaCSHARP-Models-Dobavljac 'VodjenjeKaficaCSHARP.Models.Dobavljac')
  - [Adresa](#P-VodjenjeKaficaCSHARP-Models-Dobavljac-Adresa 'VodjenjeKaficaCSHARP.Models.Dobavljac.Adresa')
  - [Grad](#P-VodjenjeKaficaCSHARP-Models-Dobavljac-Grad 'VodjenjeKaficaCSHARP.Models.Dobavljac.Grad')
  - [Naziv](#P-VodjenjeKaficaCSHARP-Models-Dobavljac-Naziv 'VodjenjeKaficaCSHARP.Models.Dobavljac.Naziv')
  - [Oib](#P-VodjenjeKaficaCSHARP-Models-Dobavljac-Oib 'VodjenjeKaficaCSHARP.Models.Dobavljac.Oib')
- [DobavljacController](#T-VodjenjeKaficaCSHARP-Controllers-DobavljacController 'VodjenjeKaficaCSHARP.Controllers.DobavljacController')
  - [#ctor(context,mapper)](#M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext,AutoMapper-IMapper- 'VodjenjeKaficaCSHARP.Controllers.DobavljacController.#ctor(VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext,AutoMapper.IMapper)')
  - [Delete(Sifra)](#M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-Delete-System-Int32- 'VodjenjeKaficaCSHARP.Controllers.DobavljacController.Delete(System.Int32)')
  - [Get()](#M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-Get 'VodjenjeKaficaCSHARP.Controllers.DobavljacController.Get')
  - [GetBySifra(Sifra)](#M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-GetBySifra-System-Int32- 'VodjenjeKaficaCSHARP.Controllers.DobavljacController.GetBySifra(System.Int32)')
  - [Post(dto)](#M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-Post-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate- 'VodjenjeKaficaCSHARP.Controllers.DobavljacController.Post(VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate)')
  - [Put(Sifra,dto)](#M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-Put-System-Int32,VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate- 'VodjenjeKaficaCSHARP.Controllers.DobavljacController.Put(System.Int32,VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate)')
  - [TraziDobavljacStranicenje(stranica,uvjet)](#M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-TraziDobavljacStranicenje-System-Int32,System-String- 'VodjenjeKaficaCSHARP.Controllers.DobavljacController.TraziDobavljacStranicenje(System.Int32,System.String)')
  - [TraziDobavljaca(uvjet)](#M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-TraziDobavljaca-System-String- 'VodjenjeKaficaCSHARP.Controllers.DobavljacController.TraziDobavljaca(System.String)')
- [DobavljacDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate')
  - [#ctor(Naziv,Grad,Adresa,Oib)](#M-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-#ctor-System-String,System-String,System-String,System-String- 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate.#ctor(System.String,System.String,System.String,System.String)')
  - [Adresa](#P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-Adresa 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate.Adresa')
  - [Grad](#P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-Grad 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate.Grad')
  - [Naziv](#P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-Naziv 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate.Naziv')
  - [Oib](#P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-Oib 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate.Oib')
- [DobavljacDTORead](#T-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTORead')
  - [#ctor(Sifra,Naziv,Grad,Adresa,Oib)](#M-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-#ctor-System-Int32,System-String,System-String,System-String,System-String- 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTORead.#ctor(System.Int32,System.String,System.String,System.String,System.String)')
  - [Adresa](#P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Adresa 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTORead.Adresa')
  - [Grad](#P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Grad 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTORead.Grad')
  - [Naziv](#P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Naziv 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTORead.Naziv')
  - [Oib](#P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Oib 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTORead.Oib')
  - [Sifra](#P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Sifra 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTORead.Sifra')
- [Entitet](#T-VodjenjeKaficaCSHARP-Models-Entitet 'VodjenjeKaficaCSHARP.Models.Entitet')
  - [Sifra](#P-VodjenjeKaficaCSHARP-Models-Entitet-Sifra 'VodjenjeKaficaCSHARP.Models.Entitet.Sifra')
- [Nabava](#T-VodjenjeKaficaCSHARP-Models-Nabava 'VodjenjeKaficaCSHARP.Models.Nabava')
  - [BrojNabave](#P-VodjenjeKaficaCSHARP-Models-Nabava-BrojNabave 'VodjenjeKaficaCSHARP.Models.Nabava.BrojNabave')
  - [DatumNabave](#P-VodjenjeKaficaCSHARP-Models-Nabava-DatumNabave 'VodjenjeKaficaCSHARP.Models.Nabava.DatumNabave')
  - [Dobavljac](#P-VodjenjeKaficaCSHARP-Models-Nabava-Dobavljac 'VodjenjeKaficaCSHARP.Models.Nabava.Dobavljac')
  - [Stavke](#P-VodjenjeKaficaCSHARP-Models-Nabava-Stavke 'VodjenjeKaficaCSHARP.Models.Nabava.Stavke')
- [NabavaController](#T-VodjenjeKaficaCSHARP-Controllers-NabavaController 'VodjenjeKaficaCSHARP.Controllers.NabavaController')
  - [#ctor(context,mapper)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext,AutoMapper-IMapper- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.#ctor(VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext,AutoMapper.IMapper)')
  - [Delete(sifra)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-Delete-System-Int32- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.Delete(System.Int32)')
  - [DodajStavku(dto)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-DodajStavku-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.DodajStavku(VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate)')
  - [Get()](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-Get 'VodjenjeKaficaCSHARP.Controllers.NabavaController.Get')
  - [GetBySifra(sifra)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-GetBySifra-System-Int32- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.GetBySifra(System.Int32)')
  - [ObrisiStavka(sifra)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-ObrisiStavka-System-Int32- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.ObrisiStavka(System.Int32)')
  - [Post(dto)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-Post-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.Post(VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate)')
  - [Put(sifra,dto)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-Put-System-Int32,VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.Put(System.Int32,VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate)')
  - [TraziNabavu(uvjet)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-TraziNabavu-System-String- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.TraziNabavu(System.String)')
  - [TraziNabavuStranicenje(stranica,uvjet)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-TraziNabavuStranicenje-System-Int32,System-String- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.TraziNabavuStranicenje(System.Int32,System.String)')
  - [getArtikli(sifraNabave)](#M-VodjenjeKaficaCSHARP-Controllers-NabavaController-getArtikli-System-Int32- 'VodjenjeKaficaCSHARP.Controllers.NabavaController.getArtikli(System.Int32)')
- [NabavaDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate')
  - [#ctor(BrojNabave,DatumNabave,DobavljacSifra)](#M-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-#ctor-System-Nullable{System-Int32},System-Nullable{System-DateTime},System-Nullable{System-Int32}- 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate.#ctor(System.Nullable{System.Int32},System.Nullable{System.DateTime},System.Nullable{System.Int32})')
  - [BrojNabave](#P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-BrojNabave 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate.BrojNabave')
  - [DatumNabave](#P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-DatumNabave 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate.DatumNabave')
  - [DobavljacSifra](#P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-DobavljacSifra 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate.DobavljacSifra')
- [NabavaDTORead](#T-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTORead')
  - [#ctor(Sifra,BrojNabave,DatumNabave,DobavljacNaziv)](#M-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-#ctor-System-Int32,System-Nullable{System-Int32},System-Nullable{System-DateTime},System-String- 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTORead.#ctor(System.Int32,System.Nullable{System.Int32},System.Nullable{System.DateTime},System.String)')
  - [BrojNabave](#P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-BrojNabave 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTORead.BrojNabave')
  - [DatumNabave](#P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-DatumNabave 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTORead.DatumNabave')
  - [DobavljacNaziv](#P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-DobavljacNaziv 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTORead.DobavljacNaziv')
  - [Sifra](#P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-Sifra 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTORead.Sifra')
- [OibValidator](#T-VodjenjeKaficaCSHARP-Validations-OibValidator 'VodjenjeKaficaCSHARP.Validations.OibValidator')
  - [IsValid(value,validationContext)](#M-VodjenjeKaficaCSHARP-Validations-OibValidator-IsValid-System-Object,System-ComponentModel-DataAnnotations-ValidationContext- 'VodjenjeKaficaCSHARP.Validations.OibValidator.IsValid(System.Object,System.ComponentModel.DataAnnotations.ValidationContext)')
  - [IsValidOIB(oib)](#M-VodjenjeKaficaCSHARP-Validations-OibValidator-IsValidOIB-System-String- 'VodjenjeKaficaCSHARP.Validations.OibValidator.IsValidOIB(System.String)')
- [Operater](#T-VodjenjeKaficaCSHARP-Models-Operater 'VodjenjeKaficaCSHARP.Models.Operater')
  - [Email](#P-VodjenjeKaficaCSHARP-Models-Operater-Email 'VodjenjeKaficaCSHARP.Models.Operater.Email')
  - [Lozinka](#P-VodjenjeKaficaCSHARP-Models-Operater-Lozinka 'VodjenjeKaficaCSHARP.Models.Operater.Lozinka')
- [OperaterDTO](#T-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO 'VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO')
  - [#ctor(email,password)](#M-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO-#ctor-System-String,System-String- 'VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO.#ctor(System.String,System.String)')
  - [email](#P-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO-email 'VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO.email')
  - [password](#P-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO-password 'VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO.password')
- [Stavka](#T-VodjenjeKaficaCSHARP-Models-Stavka 'VodjenjeKaficaCSHARP.Models.Stavka')
  - [Artikl](#P-VodjenjeKaficaCSHARP-Models-Stavka-Artikl 'VodjenjeKaficaCSHARP.Models.Stavka.Artikl')
  - [Cijena](#P-VodjenjeKaficaCSHARP-Models-Stavka-Cijena 'VodjenjeKaficaCSHARP.Models.Stavka.Cijena')
  - [KolicinaArtikla](#P-VodjenjeKaficaCSHARP-Models-Stavka-KolicinaArtikla 'VodjenjeKaficaCSHARP.Models.Stavka.KolicinaArtikla')
  - [Nabava](#P-VodjenjeKaficaCSHARP-Models-Stavka-Nabava 'VodjenjeKaficaCSHARP.Models.Stavka.Nabava')
- [StavkaDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate')
  - [#ctor(SifraNabave,SifraArtikla,KolicinaArtikla,Cijena)](#M-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-#ctor-System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Decimal}- 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate.#ctor(System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Decimal})')
  - [Cijena](#P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-Cijena 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate.Cijena')
  - [KolicinaArtikla](#P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-KolicinaArtikla 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate.KolicinaArtikla')
  - [SifraArtikla](#P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-SifraArtikla 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate.SifraArtikla')
  - [SifraNabave](#P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-SifraNabave 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate.SifraNabave')
- [StavkaDTORead](#T-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTORead')
  - [#ctor(Sifra,ArtiklaNaziv,KolicinaArtikla,Cijena)](#M-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-#ctor-System-Int32,System-String,System-Nullable{System-Int32},System-Nullable{System-Decimal}- 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTORead.#ctor(System.Int32,System.String,System.Nullable{System.Int32},System.Nullable{System.Decimal})')
  - [ArtiklaNaziv](#P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-ArtiklaNaziv 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTORead.ArtiklaNaziv')
  - [Cijena](#P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-Cijena 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTORead.Cijena')
  - [KolicinaArtikla](#P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-KolicinaArtikla 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTORead.KolicinaArtikla')
  - [Sifra](#P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-Sifra 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTORead.Sifra')
- [VodjenjeKaficaContext](#T-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext')
  - [#ctor(opcije)](#M-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-#ctor-Microsoft-EntityFrameworkCore-DbContextOptions{VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext}- 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext.#ctor(Microsoft.EntityFrameworkCore.DbContextOptions{VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext})')
  - [Artikli](#P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Artikli 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext.Artikli')
  - [Dobavljaci](#P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Dobavljaci 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext.Dobavljaci')
  - [Nabave](#P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Nabave 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext.Nabave')
  - [Operateri](#P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Operateri 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext.Operateri')
  - [Stavke](#P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Stavke 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext.Stavke')
  - [OnModelCreating(modelBuilder)](#M-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-OnModelCreating-Microsoft-EntityFrameworkCore-ModelBuilder- 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)')
- [VodjenjeKaficaController](#T-VodjenjeKaficaCSHARP-Controllers-VodjenjeKaficaController 'VodjenjeKaficaCSHARP.Controllers.VodjenjeKaficaController')
  - [#ctor(context,mapper)](#M-VodjenjeKaficaCSHARP-Controllers-VodjenjeKaficaController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext,AutoMapper-IMapper- 'VodjenjeKaficaCSHARP.Controllers.VodjenjeKaficaController.#ctor(VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext,AutoMapper.IMapper)')
  - [_context](#F-VodjenjeKaficaCSHARP-Controllers-VodjenjeKaficaController-_context 'VodjenjeKaficaCSHARP.Controllers.VodjenjeKaficaController._context')
  - [_mapper](#F-VodjenjeKaficaCSHARP-Controllers-VodjenjeKaficaController-_mapper 'VodjenjeKaficaCSHARP.Controllers.VodjenjeKaficaController._mapper')
- [VodjenjeKaficaExtensions](#T-VodjenjeKaficaCSHARP-Extensions-VodjenjeKaficaExtensions 'VodjenjeKaficaCSHARP.Extensions.VodjenjeKaficaExtensions')
  - [AddVodjenjeKaficaCORS(Services)](#M-VodjenjeKaficaCSHARP-Extensions-VodjenjeKaficaExtensions-AddVodjenjeKaficaCORS-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'VodjenjeKaficaCSHARP.Extensions.VodjenjeKaficaExtensions.AddVodjenjeKaficaCORS(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddVodjenjeKaficaCSHARPSwaggerGen(Services)](#M-VodjenjeKaficaCSHARP-Extensions-VodjenjeKaficaExtensions-AddVodjenjeKaficaCSHARPSwaggerGen-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'VodjenjeKaficaCSHARP.Extensions.VodjenjeKaficaExtensions.AddVodjenjeKaficaCSHARPSwaggerGen(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
  - [AddVodjenjeKaficaSecurity(Services)](#M-VodjenjeKaficaCSHARP-Extensions-VodjenjeKaficaExtensions-AddVodjenjeKaficaSecurity-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'VodjenjeKaficaCSHARP.Extensions.VodjenjeKaficaExtensions.AddVodjenjeKaficaSecurity(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
- [VodjenjeKaficaMappingProfile](#T-VodjenjeKaficaCSHARP-Mapping-VodjenjeKaficaMappingProfile 'VodjenjeKaficaCSHARP.Mapping.VodjenjeKaficaMappingProfile')
  - [#ctor()](#M-VodjenjeKaficaCSHARP-Mapping-VodjenjeKaficaMappingProfile-#ctor 'VodjenjeKaficaCSHARP.Mapping.VodjenjeKaficaMappingProfile.#ctor')

<a name='T-VodjenjeKaficaCSHARP-Models-Artikl'></a>
## Artikl `type`

##### Namespace

VodjenjeKaficaCSHARP.Models

##### Summary

Artikl u bazi podataka.

<a name='P-VodjenjeKaficaCSHARP-Models-Artikl-NazivArtikla'></a>
### NazivArtikla `property`

##### Summary

Naziv artikla.

<a name='P-VodjenjeKaficaCSHARP-Models-Artikl-Stavke'></a>
### Stavke `property`

##### Summary

Lista stavki u nabavi.

<a name='T-VodjenjeKaficaCSHARP-Controllers-ArtiklController'></a>
## ArtiklController `type`

##### Namespace

VodjenjeKaficaCSHARP.Controllers

##### Summary

Kontroler za upravljanjem artiklima.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:VodjenjeKaficaCSHARP.Controllers.ArtiklController](#T-T-VodjenjeKaficaCSHARP-Controllers-ArtiklController 'T:VodjenjeKaficaCSHARP.Controllers.ArtiklController') | Pristup podacima u bazi. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext,AutoMapper-IMapper-'></a>
### #ctor(context,mapper) `constructor`

##### Summary

Kontroler za upravljanjem artiklima.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext](#T-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext') | Pristup podacima u bazi. |
| mapper | [AutoMapper.IMapper](#T-AutoMapper-IMapper 'AutoMapper.IMapper') | Pristup Automaperu. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-Delete-System-Int32-'></a>
### Delete(Sifra) `method`

##### Summary

Briše artikl prema šifri.

##### Returns

HTTP status kod i poruka o uspješnom brisanju.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra artikla. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-Get'></a>
### Get() `method`

##### Summary

Dohvaća sve artikle.

##### Returns

Popis artikala u obliku DTO objekata.

##### Parameters

This method has no parameters.

<a name='M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-GetBySifra-System-Int32-'></a>
### GetBySifra(Sifra) `method`

##### Summary

Dohvaća artikle prema šifri.

##### Returns

Artikl u obliku DTO objekta.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra artikla. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-Post-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate-'></a>
### Post(dto) `method`

##### Summary

Dodaje novi artikla.

##### Returns

HTTP status kod i dodani artikl u obliku DTO objekta.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dto | [VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate') | Podaci o artiklu za unos |

<a name='M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-Put-System-Int32,VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate-'></a>
### Put(Sifra,dto) `method`

##### Summary

Ažurira artikl prema šifri.

##### Returns

HTTP status kod i poruka o uspješnom ažuriranju.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra artikla. |
| dto | [VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate') | Podaci o artiklu za ažuriranje. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-TraziArtikl-System-String-'></a>
### TraziArtikl(uvjet) `method`

##### Summary

Traži artikle prema uvjetu.

##### Returns

Popis artikala koji zadovoljavaju uvjet pretrage u obliku DTO objekata.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| uvjet | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Uvjet pretrage. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-ArtiklController-TraziArtiklStranicenje-System-Int32,System-String-'></a>
### TraziArtiklStranicenje(stranica,uvjet) `method`

##### Summary

Traži artikle s paginacijom.

##### Returns

Popis artikala koji zadovoljavaju uvjet pretrage s paginacijom u obliku DTO objekata.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stranica | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Broj stranice. |
| uvjet | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Uvjet pretrage. |

<a name='T-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate'></a>
## ArtiklDTOInsertUpdate `type`

##### Namespace

VodjenjeKaficaCSHARP.Models.DTO

##### Summary

Klasa koja predstavlja podatke za unos ili ažuriranje artikla.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| NazivArtikla | [T:VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate](#T-T-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate 'T:VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTOInsertUpdate') | Naziv artikla. |

<a name='M-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate-#ctor-System-String-'></a>
### #ctor(NazivArtikla) `constructor`

##### Summary

Klasa koja predstavlja podatke za unos ili ažuriranje artikla.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| NazivArtikla | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv artikla. |

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTOInsertUpdate-NazivArtikla'></a>
### NazivArtikla `property`

##### Summary

Naziv artikla.

<a name='T-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTORead'></a>
## ArtiklDTORead `type`

##### Namespace

VodjenjeKaficaCSHARP.Models.DTO

##### Summary

Klasa koja predstavlja podatke o artiklu za čitanje.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [T:VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTORead](#T-T-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTORead 'T:VodjenjeKaficaCSHARP.Models.DTO.ArtiklDTORead') | Šifra artikla |

<a name='M-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTORead-#ctor-System-Int32,System-String-'></a>
### #ctor(Sifra,NazivArtikla) `constructor`

##### Summary

Klasa koja predstavlja podatke o artiklu za čitanje.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra artikla |
| NazivArtikla | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv artikla |

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTORead-NazivArtikla'></a>
### NazivArtikla `property`

##### Summary

Naziv artikla

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-ArtiklDTORead-Sifra'></a>
### Sifra `property`

##### Summary

Šifra artikla

<a name='T-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController'></a>
## AutorizacijaController `type`

##### Namespace

VodjenjeKaficaCSHARP.Controllers

##### Summary

Controller for handling authorization related actions.

<a name='M-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-'></a>
### #ctor(context) `constructor`

##### Summary

Initializes a new instance of the [AutorizacijaController](#T-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController 'VodjenjeKaficaCSHARP.Controllers.AutorizacijaController') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext](#T-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext') | The database context. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController-GenerirajToken-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO-'></a>
### GenerirajToken(operater) `method`

##### Summary

Generates a JWT token for the given operator.

##### Returns

The generated JWT token.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| operater | [VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO](#T-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO 'VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO') | The operator data transfer object. |

<a name='T-VodjenjeKaficaCSHARP-Models-Dobavljac'></a>
## Dobavljac `type`

##### Namespace

VodjenjeKaficaCSHARP.Models

##### Summary

Dobavljač u bazi podataka.

<a name='P-VodjenjeKaficaCSHARP-Models-Dobavljac-Adresa'></a>
### Adresa `property`

##### Summary

Adresa dobavljača.

<a name='P-VodjenjeKaficaCSHARP-Models-Dobavljac-Grad'></a>
### Grad `property`

##### Summary

Grad dobavljača.

<a name='P-VodjenjeKaficaCSHARP-Models-Dobavljac-Naziv'></a>
### Naziv `property`

##### Summary

Naziv dobavljača.

<a name='P-VodjenjeKaficaCSHARP-Models-Dobavljac-Oib'></a>
### Oib `property`

##### Summary

OIB dobavljača

<a name='T-VodjenjeKaficaCSHARP-Controllers-DobavljacController'></a>
## DobavljacController `type`

##### Namespace

VodjenjeKaficaCSHARP.Controllers

##### Summary

Kontroler za upravljanje dobavljačima

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:VodjenjeKaficaCSHARP.Controllers.DobavljacController](#T-T-VodjenjeKaficaCSHARP-Controllers-DobavljacController 'T:VodjenjeKaficaCSHARP.Controllers.DobavljacController') | Pristup podacima u bazi |

<a name='M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext,AutoMapper-IMapper-'></a>
### #ctor(context,mapper) `constructor`

##### Summary

Kontroler za upravljanje dobavljačima

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext](#T-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext') | Pristup podacima u bazi |
| mapper | [AutoMapper.IMapper](#T-AutoMapper-IMapper 'AutoMapper.IMapper') | Pristup automaperu |

<a name='M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-Delete-System-Int32-'></a>
### Delete(Sifra) `method`

##### Summary

Briše dobavljača prema šifri.

##### Returns

HTTP status kod i poruka o uspješnom brisanju.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra dobavljača. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-Get'></a>
### Get() `method`

##### Summary

Dohvaća sve dobavljače.

##### Returns

Popis dobavljača u obliku DTO objekata

##### Parameters

This method has no parameters.

<a name='M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-GetBySifra-System-Int32-'></a>
### GetBySifra(Sifra) `method`

##### Summary

Dohvaća dobavljače prema šifri.

##### Returns

Dobavljač u obliku DTO objekta

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra dobavljača. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-Post-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-'></a>
### Post(dto) `method`

##### Summary

Dodaje novog dobavljača.

##### Returns

HTTP status kod i dodani dobavljač u obliku DTO objekta.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dto | [VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate') | Podaci o dobavljaču za unos |

<a name='M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-Put-System-Int32,VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-'></a>
### Put(Sifra,dto) `method`

##### Summary

Ažurira dobavljača prema šifri.

##### Returns

HTTP status kod i poruka o uspješnom ažuriranju.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra dobavljača. |
| dto | [VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate') | Podaci o dobavljaču za ažuriranje. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-TraziDobavljacStranicenje-System-Int32,System-String-'></a>
### TraziDobavljacStranicenje(stranica,uvjet) `method`

##### Summary

Traži dobavljače s paginacijom.

##### Returns

Popis dobavljača koji zadovoljavaju uvjet pretrage s paginacijom u obliku DTO objekata.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stranica | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Broj stranice |
| uvjet | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Uvjet pretrage |

<a name='M-VodjenjeKaficaCSHARP-Controllers-DobavljacController-TraziDobavljaca-System-String-'></a>
### TraziDobavljaca(uvjet) `method`

##### Summary

Traži dobavljače prema uvjetu.

##### Returns

Popis dobavljača koji zadovoljavaju uvjet pretrage u obliku DTO objekata.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| uvjet | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Uvjet pretrage. |

<a name='T-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate'></a>
## DobavljacDTOInsertUpdate `type`

##### Namespace

VodjenjeKaficaCSHARP.Models.DTO

##### Summary

Klasa koja predstavlja podatke za unos ili ažuriranje dobavljača.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Naziv | [T:VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate](#T-T-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate 'T:VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTOInsertUpdate') | Naziv dobavljača. |

<a name='M-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-#ctor-System-String,System-String,System-String,System-String-'></a>
### #ctor(Naziv,Grad,Adresa,Oib) `constructor`

##### Summary

Klasa koja predstavlja podatke za unos ili ažuriranje dobavljača.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Naziv | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv dobavljača. |
| Grad | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Grad dobavljača. |
| Adresa | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Adresa dobavljača. |
| Oib | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | OIB dobavljača. |

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-Adresa'></a>
### Adresa `property`

##### Summary

Adresa dobavljača.

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-Grad'></a>
### Grad `property`

##### Summary

Grad dobavljača.

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-Naziv'></a>
### Naziv `property`

##### Summary

Naziv dobavljača.

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTOInsertUpdate-Oib'></a>
### Oib `property`

##### Summary

OIB dobavljača.

<a name='T-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead'></a>
## DobavljacDTORead `type`

##### Namespace

VodjenjeKaficaCSHARP.Models.DTO

##### Summary

Klasa koja predstavlja podatke o dobavljaču za čitanje.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [T:VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTORead](#T-T-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead 'T:VodjenjeKaficaCSHARP.Models.DTO.DobavljacDTORead') | Šifra dobavljača |

<a name='M-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-#ctor-System-Int32,System-String,System-String,System-String,System-String-'></a>
### #ctor(Sifra,Naziv,Grad,Adresa,Oib) `constructor`

##### Summary

Klasa koja predstavlja podatke o dobavljaču za čitanje.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra dobavljača |
| Naziv | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv dobavljača |
| Grad | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Grad dobavljača |
| Adresa | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Adresa dobavljača |
| Oib | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | OIB dobavljača |

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Adresa'></a>
### Adresa `property`

##### Summary

Adresa dobavljača

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Grad'></a>
### Grad `property`

##### Summary

Grad dobavljača

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Naziv'></a>
### Naziv `property`

##### Summary

Naziv dobavljača

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Oib'></a>
### Oib `property`

##### Summary

OIB dobavljača

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-DobavljacDTORead-Sifra'></a>
### Sifra `property`

##### Summary

Šifra dobavljača

<a name='T-VodjenjeKaficaCSHARP-Models-Entitet'></a>
## Entitet `type`

##### Namespace

VodjenjeKaficaCSHARP.Models

##### Summary

Apstraktna klasa koja predstavlja entitet.

<a name='P-VodjenjeKaficaCSHARP-Models-Entitet-Sifra'></a>
### Sifra `property`

##### Summary

Jedinstveni identifikator entiteta.

<a name='T-VodjenjeKaficaCSHARP-Models-Nabava'></a>
## Nabava `type`

##### Namespace

VodjenjeKaficaCSHARP.Models

##### Summary

Model klasa koja predstavlja nabavu.

<a name='P-VodjenjeKaficaCSHARP-Models-Nabava-BrojNabave'></a>
### BrojNabave `property`

##### Summary

Broj nabave.

<a name='P-VodjenjeKaficaCSHARP-Models-Nabava-DatumNabave'></a>
### DatumNabave `property`

##### Summary

Datum nabave.

<a name='P-VodjenjeKaficaCSHARP-Models-Nabava-Dobavljac'></a>
### Dobavljac `property`

##### Summary

Dobavljač kojem nabava pripada.

<a name='P-VodjenjeKaficaCSHARP-Models-Nabava-Stavke'></a>
### Stavke `property`

##### Summary

Lista stavki u nabavi.

<a name='T-VodjenjeKaficaCSHARP-Controllers-NabavaController'></a>
## NabavaController `type`

##### Namespace

VodjenjeKaficaCSHARP.Controllers

##### Summary

Kontroler za upravljanje nabavama.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:VodjenjeKaficaCSHARP.Controllers.NabavaController](#T-T-VodjenjeKaficaCSHARP-Controllers-NabavaController 'T:VodjenjeKaficaCSHARP.Controllers.NabavaController') | Pristup podacima u bazi. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext,AutoMapper-IMapper-'></a>
### #ctor(context,mapper) `constructor`

##### Summary

Kontroler za upravljanje nabavama.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext](#T-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext') | Pristup podacima u bazi. |
| mapper | [AutoMapper.IMapper](#T-AutoMapper-IMapper 'AutoMapper.IMapper') | Pristup Automaperu. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-Delete-System-Int32-'></a>
### Delete(sifra) `method`

##### Summary

Briše nabavu prema šifri.

##### Returns

Poruka o uspješnom brisanju

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra nabave |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-DodajStavku-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-'></a>
### DodajStavku(dto) `method`

##### Summary

Dodaje stavku u nabavu(ArtiklNaziv,količina,cijena).

##### Returns

Poruka o uspješnom dodavanju stavke u nabavu

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dto | [VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate') | Stavka u nabavi(ArtiklNaziv,količina,cijena) |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-Get'></a>
### Get() `method`

##### Summary

Dohvaća sve nabave.

##### Returns

Popis nabava

##### Parameters

This method has no parameters.

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-GetBySifra-System-Int32-'></a>
### GetBySifra(sifra) `method`

##### Summary

Dohvaća nabavu prema šifri.

##### Returns

Nabava

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-ObrisiStavka-System-Int32-'></a>
### ObrisiStavka(sifra) `method`

##### Summary

Briše stavku iz nabave.

##### Returns

HTTP status kod i poruka o uspješnom brisanju.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra stavke u nabavi. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-Post-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-'></a>
### Post(dto) `method`

##### Summary

Dodaje novu nabavu.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dto | [VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate') | Podaci o nabavi |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-Put-System-Int32,VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-'></a>
### Put(sifra,dto) `method`

##### Summary

Ažurira nabavu prema šifri.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra nabave |
| dto | [VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate](#T-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate 'VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate') | Podaci o nabavi |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-TraziNabavu-System-String-'></a>
### TraziNabavu(uvjet) `method`

##### Summary

Dohvaća nabave prema uvjetu.

##### Returns

Popis nabava koji zadovoljavaju uvjet pretrage u obliku DTO objekata.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| uvjet | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Uvjet pretrage. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-TraziNabavuStranicenje-System-Int32,System-String-'></a>
### TraziNabavuStranicenje(stranica,uvjet) `method`

##### Summary

Traži nabave s paginacijom.

##### Returns

Popis nabava koji zadovoljavaju uvjet pretrage s paginacijom u obliku DTO objekata.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stranica | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Broj stranice. |
| uvjet | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Uvjet pretrage. |

<a name='M-VodjenjeKaficaCSHARP-Controllers-NabavaController-getArtikli-System-Int32-'></a>
### getArtikli(sifraNabave) `method`

##### Summary

Dohvaća artikle prema šifri nabave.

##### Returns

Popis artikala

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sifraNabave | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra nabave |

<a name='T-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate'></a>
## NabavaDTOInsertUpdate `type`

##### Namespace

VodjenjeKaficaCSHARP.Models.DTO

##### Summary

Klasa koja predstavlja podatke za unos ili ažuriranje nabave.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| BrojNabave | [T:VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate](#T-T-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate 'T:VodjenjeKaficaCSHARP.Models.DTO.NabavaDTOInsertUpdate') | Broj nabave |

<a name='M-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-#ctor-System-Nullable{System-Int32},System-Nullable{System-DateTime},System-Nullable{System-Int32}-'></a>
### #ctor(BrojNabave,DatumNabave,DobavljacSifra) `constructor`

##### Summary

Klasa koja predstavlja podatke za unos ili ažuriranje nabave.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| BrojNabave | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Broj nabave |
| DatumNabave | [System.Nullable{System.DateTime}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.DateTime}') | Datum nabave |
| DobavljacSifra | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Šifra dobavljača |

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-BrojNabave'></a>
### BrojNabave `property`

##### Summary

Broj nabave

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-DatumNabave'></a>
### DatumNabave `property`

##### Summary

Datum nabave

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTOInsertUpdate-DobavljacSifra'></a>
### DobavljacSifra `property`

##### Summary

Šifra dobavljača

<a name='T-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead'></a>
## NabavaDTORead `type`

##### Namespace

VodjenjeKaficaCSHARP.Models.DTO

##### Summary

DTO klasa koja predstavlja čitanje podataka o nabavi.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [T:VodjenjeKaficaCSHARP.Models.DTO.NabavaDTORead](#T-T-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead 'T:VodjenjeKaficaCSHARP.Models.DTO.NabavaDTORead') | Šifra nabave |

<a name='M-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-#ctor-System-Int32,System-Nullable{System-Int32},System-Nullable{System-DateTime},System-String-'></a>
### #ctor(Sifra,BrojNabave,DatumNabave,DobavljacNaziv) `constructor`

##### Summary

DTO klasa koja predstavlja čitanje podataka o nabavi.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra nabave |
| BrojNabave | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Broj nabave |
| DatumNabave | [System.Nullable{System.DateTime}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.DateTime}') | Datum nabave |
| DobavljacNaziv | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv dobavljača |

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-BrojNabave'></a>
### BrojNabave `property`

##### Summary

Broj nabave

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-DatumNabave'></a>
### DatumNabave `property`

##### Summary

Datum nabave

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-DobavljacNaziv'></a>
### DobavljacNaziv `property`

##### Summary

Naziv dobavljača

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-NabavaDTORead-Sifra'></a>
### Sifra `property`

##### Summary

Šifra nabave

<a name='T-VodjenjeKaficaCSHARP-Validations-OibValidator'></a>
## OibValidator `type`

##### Namespace

VodjenjeKaficaCSHARP.Validations

##### Summary

Provjerava valjanost OIB-a (Osobni identifikacijski broj) prema hrvatskom standardu.

<a name='M-VodjenjeKaficaCSHARP-Validations-OibValidator-IsValid-System-Object,System-ComponentModel-DataAnnotations-ValidationContext-'></a>
### IsValid(value,validationContext) `method`

##### Summary

Provjerava valjanost OIB-a.

##### Returns

Rezultat provjere valjanosti.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Vrijednost OIB-a koju treba provjeriti. |
| validationContext | [System.ComponentModel.DataAnnotations.ValidationContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.DataAnnotations.ValidationContext 'System.ComponentModel.DataAnnotations.ValidationContext') | Kontekst provjere valjanosti. |

<a name='M-VodjenjeKaficaCSHARP-Validations-OibValidator-IsValidOIB-System-String-'></a>
### IsValidOIB(oib) `method`

##### Summary

Provjerava valjanost OIB-a (Osobni identifikacijski broj) prema hrvatskom standardu.

##### Returns

True ako je OIB valjan, inače False

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| oib | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | OIB koji se provjerava |

<a name='T-VodjenjeKaficaCSHARP-Models-Operater'></a>
## Operater `type`

##### Namespace

VodjenjeKaficaCSHARP.Models

##### Summary

Operater koji se koristi za prijavu u sustav.

<a name='P-VodjenjeKaficaCSHARP-Models-Operater-Email'></a>
### Email `property`

##### Summary

Email operatera.

<a name='P-VodjenjeKaficaCSHARP-Models-Operater-Lozinka'></a>
### Lozinka `property`

##### Summary

Lozinka operatera.

<a name='T-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO'></a>
## OperaterDTO `type`

##### Namespace

VodjenjeKaficaCSHARP.Models.DTO

##### Summary

DTO (Data Transfer Object) za operatera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| email | [T:VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO](#T-T-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO 'T:VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO') | Email operatera. |

<a name='M-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO-#ctor-System-String,System-String-'></a>
### #ctor(email,password) `constructor`

##### Summary

DTO (Data Transfer Object) za operatera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| email | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Email operatera. |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Lozinka operatera. |

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO-email'></a>
### email `property`

##### Summary

Email operatera.

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO-password'></a>
### password `property`

##### Summary

Lozinka operatera.

<a name='T-VodjenjeKaficaCSHARP-Models-Stavka'></a>
## Stavka `type`

##### Namespace

VodjenjeKaficaCSHARP.Models

##### Summary

Stavka u nabavi.

<a name='P-VodjenjeKaficaCSHARP-Models-Stavka-Artikl'></a>
### Artikl `property`

##### Summary

Šifra artikla (Naziv artikla) koja pripada stavci.

<a name='P-VodjenjeKaficaCSHARP-Models-Stavka-Cijena'></a>
### Cijena `property`

##### Summary

Cijena artikla.

<a name='P-VodjenjeKaficaCSHARP-Models-Stavka-KolicinaArtikla'></a>
### KolicinaArtikla `property`

##### Summary

Količina artikla.

<a name='P-VodjenjeKaficaCSHARP-Models-Stavka-Nabava'></a>
### Nabava `property`

##### Summary

Šifra nabave (Broj nabave) koja pripada stavci.

<a name='T-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate'></a>
## StavkaDTOInsertUpdate `type`

##### Namespace

VodjenjeKaficaCSHARP.Models.DTO

##### Summary

Klasa koja predstavlja DTO (Data Transfer Object) za unos i ažuriranje stavke nabave.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| SifraNabave | [T:VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate](#T-T-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate 'T:VodjenjeKaficaCSHARP.Models.DTO.StavkaDTOInsertUpdate') | Šifra nabave |

<a name='M-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-#ctor-System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Decimal}-'></a>
### #ctor(SifraNabave,SifraArtikla,KolicinaArtikla,Cijena) `constructor`

##### Summary

Klasa koja predstavlja DTO (Data Transfer Object) za unos i ažuriranje stavke nabave.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| SifraNabave | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Šifra nabave |
| SifraArtikla | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Šifra artikla |
| KolicinaArtikla | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Količina artikla |
| Cijena | [System.Nullable{System.Decimal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Decimal}') | Cijena artikla |

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-Cijena'></a>
### Cijena `property`

##### Summary

Cijena artikla

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-KolicinaArtikla'></a>
### KolicinaArtikla `property`

##### Summary

Količina artikla

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-SifraArtikla'></a>
### SifraArtikla `property`

##### Summary

Šifra artikla

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTOInsertUpdate-SifraNabave'></a>
### SifraNabave `property`

##### Summary

Šifra nabave

<a name='T-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead'></a>
## StavkaDTORead `type`

##### Namespace

VodjenjeKaficaCSHARP.Models.DTO

##### Summary

DTO klasa koja predstavlja čitanje podataka o stavci.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [T:VodjenjeKaficaCSHARP.Models.DTO.StavkaDTORead](#T-T-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead 'T:VodjenjeKaficaCSHARP.Models.DTO.StavkaDTORead') | Šifra stavke |

<a name='M-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-#ctor-System-Int32,System-String,System-Nullable{System-Int32},System-Nullable{System-Decimal}-'></a>
### #ctor(Sifra,ArtiklaNaziv,KolicinaArtikla,Cijena) `constructor`

##### Summary

DTO klasa koja predstavlja čitanje podataka o stavci.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Sifra | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Šifra stavke |
| ArtiklaNaziv | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Naziv artikla |
| KolicinaArtikla | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Količina artikla |
| Cijena | [System.Nullable{System.Decimal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Decimal}') | Cijena artikla |

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-ArtiklaNaziv'></a>
### ArtiklaNaziv `property`

##### Summary

Naziv artikla

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-Cijena'></a>
### Cijena `property`

##### Summary

Cijena artikla

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-KolicinaArtikla'></a>
### KolicinaArtikla `property`

##### Summary

Količina artikla

<a name='P-VodjenjeKaficaCSHARP-Models-DTO-StavkaDTORead-Sifra'></a>
### Sifra `property`

##### Summary

Šifra stavke

<a name='T-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext'></a>
## VodjenjeKaficaContext `type`

##### Namespace

VodjenjeKaficaCSHARP.Data

##### Summary

Klasa koja predstavlja kontekst baze podataka za Kafic aplikaciju.

<a name='M-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-#ctor-Microsoft-EntityFrameworkCore-DbContextOptions{VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext}-'></a>
### #ctor(opcije) `constructor`

##### Summary

Konstruktor klase VodjenjeKaficaContext.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| opcije | [Microsoft.EntityFrameworkCore.DbContextOptions{VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext}](#T-Microsoft-EntityFrameworkCore-DbContextOptions{VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext} 'Microsoft.EntityFrameworkCore.DbContextOptions{VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext}') | Zahtjevani parametar |

<a name='P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Artikli'></a>
### Artikli `property`

##### Summary

Predstavlja kolekciju artikala.

<a name='P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Dobavljaci'></a>
### Dobavljaci `property`

##### Summary

Predstavlja kolekciju dobavljača.

<a name='P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Nabave'></a>
### Nabave `property`

##### Summary

Predstavlja kolekciju nabavi.

<a name='P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Operateri'></a>
### Operateri `property`

##### Summary

Predstavlja kolekciju operatera.

<a name='P-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-Stavke'></a>
### Stavke `property`

##### Summary

Predstavlja kolekciju stavki.

<a name='M-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext-OnModelCreating-Microsoft-EntityFrameworkCore-ModelBuilder-'></a>
### OnModelCreating(modelBuilder) `method`

##### Summary

Metoda za definiranje veza između entiteta.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| modelBuilder | [Microsoft.EntityFrameworkCore.ModelBuilder](#T-Microsoft-EntityFrameworkCore-ModelBuilder 'Microsoft.EntityFrameworkCore.ModelBuilder') | Instanca modelBuilder |

<a name='T-VodjenjeKaficaCSHARP-Controllers-VodjenjeKaficaController'></a>
## VodjenjeKaficaController `type`

##### Namespace

VodjenjeKaficaCSHARP.Controllers

##### Summary

Apstraktna klasa koja omogućuje instancu konteksta i mapera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:VodjenjeKaficaCSHARP.Controllers.VodjenjeKaficaController](#T-T-VodjenjeKaficaCSHARP-Controllers-VodjenjeKaficaController 'T:VodjenjeKaficaCSHARP.Controllers.VodjenjeKaficaController') | pristup podacima u MSSQL bazi |

<a name='M-VodjenjeKaficaCSHARP-Controllers-VodjenjeKaficaController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext,AutoMapper-IMapper-'></a>
### #ctor(context,mapper) `constructor`

##### Summary

Apstraktna klasa koja omogućuje instancu konteksta i mapera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext](#T-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext 'VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext') | pristup podacima u MSSQL bazi |
| mapper | [AutoMapper.IMapper](#T-AutoMapper-IMapper 'AutoMapper.IMapper') | pristup Automaperu |

<a name='F-VodjenjeKaficaCSHARP-Controllers-VodjenjeKaficaController-_context'></a>
### _context `constants`

##### Summary

Instance VodjenjeKaficaContext

<a name='F-VodjenjeKaficaCSHARP-Controllers-VodjenjeKaficaController-_mapper'></a>
### _mapper `constants`

##### Summary

Instance IMapper

<a name='T-VodjenjeKaficaCSHARP-Extensions-VodjenjeKaficaExtensions'></a>
## VodjenjeKaficaExtensions `type`

##### Namespace

VodjenjeKaficaCSHARP.Extensions

##### Summary

Extension methods for configuring services in the Kafic application.

<a name='M-VodjenjeKaficaCSHARP-Extensions-VodjenjeKaficaExtensions-AddVodjenjeKaficaCORS-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddVodjenjeKaficaCORS(Services) `method`

##### Summary

Adds CORS policy to allow any origin, method, and header.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | The service collection to add the CORS policy to. |

<a name='M-VodjenjeKaficaCSHARP-Extensions-VodjenjeKaficaExtensions-AddVodjenjeKaficaCSHARPSwaggerGen-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddVodjenjeKaficaCSHARPSwaggerGen(Services) `method`

##### Summary

Adds Swagger generation with custom settings for the Kafic APP.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | The service collection to add the Swagger generation to. |

<a name='M-VodjenjeKaficaCSHARP-Extensions-VodjenjeKaficaExtensions-AddVodjenjeKaficaSecurity-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddVodjenjeKaficaSecurity(Services) `method`

##### Summary

Adds JWT-based authentication to the service collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | The service collection to add the authentication to. |

<a name='T-VodjenjeKaficaCSHARP-Mapping-VodjenjeKaficaMappingProfile'></a>
## VodjenjeKaficaMappingProfile `type`

##### Namespace

VodjenjeKaficaCSHARP.Mapping

##### Summary

Klasa koja sadrži mapiranja između modela i DTO objekata.

<a name='M-VodjenjeKaficaCSHARP-Mapping-VodjenjeKaficaMappingProfile-#ctor'></a>
### #ctor() `constructor`

##### Summary

Konstruktor koji definira mapiranja između modela i DTO objekata.

##### Parameters

This constructor has no parameters.
