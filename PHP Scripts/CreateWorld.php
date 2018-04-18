<?php
include ("inc/Credentials.inc");
error_reporting(0);

$user_id = $_POST[htmlentities("idPost")];
$user_username = $_POST[htmlentities("usernamePost")];
$user_worldname = $_POST[htmlentities("worldNamePost")];
$user_worldinfo = $_POST[htmlentities("worldInfoPost")];
$user_worldsky = $_POST[htmlentities("worldSkyPost")];
$user_worldground = $_POST[htmlentities("worldGroundPost")];
$X = $_POST[htmlentities("xPost")];
$Y = $_POST[htmlentities("yPost")];
$Z = $_POST[htmlentities("zPost")];

$sql = "INSERT INTO universeinfo (user_id, username, Title, Description, X, Y, Z, skybox, ground) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

$stmt = $conn->prepare($sql);
if ($stmt && ($user_id > 0)) {
    $stmt->bind_param('isssdddii', $user_id, $user_username, $user_worldname, $user_worldinfo, $X, $Y, $Z, $user_worldsky, $user_worldground);
    $stmt->execute();
}
?>
