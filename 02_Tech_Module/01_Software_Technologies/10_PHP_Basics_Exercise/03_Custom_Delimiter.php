<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>03_Custom_Delimiter</title>
</head>
<body>
    <form>
        Text:
        <textarea name="lines"></textarea>
        Delimiter:
        <input type="text" name="delimiter">
        <input type="submit">
        <?php
            if(isset($_GET['lines']) && isset($_GET['delimiter'])){
                $input = $_GET['lines'];
                $delimiter = $_GET['delimiter'];
                $input = explode("\n",$input);
                foreach ($input as $line){
                    $splittedLine = explode($delimiter, $line);
                    $splittedLine = array_map('trim',$splittedLine);
                    foreach($splittedLine as $word){
                        if($word == "Stop"){
                            break;
                        }
                        echo $word . "<br>";
                    }
                }

            }
        ?>
    </form>
</body>
</html>