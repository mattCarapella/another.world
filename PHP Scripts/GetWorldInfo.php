<?php
include ("inc/Credentials.inc");
error_reporting(0);

$world_id = $_POST[htmlentities("worldidPost")];

if ($world_id > 0){
	$sql = "SELECT skybox, ground, timespeed FROM universeinfo WHERE world_id = ?";
	$stmt = $conn->prepare($sql);
	$stmt->bind_param('i', $world_id);
	$stmt->execute();
	$stmt->bind_result($skybox, $ground, $timespeed);
	$stmt->fetch();

	$timespeed = 0;

	echo $skybox.";".$ground.";".$timespeed."\n";
	$stmt->close();

	$sql2 = "SELECT model_id, X, Y, Z, RX, RY, RZ FROM worldinfo WHERE world_id = ?";
	$stmt2 = $conn->prepare($sql2);
	$stmt2->bind_param('i', $world_id);
	$stmt2->execute();
	$stmt2->bind_result($model_id, $x, $y, $z, $rx, $ry, $rz);
	$stmt2->store_result();

	if ($stmt2->num_rows > 0){
	    while ($stmt2->fetch()){
	        echo $model_id.";".$x.";".$y.";".$z.";".$rx.";".$ry.";".$rz."\n";
	    }
	}
}	

?>
