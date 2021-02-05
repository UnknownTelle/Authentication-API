CREATE TABLE users (
    user_id INT NOT NULL IDENTITY,
    first_name VARCHAR(35) NOT NULL,
    last_name VARCHAR(35) NOT NULL,
    user_email VARCHAR(50) NOT NULL,
    user_password VARCHAR(15) NOT NULL

    PRIMARY KEY (user_id)
)

CREATE TABLE passwords (
    password_id INT NOT NULL IDENTITY,
    user_id INT NOT NULL,
    date_changed DATETIME NOT NULL

    PRIMARY KEY (password_id)
    FOREIGN KEY (user_id) REFERENCES users(user_id)
)

CREATE TABLE session_table (
    session_id INT NOT NULL IDENTITY,
    user_id INT NOT NULL,
    session_time DATETIME NOT NULL

    PRIMARY KEY (session_id)
    FOREIGN KEY (user_id) REFERENCES users(user_id)
)