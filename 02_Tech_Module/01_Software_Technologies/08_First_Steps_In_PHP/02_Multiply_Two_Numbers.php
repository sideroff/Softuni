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
    if(isset($_GET['num1']) && isset($_GET['num1']) ){
        echo intval($_GET['num1'])*intval($_GET['num2']);
    }
    ?>
</main>
</body>
</html>