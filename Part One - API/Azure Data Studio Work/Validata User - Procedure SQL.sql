ALTER PROCEDURE validate_user (
    @user_email VARCHAR(50),
    @user_password VARCHAR(15)
)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY

    DECLARE @error NVARCHAR(MAX)
    DECLARE @check INT
    DECLARE @user_id INT
    
    SET @check = 0
    SELECT @check = COUNT(user_id) FROM dbo.users
    WHERE @user_email = user_email AND @user_password = user_password

    SET @user_id = SCOPE_IDENTITY()

    IF (@check = 1) BEGIN
        INSERT INTO dbo.session_table
            (
                user_id, session_time
            )
        VALUES 
            (
                @user_id, GETDATE()
            )
        COMMIT
        END

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