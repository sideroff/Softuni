package com.company;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Created by Siderov on 7.11.2015 ã..
 */
public class MirrorNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        sc.nextLine();
        List<String> list = Arrays.stream(sc.nextLine().split("\\s+")).collect(Collectors.toList());
        boolean printNo=true;
        for (int i = 0; i < list.size(); i++) {
            for (int j = i; j < list.size(); j++) {
                if(list.get(i).charAt(0)==list.get(i).charAt(1)&&list.get(i).charAt(1)==list.get(i).charAt(2)&&list.get(i).charAt(2)==list.get(i).charAt(3)) continue;
                if(list.get(i).equals(new StringBuilder(list.get(j)).reverse().toString())){
                    System.out.printf("%s<!>%s\n",list.get(i).toString(),list.get(j).toString());
                    printNo=false;
                }

            }

        }
        if(printNo) System.out.println("No");

    }

}
