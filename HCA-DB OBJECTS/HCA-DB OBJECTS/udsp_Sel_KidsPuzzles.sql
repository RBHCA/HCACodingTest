USE [HolidayGifts]
GO

/****** Object:  StoredProcedure [dbo].[udsp_Sel_KidsPuzzles]    Script Date: 1/3/2022 4:25:42 PM ******/
DROP PROCEDURE [dbo].[udsp_Sel_KidsPuzzles]
GO

/****** Object:  StoredProcedure [dbo].[udsp_Sel_KidsPuzzles]    Script Date: 1/3/2022 4:25:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[udsp_Sel_KidsPuzzles]	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT *
	FROM KidsPuzzles
END
GO


