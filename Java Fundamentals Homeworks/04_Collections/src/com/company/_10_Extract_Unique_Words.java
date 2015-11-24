package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

/**
 * Created by Siderov on 28.10.2015 ã..
 */
public class _10_Extract_Unique_Words {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        ArrayList<String> uniques = new ArrayList<String>();
        ArrayList<String> input = new ArrayList(Arrays.asList(sc.nextLine().toLowerCase().split(" ")));
        for (String s : input) {
            if(!uniques.contains(s))uniques.add(s);
        }
        for (String unique : uniques) {
            System.out.print(unique + " ");
        }
        
    }
}
