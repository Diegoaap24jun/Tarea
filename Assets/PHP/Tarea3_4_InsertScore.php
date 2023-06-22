<?php
//header("Content-type: application/json");
$mysqli = new mysqli("localhost","root","","tarea3_4");

if ($mysqli->connect_error)
{
    echo "error";
}
else
{

    $nombre = $_POST["nombre"];
    $nombreNivel = $_POST["nombreNivel"];
    $puntaje = $_POST["puntaje"];

    $sql = "SELECT usuario_id 
            FROM usuarios 
            WHERE nombre=?;";
    $query = $mysqli->prepare($sql);
    $query->bind_param("s",$nombre);
    $query->execute();
    $result = $query->get_result();
    $usuario_id = 0;
    if ($result->num_rows > 0)
    {

        $usuario_id = $result -> fetch_all(MYSQLI_ASSOC)[0]["usuario_id"];

    }
    else
    {
        $sql = "INSERT INTO usuarios (usuario_id,nombre) 
                VALUES (NULL,?);";
        $query = $mysqli->prepare($sql);
        $query->bind_param("s",$nombre);
        $query->execute();

        $sql = "SELECT usuario_id 
                FROM usuarios 
                WHERE nombre=?;";
        $query = $mysqli->prepare($sql);
        $query->bind_param("s",$nombre);
        $query->execute();
        $result = $query->get_result();
        $usuario_id = $result -> fetch_all(MYSQLI_ASSOC)[0]["usuario_id"];
    }

    $sql = "SELECT nivel_id 
            FROM niveles 
            WHERE nombreNivel=?;";
    $query = $mysqli->prepare($sql);
    $query->bind_param("s",$nombreNivel);
    $query->execute();
    $result = $query->get_result();
    $nivel_id = 0;
    if ($result->num_rows > 0)
    {
        $nivel_id = $result -> fetch_all(MYSQLI_ASSOC)[0]["nivel_id"];

        $sql = "INSERT INTO usuarios_niveles (usuario_nivel_id,usuario_id,nivel_id,puntaje) 
                VALUES (NULL,?,?,?);";
        $query = $mysqli->prepare($sql);
        $query->bind_param("iii",$usuario_id,$nivel_id,$puntaje);
        if($query->execute())
        {
            echo "Funcionó";
        }
        else
        {
            echo "No funcionó";
        }
    }

    $mysqli->close();
}