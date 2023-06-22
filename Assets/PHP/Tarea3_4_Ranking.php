<?php
header("Content-type: application/json");
$mysqli = new mysqli("localhost","root","","tarea3_4");

if ($mysqli->connect_error)
{
    echo "error";
}
else
{
    $nombreNivel = $_POST["nombreNivel"];

    $sql = "SELECT niveles.nombreNivel AS NombreDelNivel,usuarios_niveles.puntaje AS Puntaje,usuarios.nombre AS NombreDeUsuario
            FROM niveles
            INNER JOIN usuarios_niveles
            ON usuarios_niveles.nivel_id=niveles.nivel_id
            INNER JOIN usuarios
            ON usuarios_niveles.usuario_id=usuarios.usuario_id
            WHERE nombreNivel=?
            ORDER BY puntaje DESC;";

    $query = $mysqli->prepare($sql);
    $query->bind_param("s",$nombreNivel);
    $query->execute();
    $result = $query->get_result();
    if ($result->num_rows > 0)
    {
        $data = $result->fetch_all(MYSQLI_ASSOC);
        echo json_encode(["data" => $data]);
    }
    else
    {
        echo "Error";
    }
}