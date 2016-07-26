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
                    echo intval($_GET['num'])*2;
                }
            ?>
        </main>
    </body>
</html>