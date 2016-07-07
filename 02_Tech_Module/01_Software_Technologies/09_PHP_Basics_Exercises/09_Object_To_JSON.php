<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>09_Object_To_JSON</title>
</head>
<body>
    <form>
        Data to
        <textarea name="input"></textarea>
        <input type="text" name="delimiter">
        <input type="submit">
    </form>
    <?php
    if(isset($_GET['input']) && isset($_GET['delimiter'])){

        $delimiter = $_GET['delimiter'];
        $input = explode("\n",$_GET['input']);
        $input = array_map('trim',$input);
        $input = array_filter($input);

        $object = [];
        foreach($input as $line){
            $splitted = explode($delimiter, $line);
            if(is_numeric($splitted[1])){
                $object[$splitted[0]] = intval($splitted[1]);
            }
            else{

                $object[$splitted[0]] = $splitted[1];
            }
        }

        echo(json_encode($object,JSON_UNESCAPED_SLASHES));
    }
    ?>
</body>
</html>