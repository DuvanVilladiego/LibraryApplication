USE LIBRARYDB;

CREATE TABLE AUTHOR_TBL (
	AUTHOR_ID INT PRIMARY KEY IDENTITY(1,1),
	FULL_NAME VARCHAR(50) NOT NULL,
	BIRTH_DATE DATE NOT NULL,
	BIRTH_TOWN VARCHAR(100) NOT NULL,
	EMAIL VARCHAR(50) NOT NULL
);

CREATE TABLE BOOK_TBL (
    BOOK_ID INT PRIMARY KEY IDENTITY(1,1),
    TITLE VARCHAR(100) NOT NULL,
    YEAR_PUBLISHED INT NOT NULL,
    GENRE VARCHAR(50) NOT NULL,
    NUM_PAGES INT NOT NULL,
    AUTHOR_ID INT NOT NULL,
    FRONT_PAGE VARCHAR(150) NOT NULL,
    FOREIGN KEY (AUTHOR_ID) REFERENCES AUTHOR_TBL(AUTHOR_ID)
);

-- Insertar datos en AUTHOR_TBL
INSERT INTO AUTHOR_TBL (FULL_NAME, BIRTH_DATE, BIRTH_TOWN, EMAIL)
VALUES
    ('John Doe', '1980-01-01', 'Anytown', 'john.doe@example.com'),
    ('Jane Smith', '1990-05-15', 'Othertown', 'jane.smith@example.com'),
    ('Bob Johnson', '1975-11-20', 'Newtown', 'bob.johnson@example.com');

-- Insertar datos en BOOK_TBL
INSERT INTO BOOK_TBL (TITLE, YEAR_PUBLISHED, GENRE, NUM_PAGES, AUTHOR_ID, FRONT_PAGE)
VALUES
    ('Introduction to Programming', 2020, 'Programming', 300, 1, 'https://edit.org/images/cat/portadas-libros-big-2019101610.jpg'),
    ('The Mystery of the Lost Key', 2018, 'Mystery', 250, 2, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1664300156i/62808448.jpg'),
    ('Historical Journey', 2019, 'History', 400, 3, 'https://www.irinadelgado.com/wp-content/uploads/2020/04/herramienta-ejemplos-2.png');

select * from BOOK_TBL