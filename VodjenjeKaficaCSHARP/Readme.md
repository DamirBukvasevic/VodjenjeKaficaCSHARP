<a name='assembly'></a>
# VodjenjeKaficaCSHARP

## Contents

- [AutorizacijaController](#T-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController 'VodjenjeKaficaCSHARP.Controllers.AutorizacijaController')
  - [#ctor(context)](#M-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController-#ctor-VodjenjeKaficaCSHARP-Data-VodjenjeKaficaContext- 'VodjenjeKaficaCSHARP.Controllers.AutorizacijaController.#ctor(VodjenjeKaficaCSHARP.Data.VodjenjeKaficaContext)')
  - [GenerirajToken(operater)](#M-VodjenjeKaficaCSHARP-Controllers-AutorizacijaController-GenerirajToken-VodjenjeKaficaCSHARP-Models-DTO-OperaterDTO- 'VodjenjeKaficaCSHARP.Controllers.AutorizacijaController.GenerirajToken(VodjenjeKaficaCSHARP.Models.DTO.OperaterDTO)')
- [Operater](#T-VodjenjeKaficaCSHARP-Models-Operater 'VodjenjeKaficaCSHARP.Models.Operater')
  - [Email](#P-VodjenjeKaficaCSHARP-Models-Operater-Email 'VodjenjeKaficaCSHARP.Models.Operater.Email')
  - [Lozinka](#P-VodjenjeKaficaCSHARP-Models-Operater-Lozinka 'VodjenjeKaficaCSHARP.Models.Operater.Lozinka')

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
