USE [master]
GO
/****** Object:  Database Personas    Script Date: 3/22/2024 2:37:42 AM ******/
CREATE DATABASE Personas
GO
USE Personas
GO
/****** Object:  Table [dbo].[CuentaBancaria]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaBancaria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonaId] [int] NOT NULL,
	[NumeroCuenta] [varchar](50) NOT NULL,
	[Tipo] [smallint] NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
	CONSTRAINT [PK_CuentaBancaria] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](30) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Apellidos] [varchar](250) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Referencia] [varchar](200) NOT NULL,
	[Ciudad] [varchar](100) NOT NULL,
	[Provincia] [varchar](100) NOT NULL,
	[Pais] [varchar](100) NOT NULL,
	[CodigoPostal] [varchar](10) NULL,
	CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_CuentaBancaria_Persona] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_CuentaBancaria_Persona]
GO
/****** Object:  StoredProcedure [dbo].[CuentaBancaria_Create]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Crear registro de Cuentas Bancarias
-- =============================================.
CREATE PROCEDURE [dbo].[CuentaBancaria_Create] 
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
/****** Object:  StoredProcedure [dbo].[CuentaBancaria_Delete]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Eliminar registro de Cuentas Bancarias
-- =============================================
CREATE PROCEDURE [dbo].[CuentaBancaria_Delete]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.CuentaBancaria
	WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[CuentaBancaria_GetAllByPersonaId]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-----------------------------------------------------------------
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Obtener todos los registros de Cuentas Bancarias
-- =============================================
CREATE PROCEDURE [dbo].[CuentaBancaria_GetAllByPersonaId]
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
/****** Object:  StoredProcedure [dbo].[CuentaBancaria_GetById]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Obtener Cuentas Bancarias por Id
-- =============================================
CREATE PROCEDURE [dbo].[CuentaBancaria_GetById]
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
/****** Object:  StoredProcedure [dbo].[CuentaBancaria_Update]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Actualizar registro de Cuentas Bancarias
-- =============================================
CREATE PROCEDURE [dbo].[CuentaBancaria_Update]
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
/****** Object:  StoredProcedure [dbo].[Persona_Create]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Crear registro de Personas
-- =============================================.
CREATE PROCEDURE [dbo].[Persona_Create] 
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
    DECLARE @Existe BIT = 0;
    SELECT TOP 1 @Existe = 1 FROM dbo.Persona WHERE Identificacion = @Identificacion;
    IF @Existe = 1
    BEGIN
		RAISERROR ('El cliente ya se encuentra registrado.', -- Message text.
               16, -- Severity.
               1 -- State.
               );
		RETURN
    END

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
/****** Object:  StoredProcedure [dbo].[Persona_Delete]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Eliminar registro de Personas
-- =============================================
CREATE PROCEDURE [dbo].[Persona_Delete]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Persona
	WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[Persona_GetAll]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Obtener todos los registros de personas
-- =============================================
CREATE PROCEDURE [dbo].[Persona_GetAll]
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
/****** Object:  StoredProcedure [dbo].[Persona_GetById]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Obtener personas por Id
-- =============================================
CREATE PROCEDURE [dbo].[Persona_GetById]
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
/****** Object:  StoredProcedure [dbo].[Persona_Update]    Script Date: 3/22/2024 2:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ronald Ramirez
-- Create date: 21/03/2024
-- Description:	Actualizar registro de Personas
-- =============================================
CREATE PROCEDURE [dbo].[Persona_Update]
	@Id INT,
	@Identificacion varchar(50),
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
	SET Identificacion		= @Identificacion
		,Nombre				= @Nombre
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
