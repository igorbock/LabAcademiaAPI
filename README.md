# LabAcademiaAPI

API do projeto LabAcademia. Aplicado a segurança de autenticação de usuários e autorização.

## Autenticação e Autorização

Para realizar a autenticação de usuários e acessar os endpoints desse projeto, será necessário obter o JWT através do repositório LabIS4.
![image](https://github.com/igorbock/LabAcademiaAPI/assets/57839096/924ab2fd-a1c3-4a3a-9d1b-e4688b1ae0b1)

Abaixo uma resposta (200) com o JWT.
![image](https://github.com/igorbock/LabAcademiaAPI/assets/57839096/3f66bbb5-0a5a-4819-930a-bfd12e52d248)

## Usando o Swagger

Na utilização dos endpoints é obrigatório registrar o JWT para autenticação do usuário.

![image](https://github.com/igorbock/LabAcademiaAPI/assets/57839096/f0ad3ca1-cd1b-41d6-89cf-92921e8a2dbc)

Mantendo sempre o pré-fixo "Bearer", caso contrário a autenticação não ocorerrá.

![image](https://github.com/igorbock/LabAcademiaAPI/assets/57839096/4e493790-2872-4bbf-8d87-a0a491c66855)
