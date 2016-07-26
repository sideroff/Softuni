<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>04_Array_Indexes</title>
</head>
<body>
    <form>
        KeyValuePairs:
        <textarea name="key-value-pairs"></textarea>
        Delimiter:
        <input type="text" name="delimiter">
        Array size:
        <input type="text" name="array-size">
        <input type="submit">
    </form>
    <?php
        if(isset($_GET['key-value-pairs']) &&
            isset($_GET['delimiter']) &&
            isset($_GET['array-size'])){

            $input = $_GET['key-value-pairs'];
            $delimiter = $_GET['delimiter'];
            $size = $_GET['array-size'];

            $arr = [];
            for($i = 0; $i<$size; $i++){
                $arr[$i] = 0;
            }

            $input = explode("\n",$input);
            $input = array_map('trim',$input);

            foreach($input as $line){
                $splitted = explode($delimiter,$line);
                $arr[$splitted[0]] = $splitted[1];
            }

            foreach($arr as $entry){
                echo $entry . "<br>";
            }
        }
    ?>
</body>
</html>