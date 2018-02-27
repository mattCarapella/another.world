<?php

  include ("Credentials.php"); // Will not provide this php file due to security reasons

  $user_email = $_POST["emailPost"];
  $user_password = $_POST["passwordPost"];

  $sql = "SELECT password FROM users WHERE email = '".$user_email."' ";
  $result = mysqli_query($conn, $sql);


  if(mysqli_num_rows($result) > 0){
    while ($row = mysqli_fetch_assoc($result)){
      if($row['password'] == $user_password){
        echo "Login success";
      } else {
        echo "Password Incorrect";
      }
    }
  } else {
    echo "User Not Found";
  }

?>
