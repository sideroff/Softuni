package com.company;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

//Run Usinc CTRL+Shift+F10
//find number of substring occurances in a string;

//Zero test #2 doesnt work (Input: aaaaaa\n aa\n | Expected output: 5 | My output: 3 ) if you find a way to make this work with regex tell me
public class _7_Substring_Occurances {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine().toLowerCase();
        Pattern word = Pattern.compile(sc.nextLine().toLowerCase());
        Matcher matcher = word.matcher(input);

        int count = 0;
        while(matcher.find()){
            count++;
        }
        System.out.println(count);
    }
}
