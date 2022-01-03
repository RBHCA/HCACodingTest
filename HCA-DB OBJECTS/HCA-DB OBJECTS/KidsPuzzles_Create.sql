USE [HolidayGifts]
GO

/****** Object:  Table [dbo].[KidsPuzzles]    Script Date: 1/3/2022 4:22:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KidsPuzzles](
	[PuzzleID] [int] IDENTITY(1,1) NOT NULL,
	[PuzzleName] [varchar](100) NOT NULL,
	[PuzzleDescription] [varchar](200) NOT NULL,
	[PuzzlePrice] [int] NOT NULL,
	[PuzzleRating] [int] NOT NULL,
 CONSTRAINT [PK_ChristmasGifts-Puzzles] PRIMARY KEY CLUSTERED 
(
	[PuzzleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

