<?php

class Database{
    private $host;
    private $db;
    private $user;
    private $password;
    private $charset;
    public function __construct(){
        $this -> host = 'http://sql629.main-hosting.eu/';
        $this -> db = 'u142416532_fah_db';
        $this -> user = 'u142416532_fah_user';
        $this -> password = '80=]lr3:Kp';
        $this -> charset = 'utf8mb4';
    }
    function connect(){
        try{
            $connection = "mysql:host=" . $this->host . ";dbname=" . $this->db . ";charset=" . $this->charset;
            $options = [
                PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
                PDO::ATTR_EMULATE_PREPARES   => false,
            ];
            $pdo = new PDO($connection, $this->user, $this->password, $options);
            return $pdo;
        }catch(PDOException $e){
            return false;
        }
    }
}

?>