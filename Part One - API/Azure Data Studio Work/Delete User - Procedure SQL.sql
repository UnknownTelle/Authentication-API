CREATE PROCEDURE delete_user(
    @user_id INT
)

AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY

    DECLARE @error NVARCHAR(MAX)

    DELETE FROM users
    WHERE user_id = @user_id

    
    IF @@TRANCOUNT > 0
    ROLLBACK TRANSACTION

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