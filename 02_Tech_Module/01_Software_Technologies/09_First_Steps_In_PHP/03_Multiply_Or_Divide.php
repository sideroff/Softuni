<!DOCTYPE HTML>
<html>
<head>
    <title></title>
</head>
<body>
<main>
    <form>
        <input type="text" name="num1">
        <input type="text" name="num2">
        <input type="text" name="num3">
        <input type="submit">
    </form>
    <?php
    if(isset($_GET['num1']) &&
        isset($_GET['num2']) &&
        isset($_GET['num3'])  ){

        $arr = [intval($_GET['num1']),intval($_GET['num2']),intval($_GET['num3'])];
        $zero = false;
        $negatives =0;
        foreach($arr as $val){
            if($val==0){
                $zero = true;
                break;
            }
            if($val<0){
                $negatives++;
            }
        }
        echo "zero $zero, negatives $negatives";
        if($zero || $negatives%2==0){
            echo "Positive";
            return;
        }
        else{
            echo "Negative";
        }
    }
    ?>
</main>
</body>
</html>