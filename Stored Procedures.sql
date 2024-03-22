-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Obtener todos los registros de personas
-- =============================================
CREATE PROCEDURE Persona_GetAll
AS
BEGIN
	SET NOCOUNT ON;

    SELECT Id
      ,Identificacion
      ,Nombre
      ,Apellidos
      ,FechaNacimiento
      ,Direccion
      ,Referencia
      ,Ciudad
      ,Provincia
      ,Pais
      ,CodigoPostal
  FROM dbo.Persona;
END
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Obtener personas por Id
-- =============================================
CREATE PROCEDURE Persona_GetById
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT Id
      ,Identificacion
      ,Nombre
      ,Apellidos
      ,FechaNacimiento
      ,Direccion
      ,Referencia
      ,Ciudad
      ,Provincia
      ,Pais
      ,CodigoPostal
  FROM dbo.Persona
  WHERE ID = @Id;

END
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Crear registro de Personas
-- =============================================.
CREATE PROCEDURE Persona_Create 
	@Identificacion varchar(30),
	@Nombre varchar(250),
	@Apellidos varchar(250),
	@FechaNacimiento datetime,
	@Direccion varchar(200),
	@Referencia varchar(200),
	@Ciudad varchar(100),
	@Provincia varchar(100),
	@Pais varchar(100),
	@CodigoPostal varchar(10) 
AS
BEGIN
	INSERT INTO dbo.Persona
           (Identificacion
           ,Nombre
           ,Apellidos
           ,FechaNacimiento
           ,Direccion
           ,Referencia
           ,Ciudad
           ,Provincia
           ,Pais
           ,CodigoPostal)
     VALUES
           (@Identificacion
           ,@Nombre
           ,@Apellidos
           ,@FechaNacimiento
           ,@Direccion
           ,@Referencia
           ,@Ciudad
           ,@Provincia
           ,@Pais
           ,@CodigoPostal)

	RETURN @@IDENTITY
END
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Actualizar registro de Personas
-- =============================================
CREATE PROCEDURE Persona_Update
	@Id INT,
	@Nombre varchar(250),
	@Apellidos varchar(250),
	@FechaNacimiento datetime,
	@Direccion varchar(200),
	@Referencia varchar(200),
	@Ciudad varchar(100),
	@Provincia varchar(100),
	@Pais varchar(100),
	@CodigoPostal varchar(10) 
AS
BEGIN 
	SET NOCOUNT ON;

	UPDATE dbo.Persona
	SET Nombre				= @Nombre
		,Apellidos			= @Apellidos
		,FechaNacimiento	= @FechaNacimiento
		,Direccion			= @Direccion
		,Referencia			= @Referencia		
		,Ciudad				= @Ciudad			
		,Provincia			= @Provincia		
		,Pais				= @Pais			
		,CodigoPostal		= @CodigoPostal
	WHERE Id = @Id; 
END
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Eliminar registro de Personas
-- =============================================
CREATE PROCEDURE Persona_Delete
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Persona
	WHERE Id = @Id;
END
GO



-----------------------------------------------------------------
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Obtener todos los registros de Cuentas Bancarias
-- =============================================
CREATE PROCEDURE CuentaBancaria_GetAllByPersonaId
	@PersonaId INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT Id
      ,PersonaId
      ,NumeroCuenta
      ,Tipo
      ,Balance
      ,Comentarios
  FROM dbo.CuentaBancaria
  WHERE PersonaId = @PersonaId;
END
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Obtener Cuentas Bancarias por Id
-- =============================================
CREATE PROCEDURE CuentaBancaria_GetById
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT Id
      ,PersonaId
      ,NumeroCuenta
      ,Tipo
      ,Balance
      ,Comentarios
  FROM dbo.CuentaBancaria
  WHERE ID = @Id;

END
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Crear registro de Cuentas Bancarias
-- =============================================.
CREATE PROCEDURE CuentaBancaria_Create 
	@PersonaId int,
	@NumeroCuenta varchar(50),
	@Tipo smallint,
	@Balance decimal(18, 2),
	@Comentarios varchar(200)
AS
BEGIN
	INSERT INTO dbo.CuentaBancaria
           (PersonaId
			,NumeroCuenta
			,Tipo
			,Balance
			,Comentarios)
     VALUES
           (@PersonaId
			,@NumeroCuenta
			,@Tipo
			,@Balance
			,@Comentarios)

	RETURN @@IDENTITY
END
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Actualizar registro de Cuentas Bancarias
-- =============================================
CREATE PROCEDURE CuentaBancaria_Update
	@Id int,
	@PersonaId int,
	@NumeroCuenta varchar(50),
	@Tipo smallint,
	@Balance decimal(18, 2),
	@Comentarios varchar(200)
AS
BEGIN 
	SET NOCOUNT ON;

	UPDATE dbo.CuentaBancaria
	SET PersonaId		  = @PersonaId
		,NumeroCuenta	  = @NumeroCuenta
		,Tipo			  = @Tipo
		,Balance		  = @Balance
		,Comentarios	  = @Comentarios
	WHERE Id = @Id; 
END
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Eliminar registro de Cuentas Bancarias
-- =============================================
CREATE PROCEDURE CuentaBancaria_Delete
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.CuentaBancaria
	WHERE Id = @Id;
END
GO
