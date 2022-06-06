<?php

$x_auth_token = '411cededc5c7a6cddd7d31142d4c4c71cc7a174374dde0bcab3d62c9cf03c67d';
$res = [];

try {
	if ($_POST['x-auth-token'] != $x_auth_token) {
		throw new Exception('Error: Token de autenticación incorrecto', 1);
	}

	include_once 'database.php';
	$db = new Database();
	$connection = $db->connect();
	if (!$connection) {
		throw new Exception('Error al conectar a la BD', 1);
	}

	$query = $connection -> prepare($_POST['query']);
	$result = $query -> execute(json_decode($_POST['params'], true));

	if (!$result) {
		throw new Exception('Error al ejecutar la consulta ' . $_POST['query'], 1);
	}
	
	if ($_POST['fetch'] == 'one') {
		$res['data'] = $query -> fetch(PDO::FETCH_ASSOC);
		$res['data'] = $res['data'] ? [$res['data']]: [];
		$res['result'] = $res['data'] ? true: false;
		$res['message'] = $res['data'] ? 'Operación correcta': 'No existe registro en la BD';
	} else if ($_POST['fetch'] == 'all') {
		$res['data'] = $query -> fetchAll(PDO::FETCH_ASSOC);
		$res['result'] = $res['data'] ? true: false;
		$res['message'] = $res['data'] ? 'Operación correcta': 'No existen registros en la BD';
	} else if ($_POST['fetch'] == 'result') {
		$res['result'] = $result ? true: false;
		$res['data'] = null;
		$res['message'] = $result ? 'Operación correcta': 'Ocurrió un error en la ejecución';
	} else {
		$res['message'] = 'Petición fetch inálida';
		$res['data'] = null;
        $res['result'] = false;
	}
	$res['status'] = 200;
} catch (Exception $e) {
	$res['status'] = 400;
	$res['message'] = $e -> getMessage();
	$res['data'] = null;
    $res['result'] = false;
} finally {
	//http_response_code($res['status']);
	header('Content-Type: application/json');
	echo json_encode($res, JSON_PRETTY_PRINT);
}