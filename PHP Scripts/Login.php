<?php
include ("inc/Credentials.inc");
error_reporting(0);

$username_email = $_POST[htmlentities("usernameemailPost")];
$user_password = hash('sha256', $_POST[htmlentities("passwordPost")]);

if ($username_email != "" && $user_password != "") {
    
    if (filter_var($username_email, FILTER_VALIDATE_EMAIL)) {
        $sql = "SELECT id, username, password, fuser, fpass FROM users WHERE email = ?";
        
        if ($stmt = $conn->prepare($sql)) {
            $stmt->bind_param('s', $username_email); // bind parameters for markers
            $stmt->execute(); // execute query
            $stmt->bind_result($id, $username, $db_password, $fuser, $fpass); // bind result variable
            $stmt->store_result(); // fetch value
            
            if ($stmt->num_rows == 1) {
                if ($stmt->fetch()) {
                    if (decrypt($db_password) == $user_password) {
                        echo "IN;" . $id . ";" . $username . ";" . $username_email . ";" . $fuser . ";" . $fpass;
                    } else {
                        echo "Wrong Password";
                    }
                }
            } else {
                echo "User does not exist";
            }
            $stmt->close();
        } else {
            die("Errormessage: " . $conn->error);
        }
    } else if (preg_match("/^[a-z0-9]+$/", $username_email)) {
        $sql = "SELECT id, email, password, fuser, fpass FROM users WHERE username = ?";
        
        if ($stmt = $conn->prepare($sql)) {
            $stmt->bind_param('s', $username_email); // bind parameters for markers
            $stmt->execute(); // execute query
            $stmt->bind_result($id, $email, $db_password, $fuser, $fpass); // bind result variable
            $stmt->store_result(); // fetch value
            
            if ($stmt->num_rows == 1) {
                if ($stmt->fetch()) {
                    if (decrypt($db_password) == $user_password) {
                        echo "IN;" . $id . ";" . $username_email . ";" . $email . ";" . $fuser . ";" . $fpass;
                    } else {
                        echo "Wrong Password";
                    }
                }
            } else {
                echo "User does not exist";
            }
            $stmt->close();
        } else {
            die("Errormessage: " . $conn->error);
        }
    } else {
        echo "Wrong username/email format, try again";
    }
    $conn->close();
}

function decrypt($password)
{
    include ("inc/Credentials.inc");
    $encrypt_method = "AES-256-CBC";
    $key = hash("sha256", $secret_key);
    $iv = substr(hash("sha256", $secret_iv), 0, 16);
    
    $d = openssl_decrypt(base64_decode($password), $encrypt_method, $key, 0, $iv);
    
    return $d;
}
?>
