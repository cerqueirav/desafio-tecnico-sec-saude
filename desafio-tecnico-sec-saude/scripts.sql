USE [SecSaudeDb]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 04/06/2023 18:08:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Senha] [varchar](200) NOT NULL,
	[CPF] [varchar](20) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Perfil] [varchar](100) NOT NULL,
	[CEP] [varchar](100) NOT NULL,
	[Logradouro] [varchar](100) NOT NULL,
	[Complemento] [varchar](200) NULL,
	[Numero] [varchar](100) NOT NULL,
	[Cidade] [varchar](100) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Pais] [varchar](100) NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Contato]    Script Date: 04/06/2023 18:06:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[TipoContatoId] [int] NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Contato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_Contato_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Contato_Usuario]
GO
