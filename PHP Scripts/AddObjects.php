<?php
include ("inc/Credentials.inc");
error_reporting(0);

$world_id = $_POST[htmlentities("worldidPost")];
$model_id = $_POST[htmlentities("modelidPost")];
$model_x = $_POST[htmlentities("modelxPost")];
$model_y = $_POST[htmlentities("modelyPost")];
$model_z = $_POST[htmlentities("modelzPost")];
$rotation_x = $_POST[htmlentities("rotationxPost")];
$rotation_y = $_POST[htmlentities("rotationyPost")];
$rotation_z = $_POST[htmlentities("rotationzPost")];

$sql = "INSERT INTO worldinfo (world_id, model_id, X, Y, Z, RX, RY, RZ) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

$stmt = $conn->prepare($sql);
if ($stmt) {
    $stmt->bind_param('iidddddd', $world_id, $model_id, $model_x, $model_y, $model_z, $rotation_x, $rotation_y, $rotation_z);
    $stmt->execute();
}
?>
