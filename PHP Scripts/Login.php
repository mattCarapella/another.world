<?php
include ("inc/Credentials.inc");
error_reporting(0);

$user_email = $_POST[htmlentities("emailPost")];
$user_password = hash('sha256', $_POST[htmlentities("passwordPost")]);

if ($user_email != "" && $user_password != "") {
    
    $sql = "SELECT id, username, password, fuser, fpass FROM users WHERE email = ?";
    
    $stmt = $conn->prepare($sql);
    $stmt->bind_param('s', $user_email); // bind parameters for markers
    $stmt->execute(); // execute query
    $stmt->bind_result($id, $username, $db_password, $fuser, $fpass); // bind result variable
    $stmt->store_result(); // fetch value
    
    if ($stmt->num_rows == 1) {
        if ($stmt->fetch()) {
            if (decrypt($db_password) == $user_password) {
                echo "IN;".$id.";".$username.";".$user_email.";".$fuser.";".$fpass;
            } else {
                echo "Wrong Password";
            }
        }
    } else {
        echo "User does not exist";
    }
    $stmt->close();
} else {
    echo "Email and/or Password cannot be empty";
}
$conn->close();

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
