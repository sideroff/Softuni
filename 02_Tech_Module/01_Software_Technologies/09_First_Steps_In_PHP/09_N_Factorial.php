<!DOCTYPE HTML>
<html>
<head>
    <title></title>
</head>
<body>
<main>
    <form>
        N:<input type="text" name="num">
        <input type="submit">
    </form>
    <?php
    if(isset($_GET['num'])){
        $n = intval($_GET['num']);
        $sum = 1;
        for($i = 1; $i<=$n; $i++){
            $sum = $sum * $i;
        }
        echo $sum;
    }
    ?>
</main>
</body>
</html>