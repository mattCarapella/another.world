<?php

  include ("Credentials.php"); // Will not provide this php file due to security reasons

  $username = $_POST["usernamePost"];
  $email = $_POST["emailPost"];
  $password = $_POST["passwordPost"];

  $sql = "INSERT INTO users (username, email, password) VALUES ('".$username."','".$email."','".$password."')";
  $result = mysqli_query($conn, $sql);

  if (!$result) echo "There was an error";
  else echo "Success";

?>
