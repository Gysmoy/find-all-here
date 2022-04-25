<?php

$request = $_GET;
$response = [];
try {
    require_once 'database.php';
    $db = new Database();
    $connection = $db->connect();
    if ($connection == false) {
        throw new Exception('No se pudo conectar a la base de datos', 1);
    }
    if ($request['id'] == '') {
        throw new Exception('Error al obtener datos de imagen', 1);
    }
    if (!($request['size'] == 'mini' || $request['size'] == 'full')) {
        throw new Exception('Tamaño de imagen no admitida', 1);
    }
    
    // Tipos de imagen
    switch ($request['type']) {
        case 'user':
            $size = 'profile_' . $request['size'];
            $query = $connection -> prepare('SELECT
                ' . $size . ' AS profile,
                profile_type AS type
            FROM USERS
            WHERE id = ?
            ');
            $query -> execute([$request['id']]);
            $row = $query -> fetch(PDO::FETCH_ASSOC);
            if ($row && !empty($row['profile'])) {
                $response['source'] = $row['profile'];
                $response['type'] = $row['type'];
            } else {
                throw new Exception('Error al obtener datos de imagen', 1);
            }
            break;
        case 'product':
            $size = 'image_' . $request['size'];
            $query = $connection -> prepare('SELECT
                ' . $size . ' AS image,
                image_type AS type
            FROM PRODUCTS
            WHERE id = ?
            ');
            $query -> execute([$request['id']]);
            $row = $query -> fetch(PDO::FETCH_ASSOC);
            if ($row && !empty($row['image'])) {
                $response['source'] = $row['image'];
                $response['type'] = $row['type'];
            } else {
                throw new Exception('Error al obtener datos de imagen', 1);
            }
            break;
        default:
            throw new Exception('La resolución solicitada no está disponible', 1);
            break;
    }
    $response['status'] = 200;
} catch (Exception $e) {
    $response['status'] = 400;
    $file = $request['type'] == 'user' ? 'user_not_found.png': 'product_not_found.png';
    $response['source'] = file_get_contents($file);
    $response['type'] = 'image/png';
} finally {
    //http_response_code($response['status']);
    header('Content-Type: ' . $response['type']);
    echo $response['source'];
}