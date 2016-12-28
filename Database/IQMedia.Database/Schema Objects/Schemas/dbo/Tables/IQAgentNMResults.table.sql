﻿CREATE TABLE [dbo].[IQAgent_NMResults](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IQAgentSearchRequestID] [bigint] NOT NULL,
	[_QueryVersion] [int] NULL,
	[ArticleID] [varchar](50) NOT NULL,
	[Url] [varchar](max) NOT NULL,
	[Publication] [varchar](255) NULL,
	[Title] [nvarchar](max) NULL,
	[harvest_time] [datetime] NOT NULL,
	[Category] [varchar](250) NOT NULL,
	[Genre] [varchar](250) NOT NULL,
	[Number_Hits] [int] NULL,
	[HighlightingText] [xml] NULL,
	[Sentiment] [xml] NULL,
	[Compete_Audience] [int] NULL,
	[IQAdShareValue] [float] NULL,
	[Compete_Result] [char](1) NULL,
	[CompeteURL] [varchar](255) NULL,
	[Communication_flag] [bit] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[i_comm_flag] [bit] NULL,
	[h_comm_flag] [bit] NULL,
	[d_comm_flag] [bit] NULL,
	[w_comm_flag] [bit] NULL,
	[_IQDMAID] [int] NULL,
	[DMA_Name] [varchar](255) NULL,
	[IQLicense] [tinyint] NULL,
	[IQProminence] [decimal](18, 6) NULL,
	[IQProminenceMultiplier] [decimal](18, 6) NULL,
	[State] [varchar](100) NULL,
	[CountryCode] [varchar](2) NULL,
	[feedClass] [varchar](50) NULL,
	[v5SubMediaType] [varchar](50) NULL,
 CONSTRAINT [PK_IQAgentNMResult] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]