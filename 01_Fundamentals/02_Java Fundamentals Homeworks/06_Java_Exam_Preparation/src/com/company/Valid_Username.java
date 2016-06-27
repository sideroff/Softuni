package com.company;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

/**
 * Created by Siderov on 7.11.2015 �..
 */
public class Valid_Username {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("(?:\\s+|\\/|\\\\|\\(|\\))+");
        Integer indexOfMaxSum = Integer.MIN_VALUE;
        Integer maxSum = Integer.MIN_VALUE;
        List<String> validUsernames = new ArrayList<>();
        for (int i = 0; i < input.length-1; i++) {
            Pattern pattern = Pattern.compile("([A-Za-z0-9_]+)");
            Matcher matcher = pattern.matcher(input[i]);
            Integer length = 0;
            while(matcher.find()){
                length+=matcher.group(1).length();
            }
            if(length>2&&length<26&&length==input[i].length()) validUsernames.add(input[i]);
        }
        //String[] usernames = validUsernames.toArray();
        System.out.printf("%s\n%s",input[indexOfMaxSum],input[indexOfMaxSum+1]);
    }
}
