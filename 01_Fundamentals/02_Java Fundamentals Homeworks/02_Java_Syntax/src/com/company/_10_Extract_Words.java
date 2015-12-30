package com.company;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 20.10.2015 ã..
 */
public class _10_Extract_Words {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Pattern pattern = Pattern.compile("[A-Za-z]+");

        // Get matcher on this String.
        Matcher m = pattern.matcher(sc.nextLine());
        while(m.find()){
            System.out.print(m.group()+" ");
        }
    }
}
