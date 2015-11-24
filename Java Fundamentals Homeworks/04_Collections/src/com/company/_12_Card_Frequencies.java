package com.company;

import java.util.*;

/**
 * Created by Siderov on 28.10.2015 ã..
 */
public class _12_Card_Frequencies {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("(\\W+)");
        System.out.println();
        Map<String,Integer> appearances = new HashMap<>();
        for (String s : input) {
            if(!appearances.containsKey(s))appearances.put(s, 1);
            else appearances.put(s, appearances.get(s)+1);
        }

        for (Map.Entry<String, Integer> entry : appearances.entrySet()) {
            System.out.printf("%s appears in input %.2f",entry.getKey(), (float)input.length*entry.getValue());
            System.out.println("% of the time.");
        }

    }
}
