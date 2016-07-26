<!DOCTYPE HTML>
<html>
<head>
    <title></title>
</head>
<body>
<main>
    <table>
        <th>
            <td>Red</td>
            <td>Green</td>
            <td>Blue</td>
        </th>
        <?php
        $color = 0;
            for($i=0;$i<5;$i++){
                $color+=51;
                echo "<tr>";
                    echo "<td style='background-color: rgb($color,0,0)'></td>";
                    echo "<td style='background-color: rgb(0,$color,0)'></td>";
                    echo "<td style='background-color: rgb(0,0,$color)'></td>";
                echo "</tr>";
            }
        ?>
    </table>
</main
</body>
</html>