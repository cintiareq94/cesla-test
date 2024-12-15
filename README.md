
# Cesla Test

Este projeto foi desenvolvido com base nos princípios da Clean Architecture para estruturar o código de maneira modular e organizada. A aplicação gerencia colaboradores, empresas e seus relacionamentos, respeitando regras de negócio específicas.

--------

## Entidades e Estrutura de Dados

**Tabelas**

 A aplicação possui 3 tabelas principais:

   **1. Collaborator**
 
  Armazena as informações dos colaboradores, como:
            `Id` , `Name`, `Email`, `Phone`, `Address`,` Document`, `CreationDate`.

  **Regras:**
           
 - Um colaborador só pode existir na tabela caso tenha um link ativo na tabela CollaboratorCompanyLink (`IsEnabled == true`).
 - Não há duplicação de colaboradores com o mesmo documento e links ativos.
            Se um colaborador for adicionado novamente com o mesmo documento e um novo link, um novo registro será criado com um novo `Id`.

  **2. Company**
        Armazena as informações das empresas, como:
            `Id`,` TradeName`, `Document`, `Phone`, `Address`, `IsEnabled`.


 **Regras:**
-  Não é possível adicionar uma Empresa com o mesmo documento de outra empresa que esteja habilitada.
            Quando uma empresa é desabilitada (`IsEnabled = false`), todos os seus links na tabela CollaboratorCompanyLink são desativados.


**3. CollaboratorCompanyLink**
        Representa o relacionamento entre Collaborator e Company, com os seguintes campos:
            `Id`, `CollaboratorId`, `CompanyId`, `Role`, `Department`, `IsEnabled`.

**Regras:**
 - Um colaborador pode ter múltiplos links com empresas diferentes.
  - Se todos os links de um colaborador forem desabilitados (`IsEnabled == false`), o colaborador é considerado desabilitado.


       **Atualizações**:
     - Caso um colaborador seja adicionado a uma nova empresa, é criado um novo link.
     -  Caso ele seja atualizado para a mesma empresa, o link existente é mantido.

    **Role e Department:**

    -  O campo `Role` (função) e o campo `Department` (departamento) do colaborador são definidos no contexto do relacionamento com uma empresa na tabela CollaboratorCompanyLink.
    - Cada link com uma empresa pode ter valores distintos para Role e Department, permitindo flexibilidade no gerenciamento do relacionamento.

--------------------------------

**Tecnologias Utilizadas**
  
    Linguagem: C#
    Banco de Dados: MySQL
    Estrutura de Arquitetura: Clean Architecture
    ORM: Entity Framework Core
    Docker
  
  -------------------
  **Como rodar o projeto**

No terminal, na pasta onde está o `docker-compose` (Api) e executar:

    docker-compose --build

Acessar no navegador de sua preferência:

    http://localhost:5000/swagger/index.html


                
