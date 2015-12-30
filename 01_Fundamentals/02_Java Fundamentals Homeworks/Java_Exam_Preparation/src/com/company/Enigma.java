package com.company;
import java.util.Scanner;
public class Enigma {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Integer n = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < n; i++) {
            String input = sc.nextLine();
            char[] array = input.toCharArray();
            Integer length = 0;
            for (char c : array) {
                if(c!=' '&&!"0123456789".contains(c+"")) length++;
            }
            length/=2;
            for (char c : array) {
                if(c!=' '&&!"0123456789".contains(c+"")) c = (char)(c+length);
                System.out.printf("%c",c);
            }
            System.out.println();
        }
    }
}
