ALTER PROCEDURE register(
    @first_name VARCHAR(35),
    @last_name VARCHAR(35),
    @user_email VARCHAR(50),
    @user_password VARCHAR(15),
    @register INT OUTPUT
)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY

    DECLARE @error NVARCHAR(MAX)

    INSERT INTO dbo.users
    (
        first_name, last_name, user_email, user_password
    )
    VALUES
    (
        @first_name, @last_name, @user_email, @user_password
    )
    COMMIT

    SET @register = SCOPE_IDENTITY()

END TRY
BEGIN CATCH
    SET @error = 'ERROR'
    IF @@TRANCOUNT > 0 BEGIN
        ROLLBACK TRANSACTION
        END
    RAISERROR(@error,1,0)
END CATCH
END
GO