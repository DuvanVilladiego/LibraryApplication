USE LIBRARYDB;

CREATE TABLE AUTHOR_TBL (
	AUTHOR_ID INT PRIMARY KEY IDENTITY(1,1),
	FULL_NAME VARCHAR(50),
	BIRTH_DATE DATE,
	BIRTH_TOWN VARCHAR(100),
	EMAIL VARCHAR(50)
);

CREATE TABLE BOOK_TBL (
    BOOK_ID INT PRIMARY KEY IDENTITY(1,1),
    TITLE VARCHAR(100),
    YEAR_PUBLISHED INT,
    GENRE VARCHAR(50),
    NUM_PAGES INT,
    AUTHOR_ID INT,
    FOREIGN KEY (AUTHOR_ID) REFERENCES AUTHOR_TBL(AUTHOR_ID)
);

-- Insertar datos en AUTHOR_TBL
INSERT INTO AUTHOR_TBL (FULL_NAME, BIRTH_DATE, BIRTH_TOWN, EMAIL)
VALUES
    ('John Doe', '1980-01-01', 'Anytown', 'john.doe@example.com'),
    ('Jane Smith', '1990-05-15', 'Othertown', 'jane.smith@example.com'),
    ('Bob Johnson', '1975-11-20', 'Newtown', 'bob.johnson@example.com');

-- Insertar datos en BOOK_TBL
INSERT INTO BOOK_TBL (TITLE, YEAR_PUBLISHED, GENRE, NUM_PAGES, AUTHOR_ID)
VALUES
    ('Introduction to Programming', 2020, 'Programming', 300, 1),
    ('The Mystery of the Lost Key', 2018, 'Mystery', 250, 2),
    ('Historical Journey', 2019, 'History', 400, 3);