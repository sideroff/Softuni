package com.company;

import java.util.Scanner;

/**
 * Created by Siderov on 1.11.2015 ã..
 */
public class Letters_Change_Numbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double sum =0;
        String[] numbers = sc.nextLine().trim().split("\\s+");
        for (String number : numbers) {
            double n = Integer.parseInt(number.substring(1, number.length() - 1));
            char first = number.charAt(0);
            char last = number.charAt(number.length()-1);
            if(first>='A'&&first<='Z'){
                n/=first-64;
            }
            if(first>='a'&&first<='z'){
                n*=first-96;
            }
            if(last>='A'&&last<='Z'){
                n-=last-64;
            }
            if(last>='a'&&last<='z'){
                n+=last-96;
            }
            sum+=n;
        }
        System.out.printf("%.2f",sum);
    }
}
