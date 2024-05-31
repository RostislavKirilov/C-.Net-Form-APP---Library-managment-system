CREATE TABLE users
(
    id INT PRIMARY KEY IDENTITY(1,1),
    email VARCHAR(255) NULL,
    username VARCHAR(255) NULL,
    password VARCHAR(255) NULL,
    date_register DATE NULL
)

SELECT * FROM users