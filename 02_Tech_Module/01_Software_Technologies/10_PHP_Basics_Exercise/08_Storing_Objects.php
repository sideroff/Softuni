<!doctype html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>08_Storing_Objects</title>
    </head>
    <body>
        <form>
            <textarea name="input"></textarea>
            <input type="text" name="delimiter">
            <input type="submit">
        </form>
        <?php
            if(isset($_GET['input']) && isset($_GET['delimiter'])){
                class Person {
                    public $name;
                    public $age;
                    public $grade;
                    function __construct(string $name, int $age, float $grade )
                    {
                        $this->name = $name;
                        $this->age = $age;
                        $this->grade = $grade;
                    }
                }

                $delimiter = $_GET['delimiter'];
                $input = explode("\n",$_GET['input']);
                $input = array_map('trim',$input);

                $people = [];
                foreach($input as $line){
                    $splitted = explode($delimiter, $line);
                    $newPerson = new Person($splitted[0],$splitted[1],$splitted[2]);
                    array_push($people,$newPerson);
                }

                foreach($people as $person){
                    echo"<ul>";
                    echo"<li>Name: $person->name</li>";
                    echo"<li>Age: $person->age</li>";
                    echo"<li>Grade: $person->grade</li>";
                    echo"</ul>";
                }

            }
        ?>
    </body>
</html>