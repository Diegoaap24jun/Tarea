<?php
//Importante para la lectura del JSON.
header("Content-type: application/json");
$mysqli = new mysqli("localhost","root","","tarea3_4");

if ($mysqli->connect_error)
{
    echo "error";
}
else
{
    $sql = "SELECT SUM(puntaje) AS Suma
            FROM usuarios_niveles
            INNER JOIN usuarios
            ON usuarios.usuario_id=usuarios_niveles.usuario_id
            WHERE nombre=?;";

    $query = $mysqli->prepare($sql);
    $nombre = $_POST["nombre"];
    $query->bind_param("s", $nombre);
    $query->execute();
    $result = $query->get_result();
    $data = array();

    //JSON Opción 2
    $data = $result -> fetch_all(MYSQLI_ASSOC);
    echo json_encode(["data" => $data]);

   
    $mysqli->close();
}