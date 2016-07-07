<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>01_Reverse_Numbers</title>
</head>
<body>

<form>
    Text:
    <input type="text" name="numbers">
    Delimiter:
    <input type="text" name="delimiter">
    <input type="submit">
</form>
<?php
    if(isset($_GET['numbers']) && isset($_GET['delimiter'])){

        $delimiter = $_GET['delimiter'];
        $numbers = $_GET['numbers'];

        $arr = explode($delimiter,$numbers);
        $arr = array_map('trim',$arr);
        $arr = array_filter($arr);

        for($i = count($arr) -1; $i>=0; $i--){
            echo($arr[$i] . '<br>');
        }
    }
?>
</body>
</html>