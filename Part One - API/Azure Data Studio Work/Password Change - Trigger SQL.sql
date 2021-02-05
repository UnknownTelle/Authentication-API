CREATE TRIGGER password_change ON dbo.users

AFTER UPDATE
AS
BEGIN

DECLARE @user_id INT
SET @user_id = SCOPE_IDENTITY()

IF (UPDATE (user_password)) BEGIN
    INSERT INTO dbo.passwords 
    (
        user_id, date_changed
    )
    VALUES
    (
        @user_id, GETDATE()
    )
    COMMIT
END

END