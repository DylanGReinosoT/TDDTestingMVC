Feature: Insert

Proceso de realizar Testing BDD en Insert

@tag1
Scenario: Insert Data
	Given Llenar los campos del formulario
		| Cedula     | Apellidos      | Nombres       | FechaNacimiento | Mail                  | Telefono  | Direccion | Estado |
		| 1753026721 | Reinoso Torres | Dylan Gabriel | 06/05/2001      | dgreinoso32@gmail.com | 969048289 | Quito     | 1      |
	When Registro de usuario en la BDD
		| Cedula     | Apellidos      | Nombres       | FechaNacimiento | Mail                  | Telefono  | Direccion | Estado |
		| 1753026721 | Reinoso Torres | Dylan Gabriel | 06/05/2001      | dgreinoso32@gmail.com | 969048289 | Quito     | 1      |
	Then El resultado del registro en l a BDD
		| Cedula     | Apellidos      | Nombres       | FechaNacimiento | Mail                  | Telefono  | Direccion | Estado |
		| 1753026721 | Reinoso Torres | Dylan Gabriel | 06/05/2001      | dgreinoso32@gmail.com | 969048289 | Quito     | 1      |
