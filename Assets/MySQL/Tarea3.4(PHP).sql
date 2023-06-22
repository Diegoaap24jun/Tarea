DROP DATABASE IF EXISTS Tarea3_4;
CREATE DATABASE Tarea3_4;

USE Tarea3_4;

CREATE TABLE usuarios(
    usuario_id INT NOT NULL  AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    PRIMARY KEY (usuario_id)
);

CREATE TABLE niveles(
    nivel_id INT NOT NULL  AUTO_INCREMENT,
    nombreNivel VARCHAR(100) NOT NULL,
    PRIMARY KEY (nivel_id)
);

CREATE TABLE usuarios_niveles(
    usuario_nivel_id INT NOT NULL AUTO_INCREMENT,
    usuario_id INT NOT NULL,
    nivel_id INT NOT NULL,
    puntaje INT NOT NULL,
    PRIMARY KEY (usuario_nivel_id),
    CONSTRAINT fk_usuarios_niveles_usuarios
    FOREIGN KEY (usuario_id) 
    REFERENCES usuarios(usuario_id),
    CONSTRAINT fk_usuarios_niveles_niveles
    FOREIGN KEY (nivel_id) 
    REFERENCES niveles(nivel_id)
    
);

INSERT INTO usuarios (usuario_id,nombre)
VALUES (null,"Carolina");
INSERT INTO usuarios (usuario_id,nombre)
VALUES (null,"Andres");

INSERT INTO niveles (nivel_id,nombreNivel)
VALUES (null,"Arequipa");
INSERT INTO niveles (nivel_id,nombreNivel)
VALUES (null,"Cuzco");
INSERT INTO niveles (nivel_id,nombreNivel)
VALUES (null,"Lima");

INSERT INTO usuarios_niveles (usuario_nivel_id,usuario_id,nivel_id,puntaje)
VALUES (null,1,1,400);
INSERT INTO usuarios_niveles (usuario_nivel_id,usuario_id,nivel_id,puntaje)
VALUES (null,1,2,700);
INSERT INTO usuarios_niveles (usuario_nivel_id,usuario_id,nivel_id,puntaje)
VALUES (null,2,2,200);
INSERT INTO usuarios_niveles (usuario_nivel_id,usuario_id,nivel_id,puntaje)
VALUES (null,2,3,600);

/*Ejercicio 1:*/
SELECT *
FROM usuarios;

/*Ejercicio 2:*/
SELECT *
FROM niveles
WHERE nombreNivel="Arequipa"

/*Ejercicio 3:*/
SELECT *
FROM usuarios
INNER JOIN usuarios_niveles
ON usuarios_niveles.usuario_id=usuarios.usuario_id
INNER JOIN niveles
ON usuarios_niveles.nivel_id=niveles.nivel_id
ORDER BY nombre DESC;

/*Ejercicio 3:*/
SELECT niveles.nombreNivel AS NombreDelNivel,usuarios_niveles.puntaje,usuarios.usuario_id,usuarios.nombre AS NombreDeUsuario
FROM niveles
INNER JOIN usuarios_niveles
ON usuarios_niveles.nivel_id=niveles.nivel_id
INNER JOIN usuarios
ON usuarios_niveles.usuario_id=usuarios.usuario_id
WHERE nombre="Carolina";