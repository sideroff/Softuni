<!DOCTYPE HTML>
<html>
<head>
    <title></title>
</head>
<body>
<main>
    <form>
        <input type="text" name="num1">
        <input type="submit">
    </form>
    <?php
    if(isset($_GET['num'])){
        $n = intval($_GET['num']);
        for($i = 1; $i<=$n; $i++){
            if($i%2 ==0){
                echo $i . " ";                
            }
        }
    }
    ?>
</main>
</body>
</html>