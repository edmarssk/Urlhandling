/****** Object:  Table [dbo].[UrlLink]    Script Date: 26/03/2022 16:33:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UrlLink](
	[Id] [uniqueidentifier] NOT NULL,
	[ShortUrl] [varchar](100) NOT NULL,
	[OriginalUrl] [varchar](500) NOT NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_UrlLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

