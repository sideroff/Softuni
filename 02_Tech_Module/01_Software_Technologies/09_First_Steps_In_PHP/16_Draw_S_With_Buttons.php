<!DOCTYPE HTML>
<html>
<head>
    <title></title>
</head>
<body>
<main>
    <?php
        for($i = 0; $i<9; $i++){
            if($i%4 ==0){
                for($j = 0; $j<5; $j++){
                    echo "<button style='background-color: blue'>1</button>";
                }
            }
            else{
                if($i<4){
                    echo "<button style='background-color: blue'>1</button>";
                    for($j = 0; $j<4; $j++){
                        echo "<button>0</button>";
                    }
                }
                else{
                    for($j = 0; $j<4; $j++){
                        echo "<button>0</button>";
                    }
                    echo "<button style='background-color: blue'>1</button>";
                }

            }
            echo "<br>";
        }
    ?>
</main>
</body>
</html>