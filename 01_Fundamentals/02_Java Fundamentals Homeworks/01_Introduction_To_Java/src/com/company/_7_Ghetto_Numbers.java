package com.company;

import java.util.Scanner;
// œ”— ¿… — CTRL+SHIFT+F10

/**
 * Created by Siderov on 19.10.2015 „..
 */
public class _7_Ghetto_Numbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        StringBuilder sb = new StringBuilder();
        while(n!=0){
            int k = n%10;
            switch (k){
                case 0:
                    sb.insert(0,"Gee");
                    break;
                case 1:
                    sb.insert(0,"Bro");
                    break;
                case 2:
                    sb.insert(0,"Zuz");
                    break;
                case 3:
                    sb.insert(0,"Ma");
                    break;
                case 4:
                    sb.insert(0,"Duh");
                    break;
                case 5:
                    sb.insert(0,"Yo");
                    break;
                case 6:
                    sb.insert(0,"Dis");
                    break;
                case 7:
                    sb.insert(0,"Hood");
                    break;
                case 8:
                    sb.insert(0,"Jam");
                    break;
                case 9:
                    sb.insert(0,"Mack");
                    break;
            }
            n/=10;
        }
        System.out.println(sb.toString());
    }
}
