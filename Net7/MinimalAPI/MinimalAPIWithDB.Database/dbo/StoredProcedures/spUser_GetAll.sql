CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	select Id, FirstName, LastName
	from dbo.[User];
end