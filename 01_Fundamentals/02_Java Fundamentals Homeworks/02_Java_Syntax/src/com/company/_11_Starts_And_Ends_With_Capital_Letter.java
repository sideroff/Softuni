package com.company;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 20.10.2015 ã..
 */
public class _11_Starts_And_Ends_With_Capital_Letter {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Pattern pattern = Pattern.compile("\\b[A-Z][a-zA-Z]*[A-Z]\\b|\\b[A-Z]\\b");

        // Get matcher on this String.
        Matcher m = pattern.matcher(sc.nextLine());
        while(m.find()){
            System.out.print(m.group()+" ");
        }
    }
}
