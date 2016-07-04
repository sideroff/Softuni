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

        for($i = 1; $i<=$n; $i++){
            echo "<button>$i</button>";
        }
    }
    ?>
</main>
</body>
</html>