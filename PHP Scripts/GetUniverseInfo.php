<?php
include ("inc/Credentials.inc");
error_reporting(0);

$user_id = $_POST[htmlentities("idPost")];

$sql = "SELECT * FROM universeinfo";

if ($user_id > 0) {

	$stmt = $conn->prepare($sql);
	$stmt->execute();
	$stmt->bind_result($world_id, $user_id, $user_username, $title, $description, $x, $y, $z, $skybox, $ground, $timespeed);
	$stmt->store_result();

	if ($stmt->num_rows > 0) {
		while ($stmt->fetch()){
			echo $world_id . ";" .$user_id. ";" .$user_username. ";" .$title. ";" .$description. ";" .$x. ";" .$y. ";" .$z. "\n"; 
		}
	}
}

?>
