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

        for($i =$n; $i>1; $i--){
            $isPrime = true;
            for($j = $i-1; $j>1; $j--){
                if($i%$j==0){
                    $isPrime=false;
                    break;
                }

            }
            if($isPrime){
                echo($i . "\n");
            }
        }
    }
    ?>
</main>
</body>
</html>