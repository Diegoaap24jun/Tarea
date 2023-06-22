<?php
header("Content-type: application/json");
$mysqli = new mysqli("localhost","root","","tarea3_4");

if ($mysqli->connect_error)
{
    echo "error";
}
else
{
    $nombre = $_POST["nombre"];
    $nombreNivel = $_POST["nombreNivel"];

    $sql = "SELECT puntaje 
            FROM usuarios_niveles 
            INNER JOIN usuarios 
            ON usuarios_niveles.usuario_id = usuarios.usuario_id
            INNER JOIN niveles 
            ON usuarios_niveles.nivel_id = niveles.nivel_id
            WHERE nombre=? 
            AND nombreNivel=?;";
    $query = $mysqli->prepare($sql);
    $query->bind_param("ss",$nombre,$nombreNivel);
    $query->execute();
    $result = $query->get_result();
    if ($result->num_rows > 0)
    {

        $data = $result->fetch_all(MYSQLI_ASSOC);
        echo json_encode(["data" => $data]);
    }
    else
    {
        echo json_encode(["data" => []]);
    }
}
    
