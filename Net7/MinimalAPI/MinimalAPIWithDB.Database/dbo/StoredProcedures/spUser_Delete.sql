CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
begin
	delete
	from dbo.[User]
	where Id = @Id;
end
