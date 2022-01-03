USE [HolidayGifts]
GO

/****** Object:  StoredProcedure [dbo].[udsp_Sel_KidsPuzzleByID]    Script Date: 1/3/2022 4:25:15 PM ******/
DROP PROCEDURE [dbo].[udsp_Sel_KidsPuzzleByID]
GO

/****** Object:  StoredProcedure [dbo].[udsp_Sel_KidsPuzzleByID]    Script Date: 1/3/2022 4:25:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[udsp_Sel_KidsPuzzleByID] 
	-- Add the parameters for the stored procedure here
	@PuzzleID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	    
	SELECT *
	FROM KidsPuzzles
	WHERE PuzzleID=@PuzzleID
END
GO


