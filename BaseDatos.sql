USE [BaseDatos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[PersonaId] [int] NULL,
	[Contrasena] [varchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[CuentaId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[NroCuenta] [int] NULL,
	[TipoCuenta] [varchar](50) NULL,
	[SaldoInicial] [decimal](18, 0) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[MovimientoId] [int] IDENTITY(1,1) NOT NULL,
	[CuentaId] [int] NULL,
	[Fecha] [datetime] NULL,
	[TipoMovimiento] [varchar](50) NULL,
	[Valor] [varchar](50) NULL,
	[Saldo] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[MovimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[PersonaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Genero] [varchar](50) NULL,
	[Edad] [int] NULL,
	[Identificacion] [int] NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [PersonaId], [Contrasena], [Estado]) VALUES (1, 1, N'1234', 1)
INSERT [dbo].[Cliente] ([ClienteId], [PersonaId], [Contrasena], [Estado]) VALUES (2, 2, N'5678', 1)
INSERT [dbo].[Cliente] ([ClienteId], [PersonaId], [Contrasena], [Estado]) VALUES (3, 3, N'1245', 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 

INSERT [dbo].[Cuenta] ([CuentaId], [ClienteId], [NroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (1, 1, 478758, N'Ahorros', CAST(2000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Cuenta] ([CuentaId], [ClienteId], [NroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (2, 2, 225487, N'Corriente', CAST(100 AS Decimal(18, 0)), 1)
INSERT [dbo].[Cuenta] ([CuentaId], [ClienteId], [NroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (3, 3, 495878, N'Ahorros', CAST(0 AS Decimal(18, 0)), 1)
INSERT [dbo].[Cuenta] ([CuentaId], [ClienteId], [NroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (4, 2, 495825, N'Ahorros', CAST(540 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento] ON 

INSERT [dbo].[Movimiento] ([MovimientoId], [CuentaId], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (1, 2, CAST(N'2024-10-26T00:00:00.000' AS DateTime), N'Deposito de 600', N'600', CAST(700 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([PersonaId], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'Jose Lema', N'Masculino', 27, 458965350, N'Otavalo sn y principal', N'098254785')
INSERT [dbo].[Persona] ([PersonaId], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'Marianela Montalvo', N'Femenino', 30, 457893210, N'Amazonas y NNUU', N'097548965')
INSERT [dbo].[Persona] ([PersonaId], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (3, N'Juan Osorio', N'Masculino', 22, 102589647, N'13 Junio y Equinoccial', N'098874587')
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Persona] ([PersonaId])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_Cuenta]
GO
