ALTER PROCEDURE update_user(
    @user_id INT,
    @first_name VARCHAR(35),
    @last_name VARCHAR(35),
    @user_email VARCHAR(50),
    @user_password VARCHAR(15)
)
AS
BEGIN

    BEGIN TRANSACTION
    BEGIN TRY

    DECLARE @error NVARCHAR(MAX)

    UPDATE users
    SET     first_name = @first_name,
            last_name = @last_name,
            user_email = @user_email,
            user_password = @user_password
    WHERE
            user_id = @user_id


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