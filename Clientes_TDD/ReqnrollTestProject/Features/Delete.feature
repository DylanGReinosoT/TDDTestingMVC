Feature: Eliminar

Proceso de realizar Testing BDD en Eliminar Cliente con datos válidos e inválidos

@tag3
Scenario: Eliminar Cliente con datos válidos
    Given Existe un cliente registrado en la BDD para eliminar
        | Codigo | Cedula     | Apellidos      | Nombres       | FechaNacimiento | Mail                  | Telefono  | Direccion | Estado |
        | 1011   | 1753026721 | Reinoso Torres | Dylan Gabriel | 06/05/2001      | dgreinoso32@gmail.com | 969048289 | Quito     | 1      |
    When Elimino el cliente de la BDD
        | Codigo | Cedula     |
        | 1011   | 1753026721 |
    Then El cliente ya no debe existir en la BDD
        | Codigo | Cedula     |
        | 1011   | 1753026721 |

@tag3
Scenario: Eliminar Cliente con datos inválidos (Cliente no existe)
    Given No existe un cliente registrado en la BDD con la cédula
        | Codigo | Cedula     |
        | 999    | 9999999999 |
    When Intento eliminar el cliente de la BDD
        | Codigo | Cedula     |
        | 999    | 9999999999 |
    Then Debe mostrar un mensaje de error indicando que el cliente no existe
