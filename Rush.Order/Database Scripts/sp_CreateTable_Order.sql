USE [Rush.Order]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 9/22/2021 10:40:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[OrderNumber] [varchar](16) NULL,
	[Total] [decimal](10, 2) NULL,
	[CreateDate] [datetimeoffset](7) NOT NULL,
	[Status] [varchar](16) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderNumber]  DEFAULT (NULL) FOR [OrderNumber]
GO

ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_Total]  DEFAULT (NULL) FOR [Total]
GO

ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO

