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
        for($i = $n; $i>=1; $i--){
            if($n%$i !=0){
                echo $i . "\n";
            }
        }
    }
    ?>
</main>
</body>
</html>