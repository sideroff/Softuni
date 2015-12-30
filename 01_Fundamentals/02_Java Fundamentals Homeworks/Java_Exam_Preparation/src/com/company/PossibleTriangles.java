package com.company;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;
/**
 * Created by Siderov on 7.11.2015 �..
 */
public class PossibleTriangles {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\s+");
        String sb = "";
        while(!input[0].equals("End")){
            List<Float> list = new ArrayList<>();
            list.add(Float.parseFloat(input[0]));
            list.add(Float.parseFloat(input[1]));
            list.add(Float.parseFloat(input[2]));
            Collections.sort(list);
            if(list.get(0)+list.get(1)>list.get(2)&&
                    list.get(1)+list.get(2)>list.get(0)&&
                    list.get(0)+list.get(2)>list.get(1)){
                sb+=String.format("%.2f+%.2f>%.2f\n", list.get(0), list.get(1), list.get(2));
            }
            input = sc.nextLine().split("\\s+");
        }
        if(sb.equals("")){
            System.out.println("No");
        }
        else{
            System.out.print(sb);
        }
    }
}
