<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>07_Key_Multiple_Values</title>
</head>
<body>
<form>
    Pairs:
    <textarea name="key-value-pairs"></textarea>
    Delimiter:
    <input type="text" name="delimiter">
    Target key:
    <input type="text" name="target-key">
    <input type="submit">
</form>
<?php
if(isset($_GET['key-value-pairs']) && isset($_GET['delimiter']) && isset($_GET['target-key'])){
    $input = array_map('trim',explode("\n",$_GET['key-value-pairs']));
    $delimiter =$_GET['delimiter'];
    $targetKey = $_GET['target-key'];
    $arr = [];
    foreach($input as $line){
        $splitted = explode($delimiter, $line);
        if(!isset($arr[$splitted[0]])){
            $arr[$splitted[0]] = [];
        }
        array_push($arr[$splitted[0]],$splitted[1]);
    }
    if(isset($arr[$targetKey])){
        echo implode("<br>",$arr[$targetKey]);
    }
    else{
        echo "None";
    }
}
?>
</body>
</html>