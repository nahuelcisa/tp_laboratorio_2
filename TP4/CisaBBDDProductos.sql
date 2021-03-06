USE [Cisa.Nahuel.2A.TP4]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 22/11/2020 13:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto] [varchar](50) NULL,
	[marca] [varchar](50) NULL,
	[modelo] [varchar](50) NULL,
	[precio] [float] NULL,
	[cantidad_de_stock] [int] NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[productos] ON 

INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (11, N'Gabinete', N'Corsair', N'A70', 2500, 53)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (12, N'Procesador', N'Sentey', N'400', 34.5, 32)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (13, N'PlacaDeVideo', N'Nvidia', N'2060', 95000, 45)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (14, N'Procesador', N'Intel', N'I5 6400', 32000, 16)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (15, N'Gabinete', N'Cougar', N'ENG', 10500, 11)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (16, N'PlacaDeVideo', N'AMD', N'RX580', 19990.990234375, 50)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (17, N'PlacaDeVideo', N'NZXT', N'596', 325, 51)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (18, N'Gabinete', N'pirulin', N'pirulan', 22, 72)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (19, N'Procesador', N'intel', N'i5', 24189, 20)
SET IDENTITY_INSERT [dbo].[productos] OFF
GO
