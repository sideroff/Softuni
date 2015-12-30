package com.company;

import java.util.Scanner;

/**
 * Created by Siderov on 21.10.2015 ã..
 */
public class _12_Character_Multiplier {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        String str1 = sc.next();
        String str2 = sc.next();
        int sum = 0;
        if(str1.length()==str2.length()){
            for (int i = 0; i < str1.length(); i++) {
                sum+=str1.charAt(i)*str2.charAt(i);
            }
            System.out.println(sum);
        }
        else if(str1.length()>str2.length()){
            System.out.println(charMultiply(str1, str2));
        }
        else{
            System.out.println(charMultiply(str2, str1));
        }
    }
    public static int charMultiply(String str1, String str2){
        int sum=0;
        for (int i = 0; i < str2.length(); i++) {
            sum+=str1.charAt(i)*str2.charAt(i);
        }
        for (int i = str2.length(); i < str1.length(); i++) {
            sum+=str1.charAt(i);
        }
        return sum;
    }
}
