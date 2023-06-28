USE [elecciones]
GO
/****** Object:  Table [dbo].[Candidatos]    Script Date: 28/6/2023 11:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidatos](
	[idCandidato] [int] NOT NULL,
	[idPartido] [int] NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Foto] [varchar](255) NOT NULL,
	[Postulacion] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Candidatos] PRIMARY KEY CLUSTERED 
(
	[idCandidato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partidos]    Script Date: 28/6/2023 11:52:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partidos](
	[idPartido] [int] NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[logo] [varchar](255) NOT NULL,
	[SitioWeb] [varchar](255) NOT NULL,
	[FechaFundacion] [date] NOT NULL,
	[CantidadDiputados] [int] NOT NULL,
	[CantidadSenadores] [int] NOT NULL,
 CONSTRAINT [PK_Partidos] PRIMARY KEY CLUSTERED 
(
	[idPartido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Candidatos]  WITH CHECK ADD  CONSTRAINT [FK_Candidatos_Partidos] FOREIGN KEY([idPartido])
REFERENCES [dbo].[Partidos] ([idPartido])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Candidatos] CHECK CONSTRAINT [FK_Candidatos_Partidos]
GO
