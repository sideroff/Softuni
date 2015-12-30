package com.company;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 15.11.2015 ã..
 */
public class Softuni_Defense_System {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        String sb = "";
        Float totalLitres = 0F;
        while(!input.equals("OK KoftiShans")){
            Pattern pattern = Pattern.compile("([A-Z][a-z]+).*?([A-Z][a-z]*[A-Z]+).*?(\\d+)L");
            Matcher m = pattern.matcher(input);
            while(m.find()){
                String name= m.group(1);
                String drink= m.group(2);
                Float litres = Float.parseFloat(m.group(3));
                sb+=String.format("%s brought %.0f liters of %s!\n",name,litres,drink.toLowerCase());
                totalLitres+=litres;
            }
            input=sc.nextLine();
        }

        System.out.printf("%s%.3f softuni liters",sb,totalLitres/1000);
    }
}
