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
        <input type="submit">
    </form>
    <?php
    if(isset($_GET['num1']) && isset($_GET['num2'])){
        $outer = intval($_GET['num1']);
        $inner = intval($_GET['num2']);
        echo "<ul>";
        for($i = 1; $i<=$outer; $i++){
            echo "<li>List $i";
            echo "<ul>";
            for($j = 1; $j<=$inner; $j++) {
                echo "<li>Element $i.$j</li>";
            }
            echo "</ul>";
            echo "</li>";


        }
        echo "</ul>";
    }
    ?>
</main>
</body>
</html>