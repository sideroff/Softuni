<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>02_Print_Lines</title>
</head>
<body>
    <form>
        <textarea name="lines"></textarea>
        <input type="submit">
    </form>
    <?php
        if(isset($_GET['lines'])){
            $input = $_GET['lines'];
            $input = explode("\n", $input);
            $input = array_map('trim', $input);
            $current = 0;
            while($input[$current] != "Stop"){
                echo $input[$current] . '<br>';
                $current++;
            }
        }
    ?>
</body>
</html>