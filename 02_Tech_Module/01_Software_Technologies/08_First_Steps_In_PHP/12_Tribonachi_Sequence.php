<!DOCTYPE HTML>
<html>
<head>
    <title></title>
</head>
<body>
<main>
    <form>
        <input type="text" name="num">
        <input type="submit">
    </form>
    <?php
    if(isset($_GET['num'])){
        $n = intval($_GET['num']);
        $arr = [1,1,2];
        for($i =0; $i<$n; $i++){
            if(!isset($arr[$i])){
                $arr[$i] = $arr[$i-3] + $arr[$i-2] + $arr[$i-1];
            }
            echo $arr[$i] . "\n";
        }
    }
    ?>
</main>
</body>
</html>