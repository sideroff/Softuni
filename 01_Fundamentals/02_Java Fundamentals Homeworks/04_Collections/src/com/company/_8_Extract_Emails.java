package com.company;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 28.10.2015 ã..
 */
public class _8_Extract_Emails {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Pattern regex = Pattern.compile("(?<=\\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@(?:[a-z]+\\-?[a-z]+\\.)+[a-z]+\\-?[a-z]+)\\b");
        Matcher match = regex.matcher(sc.nextLine());
        while(match.find()){
            System.out.println(match.group(1));
        }

    }
}
