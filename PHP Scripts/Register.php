<?php
include ("inc/Credentials.inc");
error_reporting(0);

$user_username = $_POST[htmlentities("usernamePost")];
$user_email = $_POST[htmlentities("emailPost")];
$user_password = hash('sha256', $_POST[htmlentities("passwordPost")]);

$user_username_query = "SELECT username FROM users WHERE username = ?";
$username_stmt = $conn->prepare($user_username_query);
$username_stmt->bind_param('s', $user_username);
$username_stmt->execute();
$username_stmt->store_result();

$user_email_query = "SELECT email FROM users WHERE email = ?";
$email_stmt = $conn->prepare($user_email_query);
$email_stmt->bind_param('s', $user_email);
$email_stmt->execute();
$email_stmt->store_result();

if ($user_username != "" && $user_email != "" && $user_password != "") {
    if ($username_stmt->num_rows != 0) {
        echo ("Username is already taken");
        $username_stmt->close();
        $email_stmt->close();
    } else if ($email_stmt->num_rows != 0) {
        echo ("Email address is already being used with a different username");
        $username_stmt->close();
        $email_stmt->close();
    } else {    
        $username_stmt->close();
        $email_stmt->close();
        
        $sql = "INSERT INTO users (username, email, password) VALUES (?, ?, ?)";
        
        if ($stmt = $conn->prepare($sql)) {
            $stmt->bind_param('sss', $user_username, $user_email, encrypt($user_password));
            $stmt->execute();
            $stmt->close();
            echo "Registration Successful";
        } else {
            echo "Something went wrong";
        }
    }
} else {
    echo "Fields cannot be empty";
}

$conn->close();

function encrypt($password)
{
    include ("inc/Credentials.inc");
    $encrypt_method = "AES-256-CBC";
    $key = hash('sha256', $secret_key);
    $iv = substr(hash('sha256', $secret_iv), 0, 16);
    
    $e = openssl_encrypt($password, $encrypt_method, $key, 0, $iv);
    $e = base64_encode($e);
    
    return $e;
}

?>
