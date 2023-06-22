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
    $sql = "SELECT SUM(puntaje)
            FROM usuarios_niveles
            WHERE usuarios_niveles.usuario_id=?;";

    $query = $mysqli->prepare($sql);
    $id = $_POST["id"];
    $query->bind_param("i", $id);
    $query->execute();
    $result = $query->get_result();
    $data = array();

    //JSON Opción 2
    $data = $result -> fetch_all(MYSQLI_ASSOC);
    echo json_encode(["data" => $data]);

   
    $mysqli->close();
}