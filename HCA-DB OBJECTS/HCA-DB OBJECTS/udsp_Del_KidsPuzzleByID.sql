USE [HolidayGifts]
GO

/****** Object:  StoredProcedure [dbo].[udsp_Del_KidsPuzzleByID]    Script Date: 1/3/2022 4:24:25 PM ******/
DROP PROCEDURE [dbo].[udsp_Del_KidsPuzzleByID]
GO

/****** Object:  StoredProcedure [dbo].[udsp_Del_KidsPuzzleByID]    Script Date: 1/3/2022 4:24:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[udsp_Del_KidsPuzzleByID] 
	@PuzzleID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE [dbo].KidsPuzzles
	WHERE PuzzleID = @PuzzleID
END
GO


