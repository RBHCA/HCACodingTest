USE [HolidayGifts]
GO

/****** Object:  StoredProcedure [dbo].[udsp_InsOrUpd_KidsPuzzle]    Script Date: 1/3/2022 4:24:53 PM ******/
DROP PROCEDURE [dbo].[udsp_InsOrUpd_KidsPuzzle]
GO

/****** Object:  StoredProcedure [dbo].[udsp_InsOrUpd_KidsPuzzle]    Script Date: 1/3/2022 4:24:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Rekha Bojja>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[udsp_InsOrUpd_KidsPuzzle] 
	@PuzzleID INT,
	@PuzzleName VARCHAR(50),
	@PuzzleDescription VARCHAR(50),
	@PuzzlePrice INT,
	@PuzzleRating INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @PuzzleID = 0
	BEGIN
		INSERT INTO KidsPuzzles(PuzzleName,PuzzleDescription,PuzzlePrice,PuzzleRating)
		VALUES(@PuzzleName,@PuzzleDescription,@PuzzlePrice,@PuzzleRating)
	END
	ELSE
	BEGIN
		UPDATE KidsPuzzles
		SET
			PuzzleName = @PuzzleName,
			PuzzleDescription = @PuzzleDescription,
			PuzzlePrice = @PuzzlePrice,
			PuzzleRating = @PuzzleRating
		Where PuzzleID = @PuzzleID
	END
END
GO


