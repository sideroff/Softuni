<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>06_Key_Value_Pairs</title>
</head>
<body>
    <form>
        Pairs:
        <textarea name="key-value-pairs"></textarea>
        Delimiter:
        <input type="text" name="delimiter">
        Target key:
        <input type="text" name="target-key">
        <input type="submit">
    </form>
    <?php
        if(isset($_GET['key-value-pairs']) && isset($_GET['delimiter']) && isset($_GET['target-key'])){
            $input = explode("\n",$_GET['key-value-pairs']);
            $delimiter =$_GET['delimiter'];
            $targetKey = $_GET['target-key'];
            $arr = [];
            foreach($input as $line){
                $splitted = explode($delimiter, $line);
                $arr[$splitted[0]] = $splitted[1];
            }
            if(isset($arr[$targetKey])){
                echo $arr[$targetKey];
            }
            else{
                echo "None";
            }
        }
    ?>
</body>
</html>