<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>10_Dates</title>
</head>
<body>
    <form>
        Commands: (add/subtract &lt;number_of_days&gt;)
        <textarea name="commands"></textarea>
        Date in format dd/mm/yyyy:
        <input type="text" name="date">
        Format for output date: (ex. "d F y")
        <input type="text" name="format">
        <input type="submit">
    </form>
    <?php
        if(isset($_GET['commands']) && isset($_GET['date']) && isset($_GET['format'])){
            $commands = explode("\n", $_GET['commands']);
            $date = DateTime::createFromFormat ( "d/m/Y" , $_GET['date']);
            $format = $_GET['format'];

            foreach($commands as $command){
                $splitted = explode(" ", $command);
                $modifier = '-1 day';
                if($splitted[0] == "add"){
                    $modifier = '+1 day';
                }
                $daysCount = intval($splitted[1]);
                for($i = 0; $i<$daysCount; $i++){
                    $date->modify($modifier);
                }
            }
            echo $date->format($format);
        }
    ?>
</body>
</html>