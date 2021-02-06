CREATE OR ALTER PROCEDURE [dbo].[VerifySectionAndCookbookPairExist]  
    -- Add the parameters for the stored procedure here  
      
    @CookbookId INT, 
	@SectionId INT
AS  
BEGIN  
DECLARE @IsBTech BIT  
IF EXISTS(SELECT * FROM Sections Where CookbookId=@CookbookId AND SectionId=@SectionId)  
BEGIN  
SET @IsBTech=1  
END  
ELSE  
BEGIN  
SET @IsBTech=0  
END  
SELECT @IsBTech AS 'IsBTech'  
END  