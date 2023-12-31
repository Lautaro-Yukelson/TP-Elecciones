USE [Elecciones2023]
GO
/****** Object:  Table [dbo].[Candidatos]    Script Date: 2/8/2023 11:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidatos](
	[idCandidato] [int] IDENTITY(1,1) NOT NULL,
	[idPartido] [int] NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Foto] [varchar](255) NOT NULL,
	[Postulacion] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Candidatos] PRIMARY KEY CLUSTERED 
(
	[idCandidato] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partidos]    Script Date: 2/8/2023 11:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partidos](
	[idPartido] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Logo] [varchar](255) NOT NULL,
	[SitioWeb] [varchar](255) NOT NULL,
	[FechaFundacion] [datetime] NOT NULL,
	[CantidadDiputados] [int] NOT NULL,
	[CantidadSenadores] [int] NOT NULL,
	[ColorPrimario] [varchar](9) NOT NULL,
	[ColorSecundario] [varchar](9) NOT NULL,
 CONSTRAINT [PK_Partidos] PRIMARY KEY CLUSTERED 
(
	[idPartido] ASC
)
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Candidatos] ON 

INSERT [dbo].[Candidatos] ([idCandidato], [idPartido], [Apellido], [Nombre], [FechaNacimiento], [Foto], [Postulacion]) VALUES (3, 5, N'Larreta', N'Horacio', CAST(N'1965-10-29T00:00:00.000' AS DateTime), N'/assets/images/candidatos/horacio-larreta.webp', N'Presidente')
INSERT [dbo].[Candidatos] ([idCandidato], [idPartido], [Apellido], [Nombre], [FechaNacimiento], [Foto], [Postulacion]) VALUES (5, 9, N'Massa', N'Sergio', CAST(N'1972-04-20T00:00:00.000' AS DateTime), N'/assets/images/candidatos/sergio-massa.webp', N'Presidente')
INSERT [dbo].[Candidatos] ([idCandidato], [idPartido], [Apellido], [Nombre], [FechaNacimiento], [Foto], [Postulacion]) VALUES (7, 11, N'Milei', N'Javier ', CAST(N'1970-10-22T00:00:00.000' AS DateTime), N'/assets/images/candidatos/javier-milei.webp', N'Presidente')
SET IDENTITY_INSERT [dbo].[Candidatos] OFF
GO
SET IDENTITY_INSERT [dbo].[Partidos] ON 

INSERT [dbo].[Partidos] ([idPartido], [Nombre], [Logo], [SitioWeb], [FechaFundacion], [CantidadDiputados], [CantidadSenadores], [ColorPrimario], [ColorSecundario]) VALUES (5, N'Juntos por el Cambio', N'/assets/images/partidos/juntos-por-el-cambio.webp', N'https://jxc.com.ar/', CAST(N'2019-06-12T00:00:00.000' AS DateTime), 116, 17, N'#e9e63e', N'#f54e00')
INSERT [dbo].[Partidos] ([idPartido], [Nombre], [Logo], [SitioWeb], [FechaFundacion], [CantidadDiputados], [CantidadSenadores], [ColorPrimario], [ColorSecundario]) VALUES (9, N'Frente de Todos', N'/assets/images/partidos/frente-de-todos.webp', N'https://www.frentedetodos.org/', CAST(N'2019-06-12T00:00:00.000' AS DateTime), 118, 19, N'#66d7eb', N'#ffffff')
INSERT [dbo].[Partidos] ([idPartido], [Nombre], [Logo], [SitioWeb], [FechaFundacion], [CantidadDiputados], [CantidadSenadores], [ColorPrimario], [ColorSecundario]) VALUES (11, N'La Liberdad Avanza', N'/assets/images/partidos/la-libertad-avanza.png', N'https://lalibertadavanza.com.ar/', CAST(N'2021-07-14T00:00:00.000' AS DateTime), 5, 2, N'#c75ef0', N'#f0c726')
SET IDENTITY_INSERT [dbo].[Partidos] OFF
GO
ALTER TABLE [dbo].[Candidatos]  WITH CHECK ADD  CONSTRAINT [FK_Candidatos_Partidos] FOREIGN KEY([idPartido])
REFERENCES [dbo].[Partidos] ([idPartido])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Candidatos] CHECK CONSTRAINT [FK_Candidatos_Partidos]
GO
